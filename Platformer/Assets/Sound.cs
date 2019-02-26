using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource musica;

    public static Sound instance = null;
    // Start is called before the first frame update
    void Awake()
    {
        musica = GetComponent<AudioSource>();
        
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
}
