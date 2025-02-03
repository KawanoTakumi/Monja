using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status_boad : MonoBehaviour
{
    public GameObject Status_boad_obj;//ステータスボードオブジェクト
    public Text Back_Text;//戻る
    public Text Change_Text;
    GameObject Enemy;                   //エネミーオブジェクト
    Enemy_controller Enemy_controller; //エネミーコントローラー
    GameObject Player;                 //プレイヤーオブジェクト
    PlayerController PlayerController;//プレイヤーーコントローラー

    //敵のステータス
    public Text Enemy_Name;             //敵の名前
    public Text Enmey_max_hp;           //敵最大体力
    public Text Enemy_attack;           //敵の物理攻撃力
    public Text Enmey_deffence;         //敵の物理防御力
    public Text Enmey_magic;            //敵の魔法攻撃力
    public Text Enmey_magic_deffence;   //敵の魔法防御力

    bool Hit = false;//ボタンが押されたかどうか
    bool Change = false;//色を変えるかどうか

    //値の色変更
    Color Normal = new(255, 255, 255);//白（標準）
    Color Down = new(0.4f, 0.4f, 1, 1);//青色
    Color Up = new(1, 0, 0, 1);        //赤色

    //スタートメソッド
    // コンポーネントを取得、敵の名前を表示
    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerController = Player.GetComponent<PlayerController>();
        Enemy = GameObject.Find("Monster");
        Enemy_controller = Enemy.GetComponent<Enemy_controller>();
        if      (Enemy.CompareTag("skelton")) Enemy_Name.text = "スケルトン";
        else if (Enemy.CompareTag("Lich")) Enemy_Name.text = "リッチ";
        else if (Enemy.CompareTag("TheGrimReaper")) Enemy_Name.text = "死神";
        else if (Enemy.CompareTag("minotaurus")) Enemy_Name.text = "ミノタウロス";
        else if (Enemy.CompareTag("centaurus")) Enemy_Name.text = "ケンタウロス";
        else if (Enemy.CompareTag("medhusa")) Enemy_Name.text = "メデューサ";
        else if (Enemy.CompareTag("cockatrice")) Enemy_Name.text = "コカトリス";
        else if (Enemy.CompareTag("knight")) Enemy_Name.text = "ナイト";
        else if (Enemy.CompareTag("dragon")) Enemy_Name.text = "ドラゴン";
    }

    private void Update()
    {
        //敵ステータス
        Enemy_attack.text = string.Format("{0}", Enemy_controller.attack);                 //敵の物理攻撃力
        Enmey_deffence.text = string.Format("{0}", Enemy_controller.Enemy_deffence);             //敵の物理防御力
        Enmey_magic.text = string.Format("{0}", Enemy_controller.magic);                   //敵の魔法攻撃力
        Enmey_magic_deffence.text = string.Format("{0}", Enemy_controller.magic_Diffence); //敵の魔法防御力
        Enmey_max_hp.text = string.Format("{0}", Enemy_controller.HP_MAX);                 //敵の最大体力
    }

    /// <summary>
    /// ボタンが押された場合表示するか決める関数です
    /// </summary>
    public void Get_Button_Frag()
    {
        if (Hit == false)
        {
            Status_boad_obj.SetActive(true);
            Back_Text.text = "敵ステータスを閉じる";
            Hit = true;
        } 
        else
        {
            Status_boad_obj.SetActive(false);
            Back_Text.text = "敵ステータスを開く";
            Hit = false;
        }
    }
    /// <summary>
    /// ボタンが押されたとき数値に応じて色を変更するメソッド
    /// </summary>
    public void Color_Change()
    {
        if (Change == false)
        {

            Change_Text.text = "色を無効にする";
            //ステータス比較
            //物理攻撃力
            if (PlayerController.Attack_damage < Enemy_controller.attack)
                Enemy_attack.color = Up;
            else if (PlayerController.Attack_damage > Enemy_controller.attack)
                Enemy_attack.color = Down;
            //物理防御力
            if (PlayerController.Deffence < Enemy_controller.Enemy_deffence)
                Enmey_deffence.color = Up;
            else if (PlayerController.Deffence > Enemy_controller.Enemy_deffence)
                Enmey_deffence.color = Down;
            //魔法攻撃力
            if (PlayerController.Magic_damage < Enemy_controller.magic)
                Enmey_magic.color = Up;
            else if (PlayerController.Magic_damage > Enemy_controller.magic)
                Enmey_magic.color = Down;
            //魔法防御力
            if (PlayerController.Magic_diffence < Enemy_controller.magic_Diffence)
                Enmey_magic_deffence.color = Up;
            else if (PlayerController.Magic_diffence > Enemy_controller.magic_Diffence)
                Enmey_magic_deffence.color = Down;
            Change = true;
        }
        else
        {
            //色を標準に戻す
            Change_Text.text = "色を有効にする";
            Enemy_attack.color = Normal;
            Enmey_deffence.color = Normal;
            Enmey_magic.color = Normal;
            Enmey_magic_deffence.color = Normal;
            Change = false;
        }
    }
}