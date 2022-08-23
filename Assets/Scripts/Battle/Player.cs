using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject playerdie;
    public HUD HUD;
    public float speed = 10f;
    public Canvas DeathScreen;

    public static int hp = 5;

    private Vector2 moveVector;

    void Start()
    {
        hp = 5;
        rb = GetComponent<Rigidbody2D>();
        DeathScreen.enabled = false;
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
        HUD.UpdateHP_Minus();
    }

    void Die()
    {
        PlayerPrefs.SetInt("CurrentCoinsCount", HUD.GetCoins);
        Instantiate(playerdie, transform.position + new Vector3(0, 0, -2), transform.rotation);
        Destroy(gameObject);
        DeathScreen.enabled = true;
    }

    public static void Heal()
    {
        if (hp < 5)
        {
            hp += 1;
        }
        HUD.UpdateHP_Plus();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        EnemyBullet bullet = collision.GetComponent<EnemyBullet>();
        if (enemy != null)
        {
            TakeDamage(1);
            enemy.TakeDamage(1000);
            HUD.UpdateScore(-200);
        }
        else if (bullet != null)
        {
            TakeDamage(1);
        }
    }
}