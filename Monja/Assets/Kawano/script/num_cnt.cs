using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class num_cnt : MonoBehaviour
{
    public PlayerController player;//プレイヤーコントローラー
    public Enemy_controller enemy;//エネミーコントローラー
    public Text attack_Text;//攻撃力
    public Text diffence_Text;//防御力
    public Text magic_Text;//魔法力
    public Text magic_diffence_Text;//魔法防御力
    public Text turn_Text;//ターン数
    public Text player_money;//所持金額
    public Text Heal_drink_num;//ヒールドリンクの所持数
    public Text HP_Text;//プレイヤー体力
    public Text MP_Text;//プレイヤーMP
    void Update()
    {
        //intをstringに変換
        attack_Text.text = string.Format("{0}",player.Attack);
        diffence_Text.text = string.Format("{0}",player.Diffence);
        magic_Text.text = string.Format("{0}",player.Magic);
        magic_diffence_Text.text = string.Format("{0}",player.Magic_diffence);
        turn_Text.text = string.Format("{0}", Enemy_controller.turn);
        player_money.text = string.Format("{0}", PlayerController.MONEY);
        Heal_drink_num.text = string.Format("{0}", PlayerController.HP_POTION);
        HP_Text.text = string.Format("{0}",PlayerController.HP);
        MP_Text.text = string.Format("{0}",PlayerController.MP);
    }
}