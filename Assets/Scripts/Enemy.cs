using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public float speed = 0.00003f;
    public GameObject explose;
    public Rigidbody2D rb;
    public Transform size;
    public Transform Enemyship_prefab;

    void Start()
    {
        Physics2D.IgnoreCollision(Enemyship_prefab.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Randomaizer();
        speed = speed * Random.Range(1, 5);
        rb.velocity = transform.right * speed;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(explose, transform.position + new Vector3(0, 0, -2), transform.rotation);
        Destroy(gameObject);
        HUD.UpdateScore(100);
    }

    void Randomaizer()
    {
        float random = Random.Range(0.4f, 0.8f);
        int side = Random.Range(-1, 1);
        int side1 = Random.Range(-1, 1);
        if (side == 0 || side1 == 0)
        {
            side = 1;
            side1 = -1;
        }
        size.localScale = new Vector3(side * random, side1 * random);
    }
}