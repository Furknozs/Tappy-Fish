using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomleft;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject GetReady;
    public static int gameScore;
    public GameObject score;

    public static bool gameStarted;

    private void Awake()
    {
        bottomleft= Camera.main.ScreenToWorldPoint(new Vector2(0,0));
    }

    public void ResetartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void Start()
    {
        gameOver = false;
        gameStarted = false;
    }

    public void GameHasStarted()
    {
        gameStarted = true;
        GetReady.SetActive(false);
    }

   public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        gameScore = score.GetComponent<Score>().GetScore();
    }

    void Update()
    {
        
    }
}
