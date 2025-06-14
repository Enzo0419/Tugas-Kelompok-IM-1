using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public  Slider sVolumeMusic;
    public AudioSource asMusic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void VolumeMusic()
    {
        asMusic.volume = sVolumeMusic.value / 2;
    }
}
