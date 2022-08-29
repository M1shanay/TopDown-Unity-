using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    private int damage;
    public Rigidbody2D rb;
    public GameObject impact;
    public Transform self_prefab;
    public int typeOfWeapon;

    void Start()
    {
        if(typeOfWeapon == 1)
        {
            damage = 1;
            speed = 20f;
            rb.velocity = transform.right * speed;
        }
        else if(typeOfWeapon == 2)
        {
            damage = 20;
            speed = 10f;
            rb.velocity = transform.right * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroid")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
        }
        else if (collision.tag == "EnemyShip")
        {
            EnemyShip enemyShip = collision.GetComponent<EnemyShip>();
            enemyShip.TakeDamage(damage);
        }
        else if (collision.tag == "Boss_Asteroid")
        {
            Boss_Asteroid boss_Asteroid = collision.GetComponent<Boss_Asteroid>();
            boss_Asteroid.TakeDamage(damage);
        }
        else if (collision.name == "Piece")
        {
            Piece boss_Asteroid_Piece = collision.GetComponent<Piece>();
            boss_Asteroid_Piece.TakeDamage(damage);
        }
        else if (collision.tag == "HealCoin")
        {
            HealCoin hl = collision.GetComponent<HealCoin>();
            hl.Heal();
        }
        Instantiate(impact, transform.position + new Vector3(0, 0, -1), new Quaternion(0f, 0.0f, 0f, 0f));
        Destroy(gameObject);
    }
}