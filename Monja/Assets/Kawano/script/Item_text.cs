using UnityEngine;
using UnityEngine.UI;

public class Item_text : MonoBehaviour
{
    public Button button;   //ボタン
    Text Item_name;         //アイテムの名前
    Text Item_guide_text;        //アイテムの説明文

    //スタートメソッド
    //説明・・・コンポーネント取得
    void Start()
    {
        //各種値を最初に取得
        GameObject Name = GameObject.Find("Item_Name");
        Item_name = Name.GetComponent<Text>();
        GameObject Text = GameObject.Find("Item_Text");
        Item_guide_text = Text.GetComponent<Text>();
        button = GetComponent<Button>();
        button.interactable = true;
    }

    //ボタンが押されたとき
    public void Hit_button()
    {
        if (button == CompareTag("bowlingball"))
        {
            Item_name.text = "ボウリングの玉";
            Item_guide_text.text = "ボウリングに使われていた玉。少し重い。\n\n物理攻撃力を２０上昇させ、物理防御力を２０減少させる";
        }
        else if (button == CompareTag("radio"))
        {
            Item_name.text = "ラジオ";
            Item_guide_text.text = "音響を無線通信で傍聴できる機械。どこかで体操が始まる。\n\n毎ターン開始時に防御力を１０増加させ、HPを５減少させる";
        }
        else if (button == CompareTag("healdrink"))
        {
            Item_name.text = "LIFE";
            Item_guide_text.text = "缶ジュース。甘くておいしい。\n\n[消費アイテム] 体力を５０回復する。（カイフクを押すと使用できる）";
        }
        else if (button == CompareTag("hourglass"))
        {
            Item_name.text = "砂時計";
            Item_guide_text.text = "砂を使った時計。時間は有限。\n\n毎ターン開始時に物理攻撃力を１０上昇させ、体力を５減少させる";
        }
        else if (button == CompareTag("cd"))
        {
            Item_name.text = "CD";
            Item_guide_text.text = "映像や音楽を書き込むことができる。投げたら痛そう。\n\n物理防御力が高いほど、物理攻撃力を上昇させる";
        }
        else if (button == CompareTag("CDplayer"))
        {
            Item_name.text = "CDプレーヤー";
            Item_guide_text.text = "CDをセットすることで音楽を聴ける。CDはどこ？\n\n物理防御力を２０上昇させ、物理攻撃力を２０減少させる";
        }
        else if (button == CompareTag("kesigomu"))
        {
            Item_name.text = "消しゴム";
            Item_guide_text.text = "書いたものを消せる。無駄なものも消そう。\n\n物理攻撃力を２０増加させ、物理攻撃力が高いほど魔法攻撃力を下げる";
        }
        else if (button == CompareTag("TV"))
        {
            Item_name.text = "テレビ";
            Item_guide_text.text = "映像を視聴できる機械。あなたのお好きな番組は何？\n\n魔法攻撃力５につき魔法攻撃力を３上昇させる";
        }
        else if (button == CompareTag("CreditCard"))
        {
            Item_name.text = "クレジットカード";
            Item_guide_text.text = "お金を入れておけるカード。色でその人の価値がわかる。\n\n戦闘開始後２０G所持金に追加する\n";
        }
        else if (button == CompareTag("Mouse"))
        {
            Item_name.text = "マウス";
            Item_guide_text.text = "パソコンを使うときに必須の機械。マウスなしは考えられない。\n\n魔法攻撃力を１０増加させる";
        }
        else if (button == CompareTag("HandMirror"))
        {
            Item_name.text = "ハンドミラー";
            Item_guide_text.text = "手軽に容姿を確認できるコンパクトな鏡。鏡よ鏡、美しいのは誰？\n\n物理防御力と魔法防御力を１５増加させる";
        }
        else if (button == CompareTag("bowlingpin"))
        {
            Item_name.text = "ボウリングピン";
            Item_guide_text.text = "ボウリングで得点を決めるためのもの。僕にはあてないで。\n\n戦闘開始時、物理攻撃力が高いほど獲得金額が増加";
        }
        else if (button == CompareTag("baseball_ball"))
        {
            Item_name.text = "野球ボール";
            Item_guide_text.text = "野球用のボール。ストラーイク、バッターアウト！\n\n物理攻撃力を１５増加し物理防御力を１０減少させる";
        }
        else if (button == CompareTag("dice"))
        {
            Item_name.text = "サイコロ";
            Item_guide_text.text = "ランダムで数字を決めるための道具。１d６? ２d６?\n\n毎ターン開始時にランダムな効果を発動";
        }
        else if (button == CompareTag("Water bucket"))
        {
            Item_name.text = "水入りのバケツ";
            Item_guide_text.text = "水が入ったバケツ。アイスバケツチャレンジ！！！\n\n魔法防御力を１０増加させる";
        }
        else if (button == CompareTag("Popcorn"))
        {
            Item_name.text = "ポップコーン";
            Item_guide_text.text = "トウモロコシを高温ではじけさせたお菓子。映画には必須のお供。\n\n戦闘開始時、体力を２０回復させる";
        }
        else if (button == CompareTag("Apple"))
        {
            Item_name.text = "リンゴ";
            Item_guide_text.text = "赤くて甘い木に実る果実。ひらめきの種。\n\n戦闘開始時、体力を３０回復し、魔法攻撃力を１５増加させる";
        }
        else if (button == CompareTag("Scissors"))
        {
            Item_name.text = "ハサミ";
            Item_guide_text.text = "紙や髪などを切るためのお道具。どんなカットがお好み？\n\n物理攻撃力を２０増加させるがターン毎に物理防御力を２減少させる";
        }
        else if (button == CompareTag("ice"))
        {
            Item_name.text = "氷";
            Item_guide_text.text = "水を凍らせるとできる物体。かき氷にしますか？\n魔法攻撃力を１０増加させ、氷の弾で攻撃する。\n（アイテム画面でアイテムを押すと魔法攻撃が変化）";
        }
        else if (button == CompareTag("Pudding"))
        {
            Item_name.text = "プリン";
            Item_guide_text.text = "卵を牛乳などと一緒に固めた甘いお菓子。至福の時間。\n戦闘開始時体力を最大値の２５％分回復する。\nまた、リンゴを持っていると戦闘ごとに最大体力が３０増加する";
        }
        else if (button == CompareTag("Drill"))
        {
            Item_name.text = "ドリル";
            Item_guide_text.text = "物に穴を開ける道具。穴の開けすぎには注意！！\n\n戦闘開始時、敵の防御力の半分を自身の物理攻撃力に加算する。";
        }
        else if (button == CompareTag("Headphone"))
        {
            Item_name.text = "ヘッドフォン";
            Item_guide_text.text = "頭につけることで音楽を聞くことができる道具。自分の世界に入ってしまう。\n毎ターン開始時に物理攻撃力と物理防御力を３減少させて体力を１０回復";
        }
        else if (button == CompareTag("UtypeMagnet"))
        {
            Item_name.text = "U字型マグネット";
            Item_guide_text.text = "U字型のマグネット。強力な磁力を帯びている。敵の武器も引っ付く\n\n魔法攻撃力２０増加する";
        }
        else if (button == CompareTag("Coffee"))
        {
            Item_name.text = "コーヒー";
            Item_guide_text.text = "豆を焙煎した飲料水。とても苦い。Chill Time !!!\n\n体力を２０減らし魔法攻撃力を３０増加させる";
        }
        else if (button == CompareTag("Safetycone"))
        {
            Item_name.text = "三角コーン";
            Item_guide_text.text = "危険な場所に設置してあるもの。たまに蹴られる不運な奴。\n\n戦闘開始時、２５％の確率で物理攻撃力と物理防御力を４０増加";
        }
        else if (button == CompareTag("USB"))
        {
            Item_name.text = "USBメモリ";
            Item_guide_text.text = "パソコンから情報を保存できる機械。なくしたら終わり。\n\n魔法攻撃力を２０増加させ魔法防御力を１０減少させる";
        }
        else if (button == CompareTag("Smartphone"))
        {
            Item_name.text = "スマートフォン";
            Item_guide_text.text = "値段が高い様々な機能のついた電話機器。りんごのマーク。\n\n魔法攻撃力が高いほど魔法防御力を増加させる";
        }
        else if (button == CompareTag("ItypeMagnet"))
        {
            Item_name.text = "I字型マグネット";
            Item_guide_text.text = "I字型のマグネット。U字型とたいして変わらない。\n\n魔法防御力を２０増加させる";
        }
        else if (button == CompareTag("Magnifying Speculum"))
        {
            Item_name.text = "虫眼鏡";
            Item_guide_text.text = "物を拡大して見ることができる道具。レンズが輝く。\n\n毎ターン開始時に物理防御力と魔法防御力を３増加させる";
        }
        else if (button == CompareTag("Mike"))
        {
            Item_name.text = "マイク";
            Item_guide_text.text = "音を拾うことができる機械。Say Yeah!!\n魔法攻撃力を３０増加させ音のノイズで攻撃する\n（アイテム画面でアイテムを押すと魔法攻撃が変化）";
        }
        else if (button == CompareTag("Megaphone"))
        {
            Item_name.text = "メガホン";
            Item_guide_text.text = "音を大きくする機械。もう大声を出さなくてもいい。\n\n物理防御力を２０増加させる";
        }
        else if (button == CompareTag("HandMill"))
        {
            Item_name.text = "ハンドミル";
            Item_guide_text.text = "豆を挽くための道具。香ばしい香りがしてるぜ。\nコーヒーを持っている時、魔法攻撃力を６０増加させる\n持っていない時は魔法攻撃力を３０減少させる";
        }
        else if(button == CompareTag("Poteto"))
        {
            Item_name.text = "ポテト";
            Item_guide_text.text = "ジャガイモを油で揚げた食べ物。食べるのをやめられない。\nハンバーガーを持っている時物理攻撃力を６０増加させる\n持っていない時は物理攻撃力を３０減少させる";
        }
        else if (button == CompareTag("Scop"))
        {
            Item_name.text = "ショベル";
            Item_guide_text.text = "土を掘ったり、均したりできる。\n\n戦闘開始時４分の１の確率でお金を３０入手する";
        }
        else if (button == CompareTag("hammer"))
        {
            Item_name.text = "ハンマー";
            Item_guide_text.text = "様々な用途がある万能な道具。\n\n毎ターン開始時に１０分の１の確率で相手を気絶させる";
        }
        else if (button == CompareTag("Speaker"))
        {
            Item_name.text = "スピーカー";
            Item_guide_text.text = "音を増幅させる装置。カルテット？\n\n敵の物理防御力を２５減少させる";
        }
        else if (button == CompareTag("Sylinge"))
        {
            Item_name.text = "注射器";
            Item_guide_text.text = "医療目的で使われる、先端が尖った道具。\n\n毎ターン開始時に６分の１の確率で体力を３０回復させ、それ以外の時は５回復させる";
        }
        else if (button == CompareTag("Baseball_glove"))
        {
            Item_name.text = "野球グローブ";
            Item_guide_text.text = "野球で使われるグローブ。手によくフィットする。\n物理攻撃力を２５増加させる。\n野球ボールを持ってたら、魔法攻撃力も３５増加させる";
        }
        else if (button == CompareTag("Boxing_glove"))
        {
            Item_name.text = "ボクシンググローブ";
            Item_guide_text.text = "ボクシングで使用されるグローブ,一発KO！！\n\nザンゲキを押したとき物理攻撃力を３増加させる";
        }
        else if (button == CompareTag("Juice"))
        {
            Item_name.text = "ジュース";
            Item_guide_text.text = "果汁などが入った飲料水。何味かはわからない。\n\n戦闘開始時体力を２０回復させる";
        }
        else if (button == CompareTag("Gas_burner"))
        {
            Item_name.text = "ガスバーナー";
            Item_guide_text.text = "ガスで熱を生み出す道具。酸素も闘志も燃やせ！！！\n\n偶数ターン開始時、物理攻撃力を２５増加させる";
        }
        else if (button == CompareTag("Hamberger"))
        {
            Item_name.text = "ハンバーガー";
            Item_guide_text.text = "ジャンクフードの王様。カロリーが高い。一日三食これ一個。\nポテトを持っている時物理攻撃力を４０増加させる\n持っていないときは物理攻撃力を２０増加させる";
        }
        else if (button == CompareTag("Pencil"))
        {
            Item_name.text = "鉛筆";
            Item_guide_text.text = "文字を書け、色や硬さに種類がある。H or HB or B?\n\n物理攻撃力を５０増加させるが毎ターン開始時に物理攻撃力を５減少させる";
        }
        else if (button == CompareTag("Mayonnaise"))
        {
            Item_name.text = "マヨネーズ";
            Item_guide_text.text = "卵と油で作る調味料。一部の人はこれを飲もうとしたりするとか。\n\n魔法攻撃力を５０増加させるが毎ターン開始時に魔法攻撃力を５減少させる";
        }
        else if (button == CompareTag("Watch"))
        {
            Item_name.text = "腕時計";
            Item_guide_text.text = "時間を気軽に確認できる、社会人には必須のアイテム。\n\n主人公の体力が減少するほど物理攻撃力を増加させる";
        }
        else if (button == CompareTag("Scythe"))
        {
            Item_name.text = "死神の鎌";
            Item_guide_text.text = "切れ味がいい鎌。魂まで刈ってしまう。\n\n物理攻撃力を４０増加させ、クリティカルがかなり発生しやすくなる";
        }
        else if (button == CompareTag("Robe"))
        {
            Item_name.text = "死神のローブ";
            Item_guide_text.text = "死神が着ていたローブ。ひんやりと冷たい。\n\n物理防御力を４０増加させ、クリティカルが発生しやすくなる";
        }
        else if (button == CompareTag("Eye"))
        {
            Item_name.text = "メデューサの目";
            Item_guide_text.text = "メデューサの目。取り扱いには注意が必要。\n\n魔法防御力を４０増加させ、クリティカルが出やすくなる";
        }
        else if (button == CompareTag("MagicBook"))
        {
            Item_name.text = "メデューサの魔導書";
            Item_guide_text.text = "メデューサが使っていた魔導書。書かれている文字は解読できない。\n魔法攻撃力を４０増加させ、クリティカルが出やすくなる\n（アイテム画面でアイテムを押すと魔法攻撃が変化）";
        }
        else if (button == CompareTag("Scale"))
        {
            Item_name.text = "ドラゴンの鱗";
            Item_guide_text.text = "ドラゴンの体表を覆っている鱗。ほんのりと暖かい。\n\n毎ターン開始時に全ステータスを１０増加させる";
        }
        else if (button == CompareTag("Tooth"))
        {
            Item_name.text = "ドラゴンの牙";
            Item_guide_text.text = "ドラゴンの鋭い牙。手のひら位のサイズ。\n\n体力を半分に減らす代わりに物理攻撃力を１００増加させる";
        }
    }

    //魔法攻撃を後から変更するための関数（アイテム画面でボタンを押したらその魔法攻撃になる）
    public void magic_number(int num_M)
    {
        PlayerController.MAGIC_TYPE = num_M;
    }
}