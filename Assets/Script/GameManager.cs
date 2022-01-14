using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
  
  public GameObject pauseMenu;


    public void click()
    {
        
        if (Time.timeScale == 1f)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audios)
            {
                a.Pause();
            }
        
           
        }
        else
        {
            Time.timeScale=1f;
            pauseMenu.SetActive(false);
            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audios)
            {
                a.Play();
            }
        
        }
    }

    public void MainMenu ()
   {
       SceneManager.LoadScene(1);
       Time.timeScale=1f;
       AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audios)
            {
                a.UnPause();
            }
        
     
   }

   public void restart()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale=1f;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audios)
            {
                a.UnPause();
            }
        
   }


}

