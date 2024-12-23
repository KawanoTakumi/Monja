using UnityEngine;
using UnityEngine.UI;

public class Item_text : MonoBehaviour
{
    public Button button; //ボタン
    Text itemname;        //名前
    Text guide_text;      //説明文
    void Start()
    {
        //各種値を最初に取得
        GameObject Name = GameObject.Find("Item_Name");
        itemname = Name.GetComponent<Text>();
        GameObject Text = GameObject.Find("Item_Text");
        guide_text = Text.GetComponent<Text>();
        button = GetComponent<Button>();
        button.interactable = true;
    }
    public void Hit_button()
    {

        if (button == CompareTag("bowlingball"))
        {
            itemname.text = "ボウリングの玉";
            guide_text.text = "ボウリングに使われていた玉。少し重い。\n\n物理攻撃力を20上昇させ、物理防御力を20減少させる";
        }
        else if (button == CompareTag("radio"))
        {
            itemname.text = "ラジオ";
            guide_text.text = "音響を無線通信で傍聴できる機械。どこかで体操が始まる。\n\n１ターンごとに防御力を10増加させ、HPを5減少させる";
        }
        else if (button == CompareTag("healdrink"))
        {
            itemname.text = "LIFE";
            guide_text.text = "缶ジュース。甘くておいしい\n\n[消費アイテム] 体力を半分回復する";
        }
        else if (button == CompareTag("hourglass"))
        {
            itemname.text = "砂時計";
            guide_text.text = "砂を使った時計。時間は有限。\n\n１ターンごとに物理攻撃力を10上昇させ、体力を5減少させる";
        }
        else if (button == CompareTag("cd"))
        {
            itemname.text = "CD";
            guide_text.text = "映像や音楽を書き込むことができる。投げても痛そう。\n\n物理防御力が高いほど、物理攻撃力を上昇させる";
        }
        else if (button == CompareTag("CDplayer"))
        {
            itemname.text = "CDプレーヤー";
            guide_text.text = "CDをセットすることで音楽を聴ける。CDはどこ？\n\n物理防御力を20上昇させ、物理攻撃力を20減少させる";
        }
        else if (button == CompareTag("kesigomu"))
        {
            itemname.text = "消しゴム";
            guide_text.text = "書いたものを消せる。無駄なものも消そう\n\n物理攻撃力を２０増加させ、物理攻撃力が高いほど魔法攻撃力を下げる";
        }
        else if (button == CompareTag("TV"))
        {
            itemname.text = "テレビ";
            guide_text.text = "映像を視聴できる機械。あなたのお好きな番組は何？\n\n魔法攻撃力５につき魔法攻撃力を３上昇させる";
        }
        else if (button == CompareTag("CreditCard"))
        {
            itemname.text = "クレジットカード";
            guide_text.text = "お金を入れておけるカード。色でその人の価値がわかる。\n\n戦闘開始後２０G所持金に追加する\n";
        }
        else if (button == CompareTag("Mouse"))
        {
            itemname.text = "マウス";
            guide_text.text = "パソコンを使うときに必須の機械。マウスなしは考えられない\n\n魔法攻撃力を１０増加させる";
        }
        else if (button == CompareTag("HandMirror"))
        {
            itemname.text = "ハンドミラー";
            guide_text.text = "手軽に容姿を確認できるコンパクトな鏡。鏡よ鏡、美しいのは誰？\n\n物理防御力と魔法防御力を１５増加させる";
        }
        else if (button == CompareTag("bowlingpin"))
        {
            itemname.text = "ボウリングピン";
            guide_text.text = "ボウリングで得点を決めるためのもの。僕にはあてないで\n\n戦闘開始時、物理攻撃力が高いほど獲得金額が増加";
        }
        else if (button == CompareTag("baseball_ball"))
        {
            itemname.text = "野球ボール";
            guide_text.text = "野球用のボール。ストラーイク、バッターアウト\n\n物理攻撃力を１５増加し物理防御力を１０減少させる";
        }
        else if (button == CompareTag("dice"))
        {
            itemname.text = "サイコロ";
            guide_text.text = "ランダムで数字を決めるための道具。1d6? 2d6?\n\n１ターンごとにランダムな効果を発動";
        }
        else if (button == CompareTag("Water bucket"))
        {
            itemname.text = "水入りのバケツ";
            guide_text.text = "水が入ったバケツ。アイスバケツチャレンジ！！！\n\n魔法防御力を１０増加させる";
        }
        else if (button == CompareTag("Popcorn"))
        {
            itemname.text = "ポップコーン";
            guide_text.text = "トウモロコシを高温ではじけさせたお菓子。映画には必須のお供\n\n戦闘開始時、体力を２０回復させる";
        }
        else if (button == CompareTag("Apple"))
        {
            itemname.text = "リンゴ";
            guide_text.text = "赤くて甘い木に実る果実。ひらめきの種\n\n戦闘開始時、体力を３０回復し、魔法攻撃力を１５増加させる";
        }
        else if (button == CompareTag("Scissors"))
        {
            itemname.text = "ハサミ";
            guide_text.text = "紙などを切るためお道具。どんなカットがお好み？\n\n物理攻撃力を30増加させるがターン毎に物理防御力を2減少させる";
        }
        else if (button == CompareTag("ice"))
        {
            itemname.text = "氷";
            guide_text.text = "水を凍らせるとできる物体。かき氷にしますか？\n\n魔法攻撃力を１０増加させ、氷の弾で攻撃する（アイテム画面でアイテムを押すと魔法攻撃が変化）";
        }
        else if (button == CompareTag("Pudding"))
        {
            itemname.text = "プリン";
            guide_text.text = "卵を牛乳などと一緒に固めた甘いお菓子。至福の時間\n\n戦闘開始時体力を最大値の25%分回復する。\nまた、リンゴを持っていると戦闘ごとに最大体力が30増加する";
        }
        else if (button == CompareTag("Drill"))
        {
            itemname.text = "ドリル";
            guide_text.text = "物に穴を開ける道具。穴の開けすぎには注意\n\n戦闘開始時、エネミーの物理攻撃力分プレイヤー攻撃力を増加させ、エネミーの物理防御力分プレイヤーの物理防御力を減少させる";
        }
        else if (button == CompareTag("Headphone"))
        {
            itemname.text = "ヘッドフォン";
            guide_text.text = "頭につけることで音楽を聞くことができる道具。自分の世界に入ってしまう\n\nターン毎に物理攻撃力と物理防御力を３減少\n体力を１０回復";
        }
        else if (button == CompareTag("UtypeMagnet"))
        {
            itemname.text = "U字型マグネット";
            guide_text.text = "U字型のマグネット。強力な磁力を帯びている。敵の武器も引っ付く\n\n魔法攻撃力２０増加する";
        }
        else if (button == CompareTag("Coffee"))
        {
            itemname.text = "コーヒー";
            guide_text.text = "豆を焙煎した飲料水。とても苦い。Chill Time !!!\n\n体力を２０減らし魔法攻撃力を３０増加させる";
        }
        else if (button == CompareTag("Safetycone"))
        {
            itemname.text = "三角コーン";
            guide_text.text = "危険な場所に設置してあるもの。たまに蹴られる不運な奴\n\n戦闘開始時、２５％の確率で物理攻撃力と物理防御力を４０増加";
        }
        else if (button == CompareTag("USB"))
        {
            itemname.text = "USBメモリ";
            guide_text.text = "パソコンから情報を保存できる機械。なくしたら終わり\n\n魔法攻撃力を２０増加させ魔法防御力を１０減少させる";
        }
        else if (button == CompareTag("Smartphone"))
        {
            itemname.text = "スマートフォン";
            guide_text.text = "値段が高い様々な機能のついた電話機器。りんごのマーク。\n\n魔法攻撃力が高いほど魔法防御力を増加させる";
        }
        else if (button == CompareTag("ItypeMagnet"))
        {
            itemname.text = "I字型マグネット";
            guide_text.text = "I字型のマグネット。U字型とたいして変わらない。\n\n魔法防御力を２０増加させる";
        }
        else if (button == CompareTag("Magnifying Speculum"))
        {
            itemname.text = "虫眼鏡";
            guide_text.text = "物を拡大して見ることができる道具。レンズが輝く\n\n毎ターン物理防御力と魔法防御力を3増加させる";
        }
        else if (button == CompareTag("Mike"))
        {
            itemname.text = "マイク";
            guide_text.text = "音を拾うことができる機械。Say Yeah!!\n\n魔法攻撃力を３０増加させ音のノイズで攻撃する\n（アイテム画面でアイテムを押すと魔法攻撃が変化）";
        }
        else if (button == CompareTag("Megaphone"))
        {
            itemname.text = "メガホン";
            guide_text.text = "音を大きくする機械。もう大声を出さなくてもいい\n\n物理防御力を２０増加させる";
        }
        else if (button == CompareTag("HandMill"))
        {
            itemname.text = "ハンドミル";
            guide_text.text = "豆を挽くための道具。香ばしい香りがしてるぜ。\n\nコーヒーを持っている時、魔法攻撃力を６０増加させる\n持っていない時は魔法攻撃力を３０減少させる";
        }
        else if(button == CompareTag("Poteto"))
        {
            itemname.text = "ポテト";
            guide_text.text = "ジャガイモを油で揚げた食べ物。食べるのをやめられない\n\nハンバーガーを持っている時物理攻撃力を60増加させ、持っていない時は物理攻撃力を３０減少させる";
        }
        else if (button == CompareTag("Scop"))
        {
            itemname.text = "ショベル";
            guide_text.text = "土を掘ったり、鳴らしたりできる。\n\n戦闘開始時４分の１の確率でお金を３０入手する";
        }
        else if (button == CompareTag("hammer"))
        {
            itemname.text = "ハンマー";
            guide_text.text = "様々な用途がある万能な道具\n\n毎ターン１０分の１の確率で相手を気絶させる";
        }
        else if (button == CompareTag("Speaker"))
        {
            itemname.text = "スピーカー";
            guide_text.text = "音を増幅させる装置。カルテット？\n\n敵の物理防御力を25減少させる";
        }
        else if (button == CompareTag("Sylinge"))
        {
            itemname.text = "注射器";
            guide_text.text = "医療目的で使われる、先端が尖った道具\n\n６分の１の確率で体力を３０回復させ、それ以外の時は５回復させる";
        }
        else if (button == CompareTag("Baseball_glove"))
        {
            itemname.text = "野球グローブ";
            guide_text.text = "野球で使われるグローブ。手によくフィットする\n\n物理攻撃力を２５増加させる。\n野球ボールを持ってたら、魔法攻撃力も２５増加させる";
        }
        else if (button == CompareTag("Boxing_glove"))
        {
            itemname.text = "ボクシンググローブ";
            guide_text.text = "ボクシングで使用されるグローブ,一発KO\n\nコウゲキを押したとき物理攻撃力を3増加させる";
        }
        else if (button == CompareTag("Juice"))
        {
            itemname.text = "ジュース";
            guide_text.text = "果汁などが入った飲料水。何味がはわからない\n\n戦闘開始時体力を20回復させる";
        }
        else if (button == CompareTag("Gas_burner"))
        {
            itemname.text = "ガスバーナー";
            guide_text.text = "ガスで熱を生み出す道具。酸素も闘志も燃やせ！！！\n\n戦闘開始時確率で敵を炎上させる";
        }
        else if (button == CompareTag("Hamberger"))
        {
            itemname.text = "ハンバーガー";
            guide_text.text = "ジャンクフードの王様。カロリーが高い。一日三食これ一個\n\nポテトを持っている時物理攻撃力を４０増加させる\n持っていないときは物理攻撃力を２０増加させる";
        }
        else if (button == CompareTag("Pencil"))
        {
            itemname.text = "鉛筆";
            guide_text.text = "文字を書け、色や硬さに種類がある。H ore HB ore B?\n\n物理攻撃力を５０増加させるが毎ターン物理攻撃力を５減少させる";
        }
        else if (button == CompareTag("Mayonnaise"))
        {
            itemname.text = "マヨネーズ";
            guide_text.text = "卵と油で作る調味料。一部の人はこれを飲もうとしたりするとか\n\n魔法攻撃力を５０増加させるが毎ターン魔法攻撃力を５減少させる";
        }
        else if (button == CompareTag("Watch"))
        {
            itemname.text = "腕時計";
            guide_text.text = "時間を気軽に確認できる、社会人には必須のアイテム。\n\n主人公の体力が減少するほど物理攻撃力を増加させる";
        }
        else if (button == CompareTag("Scythe"))
        {
            itemname.text = "死神の鎌";
            guide_text.text = "切れ味がいい鎌。魂まで刈ってしまう\n\n物理攻撃力を40増加させ、クリティカルがかなり発生しやすくなる";
        }
        else if (button == CompareTag("Robe"))
        {
            itemname.text = "死神のローブ";
            guide_text.text = "死神が着ていたローブ。ひんやりと冷たい\n\n物理防御力を40増加させ、クリティカルが発生しやすくなる";
        }
        else if (button == CompareTag("Eye"))
        {
            itemname.text = "メデューサの目";
            guide_text.text = "メデューサの目。取り扱いには注意が必要\n\n魔法攻撃力を40増加させ、クリティカルが出やすくなる";
        }
        else if (button == CompareTag("MagicBook"))
        {
            itemname.text = "メデューサの魔導書";
            guide_text.text = "メデューサが使っていた魔導書。書かれている文字は解読できない\n\n魔法防御力を40増加させ、クリティカルが出やすくなる\n（アイテム画面でアイテムを押すと魔法攻撃が変化）";
        }
        else if (button == CompareTag("Scale"))
        {
            itemname.text = "ドラゴンの鱗";
            guide_text.text = "ドラゴンの体表を覆っている鱗。ほんのりと暖かい\n\nターン毎に全ステータスを10増加させる";
        }
        else if (button == CompareTag("Tooth"))
        {
            itemname.text = "ドラゴンの牙";
            guide_text.text = "ドラゴンの鋭い牙。取り扱いには注意\n\n体力を半分に減らす代わりに物理攻撃力を100増加させる";
        }
    }

    //魔法攻撃を後から変更するための関数（アイテム画面でボタンを押したらその魔法攻撃になる）
    public void magic_number(int num_M)
    {
        PlayerController.magic_number = num_M;
    }
}