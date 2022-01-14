using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIScript : MonoBehaviour
{
   public void GantiScene(string namaScene)
   {
       SceneManager.LoadScene(namaScene);
   }

   public void Quit()
   {
       Application.Quit();
   }
}
