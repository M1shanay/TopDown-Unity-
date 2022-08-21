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
        Physics2D.IgnoreCollision(EnemyBullet_prefab.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spawn_position = Random.Range(5, 1);
        speed = 1f;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, spawn_position), speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Before shot: " + hp);
        hp -= damage;
        Debug.Log("After shot: " + hp);

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(explose, transform.position + new Vector3(0, 0, -2), transform.rotation);
        Destroy(gameObject);
        HUD.UpdateScore(250);
    }
}