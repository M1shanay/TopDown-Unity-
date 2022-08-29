using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearService : MonoBehaviour
{
    private GameObject[] trashes;
    private float time;

    void Start()
    {
        time = 0.5f;
    }

    void Update()
    {
        FindTrash();
        ClearAll();
    }

    void ClearAll()
    {
        foreach (GameObject trash in trashes)
        {
            Clear(trash);
        }
    }

    void Clear(GameObject trash)
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Destroy(trash);
            time = 0.5f;
        }
    }

    void FindTrash()
    {
        trashes = GameObject.FindGameObjectsWithTag("Impact");
    }
}
