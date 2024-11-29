using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSE : MonoBehaviour
{
    //private new AudioSource audio;
    GameObject obj;
    AudioSource button_Audio;//ボタン用のSE
    AudioClip Sound;
    bool first_hit = false;//最初にオブジェクトに乗った時だけ反応させる

    public void Start()
    {
        //Sound = GetComponent<AudioClip>();
        obj = GameObject.Find("button_audio");
        button_Audio = obj.GetComponent<AudioSource>();
    }

    //マウスがUIの上に乗ったら音が鳴る
    public void OnMouseEnter()
    {
        if (first_hit == false)
        {
            //Debug.Log("マウスがオブジェクトに乗っています");
            button_Audio.Play();
            first_hit = true;//一度だけ鳴らす
        }
    }
    //マウスがUIから離れたとき
    public void OnMouseExit()
    {
        //Debug.Log("マウスがオブジェクトから離れました。");
        first_hit = false;
    }
}