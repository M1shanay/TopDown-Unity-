using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public GameObject piece;

    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider2D;
    private int _hp = 10;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        sprite.enabled = true;
        boxCollider2D.enabled = false;

        Instantiate(piece, transform.position, Quaternion.Euler(0f, 0f, -75f));
        Instantiate(piece, transform.position, Quaternion.Euler(0f, 0f, -90f));
        Instantiate(piece, transform.position, Quaternion.Euler(0f, 0f, -105f));

    }
}