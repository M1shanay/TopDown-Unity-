using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform target;
    public float speed;
    public int layer;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.x >= -1.2f && target.position.x<= 1.2f)
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, transform.position.y,layer), speed * Time.deltaTime);
        else if (target.position.x <= -1.2f)
            transform.position = Vector3.Lerp(transform.position, new Vector3(-1.25f, transform.position.y, layer), speed * Time.deltaTime);
        else
            transform.position = Vector3.Lerp(transform.position, new Vector3(1.25f, transform.position.y, layer), speed * Time.deltaTime);
    }
}
