using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnOffUI : MonoBehaviour
{
     [SerializeField]
     private GameObject popup;

    private bool popupIsEnabled;
   
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TurnOnAndOff);
        popupIsEnabled = false;
        popup.SetActive(popupIsEnabled);
       
        
    }
    private void TurnOnAndOff()
    {
         popupIsEnabled ^= true;
         popup.SetActive(popupIsEnabled);
      
    }
    
}
