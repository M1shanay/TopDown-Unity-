using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaapon : MonoBehaviour
{
    float SeeDist = 10f;
    public Transform castPoint;
    public GameObject BulletEnemyPrefab;

    private float timeRemaining = 0.7f;
    private float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShootIfSee();
    }
    void Firerate()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            Debug.Log(time);
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
    bool IfSee()
    {
        RaycastHit2D hit = Physics2D.Raycast(castPoint.transform.position, Vector2.down, SeeDist);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                return true;
            }
            return false;
        }
        return false;
    }
    void ShootIfSee()
    {
        RaycastHit2D hit = Physics2D.Raycast(castPoint.transform.position, Vector2.down, SeeDist);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Firerate();
            }
        }
    }
}
