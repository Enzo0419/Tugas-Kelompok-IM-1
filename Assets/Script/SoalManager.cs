using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoalManager : MonoBehaviour
{
    [System.Serializable]
    public class Soal
    {
        [TextArea]
        public string soal;

        public GameObject pilA;
        public GameObject pilB, pilC, pilD;

        public bool A;
        public bool B, C, D;

    }

    TMP_Text textSoal;

    public List<Soal> KumpulanSoal;

    // Start is called before the first frame update
    void Start()
    {
        textSoal = GameObject.Find("TextSoal").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textSoal.text =KumpulanSoal[0].soal;
    }
}
