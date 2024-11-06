using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_text : MonoBehaviour
{
    public Button button;//ボタン
    Text text;//説明文
    // Start is called before the first frame update
    void Start()
    {
        GameObject Text = GameObject.Find("Item_Text");
        text = Text.GetComponent<Text>();

        button = GetComponent<Button>();
        button.interactable = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit_button()
    {

        if (button == CompareTag("bowlingball"))
        {
            text.text = "ボーリングの玉\nボーリングに使われていた玉。少し重い。\n物理攻撃力を20上昇させ、物理防御力を20減少させる";
        }
        else if (button == CompareTag("radio"))
        {
            text.text = "ラジオ\n音響を無線通信で傍聴できる機械。どこかで体操が始まる。\n１ターンごとに防御力を10増加させ、HPを5減少させる";
        }
        else if (button == CompareTag("healdrink"))
        {
            text.text = "LIFE\nジュース缶ジュース。\n[消費アイテム] \n体力を２５％回復する";
        }
        else if (button == CompareTag("hourglass"))
        {
            text.text = "砂時計\n砂を使った時計。時間は有限。\n１ターンごとに攻撃力を10上昇させ、体力を5減少させる";
        }
        else if (button == CompareTag("cd"))
        {
            text.text = "CD\n映像や音楽を書き込むことができる。投げても痛そう。\n物理防御力が高いほど、物理攻撃力を上昇させる";
        }
        else if (button == CompareTag("CDplayer"))
        {
            text.text = "CDプレーヤー\nCDをセットすることで音楽を聴ける。CDはどこ？\n物理防御力を20上昇させ、物理攻撃力を20減少させる";
        }

    }

}
