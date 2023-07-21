using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int score = 0;
    public int superScore = 20;
    public int rainbowScore = 30;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject subMenuScreen;
    public AudioSource scoreSFX;
    public bool gameIsPause = false;

    public void AddScore(int scoreAmount)
    {
        scoreSFX.Play();
        score += scoreAmount;
        scoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void SubMenu()
    {
        gameIsPause = !gameIsPause;
        subMenuScreen.SetActive(gameIsPause);
        if (gameIsPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = 1f;
    }
}
