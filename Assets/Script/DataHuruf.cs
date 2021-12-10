using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataHuruf : MonoBehaviour
{
    public Text textDiKotak;
    public bool isUsed = false;
    public bool isFirstClick = false;
    public int rootSoal1;
    public int rootSoal2;
    public string answerWord1;
    public string answerWord2;
    public string hurufJawaban;
    public string inputJawaban;
    public Vector2Int id = new Vector2Int(0,0);

    public void Soal1()
    {
        if(rootSoal1 == 1)
        {
            TTSManager.instance.questionImage.sprite = TTSManager.instance.q.Soal[0].gambar;
            TTSManager.instance.questionText.text = TTSManager.instance.q.Soal[0].pertanyaan;
            TTSManager.instance._answerWord1 = answerWord1;
        }   
    }
    public void Soal2()
    {
        if(rootSoal2 == 2)
        {
            TTSManager.instance.questionImage.sprite = TTSManager.instance.q.Soal[1].gambar;
            TTSManager.instance.questionText.text = TTSManager.instance.q.Soal[1].pertanyaan;
            TTSManager.instance._answerWord2 = answerWord2;
        }
    }
    public void Soal3()
    {
        if(rootSoal1 == 3)
        {
            TTSManager.instance.questionImage.sprite = TTSManager.instance.q.Soal[2].gambar;
            TTSManager.instance.questionText.text = TTSManager.instance.q.Soal[2].pertanyaan;
            TTSManager.instance._answerWord1 = answerWord1;
        }    
    }
    public void Soal4()
    {
        if(rootSoal1 == 4)
        {
            TTSManager.instance.questionImage.sprite = TTSManager.instance.q.Soal[3].gambar;
            TTSManager.instance.questionText.text = TTSManager.instance.q.Soal[3].pertanyaan;
            TTSManager.instance._answerWord1 = answerWord1;
        }    
    }
}