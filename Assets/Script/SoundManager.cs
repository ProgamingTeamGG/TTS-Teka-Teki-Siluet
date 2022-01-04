using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public Slider volumeMusic;
    public GameObject ObjectMusic;

    private AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("GameMusic"))
        {
            PlayerPrefs.SetFloat("GameMusic", 0);
            Load();
        }
        else
        {
            Load();
        }

    }

    void Update()
    {
        AudioSource.volume = volumeMusic.value;
        Save();
    }

    private void OnMouseDown()
    {
        
    }
    private void Load()
    {
        volumeMusic.value = PlayerPrefs.GetFloat("GameMusic");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("GameMusic", volumeMusic.value);
    }
}

