using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform EnemyPoint;

    private float timeRemaining = 1.5f;
    private float time;

    void Start()
    {
        time = timeRemaining;
    }

    void Update()
    {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                GenerateEnemy();
                time = timeRemaining;
            }
    }

    void GenerateEnemy()
    {
        Instantiate(EnemyPrefab, EnemyPoint.position + new Vector3(Random.Range(-10f, 10f), 0), EnemyPoint.rotation);
    }
}
