
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
    public DataHuruf dataHuruf;
    public Text questionText;
    public Image questionImage;
    private GameStatus gameStatus = GameStatus.Playing;
    public GameObject kotak;
    public GameObject pilihan;
    public Transform wadahTTS;
    public Transform wadahPilihan;
    public List<GameObject> kotakList;
    public List<GameObject> pilihanList;
    public Text TextTimer;
    public float Waktu; 
    private List<int> selectedWordsIndex;
    private char[] wordsArray = new char[20];
    float s;
    public string _answerWord1;
    public string _answerWord2;
    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        selectedWordsIndex = new List<int>(); 
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
    }

    public void MakeGridBoard()
    {
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
                _kotak.GetComponent<DataHuruf>().id = new Vector2Int(col,row);
            }
        }

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
            }
        }

        List<QuestionData> soalDiKotak = q.Soal;
        for(int i = 0; i < soalDiKotak.Count; i ++)
        {
            List<Vector2Int> posHuruf = soalDiKotak[i].posHuruf;
            for(int j = 0; j < kotakList.Count; j++)
            {
                for(int k = 0; k<posHuruf.Count; k++)
                {
                    if(kotakList[j].GetComponent<DataHuruf>().id == posHuruf[k])
                    {
                        if(q.Soal[i].orientasi == 0)
                        {
                            kotakList[j].GetComponent<DataHuruf>().rootSoal1 = q.Soal[i].ID + 1;
                            kotakList[j].GetComponent<DataHuruf>().answerWord1 = q.Soal[i].jawaban;
                        }
                        else
                        {
                            kotakList[j].GetComponent<DataHuruf>().rootSoal2 = q.Soal[i].ID + 1;
                            kotakList[j].GetComponent<DataHuruf>().answerWord2 = q.Soal[i].jawaban;

                        }
                        kotakList[j].GetComponent<DataHuruf>().isUsed = true;
                    }
                }          
            }
        }

        for(int i = 0; i < kotakList.Count; i++)
        {
            if(kotakList[i].GetComponent<DataHuruf>().isUsed == false)
            {
                kotakList[i].SetActive(false);
            }
        }
    }

    public void SetQuestion()
    {
        gameStatus = GameStatus.Playing;

        questionText.text = q.Soal[dataHuruf.rootSoal1].pertanyaan;
        questionImage.sprite = q.Soal[dataHuruf.rootSoal1].gambar;

        selectedWordsIndex.Clear();
        Array.Clear(wordsArray, 0, wordsArray.Length);

        //add the correct char to the wordsArray
       // for (int i = 0; i < _answerWord1.Length; i++)
       // {
         //   wordsArray[i] = char.ToUpper(_answerWord1[i]);
        //}

        //add the dummy char to wordsArray
        for (int j = _answerWord1.Length; j < wordsArray.Length; j++)
        {
            wordsArray[j] = (char)UnityEngine.Random.Range(65, 90);
        }
        wordsArray = ShuffleList.ShuffleListItems<char>(wordsArray.ToList()).ToArray();
    }

    public void Timer()
    {
        int Menit = Mathf.FloorToInt(Waktu/60);
        int Detik = Mathf.FloorToInt(Waktu%60);
        TextTimer.text = Menit.ToString("00")+":"+ Detik.ToString("00");
    }

    public void SelectedOption()
    {
        
    }
}
public enum GameStatus
{
   Playing,
   Pause
}