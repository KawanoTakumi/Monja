using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Power : MonoBehaviour
{
    PlayerController playercontroller;
    public Text log_text;
    int turn_compare = 0;//�^�[������r�p()

    bool adapt_bowlingball = true;//�{�E�����O�p�K���ϐ�(bowlingball)
    bool adapt_CDplayer = true;//CD�v���[���[�p�K���ϐ�(CDplayer)



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
                playercontroller.Attack += 20;//�U����20�㏸
                playercontroller.Diffence -= 20;//�h���20����
                adapt_bowlingball = false;//false�ɂ��Ĉ�񂵂��ǂݍ��܂���e�ɂ���
            }
        }
        if(cd_flag == true)
        {
            if(turn_compare < Enemy_controller.turn)
            {
                playercontroller.Attack += playercontroller.Diffence / 2;//attack��diffence��1/2�̐��������Z
                turn_compare = Enemy_controller.turn;//���̃^�[���܂Ŕ������Ȃ��悤�ɂ���
            }
        }
        if(CDplayer_flag == true)
        {
            if(adapt_CDplayer == true)
            {
                playercontroller.Attack -= 20;//�U����20����
                playercontroller.Diffence += 20;//�h���20�㏸
                adapt_CDplayer = false;
            }
        }
        if(radio_flag == true)
        {
            if(turn_compare < Enemy_controller.turn)
            {
                playercontroller.Diffence += 10;//���^�[���h���10�㏸
                PlayerController.HP -= 5;//�̗͂�5���炷
                log_text.text = ("���W�I�̌��ʂ�-5HP");
                turn_compare = Enemy_controller.turn;
            }
        }
        if(hourglass_flag == true)
        {
            if(turn_compare < Enemy_controller.turn)
            {
                playercontroller.Attack += 10;//���^�[���U����10�㏸
                PlayerController.HP -= 5;//�̗͂�5���炷
                log_text.text = ("�����v�̌��ʂ�-5HP");
                turn_compare = Enemy_controller.turn;//���̃^�[���܂Ŕ������Ȃ��悤�ɂ���
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