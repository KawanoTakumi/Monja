using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Power : MonoBehaviour
{
    PlayerController playercontroller;
    public Text log_text;
    int turn_compare = 0;//�^�[������r�p()
    static bool start_cnt = true;//��ɉ񕜌n�p

    bool adapt_bowlingball = true;//�{�E�����O�p�K���ϐ�(bowlingball)
    bool adapt_CDplayer = true;//CD�v���[���[�p�K���ϐ�(CDplayer)
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
        //�A�C�e���̃t���O�擾
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
        //   �A�C�e������
        //----------------------

        if (healdrink_flag == true)
        {
            PlayerController.HP_Potion += 1;
            Item_Manager.Item["healdrink"] = false;//�q�[���h�����N�͉��ł����Ă邽�߃t���O��false
            healdrink_flag = false;
        }

        if (bowlingball_flag == true)
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
                log_text.text = "���W�I�̌��ʂ�-5HP";
                turn_compare = Enemy_controller.turn;
            }
        }
        if(hourglass_flag == true)
        {
            if(turn_compare < Enemy_controller.turn)
            {
                playercontroller.Attack += 10;//���^�[���U����10�㏸
                PlayerController.HP -= 5;//�̗͂�5���炷
                log_text.text = "�����v�̌��ʂ�-5HP";
                turn_compare = Enemy_controller.turn;//���̃^�[���܂Ŕ������Ȃ��悤�ɂ���
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
    //���@�U�����ォ��ύX���邽�߂̊֐��i�A�C�e����ʂŃ{�^�����������炻�̖��@�U���ɂȂ�j
    public void magic_number(int num_M)
    {
        PlayerController.magic_number = num_M;
    }
}