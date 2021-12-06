using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIScript : MonoBehaviour
{
   public void play ()
   {
       SceneManager.LoadScene(1);
   }

   public void Quit()
   {
       Application.Quit();
       Debug.Log("Keluar Bos");
   }
}
