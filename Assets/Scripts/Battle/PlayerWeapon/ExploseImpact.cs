using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploseImpact : MonoBehaviour
{
    private int damage;
    private CircleCollider2D _collider;
    public int typeOfWeapon;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<CircleCollider2D>();
        if (typeOfWeapon == 2)
        {
            _collider.radius = 1.2f;
            damage = 20;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Asteroid")
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
        _collider.enabled = false;
    }
}
