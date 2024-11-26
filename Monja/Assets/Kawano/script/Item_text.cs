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
            text.text = "LIFE\nジュース缶ジュース。\n[消費アイテム] 　体力を２５％回復する";
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
        else if (button == CompareTag("kesigomu"))
        {
            text.text = "消しゴム\n書いたものを消せる。無駄なものも消そう\n物理攻撃力を２５増加させ、物理攻撃力が高いほど魔法攻撃力を下げる";
        }
        else if (button == CompareTag("TV"))
        {
            text.text = "テレビ\n映像を視聴できる機械。あなたのお好きな番組は何？\n魔法攻撃力２０につき魔法攻撃力を２上昇させる";
        }
        else if (button == CompareTag("CreditCard"))
        {
            text.text = "クレジットカード\nお金を入れておけるカード。色でその人の価値がわかる。\n獲得金額を４０増加させる\n";
        }
        else if (button == CompareTag("Mouse"))
        {
            text.text = "マウス\nパソコンを使うときに必須の機械。マウスなしは考えられない\n魔法攻撃力を２０増加させる";
        }
        else if (button == CompareTag("HandMirror"))
        {
            text.text = "ハンドミラー\n手軽に容姿を確認できるコンパクトな鏡。鏡よ鏡、美しいのは誰？\n物理防御力と魔法防御力を３０増加させる\n";
        }
        else if (button == CompareTag("bowlingpin"))
        {
            text.text = "ボウリングピン\nボウリングで得点を決めるためのもの。僕にはあてないで\n戦闘開始時、物理攻撃力が高いほど獲得金額が増加";
        }
        else if (button == CompareTag("baseball_ball"))
        {
            text.text = "野球ボール\n野球用のボール。ストラーイク、バッターアウト\n物理攻撃力を３０増加し物理防御力を３０減少させる";
        }
        else if (button == CompareTag("dice"))
        {
            text.text = "サイコロ\nランダムで数字を決めるための道具。1d6? 2d6?\n１ターンごとにランダムな効果を発動";
        }
        else if (button == CompareTag("Water bucket"))
        {
            text.text = "水入りのバケツ\n水が入ったバケツ。アイスバケツチャレンジ！！！\n魔法防御力を２０増加させる";
        }
        else if (button == CompareTag("Popcorn"))
        {
            text.text = "ポップコーン\nトウモロコシを高温ではじけさせたお菓子。映画には必須のお供\n戦闘開始時、体力を４０回復させる";
        }
        else if (button == CompareTag("Apple"))
        {
            text.text = "リンゴ\n赤くて甘い木に実る果実。ひらめきの種\n戦闘開始時、体力を３０回復し、魔法攻撃力を１５増加させる";
        }
        else if (button == CompareTag("Scissors"))
        {
            text.text = "ハサミ\n紙などを切るためお道具。どんなカットがお好み？\n物理攻撃力を２０増加させる";
        }
        else if (button == CompareTag("ice"))
        {
            text.text = "氷\n水を凍らせるとできる物体。かき氷にしますか？\n魔法攻撃力を２０増加させ、氷の弾で攻撃する（アイテム画面でアイテムを押すと魔法攻撃が変化）";
        }
        else if (button == CompareTag("Pudding"))
        {
            text.text = "プリン\n卵を牛乳などと一緒に固めた甘いお菓子。至福の時間\n戦闘開始時体力を最大値の25%分回復する。\nリンゴを持っていると戦闘ごとに最大体力が30増加する";
        }
        else if (button == CompareTag("Drill"))
        {
            text.text = "ドリル\n物に穴を開ける道具。穴の開けすぎには注意\nエネミーの物理攻撃力分プレイヤー攻撃力を増加させ、エネミーの物理防御力分プレイヤーの物理防御力を減少させる";
        }
        else if (button == CompareTag("Headphone"))
        {
            text.text = "ヘッドフォン\n頭につけることで音楽を聞くことができる道具。自分の世界に入ってしまう\nターン毎に物理攻撃力と物理防御力を３減少\n体力を１０回復";
        }
        else if (button == CompareTag("UtypeMagnet"))
        {
            text.text = "U字型マグネット\nU字型のマグネット。強力な磁力を帯びている。\n敵の武器も引っ付く\n魔法攻撃力２０増加する";
        }
        else if (button == CompareTag("Coffee"))
        {
            text.text = "コーヒー\n豆を焙煎した飲料水。とても苦い。\nChill Time !!!\n体力を２０減らし魔法攻撃力を３０増加させる";
        }
        else if (button == CompareTag("Safetycone"))
        {
            text.text = "三角コーン\n危険な場所に設置してあるもの。\nたまに蹴られる不運な奴\n５０％の確率で物理攻撃力と物理防御力を４０増加";
        }
        else if (button == CompareTag("USB"))
        {
            text.text = "USBメモリ\nパソコンから情報を保存できる機械。なくしたら終わり\n魔法攻撃力を３０増加させ魔法防御力を２０減少させる";
        }
        else if (button == CompareTag("Smartphone"))
        {
            text.text = "スマートフォン\n値段が高い様々な機能のついた電話機器。りんごのマーク。\n魔法攻撃力が高いほど魔法防御力を増加させる";
        }
        else if (button == CompareTag("ItypeMagnet"))
        {
            text.text = "I字型マグネット\nI字型のマグネット。U字型とたいして変わらない。\n魔法防御力を２０増加させる";
        }
        else if (button == CompareTag("Magnifying Speculum"))
        {
            text.text = "虫眼鏡\n物を拡大して見ることができるツール。黒紙と空が晴れていたら最高da！！\n物理防御力と魔法防御力を毎ターン１０増加させる";
        }
        else if (button == CompareTag("Mike"))
        {
            text.text = "マイク\n音を拾うことができる機械。Say Yeah!!\n魔法攻撃力を３０増加させ音のノイズで攻撃する（アイテム画面でアイテムを押すと魔法攻撃が変化）";
        }
        else if (button == CompareTag("Megaphone"))
        {
            text.text = "メガホン\n音を大きくする機械。もう大声を出さなくてもいい\n物理防御力を２０増加させる";
        }
        else if (button == CompareTag("HandMill"))
        {
            text.text = "ハンドミル\n豆を挽くための道具。香ばしい香りがしてるぜ。\nコーヒーを持っている時魔法攻撃力を６０増加させる\n持っていない時は魔法攻撃力を３０減少させる";
        }
    }

    //魔法攻撃を後から変更するための関数（アイテム画面でボタンを押したらその魔法攻撃になる）
    public void magic_number(int num_M)
    {
        PlayerController.magic_number = num_M;
    }


}
