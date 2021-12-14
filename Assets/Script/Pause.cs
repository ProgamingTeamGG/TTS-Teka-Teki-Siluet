using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
  public static bool isGamePaused =false;
  [SerializeField] GameObject pauseMenu;
    public void click()
    {
        if (isGamePaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale=1f;
        isGamePaused = false;
    }
    void  PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale=0f;
        isGamePaused = true;
    }
}
