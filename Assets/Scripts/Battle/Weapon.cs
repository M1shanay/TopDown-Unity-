using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject[] BulletPrefab;
    public GameObject ShootDacayl;
    public float timeRemaining;

    private int _weaponType;
    private bool _isDoubleShot = false;
    private float _time;

    private void Awake()
    {
        if(PlayerPrefs.GetString("RocketLaunch") == "Yes")
        {
            _weaponType = 1;
        }
        else
        {
            _weaponType = 0;
        }

        if(PlayerPrefs.GetString("DoubleShot") == "Yes")
        {
            _isDoubleShot = true;
        }
    }

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
        if(_isDoubleShot)
        {
            Instantiate(BulletPrefab[_weaponType], new Vector3(FirePoint.position.x - 0.21f, FirePoint.position.y - 0.22f, FirePoint.position.z), FirePoint.rotation);
            Instantiate(BulletPrefab[_weaponType], new Vector3(FirePoint.position.x + 0.42f, FirePoint.position.y - 0.22f, FirePoint.position.z), FirePoint.rotation);
        }
        else
        {
            Instantiate(BulletPrefab[_weaponType], FirePoint.position, FirePoint.rotation);
        }        
    }

    void Firerate()
    {
        if (Input.GetButton("Fire1"))
        {
            ShootDacayl.GetComponent<SpriteRenderer>().enabled = true;
            if (_time > 0)
            {
                _time -= Time.deltaTime;
            }
            else
            {
                Shoot();
                _time = timeRemaining;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            ShootDacayl.GetComponent<SpriteRenderer>().enabled = false;
            _time = 0;
        }
    }
}