using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text txtPoint;
    public Text txtLife;

    int score = 0;
    int life = 3;

    public bool gameOver;

    public GameObject gameOverPanel;
    public GameObject loseGamePanel;
    public GameObject pauseGamePanel;

    public int numberOfBricks;

    // Start is called before the first frame update
    void Start()
    {
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }
    public void IncreasePoint()
    {
        score++;
        SetPoint();
    }

    public void DecreaseLife()
    {
        life--;
        if(life <= 0)
        {
            Time.timeScale = 0;
            LoseGame();
        }
        SetLife();
    }
    void SetPoint()
    {

    }

    void SetLife()
    {

    }

    // Update is called once per frame
    void Update()
    {
        txtPoint.text = "" + score.ToString();
        txtLife.text = "" + life.ToString();
    }

    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if(numberOfBricks <= 0)
        {
            Time.timeScale = 0;
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    void LoseGame()
    {
        loseGamePanel.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
