using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioDown : MonoBehaviour
{
    public Slider volumen;

    public AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VolumeController()
    {
        AudioListener.volume = volumen.value;
    }
}
