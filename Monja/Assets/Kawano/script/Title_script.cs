using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_script : MonoBehaviour
{
    public AudioSource Title_bgm;
    bool bgm_start = false;
    public void Update()
    {
        if (bgm_start == true)
        {
            Title_bgm.Play();
            bgm_start = false;
        }
    }

    public void BGM_manage()
    {
        bgm_start = true;
    }
}