using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public Transform target;

    float speed;
    float spawn_position;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spawn_position = Random.Range(5f, 1f);
        speed = 1f;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, spawn_position), speed * Time.deltaTime);
    }
}