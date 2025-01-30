using UnityEngine;
using UnityEngine.UI;

public class num_cnt : MonoBehaviour
{
    //コンポーネント
    public PlayerController Player;     //プレイヤーコントローラー
    GameObject Enemy;                   //エネミーオブジェクト
    Enemy_controller Enemy_controller; //エネミーコントローラー

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

    //敵のステータス
    public Text Enmey_max_hp;           //敵最大体力
    public Text Enemy_attack;           //敵の物理攻撃力
    public Text Enmey_deffence;         //敵の物理防御力
    public Text Enmey_magic;            //敵の魔法攻撃力
    public Text Enmey_magic_deffence;   //敵の魔法防御力

    //スタートメソッド
    //敵のステータスを取得
    private void Start()
    {
        Enemy = GameObject.Find("Monster");
        Enemy_controller = Enemy.GetComponent<Enemy_controller>();
    }

    //アップデートメソッド
    //説明・・・数値を文字列に変換して表示する
    void Update()
    {
        //intをstringに変換
        //プレイヤーステータス
        HP_text.text             = string.Format("{0}", PlayerController.HP);
        MP_text.text             = string.Format("{0}", PlayerController.MP);
        Heal_drink_num.text      = string.Format("{0}", PlayerController.HP_POTION);
        Player_money.text        = string.Format("{0}", PlayerController.MONEY);
        Attack_text.text         = string.Format("{0}", Player.Attack_damage);
        Diffence_text.text       = string.Format("{0}", Player.Deffence);
        Magic_text.text          = string.Format("{0}", Player.Magic_damage);
        Magic_diffence_text.text = string.Format("{0}", Player.Magic_diffence);
        Turn_text.text           = string.Format("{0}", Enemy_controller.turn);

        //敵ステータス
        Enemy_attack.text = string.Format("{0}", Enemy_controller.attack);//敵の物理攻撃力
        Enmey_deffence.text = string.Format("{0}", Enemy_controller.deffence);//敵の物理攻撃力
        Enmey_magic.text = string.Format("{0}", Enemy_controller.magic);//敵の物理攻撃力
        Enmey_magic_deffence.text = string.Format("{0}", Enemy_controller.magic_Diffence);//敵の魔法防御力
        Enmey_max_hp.text = string.Format("{0}", Enemy_controller.HP_MAX);//敵の最大体力

    }
}