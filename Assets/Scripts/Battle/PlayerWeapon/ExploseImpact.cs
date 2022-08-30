using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploseImpact : MonoBehaviour
{
    private int damage;
    private CircleCollider2D _collider;
    public int typeOfWeapon;
    float _aliveTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<CircleCollider2D>();
        if (typeOfWeapon == 2)
        {
            _collider.radius = 0.7f;
            damage = 20;
        }
        StartCoroutine(Delay());
    }
    private void Update()
    {
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
        _collider.enabled = false;
        Debug.Log("off");
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
    }
}
