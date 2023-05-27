using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed;
    BoxCollider2D box;
    float groundWhidht;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        groundWhidht =box.size.x;
      
    }

   
    void Update()
    {
       transform.position =new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if (transform.position.x<= -groundWhidht)
        {
            transform.position = new Vector2(transform.position.x + 2 * groundWhidht, transform.position.y);
        }
    }
}
