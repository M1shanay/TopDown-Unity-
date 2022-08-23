using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaapon : MonoBehaviour
{
    public Transform castPoint;
    public GameObject BulletEnemyPrefab;

    private float timeRemaining = 0.7f;
    private float time;

    float SeeDist = 10f;

    void Update()
    {
        ShootIfSee();
    }

    void Firerate()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Shoot();
            time = timeRemaining;
        }
    }

    void Shoot()
    {
        Instantiate(BulletEnemyPrefab, castPoint.position, castPoint.rotation);
    }

    void ShootIfSee()
    {
        RaycastHit2D hit = Physics2D.Raycast(castPoint.transform.position, Vector2.down, SeeDist, 1 << LayerMask.NameToLayer("Player"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Firerate();
            }
        }
    }
}