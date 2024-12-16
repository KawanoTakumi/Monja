using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_text : MonoBehaviour
{
    public Button button;//ボタン
    Text itemname;//名前
    Text text;//説明文
    void Start()
    {
        GameObject Name = GameObject.Find("Item_Name");
        itemname = Name.GetComponent<Text>();
        GameObject Text = GameObject.Find("Item_Text");
        text = Text.GetComponent<Text>();
        button = GetComponent<Button>();
        button.interactable = true;
    }
    public void Hit_button()
    {

        if (button == CompareTag("bowlingball"))
        {
            itemname.text = "ボウリングの玉";
            text.text = "ボウリングに使われていた玉。少し重い。\n物理攻撃力を20上昇させ、物理防御力を20減少させる";
        }
        else if (button == CompareTag("radio"))
        {
            itemname.text = "ラジオ";
            text.text = "音響を無線通信で傍聴できる機械。どこかで体操が始まる。\n１ターンごとに防御力を10増加させ、HPを5減少させる";
        }
        else if (button == CompareTag("healdrink"))
        {
            itemname.text = "LIFE";
            text.text = "缶ジュース。甘くておいしい\n[消費アイテム] 体力を半分回復する";
        }
        else if (button == CompareTag("hourglass"))
        {
            itemname.text = "砂時計";
            text.text = "砂を使った時計。時間は有限。\n１ターンごとに物理攻撃力を10上昇させ、体力を5減少させる";
        }
        else if (button == CompareTag("cd"))
        {
            itemname.text = "CD";
            text.text = "映像や音楽を書き込むことができる。投げても痛そう。\n物理防御力が高いほど、物理攻撃力を上昇させる";
        }
        else if (button == CompareTag("CDplayer"))
        {
            itemname.text = "CDプレーヤー";
            text.text = "CDをセットすることで音楽を聴ける。CDはどこ？\n物理防御力を20上昇させ、物理攻撃力を20減少させる";
        }
        else if (button == CompareTag("kesigomu"))
        {
            itemname.text = "消しゴム";
            text.text = "書いたものを消せる。無駄なものも消そう\n物理攻撃力を２０増加させ、物理攻撃力が高いほど魔法攻撃力を下げる";
        }
        else if (button == CompareTag("TV"))
        {
            itemname.text = "テレビ";
            text.text = "映像を視聴できる機械。あなたのお好きな番組は何？\n魔法攻撃力５につき魔法攻撃力を３上昇させる";
        }
        else if (button == CompareTag("CreditCard"))
        {
            itemname.text = "クレジットカード";
            text.text = "お金を入れておけるカード。色でその人の価値がわかる。\n戦闘開始後２０G所持金に追加する\n";
        }
        else if (button == CompareTag("Mouse"))
        {
            itemname.text = "マウス";
            text.text = "パソコンを使うときに必須の機械。マウスなしは考えられない\n魔法攻撃力を１０増加させる";
        }
        else if (button == CompareTag("HandMirror"))
        {
            itemname.text = "ハンドミラー";
            text.text = "手軽に容姿を確認できるコンパクトな鏡。鏡よ鏡、美しいのは誰？\n物理防御力と魔法防御力を１５増加させる";
        }
        else if (button == CompareTag("bowlingpin"))
        {
            itemname.text = "ボウリングピン";
            text.text = "ボウリングで得点を決めるためのもの。僕にはあてないで\n戦闘開始時、物理攻撃力が高いほど獲得金額が増加";
        }
        else if (button == CompareTag("baseball_ball"))
        {
            itemname.text = "野球ボール";
            text.text = "野球用のボール。ストラーイク、バッターアウト\n物理攻撃力を１５増加し物理防御力を１０減少させる";
        }
        else if (button == CompareTag("dice"))
        {
            itemname.text = "サイコロ";
            text.text = "ランダムで数字を決めるための道具。1d6? 2d6?\n１ターンごとにランダムな効果を発動";
        }
        else if (button == CompareTag("Water bucket"))
        {
            itemname.text = "水入りのバケツ";
            text.text = "水が入ったバケツ。アイスバケツチャレンジ！！！\n魔法防御力を１０増加させる";
        }
        else if (button == CompareTag("Popcorn"))
        {
            itemname.text = "ポップコーン";
            text.text = "トウモロコシを高温ではじけさせたお菓子。映画には必須のお供\n戦闘開始時、体力を２０回復させる";
        }
        else if (button == CompareTag("Apple"))
        {
            itemname.text = "リンゴ";
            text.text = "赤くて甘い木に実る果実。ひらめきの種\n戦闘開始時、体力を３０回復し、魔法攻撃力を１５増加させる";
        }
        else if (button == CompareTag("Scissors"))
        {
            itemname.text = "ハサミ";
            text.text = "紙などを切るためお道具。どんなカットがお好み？\n物理攻撃力を30増加させるがターン毎に物理防御力を2減少させる";
        }
        else if (button == CompareTag("ice"))
        {
            itemname.text = "氷";
            text.text = "水を凍らせるとできる物体。かき氷にしますか？\n魔法攻撃力を１０増加させ、氷の弾で攻撃する（アイテム画面でアイテムを押すと魔法攻撃が変化）";
        }
        else if (button == CompareTag("Pudding"))
        {
            itemname.text = "プリン";
            text.text = "卵を牛乳などと一緒に固めた甘いお菓子。至福の時間\n戦闘開始時体力を最大値の25%分回復する。\nまた、リンゴを持っていると戦闘ごとに最大体力が30増加する";
        }
        else if (button == CompareTag("Drill"))
        {
            itemname.text = "ドリル";
            text.text = "物に穴を開ける道具。穴の開けすぎには注意\nエネミーの物理攻撃力分プレイヤー攻撃力を増加させ、エネミーの物理防御力分プレイヤーの物理防御力を減少させる";
        }
        else if (button == CompareTag("Headphone"))
        {
            itemname.text = "ヘッドフォン";
            text.text = "頭につけることで音楽を聞くことができる道具。自分の世界に入ってしまう\nターン毎に物理攻撃力と物理防御力を３減少\n体力を１０回復";
        }
        else if (button == CompareTag("UtypeMagnet"))
        {
            itemname.text = "U字型マグネット";
            text.text = "U字型のマグネット。強力な磁力を帯びている。敵の武器も引っ付く\n魔法攻撃力２０増加する";
        }
        else if (button == CompareTag("Coffee"))
        {
            itemname.text = "コーヒー";
            text.text = "豆を焙煎した飲料水。とても苦い。Chill Time !!!\n体力を２０減らし魔法攻撃力を３０増加させる";
        }
        else if (button == CompareTag("Safetycone"))
        {
            itemname.text = "三角コーン";
            text.text = "危険な場所に設置してあるもの。たまに蹴られる不運な奴\n２５％の確率で物理攻撃力と物理防御力を４０増加";
        }
        else if (button == CompareTag("USB"))
        {
            itemname.text = "USBメモリ";
            text.text = "パソコンから情報を保存できる機械。なくしたら終わり\n魔法攻撃力を２０増加させ魔法防御力を１０減少させる";
        }
        else if (button == CompareTag("Smartphone"))
        {
            itemname.text = "スマートフォン";
            text.text = "値段が高い様々な機能のついた電話機器。りんごのマーク。\n魔法攻撃力が高いほど魔法防御力を増加させる";
        }
        else if (button == CompareTag("ItypeMagnet"))
        {
            itemname.text = "I字型マグネット";
            text.text = "I字型のマグネット。U字型とたいして変わらない。\n魔法防御力を２０増加させる";
        }
        else if (button == CompareTag("Magnifying Speculum"))
        {
            itemname.text = "虫眼鏡";
            text.text = "物を拡大して見ることができる道具。レンズが輝く\n物理防御力と魔法防御力を毎ターン3増加させる";
        }
        else if (button == CompareTag("Mike"))
        {
            itemname.text = "マイク";
            text.text = "音を拾うことができる機械。Say Yeah!!\n魔法攻撃力を３０増加させ音のノイズで攻撃する（アイテム画面でアイテムを押すと魔法攻撃が変化）";
        }
        else if (button == CompareTag("Megaphone"))
        {
            itemname.text = "メガホン";
            text.text = "音を大きくする機械。もう大声を出さなくてもいい\n物理防御力を２０増加させる";
        }
        else if (button == CompareTag("HandMill"))
        {
            itemname.text = "ハンドミル";
            text.text = "豆を挽くための道具。香ばしい香りがしてるぜ。\nコーヒーを持っている時魔法攻撃力を６０増加させる\n持っていない時は魔法攻撃力を３０減少させる";
        }
        else if(button == CompareTag("Kama"))
        {
            itemname.text = "死神の鎌";
            text.text = "切れ味がいい鎌。魂まで刈ってしまう\n物理攻撃力を40増加させ、クリティカルがかなり発生しやすくなる";
        }
        else if (button == CompareTag("Robe"))
        {
            itemname.text = "死神のローブ";
            text.text = "死神が着ていたローブ。ひんやりと冷たい\n物理防御力を40増加させ、クリティカルが発生しやすくなる";
        }
        else if (button == CompareTag("Scale"))
        {
            itemname.text = "メデューサの鱗";
            text.text = "メデューサの尻尾の部分の鱗。とても硬い\n魔法攻撃力を40増加させ、クリティカルが出やすくなる";
        }
        else if (button == CompareTag("MagicBook"))
        {
            itemname.text = "メデューサの魔導書";
            text.text = "メデューサが使っていた魔導書。書かれている文字は解読できない\n魔法防御力を40増加させ、クリティカルが出やすくなる\n（アイテム画面でアイテムを押すと魔法攻撃が変化）";
        }
        else if (button == CompareTag("Juwel"))
        {
            itemname.text = "ドラゴンの炎の結晶";
            text.text = "ドラゴンの体内で生成された結晶。ほんのりと暖かい\n最大体力を20増加させる";
        }
        else if (button == CompareTag("Tooth"))
        {
            itemname.text = "ドラゴンの牙";
            text.text = "ドラゴンの鋭い牙。取り扱いには注意\n最大を20増加させる";
        }
    }

    //魔法攻撃を後から変更するための関数（アイテム画面でボタンを押したらその魔法攻撃になる）
    public void magic_number(int num_M)
    {
        PlayerController.magic_number = num_M;
    }
}