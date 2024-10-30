using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Power : MonoBehaviour
{
    public PlayerController playercontroller;
    Item_Manager Item_Manager;

    bool adapt_bowlingball = true;//�{�E�����O�p�K���ϐ�(bowlingball)
    int turn_comp = 0;//�^�[������r�p()
    bool adapt_CDplayer = true;//CD�v���[���[�p�K���ϐ�(CDplayer)



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
                playercontroller.Attack += 20;//�U����20�㏸
                playercontroller.Diffence -= 20;//�h���20�㏸
                adapt_bowlingball = false;
            }
        }
        if(cd_flag == true)
        {
            if(turn_comp < Enemy_controller.turn)
            {
                playercontroller.Attack += playercontroller.Diffence / 2;//attack��diffence��1/2�̐��������Z
                turn_comp = Enemy_controller.turn;//���̃^�[���܂Ŕ������Ȃ��悤�ɂ���
            }
        }
        if(CDplayer_flag == true)
        {
            if(adapt_CDplayer == true)
            {
                playercontroller.Attack -= 20;//�U����20����
                playercontroller.Diffence += 20;//�h���20�㏸
            }
        }
        if(radio_flag == true)
        {
            if(turn_comp < Enemy_controller.turn)
            {
                playercontroller.Attack += 20;//���^�[���U����20�㏸
                PlayerController.HP -= 5;//�̗͂�5���炷
                turn_comp = Enemy_controller.turn;//���̃^�[���܂Ŕ������Ȃ��悤�ɂ���
            }
        }
    }
}