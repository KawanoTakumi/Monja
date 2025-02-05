using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSE : MonoBehaviour
{
    //private new AudioSource audio;
    GameObject Obj;
    AudioSource Button_Audio;//ボタン用のSE
    bool First_hit = false;//最初にオブジェクトに乗った時だけ反応させる

    public void Start()
    {
        //Sound = GetComponent<AudioClip>();
        Obj = GameObject.Find("button_audio");
        Button_Audio = Obj.GetComponent<AudioSource>();
    }

    //マウスがUIの上に乗ったら音が鳴る
    public void OnMouseEnter()
    {
        if (First_hit == false)
        {
            //Debug.Log("マウスがオブジェクトに乗っています");
            Button_Audio.Play();
            First_hit = true;//一度だけ鳴らす
        }
    }
    //マウスがUIから離れたとき
    public void OnMouseExit()
    {
        //Debug.Log("マウスがオブジェクトから離れました。");
        First_hit = false;
    }
}