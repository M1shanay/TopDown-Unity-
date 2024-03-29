using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject HealPrefab;
    public Transform EnemyPoint;
    public GameObject EnemyShipPrefab;

    private float timeRemaining = 1f;
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

    void GenerateEnemyShip()
    {
        Instantiate(EnemyShipPrefab, EnemyPoint.position + new Vector3(Random.Range(-10f, 10f), 0), EnemyShipPrefab.transform.rotation);
    }

    void GenerateAsteroids()
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
            if (heal_couldown == 25)
            {
                GenerateHeal();
                heal_couldown = 0;
            }
            GenerateAsteroids();
            GenerateEnemyShip();
            /*if (HUD.GetScore >= 000)
            {
                GenerateEnemyShip();
            }*/

            if(HUD.GetScore >= 5000)
            {
                //Instantiate()
            }
            
            heal_couldown++;
            time = timeRemaining;
        }
    }
}
