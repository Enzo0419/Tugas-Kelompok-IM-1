using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Data
{
    public static int DataLevel,DataScore;
}

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;

    int MaxLevel = 4;

    public bool GameAktif;
    public bool GameSelesai;
    public int Target, DataSaatIni;
    public int DataLevel, DataScore;

    public TMP_Text Teks_Score;
    public TMP_Text Teks_Level;

    public bool SistemAcak;
    public GameObject Gui_Transisi;

    [System.Serializable]

    public class DataGame
    {
        public string Nama;
        public Sprite Gambar;
    }

    [Header("Settingan Standar")]
    public DataGame[] DataPermainan;

    public Obj_TempatDrop[] Drop_Tempat;
    public Obj_Drag[] Drag_Obj;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameAktif = false;
        GameSelesai = false;
        ResetData();
        Target = Drop_Tempat.Length;
        if (SistemAcak)
            AcakSoal();

        DataSaatIni = 0;
        GameAktif = true;
    }

    void ResetData()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Game0")
        {
            Data.DataScore = 0;
            Data.DataLevel = 0;
        }
    }

    public List<int> _AcakSoal = new List<int>();
    public List<int> _AcakPos = new List<int>();
    int rand;
    int rand2;

    public void AcakSoal()
    {
        _AcakSoal.Clear();
        _AcakPos.Clear();

        _AcakSoal = new List<int>(new int[Drag_Obj.Length]);

        for (int i = 0; i < _AcakSoal.Count; i++)
        {
            rand = Random.Range(1, DataPermainan.Length);
            while (_AcakSoal.Contains(rand))
                rand = Random.Range(1, DataPermainan.Length);

            _AcakSoal[i] = rand;

            Drag_Obj[i].ID = rand - 1;
            Drag_Obj[i].Teks.text = DataPermainan[rand - 1].Nama;

        }

        _AcakPos = new List<int>(new int[Drop_Tempat.Length]);

        for (int i = 0; i < _AcakPos.Count; i++)
        {
            rand2 = Random.Range(1, _AcakSoal.Count + 1);
            while (_AcakPos.Contains(rand2))
                rand2 = Random.Range(1, _AcakSoal.Count + 1);

            _AcakPos[i] = rand2;

            Drop_Tempat[i].Drop.ID = _AcakSoal[rand2 - 1] - 1;
            Drop_Tempat[i].Gambar.sprite = DataPermainan[Drop_Tempat[i].Drop.ID].Gambar;

        }

    }

    public void SetInfoUI()
    {
        Teks_Score.text = Data.DataScore.ToString();

        Teks_Level.text = (Data.DataLevel + 1).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            AcakSoal();
        
        if (GameAktif && !GameSelesai)
        {
            if (DataSaatIni >= Target)
            {
                GameSelesai = true;
                GameAktif = false;

                if (Data.DataLevel < (MaxLevel - 1))
                {
                    Data.DataLevel++;

                    UnityEngine.SceneManagement.SceneManager.LoadScene("Game" + Data.DataLevel);
                    //Gui_Transisi.GetComponent<UI_Control>().Btn_Pindah("Game" + Data.DataLevel);
                }
                else
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("GameSelesai");
                }
            }

        }

        SetInfoUI();
    }
}
