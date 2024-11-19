using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Power : MonoBehaviour
{
    PlayerController playercontroller;
    public Text log_text;
    int turn_compare = 0;//ターン数比較用()
    static bool start_cnt = true;//主に回復系用

    bool adapt_bowlingball = true;//ボウリング用適応変数(bowlingball)
    bool adapt_CDplayer = true;//CDプレーヤー用適応変数(CDplayer)
    bool adapt_TV = true;
    bool adapt_CreditCard = true;
    bool adapt_Mouse = true;
    bool adapt_HandMirror = true;
    bool adapt_bowlingpin = true;
    bool adapt_baseball_ball = true;
    bool adapt_Waterbucket = true;
    bool adapt_Popcorn = true;
    bool adapt_Apple = true;
    bool adapt_Scissors = true;
    bool adapt_ice = true;

    int dice_random = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playercontroller = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    public void Update()
    {
        //アイテムのフラグ取得
        Item_Manager.Item.TryGetValue("healdrink", out bool healdrink_flag);
        Item_Manager.Item.TryGetValue("bowlingball", out bool bowlingball_flag);
        Item_Manager.Item.TryGetValue("cd", out bool cd_flag);
        Item_Manager.Item.TryGetValue("CDplayer", out bool CDplayer_flag);
        Item_Manager.Item.TryGetValue("radio", out bool radio_flag);
        Item_Manager.Item.TryGetValue("hourglass", out bool hourglass_flag);
        Item_Manager.Item.TryGetValue("kesigomu", out bool kesigomu_flag);
        Item_Manager.Item.TryGetValue("TV", out bool TV_flag);
        Item_Manager.Item.TryGetValue("CreditCard", out bool CreditCard_flag);
        Item_Manager.Item.TryGetValue("Mouse", out bool Mouse_flag);

        Item_Manager.Item.TryGetValue("HandMirror", out bool HandMirror_flag);
        Item_Manager.Item.TryGetValue("bowlingpin", out bool bowlingpin_flag);
        Item_Manager.Item.TryGetValue("baseball_ball", out bool baseball_ball_flag);
        Item_Manager.Item.TryGetValue("dice", out bool dice_flag);
        Item_Manager.Item.TryGetValue("Water bucket", out bool Waterbucket_flag);
        Item_Manager.Item.TryGetValue("Popcorn", out bool Popcorn_flag);
        Item_Manager.Item.TryGetValue("Apple", out bool Apple_flag);
        Item_Manager.Item.TryGetValue("Scissors", out bool Scissors_flag);
        Item_Manager.Item.TryGetValue("ice", out bool ice_flag);
        Item_Manager.Item.TryGetValue("Pudding", out bool Pudding_flag);


        if (Enemy_controller.turn != 1)
        {
            start_cnt = false;
        }
        else
        {
            start_cnt = true;
        }

        //----------------------
        //   アイテム効果
        //----------------------

        if (healdrink_flag == true)
        {
            PlayerController.HP_Potion += 1;
            Item_Manager.Item["healdrink"] = false;//ヒールドリンクは何個でも持てるためフラグをfalse
            healdrink_flag = false;
        }

        if (bowlingball_flag == true)
        {
            if(adapt_bowlingball == true)
            {
                playercontroller.Attack += 20;//攻撃力20上昇
                playercontroller.Diffence -= 20;//防御力20減少
                adapt_bowlingball = false;//falseにして一回しか読み込まれ内容にする
            }
        }
        if(cd_flag == true)
        {
            if(turn_compare < Enemy_controller.turn)
            {
                playercontroller.Attack += playercontroller.Diffence / 2;//attackにdiffenceの1/2の数字を加算
                turn_compare = Enemy_controller.turn;//次のターンまで発動しないようにする
            }
        }
        if(CDplayer_flag == true)
        {
            if(adapt_CDplayer == true)
            {
                playercontroller.Attack -= 20;//攻撃力20減少
                playercontroller.Diffence += 20;//防御力20上昇
                adapt_CDplayer = false;
            }
        }
        if(radio_flag == true)
        {
            if(turn_compare < Enemy_controller.turn)
            {
                playercontroller.Diffence += 10;//毎ターン防御力10上昇
                PlayerController.HP -= 5;//体力を5減らす
                log_text.text = "ラジオの効果で-5HP";
                turn_compare = Enemy_controller.turn;
            }
        }
        if(hourglass_flag == true)
        {
            if(turn_compare < Enemy_controller.turn)
            {
                playercontroller.Attack += 10;//毎ターン攻撃力10上昇
                PlayerController.HP -= 5;//体力を5減らす
                log_text.text = "砂時計の効果で-5HP";
                turn_compare = Enemy_controller.turn;//次のターンまで発動しないようにする
            }
        }
        if(kesigomu_flag == true)
        {
            if(turn_compare < Enemy_controller.turn)
            {
                playercontroller.Magic -= playercontroller.Attack / 2;
                turn_compare = Enemy_controller.turn;
            }
        }
        if(TV_flag == true)
        {
            if(adapt_TV == true)
            {
                playercontroller.Magic += (playercontroller.Magic / 20) * 2;
                adapt_TV = false;
            }
        }
        if(CreditCard_flag == true)
        {
            if(adapt_CreditCard == true)
            {
                PlayerController.Money += 40;
                adapt_CreditCard = false;
            }
        }
        if(Mouse_flag == true)
        {
            if(adapt_Mouse == true)
            {
                playercontroller.Magic += 20;
                adapt_Mouse = false;
            }
        }
        if(HandMirror_flag == true)
        {
            if(adapt_HandMirror == true)
            {
                playercontroller.Diffence += 30;
                playercontroller.Magic_Diffence += 30;
                adapt_HandMirror = false;
            }
        }
        if(bowlingpin_flag == true)
        {
            if(adapt_bowlingpin == true)
            {
                PlayerController.Money += playercontroller.Attack / 6;
                adapt_bowlingpin = false;
            }
        }
        if(baseball_ball_flag == true)
        {
            if(adapt_baseball_ball == true)
            {
                playercontroller.Attack += 30;
                playercontroller.Diffence -= 30;
                adapt_baseball_ball = false;
            }
        }
        if(dice_flag == true)
        {
            if(turn_compare < Enemy_controller.turn)
            {
                dice_random = Random.Range(1, 5);
                switch (dice_random)
                {
                    case 1: playercontroller.Attack += 5;return;
                    case 2: playercontroller.Diffence += 5;return;
                    case 3: playercontroller.Magic += 5;return;
                    case 4: playercontroller.Magic_Diffence += 5;return;
                }
                turn_compare = Enemy_controller.turn;
            }
        }
        if(Waterbucket_flag == true)
        {
            if(adapt_Waterbucket == true)
            {
                playercontroller.Magic_Diffence += 20;
                adapt_Waterbucket = false;
            }
        }
        if(Popcorn_flag == true)
        {
            if (adapt_Popcorn == true && start_cnt == true)
            {
                PlayerController.HP += 40;
                adapt_Popcorn = false;
            }
        }
        if(Apple_flag == true)
        {
            if(adapt_Apple == true)
            {
                if(start_cnt == true)
                PlayerController.HP += 30;

                playercontroller.Magic += 15;
                adapt_Apple = false;
            }
        }
        if(Scissors_flag == true)
        {
            if(adapt_Scissors == true)
            {
                playercontroller.Attack += 20;
                adapt_Scissors = false;
            }
        }
        if (ice_flag == true)
        {
            if(adapt_ice == true)
            {
                playercontroller.Magic += 20;
                adapt_ice = false;
            }
        }
        if(Pudding_flag == true)
        {
            if(Apple_flag == true && start_cnt == true)
            {
                PlayerController.HP_max += 30;
            }
            if(start_cnt == true)
            {
                PlayerController.HP = PlayerController.HP_max;
            }
        }
    }
    //魔法攻撃を後から変更するための関数（アイテム画面でボタンを押したらその魔法攻撃になる）
    public void magic_number(int num_M)
    {
        PlayerController.magic_number = num_M;
    }
}