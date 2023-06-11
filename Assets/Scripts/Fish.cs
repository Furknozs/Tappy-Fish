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
    public Score score;
    public GameManager gameManager;
    bool touchedGround;
    public Sprite fishDead;
    SpriteRenderer sp;
    Animator anim;
    public ObstacleSpawner obstaclespawner;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

 
    void Update()
    {

        FishSwim();
        
         
    }

    private void FixedUpdate()
    {
        FishRotation();
    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0)&& GameManager.gameOver == false)
        {
            if (GameManager.gameStarted ==false)
            {
                _rb.gravityScale = 4f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, speed);
                obstaclespawner.InstantiateObstacle();
                gameManager.GameHasStarted();

            }
            else
            {
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, speed); // x deðeri sabit y deðeri speed
            }
            
        }
    }

    void FishRotation()
    {
        if (_rb.velocity.y > 0)    // açý ayarlamasý 
        {
            if (angel <= maxAngel)
            {
                angel = angel + 4;
            }
        }

        else if (_rb.velocity.y < -2.5f)
        {
            if (angel > minAngel)
            {
                angel = angel - 2;
            }
        }
        if (touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            score.Scored();
        }
        else if (collision.CompareTag("Column"))
        {
            // gameover
            gameManager.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                //gameover
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                GameOver();

            }
           
        }
    }

    void GameOver()
    {
        touchedGround = true;
        sp.sprite = fishDead;
        anim.enabled = false;
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }


}
