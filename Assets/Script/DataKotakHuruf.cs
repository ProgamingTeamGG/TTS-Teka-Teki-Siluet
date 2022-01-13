using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataKotakHuruf : MonoBehaviour
{
    public Text textDiKotak;
    public Text textPilihan;
    public bool isUsed = false;
    public bool isHorizontal = false;
    public bool hurufPertama = false;
    public bool hurufBenar = false;
    public bool soalBenar = false;
    public int rootSoal1;
    public int rootSoal2;
    public int indexDiSoal;
    public int indexPilihan;
    public int indexOption;
    public string answerWord0;
    public string answerWord1;
    public char hurufJawaban;
    public string inputJawaban;
    public Vector2Int id = new Vector2Int(0,0);

    public void GantiSoal()
    {
        if(!soalBenar)
        {
            if(hurufPertama)
            {
                if(isHorizontal) 
                {
                    TTSManager.instance.questionImage.sprite = TTSManager.instance.q.Soal[rootSoal1 - 1].gambar;
                    TTSManager.instance.questionText.text = TTSManager.instance.q.Soal[rootSoal1 - 1].pertanyaan;
                    AcakPilihan();

                    TTSManager.instance.jumlahHurufBenar = 0;
                    
                    TTSManager.instance.hint.SetActive(true);
                    TTSManager.instance.hint.GetComponent<DataKotakHuruf>().isUsed = true;

                    for( int i = 0; i< TTSManager.instance.pilihanList.Count; i++)
                    {
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().indexOption = i;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().textPilihan.text = TTSManager.instance.wordsArray[i].ToString();
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().hurufJawaban = hurufJawaban;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().rootSoal1 = rootSoal1;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().answerWord0 = answerWord0;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().indexPilihan = indexDiSoal;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().isHorizontal = true;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().isUsed = true;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().hurufPertama = false;
                        TTSManager.instance.pilihanList[i].SetActive(true);
                    }
                }

                if(!isHorizontal) 
                {
                    TTSManager.instance.questionImage.sprite = TTSManager.instance.q.Soal[rootSoal2 - 1].gambar;
                    TTSManager.instance.questionText.text = TTSManager.instance.q.Soal[rootSoal2 - 1].pertanyaan;
                    AcakPilihan();

                    TTSManager.instance.jumlahHurufBenar = 0;

                    for( int i = 0; i< TTSManager.instance.pilihanList.Count; i++)
                    {
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().indexOption = i;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().textPilihan.text = TTSManager.instance.wordsArray[i].ToString();
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().hurufJawaban = hurufJawaban;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().rootSoal2 = rootSoal2;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().answerWord1 = answerWord1;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().indexPilihan = indexDiSoal;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().isHorizontal = false;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().isUsed = true;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().hurufPertama = false;
                        TTSManager.instance.pilihanList[i].SetActive(true);
                    }
                }
                
                TTSManager.instance.hasilText.text = "";
            }
            else
            {
                if(isHorizontal) 
                {
                    TTSManager.instance.questionImage.sprite = TTSManager.instance.q.Soal[rootSoal1 - 1].gambar;
                    TTSManager.instance.questionText.text = TTSManager.instance.q.Soal[rootSoal1 - 1].pertanyaan;

                    for( int i = 0; i< TTSManager.instance.pilihanList.Count; i++)
                    {
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().indexOption = i;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().hurufJawaban = hurufJawaban;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().rootSoal1 = rootSoal1;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().answerWord0 = answerWord0;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().indexPilihan = indexDiSoal;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().isHorizontal = true;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().isUsed = true;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().hurufPertama = false;
                        TTSManager.instance.pilihanList[i].SetActive(false);
                    }
                }

                if(!isHorizontal) 
                {
                    TTSManager.instance.questionImage.sprite = TTSManager.instance.q.Soal[rootSoal2 - 1].gambar;
                    TTSManager.instance.questionText.text = TTSManager.instance.q.Soal[rootSoal2 - 1].pertanyaan;

                    for( int i = 0; i< TTSManager.instance.pilihanList.Count; i++)
                    {
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().indexOption = i;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().hurufJawaban = hurufJawaban;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().rootSoal2 = rootSoal2;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().answerWord1 = answerWord1;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().indexPilihan = indexDiSoal;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().isHorizontal = false;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().isUsed = true;
                        TTSManager.instance.pilihanList[i].GetComponent<DataKotakHuruf>().hurufPertama = false;
                        TTSManager.instance.pilihanList[i].SetActive(false);
                    }
                }
            }

        }
        else
        {
            if(isHorizontal)
            {
                TTSManager.instance.hasilText.color = Color.green;
                TTSManager.instance.questionImage.sprite = TTSManager.instance.q.Soal[rootSoal1 - 1].gambarBetul;
            }
            if(!isHorizontal)
            {
                TTSManager.instance.hasilText.color = Color.green;
                TTSManager.instance.questionImage.sprite = TTSManager.instance.q.Soal[rootSoal2 - 1].gambarBetul;
            }

            for(int j = 0; j < TTSManager.instance.pilihanList.Count;j++)
            {
                TTSManager.instance.pilihanList[j].SetActive(false);
            }
        }
    }

    

    void AcakPilihan()
    {
        if(isHorizontal) 
        {
            string answerWord = answerWord0;

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
            string answerWord = answerWord1;

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
        if(!soalBenar)
        {
            if(isUsed)
            {
                if(isHorizontal)
                {
                    TTSManager.instance.kotakList[indexPilihan].GetComponent<DataKotakHuruf>().textDiKotak.text = textPilihan.text;
                    TTSManager.instance.kotakList[indexPilihan].GetComponent<DataKotakHuruf>().inputJawaban = textPilihan.text;

                    gameObject.SetActive(false);
                    JawabanBenar();
                    for(int j = 0; j < TTSManager.instance.pilihanList.Count;j++)
                    {
                        TTSManager.instance.pilihanList[j].GetComponent<DataKotakHuruf>().indexPilihan ++;
                        TTSManager.instance.pilihanList[j].GetComponent<DataKotakHuruf>().hurufJawaban = TTSManager.instance.kotakList[indexPilihan].GetComponent<DataKotakHuruf>().hurufJawaban;
                        TTSManager.instance.pilihanList[j].GetComponent<DataKotakHuruf>().inputJawaban = textPilihan.text;
                        continue;
                    }
                }

                if(!isHorizontal)
                {
                    TTSManager.instance.kotakList[indexPilihan].GetComponent<DataKotakHuruf>().textDiKotak.text = textPilihan.text;
                    TTSManager.instance.kotakList[indexPilihan].GetComponent<DataKotakHuruf>().inputJawaban = textPilihan.text;

                    gameObject.SetActive(false);
                    JawabanBenar();
                    for(int j = 0; j < TTSManager.instance.pilihanList.Count;j++)
                    {
                        TTSManager.instance.pilihanList[j].GetComponent<DataKotakHuruf>().indexPilihan +=17;
                        TTSManager.instance.pilihanList[j].GetComponent<DataKotakHuruf>().hurufJawaban = TTSManager.instance.kotakList[indexPilihan].GetComponent<DataKotakHuruf>().hurufJawaban;
                        TTSManager.instance.pilihanList[j].GetComponent<DataKotakHuruf>().inputJawaban = textPilihan.text;
                        continue;
                    }
                } 
            }
        }
    }

    public void JawabanBenar()
    {
        if(isHorizontal)
        {
            for(int i=0; i <answerWord0.Length; i++)
            {   
                if(TTSManager.instance.kotakList[indexPilihan].GetComponent<DataKotakHuruf>().inputJawaban == TTSManager.instance.kotakList[indexPilihan].GetComponent<DataKotakHuruf>().hurufJawaban.ToString())
                {
                    Debug.Log("YA");
                    TTSManager.instance.hasilText.text = "Nice";
                    TTSManager.instance.delayCounter += 3f;
                    TTSManager.instance.hasilText.color = Color.black;
                    TTSManager.instance.jumlahHurufBenar++;
                    TTSManager.instance.kotakList[indexPilihan].GetComponent<DataKotakHuruf>().hurufBenar = true;
                    Debug.Log(TTSManager.instance.jumlahHurufBenar);

                    if(TTSManager.instance.jumlahHurufBenar >= answerWord0.Length / 2)
                    {
                        TTSManager.instance.hasilText.text = "Dikit Lagi";
                        TTSManager.instance.delayCounter += 3f;
                        TTSManager.instance.hasilText.color = Color.black;
                    }

                    if(TTSManager.instance.jumlahHurufBenar >= answerWord0.Length)
                    {
                        TTSManager.instance.jumlahSoalBenar++;
                        TTSManager.instance.hasilText.text = "Jawaban Benar";
                        TTSManager.instance.delayCounter += 3f;
                        TTSManager.instance.hasilText.color = Color.green;
                        TTSManager.instance.scorePoint += 100;
                        TTSManager.instance.questionImage.sprite = TTSManager.instance.q.Soal[rootSoal1 - 1].gambarBetul;

                        for(int j = 0; j < TTSManager.instance.kotakList.Count; j++)
                        {
                            if(TTSManager.instance.kotakList[j].GetComponent<DataKotakHuruf>().rootSoal1 == rootSoal1)
                            {
                                TTSManager.instance.kotakList[j].GetComponent<DataKotakHuruf>().soalBenar = true;
                            }                   
                        }

                        for(int j = 0; j < TTSManager.instance.pilihanList.Count;j++)
                        {
                            TTSManager.instance.pilihanList[j].GetComponent<DataKotakHuruf>().isUsed = false;
                        }
                    }
                    
                    return;
                }
                else
                {
                    TTSManager.instance.kotakList[indexPilihan].GetComponent<DataKotakHuruf>().hurufBenar = false;
                    TTSManager.instance.kotakList[indexPilihan].GetComponent<DataKotakHuruf>().textDiKotak.text = "_";
                    TTSManager.instance.hasilText.text = "Jawaban Salah";
                    TTSManager.instance.delayCounter += 3f;
                    TTSManager.instance.hasilText.color = Color.red;
                    TTSManager.instance.pilihanList[indexOption].SetActive(true);
                    Debug.Log("salah");
                    for(int j = 0; j < TTSManager.instance.pilihanList.Count;j++)
                    {
                        TTSManager.instance.pilihanList[j].GetComponent<DataKotakHuruf>().indexPilihan --;
                    }
                    return;
                    TTSManager.instance.jumlahHurufBenar -= 1;
                }
            }

        }
        if(!isHorizontal)
        {
            for(int i=0; i <answerWord1.Length; i++)
            {
                if(TTSManager.instance.kotakList[indexPilihan].GetComponent<DataKotakHuruf>().inputJawaban == TTSManager.instance.kotakList[indexPilihan].GetComponent<DataKotakHuruf>().hurufJawaban.ToString())
                {
                    Debug.Log("YA");
                    TTSManager.instance.hasilText.text = "Nice";
                    TTSManager.instance.delayCounter += 3f;
                    TTSManager.instance.hasilText.color = Color.black;
                    TTSManager.instance.jumlahHurufBenar++;
                    TTSManager.instance.kotakList[indexPilihan].GetComponent<DataKotakHuruf>().hurufBenar = true;
                    Debug.Log(TTSManager.instance.jumlahHurufBenar);

                    if(TTSManager.instance.jumlahHurufBenar >= answerWord1.Length / 2)
                    {
                        TTSManager.instance.hasilText.text = "Dikit Lagi";
                        TTSManager.instance.delayCounter += 3f;
                        TTSManager.instance.hasilText.color = Color.black;
                    }
                    
                    if(TTSManager.instance.jumlahHurufBenar >= answerWord1.Length)
                    {
                        TTSManager.instance.jumlahSoalBenar++;
                        TTSManager.instance.hasilText.color = Color.green;
                        TTSManager.instance.hasilText.text = "Jawaban Benar";
                        TTSManager.instance.delayCounter += 3f;
                        TTSManager.instance.scorePoint += 100;
                        TTSManager.instance.questionImage.sprite = TTSManager.instance.q.Soal[rootSoal2 - 1].gambarBetul;

                        for(int j = 0; j < TTSManager.instance.kotakList.Count; j++)
                        {
                            if(TTSManager.instance.kotakList[j].GetComponent<DataKotakHuruf>().rootSoal2 == rootSoal2)
                            {
                                TTSManager.instance.kotakList[j].GetComponent<DataKotakHuruf>().soalBenar = true;
                            }                   
                        }

                        for(int j = 0; j < TTSManager.instance.pilihanList.Count;j++)
                        {
                            TTSManager.instance.pilihanList[j].GetComponent<DataKotakHuruf>().isUsed = false;
                        }
                    }
                    
                    return;
                }
                else
                {
                    TTSManager.instance.kotakList[indexPilihan].GetComponent<DataKotakHuruf>().hurufBenar = false;
                    TTSManager.instance.kotakList[indexPilihan].GetComponent<DataKotakHuruf>().textDiKotak.text = "_";
                    TTSManager.instance.hasilText.text = "Jawaban Salah";
                    TTSManager.instance.delayCounter += 3f;
                    TTSManager.instance.hasilText.color = Color.red;
                    Debug.Log("salah");
                    for(int j = 0; j < TTSManager.instance.pilihanList.Count;j++)
                    {
                        TTSManager.instance.pilihanList[j].GetComponent<DataKotakHuruf>().indexPilihan --;
                        TTSManager.instance.pilihanList[j].SetActive(true);
                    }
                    TTSManager.instance.jumlahHurufBenar -= 1;
                }

            }
        }
        
    }
    
    public void Hint()
    {
        if(isUsed)
        {
            if(TTSManager.instance.jumlahBantuan >= 5) return;
            TTSManager.instance.jumlahBantuan ++; 
            TTSManager.instance.hasilText.text = "Eaa bantuan, jangan dihabisin sisa " + (5 - TTSManager.instance.jumlahBantuan);
            TTSManager.instance.hasilText.color = Color.black;
            TTSManager.instance.delayCounter += 3f;

            if(TTSManager.instance.jumlahBantuan == 5)
            {
                TTSManager.instance.hasilText.text = "Kan habis bantuannya";
                TTSManager.instance.delayCounter += 3f;
                gameObject.SetActive(false);
            }

            for(int j = 0; j < TTSManager.instance.pilihanList.Count;j++)
            {
                int index = TTSManager.instance.pilihanList[j].GetComponent<DataKotakHuruf>().indexPilihan;
                TTSManager.instance.bantuanText.text = TTSManager.instance.kotakList[index].GetComponent<DataKotakHuruf>().hurufJawaban.ToString(); 
                return;

            }
        }
    }
}