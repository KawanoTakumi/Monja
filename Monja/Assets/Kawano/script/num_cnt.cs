using UnityEngine;
using UnityEngine.UI;

public class num_cnt : MonoBehaviour
{
    //コンポーネント
    public PlayerController Player;     //プレイヤーコントローラー

    //テキスト
    public Text Attack_text;            //攻撃力
    public Text Diffence_text;          //防御力
    public Text Magic_text;             //魔法力
    public Text Magic_diffence_text;    //魔法防御力
    public Text Turn_text;              //ターン数
    public Text Player_money;           //所持金額
    public Text Heal_drink_num;         //ヒールドリンクの所持数
    public Text HP_text;                //プレイヤー体力
    public Text MP_text;                //プレイヤーMP

    //アップデートメソッド
    //説明・・・数値を文字列に変換して表示する
    void Update()
    {
        //intをstringに変換
        //プレイヤーステータス
        HP_text.text             = string.Format("{0}", PlayerController.HP);
        MP_text.text             = string.Format("{0}", PlayerController.MP);
        Heal_drink_num.text      = string.Format("{0}", PlayerController.HP_potion);
        Player_money.text        = string.Format("{0}", PlayerController.Mmoney);
        Attack_text.text         = string.Format("{0}", Player.Attack_damage);
        Diffence_text.text       = string.Format("{0}", Player.Deffence);
        Magic_text.text          = string.Format("{0}", Player.Magic_damage);
        Magic_diffence_text.text = string.Format("{0}", Player.Magic_diffence);
        Turn_text.text           = string.Format("{0}", Enemy_controller.turn);

    }
}