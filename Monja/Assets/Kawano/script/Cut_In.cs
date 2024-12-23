using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cut_In : MonoBehaviour
{
    public GameObject Cut_Scene;//カットシーン
    public AudioSource Cut_In_SE;//カットイン用SE
    public AudioClip clip;//音楽データ
    public static bool first_flag = true;//初回フラグ
    public void Update()
    {
        //fairst_flagがfalseのとき、カットシーンを削除
        if (first_flag == false)
            Destroy(Cut_Scene);
    }
    //カットイン
    public void Cut_In_Del()
    {
        if(first_flag == true)
        {
            Cut_Scene.SetActive(false);
            first_flag = false;
        }
    }
    //最初のシーン以外ではカットシーンを削除
    public void First_scene()
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