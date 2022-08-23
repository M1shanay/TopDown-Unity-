using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage;
    public Rigidbody2D rb;
    public GameObject impact;
    public Transform self_prefab;

    void Start()
    {
        rb.velocity = transform.right * speed;
        damage = 1;
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
        else if (collision.tag == "HealCoin")
        {
            HealCoin hl = collision.GetComponent<HealCoin>();
            hl.Heal();
        }

        Instantiate(impact, transform.position + new Vector3(0, 0, -1), transform.rotation);
        Destroy(gameObject);
    }
}