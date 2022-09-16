using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public Transform target;
    public GameObject explose;
    public Transform EnemyBullet_prefab;

    private int hp = 6;
    private float speed;
    private float spawn_position;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spawn_position = Random.Range(5, 1);
        speed = Random.Range(1, 3);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, spawn_position), speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            DeathCounter.UpdateEnemyShipLvl1DeathDeaths();
            Die();
        }
    }

    public void DieFromDieWall()
    {
        Die();
    }

    void Die()
    {
        Instantiate(explose, transform.position + new Vector3(0, 0, -2), transform.rotation);
        Destroy(gameObject);
        HUD.UpdateScore(250);
    }
}