using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Power : MonoBehaviour
{
    public PlayerController playercontroller;
    Item_Manager Item_Manager;

    bool adapt_bowlingball = true;//ボウリング用適応変数(bowlingball)
    int turn_comp = 0;//ターン数比較用()
    bool adapt_CDplayer = true;//CDプレーヤー用適応変数(CDplayer)



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        Item_Manager.Item.TryGetValue("bowlingball", out bool bowlingball_flag);
        Item_Manager.Item.TryGetValue("cd", out bool cd_flag);
        Item_Manager.Item.TryGetValue("CDplayer", out bool CDplayer_flag);
        Item_Manager.Item.TryGetValue("radio", out bool radio_flag);
        Item_Manager.Item.TryGetValue("hourglass", out bool hourglass_flag);

        if(bowlingball_flag == true)
        {
            if(adapt_bowlingball == true)
            {
                playercontroller.Attack += 20;//攻撃力20上昇
                playercontroller.Diffence -= 20;//防御力20上昇
                adapt_bowlingball = false;
            }
        }
        if(cd_flag == true)
        {
            if(turn_comp < Enemy_controller.turn)
            {
                playercontroller.Attack += playercontroller.Diffence / 2;//attackにdiffenceの1/2の数字を加算
                turn_comp = Enemy_controller.turn;//次のターンまで発動しないようにする
            }
        }
        if(CDplayer_flag == true)
        {
            if(adapt_CDplayer == true)
            {
                playercontroller.Attack -= 20;//攻撃力20減少
                playercontroller.Diffence += 20;//防御力20上昇
            }
        }
        if(radio_flag == true)
        {
            if(turn_comp < Enemy_controller.turn)
            {
                playercontroller.Attack += 20;//毎ターン攻撃力20上昇
                PlayerController.HP -= 5;//体力を5減らす
                turn_comp = Enemy_controller.turn;//次のターンまで発動しないようにする
            }
        }
    }
}