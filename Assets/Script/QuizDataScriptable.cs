using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Orientasi
{
    mendatar = 0,
    menurun = 1
}

[CreateAssetMenu(fileName = "LevelTTS", menuName = "DataTTS", order = 1)]
public class QuizDataScriptable : ScriptableObject
{
    //BoardMap
    public int height;
    public int width;
    public Vector3 startPos;
    public float spacing;
    public float scaleKotak;


    //Soal
    public List<QuestionData> Soal = new List<QuestionData>();
}


[System.Serializable]
public class QuestionData
{
    public int ID;
    public string pertanyaan;
    public string jawaban;
    public Sprite gambar;
    public List<Vector2Int> posHuruf;
    public Orientasi orientasi;
}
