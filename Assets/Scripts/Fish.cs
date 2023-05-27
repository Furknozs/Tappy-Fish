using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed;
    int angel;
    int maxAngel = 20;
    int minAngel = -60;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

    }

 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = new Vector2(_rb.velocity.x,speed); // x de�eri sabit y de�eri speed
        }

        if (_rb.velocity.y >0)    // a�� ayarlamas� 
        {
            if (angel<= maxAngel)
            {
                angel = angel + 4;
            }
        }

        else if (_rb.velocity.y <-2.5f)
        {
            if (angel > minAngel)
            {
                angel = angel - 2;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, angel); 
    }
}
