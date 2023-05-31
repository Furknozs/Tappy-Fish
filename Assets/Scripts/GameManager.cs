using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomleft;

    private void Awake()
    {
        bottomleft= Camera.main.ScreenToWorldPoint(new Vector2(0,0));
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
