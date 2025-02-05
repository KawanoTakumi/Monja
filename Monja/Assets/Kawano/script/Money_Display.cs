using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money_Display : MonoBehaviour
{
    public Text Money_Text;//金額表示用テキスト
    void Update()
    {
        //金額をテキストに反映する
        Money_Text.text = string.Format("{0}", PlayerController.Mmoney);
    }
}
