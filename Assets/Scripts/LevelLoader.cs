using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentIndex;

    private void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(currentIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(currentIndex+1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
