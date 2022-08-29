using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Asteroid : MonoBehaviour
{
    private int _hp = 100;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void Movement()
    {

    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        /*Какой-то красивый взрыв там бах-ба-бах баааах трах и т.п.*/
    }
}