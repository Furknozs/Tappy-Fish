using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed;
    BoxCollider2D box;
    float groundWhidht;
    float obstacleWhite;
    void Start()
    {
        if (gameObject.CompareTag("Ground"))
        {
            box = GetComponent<BoxCollider2D>();
            groundWhidht = box.size.x; //BoxCollider2D bile�enini al�r ve groundWhidht de�i�kenine bu bile�enin geni�lik de�erini atar.
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            obstacleWhite = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x; //bile�eninin geni�lik de�eri atan�r.


        }

    }

   
    void Update()
    {
        if (GameManager.gameOver == false)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y); // Bu sat�r, nesnenin konumunu g�nceller. Nesnenin x konumu, mevcut x konumu (transform.position.x) �zerinden speed de�eri ile �arp�larak ve zamanla �arp�larak (Time.deltaTime) g�ncellenir. Bu sayede nesne belirli bir h�zda sola do�ru hareket eder.
        }
       

        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundWhidht)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundWhidht, transform.position.y); //Bu kod par�as�, bir nesnenin belirli bir h�zda sola do�ru hareket etmesini ve bir s�n�ra ula�t���nda sa�a kayd�r�lmas�n� sa�lar.
            }
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            if (transform.position.x< GameManager.bottomleft.x - obstacleWhite)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
