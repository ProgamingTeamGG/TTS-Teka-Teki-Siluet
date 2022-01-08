using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DataKotakHuruf : MonoBehaviour
{
    public Text textDiKotak;
    public Text textPilihan;
    public bool isUsed = false;
    public bool isHorizontal = false;
    public bool isSelected = false;
    public int rootSoal1;
    public int rootSoal2;
    public int indexDiSoal;
    public int indexPilihan;
    public string answerWord0;
    public string answerWord1;
    public char hurufJawaban;
    public char inputJawaban;
    public Vector2Int id = new Vector2Int(0,0);

    public void GantiSoal()
    {
        if(isHorizontal) 
        {
            TTSManager.instance.questionImage.sprite = TTSManager.instance.q.Soal[rootSoal1 - 1].gambar;
            TTSManager.instance.questionText.text = TTSManager.instance.q.Soal[rootSoal1 - 1].pertanyaan;
            AcakPilihan();

            for( int i = 0; i< TTSManager.instance.pilihanList.Count; i++)
            {
                TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().textPilihan.text = TTSManager.instance.wordsArray[i].ToString();
                TTSManager.instance.pilihanList[i].SetActive(true);
            }
        }

        if(!isHorizontal) 
        {
            TTSManager.instance.questionImage.sprite = TTSManager.instance.q.Soal[rootSoal2 - 1].gambar;
            TTSManager.instance.questionText.text = TTSManager.instance.q.Soal[rootSoal2 - 1].pertanyaan;

            AcakPilihan();

            for( int i = 0; i< TTSManager.instance.pilihanList.Count; i++)
            {
                TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().textPilihan.text = TTSManager.instance.wordsArray[i].ToString();
                TTSManager.instance.pilihanList[i].SetActive(true);
            }
        }
        
        isSelected = true;

    }

    void AcakPilihan()
    {
        if(isHorizontal) 
        {
            string answerWord =TTSManager.instance.q.Soal[rootSoal1 - 1].jawaban;

            Array.Clear(TTSManager.instance.wordsArray, 0, TTSManager.instance.wordsArray.Length);  //clear the array

            //add the correct char to the wordsArray
            for (int i = 0; i < answerWord.Length; i++)
            {
                TTSManager.instance.wordsArray[i] = char.ToUpper(answerWord[i]);
            }

            //add the dummy char to wordsArray
            for (int j = answerWord.Length; j < TTSManager.instance.wordsArray.Length; j++)
            {
                TTSManager.instance.wordsArray[j] = (char)UnityEngine.Random.Range(65, 90);
            }
            
            TTSManager.instance.wordsArray = AcakHuruf.AcakHurufItems<char>(TTSManager.instance.wordsArray.ToList()).ToArray();          
        }

        if(!isHorizontal) 
        {
            string answerWord =TTSManager.instance.q.Soal[rootSoal2 - 1].jawaban;

            Array.Clear(TTSManager.instance.wordsArray, 0, TTSManager.instance.wordsArray.Length);  //clear the array

            //add the correct char to the wordsArray
            for (int i = 0; i < answerWord.Length; i++)
            {
                TTSManager.instance.wordsArray[i] = char.ToUpper(answerWord[i]);
            }

            //add the dummy char to wordsArray
            for (int j = answerWord.Length; j < TTSManager.instance.wordsArray.Length; j++)
            {
                TTSManager.instance.wordsArray[j] = (char)UnityEngine.Random.Range(65, 90);
            }

            TTSManager.instance.wordsArray = AcakHuruf.AcakHurufItems<char>(TTSManager.instance.wordsArray.ToList()).ToArray();
        }
    }

    public void IsiJawaban()
    {   
        /*for(int a=0;a<TTSManager.instance.q.Soal.Count;a++)
        {
            rootSoal1
            continue;
        }*/
        for(int i = 0; i < TTSManager.instance.q.Soal[rootSoal1].posHuruf.Count;i++)
        {
            TTSManager.instance.kotakList[i].GetComponent<DataKotakHuruf>().indexDiSoal = i;
        }

        if(indexDiSoal >= TTSManager.instance.q.Soal[rootSoal1].posHuruf.Count) return;
        TTSManager.instance.kotakList[indexDiSoal].GetComponent<DataKotakHuruf>().textDiKotak.text = textPilihan.text;
        gameObject.SetActive(false);
        for(int j = 0; j < TTSManager.instance.pilihanList.Count;j++)
        {
            TTSManager.instance.pilihanList[j].GetComponent<DataKotakHuruf>().indexDiSoal ++;
            continue;
        } 
    }   
}