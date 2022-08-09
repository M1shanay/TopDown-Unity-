using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        HealCoin hl = collision.GetComponent<HealCoin>();
        if (enemy != null)
        {
            enemy.TakeDamage(10000);
            HUD.UpdateScore(-200);
        }
        if (hl != null)
        {
            hl.Die();
        }
    }
}
