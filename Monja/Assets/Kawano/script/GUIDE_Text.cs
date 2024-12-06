using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIDE_Text : MonoBehaviour
{
    public Text Text_Box;//説明文
    public Text Title_box;//タイトル
    public Image Image;//表示画像
    public Sprite Image1;
    public Sprite Image2;

    public void Start()
    {
        Image = GetComponent<Image>();
    }
    public void Text_Change_Guide(int change_num)
    {
        switch (change_num)
        {
            case 1:
                {
                    Image.sprite = Image1;
                    Title_box.text = "戦闘画面";
                    Text_Box.text = "基本操作はマウスの左クリックのみ\nコウゲキ、マホウ、シュウチュウ、カイフクの四つのボタンを選択して敵を倒していく\n\n" +
                                    "コウゲキ・・・自分の攻撃力から相手の防御力の数値を引いたダメージを与える\nマホウ・・・ＭＰを消費してマホウ攻撃力から相手のマホウ防御力を引いたダメージを与える\n" +
                                    "シュウチュウ・・・ＭＰを半分カイフクし、マホウ攻撃力を１ターン分強化する\nカイフク・・・回復アイテムを持っている場合自分の体力を回復する\n\n" +
                                    "画面の左下側の赤いゲージは体力、青いゲージはＭＰを表す\n" +
                                    "その下の４つの数値は左上が物理攻撃力、右上が物理防御力、左下が魔法攻撃力、右下が魔法防御力を表している\n" +
                                    "真ん中の缶は回復アイテムの所持数を表している";
                }
                break;
            case 2:
                {
                    Image.sprite = Image2;
                    Title_box.text = "SHOP画面";
                    Text_Box.text = "基本操作はマウスの左クリックのみ\n敵を倒して入手したお金でアイテムを買える\nショップに並ぶアイテムはランダムであり、購入するのに必要な金額は左に並ぶアイテム程安く買える\n\n" +
                        "購入済みのアイテムしかないときや、ほしいアイテムがないときは画面左にあるリロールボタンからアイテムを変更することができる\n" +
                        "また、とある条件を満たさないと出現しないアイテムも・・・\n";
                }
                break;
        }
    }
}