using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject[] BulletPrefabMainWeapon;
    public GameObject[] BulletPrefabSecondaryWeapon;
    public GameObject ShootDacayl1;
    public GameObject ShootDacayl2;

    private GameObject ShootDacayl;
    public float timeRemainingMainWeapon;
    public float timeRemainingSecondaryWeapon;

    private int _weaponMainType;
    private int _weaponSecondaryType;
    private bool _isDoubleShot = false;
    private float _timeMainWeapon;
    private float _timeSecondaryWeapon;
    bool _enableSecondaryWeapon = false;

    private void Awake()
    {
        _weaponMainType = 0;
        if(PlayerPrefs.GetString("RocketLaunch") == "Yes")
        {
            _enableSecondaryWeapon = true;
            _weaponSecondaryType = 0;
        }

        if(PlayerPrefs.GetString("DoubleShot") == "Yes")
        {
            _isDoubleShot = true;
        }
    }

    void Start()
    {
        ShootDacayl1.GetComponent<SpriteRenderer>().enabled = false;
        ShootDacayl2.GetComponent<SpriteRenderer>().enabled = false;
        if (_isDoubleShot)
        {
            ShootDacayl = ShootDacayl2;
            ShootDacayl.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            ShootDacayl = ShootDacayl1;
            ShootDacayl.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void Update()
    {
        FirerateMainWeapon();
        if (_enableSecondaryWeapon)
        {
            FirerateSecondaryWeapon();
        }
    }

    void ShootSecondaryWeapon()
    {
        Instantiate(BulletPrefabSecondaryWeapon[_weaponSecondaryType], FirePoint.position, FirePoint.rotation);
    }
    void ShootMainWeapon()
    {
        if (_isDoubleShot)
        {
            Instantiate(BulletPrefabMainWeapon[_weaponMainType], new Vector3(FirePoint.position.x - 0.22f, FirePoint.position.y - 0.22f, FirePoint.position.z), FirePoint.rotation);
            Instantiate(BulletPrefabMainWeapon[_weaponMainType], new Vector3(FirePoint.position.x + 0.22f, FirePoint.position.y - 0.22f, FirePoint.position.z), FirePoint.rotation);
        }
        else
        {
            Instantiate(BulletPrefabMainWeapon[_weaponMainType], FirePoint.position, FirePoint.rotation);
        }
    }

    void FirerateMainWeapon()
    {
        if (Input.GetButton("Fire1"))
        {
            ShootDacayl.GetComponent<SpriteRenderer>().enabled = true;
            if (_timeMainWeapon > 0)
            {
                _timeMainWeapon -= Time.deltaTime;
            }
            else
            {
                ShootMainWeapon();
                _timeMainWeapon = timeRemainingMainWeapon;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            ShootDacayl.GetComponent<SpriteRenderer>().enabled = false;
            _timeMainWeapon = 0;
        }
    }
    void FirerateSecondaryWeapon()
    {
        if (Input.GetButton("Fire2"))
        {
            if (_timeSecondaryWeapon > 0)
            {
                _timeSecondaryWeapon -= Time.deltaTime;
            }
            else
            {
                ShootSecondaryWeapon();
                _timeSecondaryWeapon = timeRemainingSecondaryWeapon;
            }
        }
    }
}