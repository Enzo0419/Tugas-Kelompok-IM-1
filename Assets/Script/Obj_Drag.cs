using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Obj_Drag : MonoBehaviour
{
    [HideInInspector]public Vector2 SavePosisi;
    [HideInInspector]public bool IsDiatasObj;

    Transform SaveObj;

    public int ID;
    public TMP_Text Teks;
    public GameObject Benar, Salah;


    void Start()
    {
        SavePosisi = transform.position;
        Benar.SetActive (false);
        Salah.SetActive (false);
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        
    }
    private void OnMouseUp()
    {
        if (IsDiatasObj)
        {
            int ID_TempatDrop = SaveObj.GetComponent<Tempat_Drop>().ID;

            if (ID == ID_TempatDrop)
            {
                transform.SetParent(SaveObj);
                transform.localPosition = Vector3.zero;
                transform.localScale = new Vector2(0.1830838f, 0.1865425f);

                SaveObj.GetComponent<SpriteRenderer>().enabled = false;

                GameSystem.instance.DataSaatIni++;
                Data.DataScore += 200;
                Benar.SetActive (false);
                Benar.SetActive (true);
            }
            else
            {
                transform.position = SavePosisi;
                Salah.SetActive (false);
                Salah.SetActive (true);
            }

        }
        else
        {
            transform.position = SavePosisi;
            Salah.SetActive (false);
            Salah.SetActive (true);
        }
    }

    private void OnMouseDrag()
    {
        Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Pos;
    }

    private void OnTriggerStay2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Drop"))
        {
            IsDiatasObj = true;
            SaveObj = trig.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Drop"))
        {
            IsDiatasObj = false;
        }
    }
}
