using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TTSManager : MonoBehaviour
{
    public static TTSManager instance {get; set;}

    public QuizDataScriptable q;
    public DataKotakHuruf dataHuruf;
    public Text questionText;
    public Text hasilText;
    public Text scoreText;
    public Text bantuanText;
    public Image questionImage;
    public GameObject kotak;
    public GameObject pilihan;
    public GameObject titik;
    public GameObject hint;
    public Transform wadahTTS;
    public Transform wadahPilihan;
    public List<GameObject> kotakList;
    public List<GameObject> pilihanList;
    public Text TextTimer;
    public float Waktu; 

    float s;
    public float delayCounter;

    public int scorePoint;
    public int jumlahBantuan = 0;
    public int jumlahHurufBenar = 0;
    public int jumlahSoalBenar = 0;
    public char[] wordsArray = new char[20];               //array which store char of each options
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(this != instance) {
            Destroy(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        SetQuestion();
        MakeGridBoard();
    }

    void Update()
    {
        Timer();

        s += Time.deltaTime;
        if(s >= 1)
        {
            Waktu++;
            s = 0;
        }
        
        if(delayCounter >= 0)
        {
            delayCounter -= Time.deltaTime;
            if(delayCounter < 0)
            {
                hasilText.text = "";
                bantuanText.text = "?";
            }
        }
    }

    public void MakeGridBoard()
    {
        // Spawn Grid
        kotakList = new List<GameObject>();
        for(int row = 0; row < q.height; row++ )
        {
            for(int col = 0; col < q.width; col++ )
            {
                Vector3 startingPos = new Vector3(q.startPos.x +col*q.spacing, q.startPos.y - row*q.spacing, q.startPos.z);
                GameObject _kotak = Instantiate(kotak, startingPos, Quaternion.identity);
                _kotak.transform.parent = wadahTTS.transform;
                kotakList.Add(_kotak);
                _kotak.transform.localScale = new Vector3(q.scaleKotak,q.scaleKotak,q.scaleKotak);
                _kotak.name = col + "," + row;
                _kotak.GetComponent<DataKotakHuruf>().id = new Vector2Int(col,row);
            }
        }

        // Membuat Map TTS
        List<QuestionData> soalDiKotak = q.Soal;      
        for(int i = 0; i < soalDiKotak.Count; i ++)
        {
            string jawaban = q.Soal[i].jawaban;
            List<char> _soal = new List<char> (jawaban.ToCharArray());
            List<Vector2Int> posHuruf = soalDiKotak[i].posHuruf;
            for(int j = 0; j < kotakList.Count; j++)
            {
                for(int k = 0; k<posHuruf.Count; k++)
                {
                    if(kotakList[j].GetComponent<DataKotakHuruf>().id == posHuruf[k])
                    {
                        if(q.Soal[i].orientasi == 0)
                        {
                            kotakList[j].GetComponent<DataKotakHuruf>().rootSoal1 = q.Soal[i].ID + 1;
                            kotakList[j].GetComponent<DataKotakHuruf>().answerWord0 = q.Soal[i].jawaban;
                            kotakList[j].GetComponent<DataKotakHuruf>().isHorizontal = true;
                        }
                        else
                        {
                            kotakList[j].GetComponent<DataKotakHuruf>().rootSoal2 = q.Soal[i].ID + 1;
                            kotakList[j].GetComponent<DataKotakHuruf>().answerWord1 = q.Soal[i].jawaban;
                            kotakList[j].GetComponent<DataKotakHuruf>().isHorizontal = false;
                        }

                        kotakList[j].GetComponent<DataKotakHuruf>().isUsed = true;
                        kotakList[j].GetComponent<DataKotakHuruf>().indexDiSoal = j;
                        kotakList[j].GetComponent<DataKotakHuruf>().hurufJawaban = _soal[k];

                        if(kotakList[j].GetComponent<DataKotakHuruf>().id == posHuruf[0])
                        {
                            kotakList[j].GetComponent<DataKotakHuruf>().hurufPertama = true;                           
                        }
                        else 
                        {
                            kotakList[j].GetComponent<DataKotakHuruf>().hurufPertama = false;

                        }
                    }
                }
            }
        }

        //Disable GameObject Grid
        for(int i = 0; i < kotakList.Count; i++)
        {
            if(kotakList[i].GetComponent<DataKotakHuruf>().isUsed == false)
            {
                kotakList[i].SetActive(false);
                kotakList[i].GetComponent<DataKotakHuruf>().hurufPertama = false;
            }
        }              

        // Spawn Option Jawaban
        pilihanList = new List<GameObject>();
        for(int row = 0; row < 2; row++ )
        {
            for(int col = 0; col < 10; col++ )
            {
                Vector3 startingPos = new Vector3(0f +col*0.75f,-2.5f-row*0.85f,0);
                GameObject _pilihan = Instantiate(pilihan, startingPos, Quaternion.identity);
                _pilihan.transform.parent = wadahPilihan.transform;
                pilihanList.Add(_pilihan);
                _pilihan.transform.localScale = new Vector3(0.75f,0.75f,0.75f);
                _pilihan.name = "Pilihan di " + col + "," + row;        

                for( int i = 0; i< pilihanList.Count; i++)
                {
                    pilihanList[i].SetActive(false);
                }       
            }
        }
    }
    
    public void SetQuestion()
    {
        questionText.text = q.Soal[0].pertanyaan;
        questionImage.sprite = q.Soal[0].gambar;
        
        string answerWord = q.Soal[0].jawaban;
    }
    
    public void Timer()
    {
        int Menit = Mathf.FloorToInt(Waktu/60);
        int Detik = Mathf.FloorToInt(Waktu%60);
        TextTimer.text = Menit.ToString("00")+":"+ Detik.ToString("00");
    }
}