using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    public GameObject ShootDacayl;
    public float timeRemaining;

    private float time;

    void Start()
    {
       ShootDacayl.GetComponent<SpriteRenderer>().enabled=false;
    }
    void Update()
    {
        Firerate();  
    }

    void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }

    void Firerate()
    {
        if (Input.GetButton("Fire1"))
        {
            ShootDacayl.GetComponent<SpriteRenderer>().enabled = true;
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
        if (Input.GetButtonUp("Fire1"))
        {
            ShootDacayl.GetComponent<SpriteRenderer>().enabled = false;
            time = 0;
        }
    }
}