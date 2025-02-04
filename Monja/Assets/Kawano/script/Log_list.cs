using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Log_list : MonoBehaviour
{
    //ログ用のリストを追加
    public static List<string> LogList = new();
    public TextMeshProUGUI Log_text;
    public GameObject Log_list_box;
    bool Hit = false;
    Vector3 pos;

    private void Start()
    {
        pos = Log_text.GetComponent<RectTransform>().anchoredPosition;
    }
    public void Update()
    {
        //Log_textのPos.yが０より上にいかないようにする
        if (Log_text.GetComponent<RectTransform>().anchoredPosition.y > 0)
            Log_text.GetComponent<RectTransform>().anchoredPosition = pos;
    }
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
            Log_text.text = "";//テキストを初期化
            pos.y = 0f;
            Log_text.GetComponent<RectTransform>().anchoredPosition = pos;
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
            Log_text.text += LogList[i];//LogList[0]から順番に入れる
        }
    }
    //ログリストの中身を破棄
    //(勝ち、負け、終了時に呼び出す)
    public static void Log_Clear()
    {
        LogList.Clear();
    }
}