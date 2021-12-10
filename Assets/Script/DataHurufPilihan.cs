using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataHurufPilihan : MonoBehaviour
{
    [SerializeField] private Text wordText;

    [HideInInspector]
    public char wordValue;

    private Button buttonComponent;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
        if (buttonComponent)
        {
            buttonComponent.onClick.AddListener(() => WordSelected());
        }
    }

    public void SetWord(char value)
    {
        wordText.text = value + "";
        wordValue = value;
    }

    private void WordSelected()
    {
        //TTSManager.instance.SelectedOption(this);
    }
}
