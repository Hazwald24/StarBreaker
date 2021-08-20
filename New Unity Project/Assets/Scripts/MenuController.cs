using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public string mainMenuScene;
    public GameObject pauseMenu, gameOverScreen;
    public bool isPaused;
    public Text scoreText;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReturnToMain()
    {
        ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        isPaused = true;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;

        int score = scoreManager.getScore();
        scoreText.text = score.ToString("D5");
    }

    public void RestartGame()
    {
        isPaused = false;
        gameOverScreen.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }


}
