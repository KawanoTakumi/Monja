using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSE : MonoBehaviour
{
   
    //マウスがUIの上に乗ったら音が鳴る
    void OnMouseEnter()
    {
        Debug.Log("abcd");
            GetComponent<AudioSource>().Play();  // 効果音を鳴らす
    }
    void OnMouseExit()
    {
        Debug.Log("マウスがオブジェクトから離れました。");
        
    }
}
