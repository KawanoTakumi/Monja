using UnityEngine;
using UnityEngine.UI;

public class GUIDE_Text : MonoBehaviour
{
    public Text Guide_text;             //説明文
    public Text Guide_title;            //説明のタイトル
    public Image Guide_image_target;    //表示先画像
    public Sprite[] Guide_image_source; //表示元画像

    //スタート関数
    //説明・・・コンポーネントを取得
    public void Start()
    {
        Guide_image_target = GetComponent<Image>();
    }
    //ボタンが押された時、表示する画像とテキストを変更する(変更する番号)
    public void Text_Change_Guide(int change_num)
    {
        switch (change_num)
        {
            case 1:
                {
                    //戦闘画面
                    Guide_image_target.sprite = Guide_image_source[0];
                    Guide_title.text = "戦闘画面";
                    Guide_text.text = "基本操作はマウスの左クリックのみ\nザンゲキ、マホウ、シュウチュウ、カイフクの四つのボタンを選択して敵を倒していく\n\n" +
                                    "　　ザンゲキ・・・自分の攻撃力から相手の防御力の数値を引いたダメージを与える\n　　　マホウ・・・ＭＰを消費してマホウ攻撃力から相手のマホウ防御力を引いたダメージを与える\n" +
                                    "シュウチュウ・・・ＭＰを半分カイフクし、マホウ攻撃力を１ターン分強化する\n　　カイフク・・・回復アイテムを持っている場合自分の体力を回復する\n\n" +
                                    "画面の左下側の赤いゲージは体力、青いゲージはＭＰを表す\n" +
                                    "その下の４つの数値は左上が物理攻撃力、右上が物理防御力、左下が魔法攻撃力、右下が魔法防御力を表している\n" +
                                    "真ん中の缶は回復アイテムの所持数を表している";
                }
                break;
            case 2:
                {
                    //ショップ画面
                    Guide_image_target.sprite = Guide_image_source[1];
                    Guide_title.text = "ショップ画面";
                    Guide_text.text = "基本操作はマウスの左クリックのみ\n敵を倒して入手したお金でアイテムを買える\nショップに並ぶアイテムはランダムであり、購入するのに必要な金額は左に並ぶアイテム程安く買える\n\n" +
                        "購入済みのアイテムしかないときや、ほしいアイテムがないときは画面左にあるリロールボタンからアイテムを変更することができる\n" +
                        "また、とある条件を満たさないと出現しないアイテムも・・・\n";
                }
                break;
        }
    }
}