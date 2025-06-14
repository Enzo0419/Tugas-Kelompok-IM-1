using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXControler : MonoBehaviour
{
    public Slider sVolumeSFX;
    public AudioSource asSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VolumeSFX()
    {
        asSFX.volume = sVolumeSFX.value / 2;
    }
}
