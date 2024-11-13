using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Setting_Manager : MonoBehaviour
{
    public AudioSource sorce;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sorce.volume = Slider_Manager.Music_Volume;
    }
}
