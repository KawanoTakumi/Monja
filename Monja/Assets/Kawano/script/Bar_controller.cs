using UnityEngine;
using UnityEngine.UI;

public class Bar_controller : MonoBehaviour
{
    public Slider HP_bar;//主人公HP
    public Slider MP_bar;//主人公MP
    public Slider Enemy_HP_bar;//敵HP

    //スタートメソッド
    //説明・・・各種数値を取得
    void Start()
    {
        //各数値をスライダーの Varueに入れる
        HP_bar.value          = PlayerController.HP_MAX;
        HP_bar.maxValue       = PlayerController.HP_MAX;
        MP_bar.value          = PlayerController.MP_MAX;
        MP_bar.maxValue       = PlayerController.MP_MAX;
        Enemy_HP_bar.maxValue = Enemy_controller.HP_MAX;
    }
    //アップデートメソッド
    //説明・・・数値を更新する
    void Update()
    {
        HP_bar.value            = PlayerController.HP;
        MP_bar.value            = PlayerController.MP;
        Enemy_HP_bar.value      = Enemy_controller.HP;
        Enemy_HP_bar.maxValue   = Enemy_controller.HP_MAX;
    }
}