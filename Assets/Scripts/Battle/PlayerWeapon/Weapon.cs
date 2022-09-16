using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject[] BulletPrefabMainWeapon;
    public GameObject[] BulletPrefabSecondaryWeapon;
    public GameObject ShootDacayl1;
    public GameObject ShootDacayl2;
    public Image MainWeaponOverheatingImage;
    public Image SecondWeaponChargeImage;

    public float timeRemainingMainWeapon;
    public float mainWeaponOverheatingTime;
    public float timeRemainingSecondaryWeapon;

    private GameObject ShootDacayl;
    private int _weaponMainType;
    private int _weaponSecondaryType;
    private bool _isDoubleShot = false;
    private float _timeMainWeapon;
    private float _startTimeRemainingMainWeapon;
    private float _mainWeaponOverheatingTime;
    private bool _isMainWeaponColling = false;
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
        _startTimeRemainingMainWeapon = timeRemainingMainWeapon;
        _timeSecondaryWeapon = timeRemainingSecondaryWeapon;
        _mainWeaponOverheatingTime = 0f;

        if (_isDoubleShot)
        {
            ShootDacayl = ShootDacayl2;
        }
        else
        {
            ShootDacayl = ShootDacayl1;
        }
    }

    void Update()
    {
        FirerateMainWeapon();
        MainWeaponOverheatingImage.fillAmount = _mainWeaponOverheatingTime / mainWeaponOverheatingTime;

        if (_enableSecondaryWeapon)
        {
            FirerateSecondaryWeapon();
        }
    }

    void ShootSecondaryWeapon()
    {
        Instantiate(BulletPrefabSecondaryWeapon[_weaponSecondaryType], FirePoint.position, FirePoint.rotation);
        SecondWeaponChargeImage.fillAmount = 0;
    }

    void ShootMainWeapon()
    {
        if (!_isMainWeaponColling)
        {
            _mainWeaponOverheatingTime += 0.15f;
        }
        
        if((_mainWeaponOverheatingTime >= mainWeaponOverheatingTime) && (!_isMainWeaponColling))
        {
            _isMainWeaponColling = true;
            timeRemainingMainWeapon *= 5f;
        }

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
            ShootDacayl.SetActive(true);

            if (_timeMainWeapon > 0)
            {
                _timeMainWeapon -= Time.deltaTime;
            }
            else
            {
                ShootMainWeapon();
                _timeMainWeapon = timeRemainingMainWeapon;
            }

            if(_isMainWeaponColling)
            {
                _mainWeaponOverheatingTime -= Time.deltaTime;
                if (_mainWeaponOverheatingTime <= 0)
                {
                    _isMainWeaponColling = false;
                    timeRemainingMainWeapon = _startTimeRemainingMainWeapon;
                }
            }
        }
        else
        {
            _mainWeaponOverheatingTime -= Time.deltaTime;
        }

        if (Input.GetButtonUp("Fire1") && (_mainWeaponOverheatingTime != mainWeaponOverheatingTime))
        {
            ShootDacayl.SetActive(false);
            _timeMainWeapon = 0;
        }
    }

    void FirerateSecondaryWeapon()
    {
        if (_timeSecondaryWeapon < timeRemainingSecondaryWeapon)
        {
            _timeSecondaryWeapon += Time.deltaTime;
            SecondWeaponChargeImage.fillAmount = _timeSecondaryWeapon / timeRemainingSecondaryWeapon;
        }
        else
        {
            if (Input.GetButton("Fire2"))
            {
                ShootSecondaryWeapon();
                _timeSecondaryWeapon = 0;
            }
        }
    }
}