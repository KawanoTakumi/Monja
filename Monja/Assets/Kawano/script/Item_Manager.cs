using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item_Manager : MonoBehaviour
{
    //念のためstaticにしてどこでも値が保持されるようにする
    public static IDictionary<string, bool> Item = new Dictionary<string, bool>();
    private void Awake()
    {
        Application.targetFrameRate = 60;

        DontDestroyOnLoad(this);
        //辞書にキーを設定
        if (Item.ContainsKey("healdrink") == false)
        {
            Item.Add("none", false);//空のキーを設定（アイテムがないとき）
            //アイテムをItem辞書に登録
            Item.Add("healdrink", false);
            Item.Add("bowlingball", false);
            Item.Add("CDplayer", false);
            Item.Add("cd", false);
            Item.Add("radio", false);
            Item.Add("hourglass", false);
        }
    }

    public void Start()
    {
       
    }

}