using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    private int damage = 1;
    public Rigidbody2D rb;
    public GameObject impact;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(impact, transform.position + new Vector3(0, 0, -1), transform.rotation);
        Destroy(gameObject);
    }
}
