using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cut_In : MonoBehaviour
{
    public GameObject Cut_Scene;
    public AudioSource Cut_In_SE;//カットイン用SE
    public AudioClip clip;
    public static bool first_flag = true;//初回のみ再生

    public void Update()
    {
        if (first_flag == false)
            Destroy(Cut_Scene);
    }

    public void Cut_In_Del()
    {
        if(first_flag == true)
        {
            Cut_Scene.SetActive(false);
            first_flag = false;
        }
    }
    public void first_scene()
    {
        if(Enemy_controller.turn != 1)
        {
            Cut_Scene.SetActive(false);
        }
    }
    //カットインサウンド関数
    public void Cut_In_Sound()
    {
        Cut_In_SE.PlayOneShot(clip);
    }
}