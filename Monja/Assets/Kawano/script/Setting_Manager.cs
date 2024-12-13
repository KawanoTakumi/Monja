using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Setting_Manager : MonoBehaviour
{
    public AudioSource sorce_1;//1
    public AudioSource sorce_2;//2
    public AudioSource sorce_3;//3
    public AudioSource sorce_4;//4
    public AudioSource sorce_5;//5
    void Update()
    {
        sorce_1.volume = Slider_Manager.Music_Volume;
        sorce_2.volume = sorce_1.volume;
        sorce_3.volume = sorce_1.volume;
        sorce_4.volume = sorce_1.volume;
        sorce_5.volume = sorce_1.volume;
    }
}