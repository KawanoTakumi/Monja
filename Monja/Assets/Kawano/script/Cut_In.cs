using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cut_In : MonoBehaviour
{
    public GameObject Cut_scene;            //カットシーン
    public AudioSource Cut_in_SE;           //カットイン用SE
    public AudioClip Clip;                  //オーディオクリップ
    public static bool FIRST_FLAG = true;   //初回フラグ

    //アップデートメソッド
    //説明・・・一度再生されたらカットシーンを削除
    public void Update()
    {
        //初回フラグがfalseの時、カットインを再生しない
        if (FIRST_FLAG == false)
            Destroy(Cut_scene);
    }
    //カットイン削除メソッド
    public void Cut_In_Del()
    {
        if(FIRST_FLAG == true)
        {
            Cut_scene.SetActive(false);
            FIRST_FLAG = false;
        }
    }
    //最初のシーン以外ではカットシーンを削除
    public void First_scene()
    {
        if(Enemy_controller.turn != 1)
        {
            Cut_scene.SetActive(false);
        }
    }
    //カットインサウンド関数
    public void Cut_In_Sound()
    {
        Cut_in_SE.PlayOneShot(Clip);//クリップを再生
    }
}