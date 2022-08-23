using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        HealCoin hl = collision.GetComponent<HealCoin>();

        if (enemy != null)
        {
            enemy.DieFromDieWall();
            if (Player.hp > 0)
            {
                HUD.UpdateScore(-200);
            }
        }

        if (hl != null)
        {
            hl.Die();
        }
    }
}