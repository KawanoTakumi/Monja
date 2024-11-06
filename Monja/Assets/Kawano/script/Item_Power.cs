using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Power : MonoBehaviour
{
    PlayerController playercontroller;
    public Text log_text;
    int turn_compare = 0;//ターン数比較用()

    bool adapt_bowlingball = true;//ボウリング用適応変数(bowlingball)
    bool adapt_CDplayer = true;//CDプレーヤー用適応変数(CDplayer)



    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playercontroller = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    public void Update()
    {
        Item_Manager.Item.TryGetValue("bowlingball", out bool bowlingball_flag);
        Item_Manager.Item.TryGetValue("cd", out bool cd_flag);
        Item_Manager.Item.TryGetValue("CDplayer", out bool CDplayer_flag);
        Item_Manager.Item.TryGetValue("radio", out bool radio_flag);
        Item_Manager.Item.TryGetValue("hourglass", out bool hourglass_flag);
        Item_Manager.Item.TryGetValue("healdrink", out bool healdrink_flag);

        if(bowlingball_flag == true)
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
                log_text.text = ("ラジオの効果で-5HP");
                turn_compare = Enemy_controller.turn;
            }
        }
        if(hourglass_flag == true)
        {
            if(turn_compare < Enemy_controller.turn)
            {
                playercontroller.Attack += 10;//毎ターン攻撃力10上昇
                PlayerController.HP -= 5;//体力を5減らす
                log_text.text = ("砂時計の効果で-5HP");
                turn_compare = Enemy_controller.turn;//次のターンまで発動しないようにする
            }
        }
        if(healdrink_flag == true)
        {
            playercontroller.HP_Potion += 1;
            Item_Manager.Item["healdrink"] = false;
            healdrink_flag = false;
        }
    }
}