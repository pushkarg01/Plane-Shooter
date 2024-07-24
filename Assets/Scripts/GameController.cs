using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;

    public GameObject gameOverMenu;
    public GameObject levelCompletePanel;



    void Start()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);

        levelCompletePanel.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    void Update()
    {
        
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;      
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public IEnumerator LevelComplete()
    {
  
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;    
        levelCompletePanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    
}
