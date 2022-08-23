using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{
    static int countOfAsteroidDeath;
    static int countOfEnemyShipLvl1Death;

    void Start()
    {
        countOfAsteroidDeath = 0;
        countOfEnemyShipLvl1Death = 0;
    }

    static public void UpdateAsteroidDeaths()
    {
        countOfAsteroidDeath += 1;
        HUD.UpdateCoins(1);
    }

    static public void UpdateEnemyShipLvl1DeathDeaths()
    {
        countOfEnemyShipLvl1Death += 1;
        HUD.UpdateCoins(2);
    }

    static public int GetAsteroidDeath
    {
        get { return countOfAsteroidDeath; }
    }

    static public int GetShipLvl1Death
    {
        get { return countOfEnemyShipLvl1Death; }
    }
}