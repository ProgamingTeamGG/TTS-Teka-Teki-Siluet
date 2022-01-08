using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public Slider volumeMusic;
    public GameObject ObjectMusic;

    private float MusicVolume = 5;
    private AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

    }

    void Update()
    {
        AudioSource.volume = volumeMusic.value;
    }

    private void OnMouseDown()
    {
        
    }

}
