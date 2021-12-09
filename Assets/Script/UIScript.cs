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
   public void level1_1 ()
   {
       SceneManager.LoadScene(2);
   }
   public void level1_2 ()
   {
       SceneManager.LoadScene(3);
   }
   public void level1_3 ()
   {
       SceneManager.LoadScene(4);
   }
   public void level1_4 ()
   {
       SceneManager.LoadScene(5);
   }
   public void level1_5()
   {
       SceneManager.LoadScene(6);
   }
   public void level2_1()
   {
       SceneManager.LoadScene(7);
   }
   public void level2_2()
   {
       SceneManager.LoadScene(8);
   }
   public void level2_3()
   {
       SceneManager.LoadScene(9);
   }
   public void level2_4()
   {
       SceneManager.LoadScene(10);
   }
   public void level2_5()
   {
       SceneManager.LoadScene(11);
   }


   public void Quit()
   {
       Application.Quit();
       Debug.Log("Keluar Bos");
   }
}
