using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jawab : MonoBehaviour
{
    public GameObject feed_benar, feed_salah;
    public AudioClip suaraBenar;
    public AudioClip suaraSalah;
    private AudioSource audioSource;

    void Start()
    {
        feed_benar.SetActive(false);
        feed_salah.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    public void jawaban(bool jawab)
    {
        StartCoroutine(HandleJawaban(jawab));
    }

    IEnumerator HandleJawaban(bool jawab)
    {
        if (jawab)
        {
            feed_benar.SetActive(true);

            if (audioSource != null && suaraBenar != null)
                audioSource.PlayOneShot(suaraBenar);

            int skor = PlayerPrefs.GetInt("skor") + 200;
            PlayerPrefs.SetInt("skor", skor);
            PlayerPrefs.Save();

            yield return new WaitForSeconds(1f);
            feed_benar.SetActive(false);
        }
        else
        {
            feed_salah.SetActive(true);

            if (audioSource != null && suaraSalah != null)
                audioSource.PlayOneShot(suaraSalah);

            yield return new WaitForSeconds(1f);
            feed_salah.SetActive(false);
        }

        gameObject.SetActive(false);
        transform.parent.GetChild(transform.GetSiblingIndex() + 1).gameObject.SetActive(true);
    }
}