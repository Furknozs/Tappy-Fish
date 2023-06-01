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
            groundWhidht = box.size.x; //BoxCollider2D bileþenini alýr ve groundWhidht deðiþkenine bu bileþenin geniþlik deðerini atar.
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            obstacleWhite = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x; //bileþeninin geniþlik deðeri atanýr.


        }

    }

   
    void Update()
    {
        if (GameManager.gameOver == false)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y); // Bu satýr, nesnenin konumunu günceller. Nesnenin x konumu, mevcut x konumu (transform.position.x) üzerinden speed deðeri ile çarpýlarak ve zamanla çarpýlarak (Time.deltaTime) güncellenir. Bu sayede nesne belirli bir hýzda sola doðru hareket eder.
        }
       

        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundWhidht)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundWhidht, transform.position.y); //Bu kod parçasý, bir nesnenin belirli bir hýzda sola doðru hareket etmesini ve bir sýnýra ulaþtýðýnda saða kaydýrýlmasýný saðlar.
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
