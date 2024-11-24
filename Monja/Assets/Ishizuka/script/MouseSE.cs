using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSE : MonoBehaviour
{
    private new AudioSource audio;
    public AudioClip Sound;
    bool first_hit = false;//最初にオブジェクトに乗った時だけ反応させる

    //マウスがUIの上に乗ったら音が鳴る
    public void OnMouseEnter()
    {
        if (first_hit == false)
        {
            Debug.Log("マウスがオブジェクトに乗っています");
            GetComponent<AudioSource>().Play();  // 効果音を鳴らす
            first_hit = true;
        }
    }
    //マウスがUIから離れたとき
    public void OnMouseExit()
    {
        Debug.Log("マウスがオブジェクトから離れました。");
        first_hit = false;
    }
}