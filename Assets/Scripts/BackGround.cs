using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    float speed = 2;
    Transform back_trans;
    float back_size;
    float back_pos;
    // Start is called before the first frame update
    void Start()
    {
        back_trans = GetComponent<Transform>();
        back_size = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        Slide();
    }

    void Slide()
    {
        back_pos -= speed * Time.deltaTime;
        back_pos = Mathf.Repeat(back_pos, back_size);
        back_trans.position = new Vector3(0, back_pos, 1);
    }
}
