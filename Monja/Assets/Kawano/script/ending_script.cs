using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ending_script : MonoBehaviour
{
    public GameObject scene;//シーン
    public Text text_box;//テキストボックス
    //洞窟のシーンを削除
    public void cave_del()
    {
        scene.SetActive(false);
    }

    public void Text_Change(int Number)
    {
        switch (Number)
        {
            case 1:text_box.text = "無事、洞窟の主であるドラゴンを\n倒すことができた主人公は";break;
            case 2:text_box.text = "パラレライト鉱石が\n大量に存在している空間に辿り着くことができた";break;
            case 3:text_box.text = "主人公はパラレライト鉱石を大量に\n持ち帰って"; break;
            case 4:text_box.text = "大金を手に入れることができた\nかくして主人公は夢を達成することができた"; break;
            case 5:text_box.text = "後日盗賊団にお金をすべて盗まれてしまったが・・・";break;
        }
    }
}
