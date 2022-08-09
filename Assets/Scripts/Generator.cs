using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject HealPrefab;
    public Transform EnemyPoint;

    private float timeRemaining = 1.5f;
    private float time;

    private int heal_couldown = 0;

    void Start()
    {
        time = timeRemaining;
    }

    void Update()
    {
        Generation();
    }

    void GenerateEnemy()
    {
        Instantiate(EnemyPrefab, EnemyPoint.position + new Vector3(Random.Range(-10f, 10f), 0), EnemyPoint.rotation);
    }
    void GenerateHeal()
    {
        Instantiate(HealPrefab, EnemyPoint.position + new Vector3(Random.Range(-10f, 10f), 0), EnemyPoint.rotation);
    }
    void Generation()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            if (heal_couldown == 5)
            {
                GenerateHeal();
                heal_couldown = 0;
            }
            GenerateEnemy();
            heal_couldown++;
            time = timeRemaining;
        }
    }
}
