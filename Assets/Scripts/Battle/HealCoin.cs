using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCoin : MonoBehaviour
{
    public Rigidbody2D rb;
    float speed = 0.7f;
    public GameObject explose;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    public void Heal()
    {
        Instantiate(explose, transform.position + new Vector3(0, 0, -2), transform.rotation);
        Destroy(gameObject);
        Player.Heal();
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
