using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    //Check if the game is already paused
    public bool isPaused;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void OnPause()
    {
        if(isPaused)
        {
            ResumeGame();
        } else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);

        //Stopping time and making pause
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);

        //Restart time
        Time.timeScale = 1.0f;
        isPaused = false; 
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
