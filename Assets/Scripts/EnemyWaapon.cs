using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaapon : MonoBehaviour
{
    float SeeDist = 10f;
    public Transform castPoint;
    public GameObject BulletEnemyPrefab;

    private float timeRemaining = 0.5f;
    private float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Firerate();
    }
    void Firerate()
    {
        if (IfSee())
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                Debug.Log(time);
            }
            else
            {
                Shoot();
                Debug.Log(time);
                time = timeRemaining;
            }
        }
        else
            time = 0;
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
}
