using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    public float timeRemaining;
    private float time;

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
            time = 0;
        }
    }
}