using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SounEfek : MonoBehaviour
{
  
    public  AudioClip Touch;
    private AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.currentSelectedGameObject != null){
          if (Input.GetMouseButtonDown(0)){
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>()!= null){
                PlaySound(Touch);
            }
        }
        }
        
    }
          public void PlaySound (AudioClip Aclip)
   {
        audioSrc.PlayOneShot(Aclip);
   }
}
