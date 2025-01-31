using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log_list : MonoBehaviour
{
    //ログ用のリストを追加
    public static List<string> LogList = new();
    public Text Text;
    public GameObject Log_list_box;
    bool Hit = false;

    //ボタンが押された場合ログを開く
    public void Log_Open()
    {
        if(Hit == false)
        {
            Log_list_box.SetActive(true);
            Log_Get();//ログを読み込む
            Hit = true;
        }
        else
        {
            Text.text = "";//テキストを初期化
            Log_list_box.SetActive(false);//ログを閉じる
            Hit = false;
        }
    }
    //ログをテキストに入れる
    void Log_Get()
    {
        //LogList.Reverse();//listを逆順にする
        for (int i = 0; i <LogList.Count; i++)
        {
            Text.text += LogList[i];//LogList[0]から順番に入れる
        }
    }
    //ログリストの中身を破棄
    //(勝ち、負け、終了時に呼び出す)
    public static void Log_Clear()
    {
        LogList.Clear();
    }
}