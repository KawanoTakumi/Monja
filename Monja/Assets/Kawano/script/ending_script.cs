using UnityEngine;
using UnityEngine.UI;

public class ending_script : MonoBehaviour
{
    public GameObject Cave_scene;//洞窟のシーン
    public Text Ending_Text;//エンディング用テキスト

    //洞窟のシーンを削除
    public void Cave_del()
    {
        Cave_scene.SetActive(false);
    }

    public void Text_Change(int Number)
    {
        switch (Number)
        {
            case 1: Ending_Text.text = "無事、洞窟の主であるドラゴンを\n倒すことができた主人公は";break;
            case 2: Ending_Text.text = "パラレライト鉱石が\n大量に存在している空間に辿り着くことができた";break;
            case 3: Ending_Text.text = "主人公はパラレライト鉱石を\n大量に持ち帰って"; break;
            case 4: Ending_Text.text = "大金を手に入れることができた\nかくして主人公は夢を達成することができた"; break;
            case 5: Ending_Text.text = "後日盗賊団にお金をすべて盗まれてしまったが・・・";break;
        }
    }
}
