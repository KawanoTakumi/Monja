using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Power : MonoBehaviour
{
    PlayerController playercontroller;
    public Enemy_controller enemy_Controller;
    public Text log_text;
    int turn_compare = 0;//�^�[������r�p()

    bool adapt_bowlingball = true;//�{�E�����O�p�K���ϐ�(bowlingball)
    bool adapt_CDplayer = true;//CD�v���[���[�p�K���ϐ�(CDplayer)
    bool adapt_kesigomu = true;
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
    bool adapt_Drill = true;
    bool adapt_Utype_M = true;
    bool adapt_Coffee = true;
    bool adapt_SafetyCorn = true;
    bool adapt_USB = true;
    bool adapt_SmartPhone = true;
    bool adapt_Itype_M = true;
    bool adapt_Mike = true;
    bool adapt_Megaphone = true;
    bool adapt_HandMill = true;
    bool adapt_Pudding = true;
    int dice_random = 0;
    int safetycorn_random = 0;
    public static bool dice_crit = false;
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

        Item_Manager.Item.TryGetValue("Drill", out bool Drill_flag);
        Item_Manager.Item.TryGetValue("Headphone", out bool Headphone_flag);
        Item_Manager.Item.TryGetValue("UtypeMagnet", out bool UtypeMagnet_flag);
        Item_Manager.Item.TryGetValue("Coffee", out bool Coffee_flag);
        Item_Manager.Item.TryGetValue("Safetycone", out bool Safetycone_flag);
        Item_Manager.Item.TryGetValue("USB", out bool USB_flag);
        Item_Manager.Item.TryGetValue("Smartphone", out bool Smartphone_flag);
        Item_Manager.Item.TryGetValue("ItypeMagnet", out bool ItypeMagnet_flag);
        Item_Manager.Item.TryGetValue("Magnifying Speculum", out bool MagnifyingSpeculum_flag);
        Item_Manager.Item.TryGetValue("Mike", out bool Mike_flag);

        Item_Manager.Item.TryGetValue("Megaphonee", out bool Megaphone_flag);
        Item_Manager.Item.TryGetValue("HandMill", out bool HandMill_flag);

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
            if(adapt_kesigomu == true)
            {
                playercontroller.Attack += 25;
                playercontroller.Magic -= playercontroller.Attack / 2;
                adapt_kesigomu = false;
            }
        }
        if(TV_flag == true)
        {
            if(adapt_TV == true)
            {
                playercontroller.Magic += (playercontroller.Magic / 20) * 4;
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
            //��ԉ�
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
                dice_random = Random.Range(1, 7);
                switch (dice_random)
                {
                    case 1: playercontroller.Attack += 10;break;
                    case 2: playercontroller.Attack -= 5;break;
                    case 3: playercontroller.Magic += 10; break;
                    case 4: playercontroller.Magic -= 5; break;
                    case 5: PlayerController.Money += 50;break;
                    case 6: dice_crit = true; break;
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
            if (adapt_Popcorn == true && adapt_Popcorn == true)
            {
                PlayerController.HP += 40;
                adapt_Popcorn = false;
            }
        }
        if(Apple_flag == true)
        {
            if(adapt_Apple == true)
            {
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
            if(Apple_flag == true && adapt_Pudding == true)
            {
                PlayerController.HP_max += 30;
                adapt_Pudding = false;
            }
            else if(adapt_Pudding == true)
            {
                PlayerController.HP += PlayerController.HP_max / 4;
                adapt_Pudding = false;
            }
        }
        if(Drill_flag == true)
        {
            if(adapt_Drill == true)
            {
                playercontroller.Attack += enemy_Controller.deffence / 2;
                adapt_Drill = false;
            }
        }
        if(Headphone_flag)
        {
            if (turn_compare < Enemy_controller.turn)
            {
                playercontroller.Attack -= 3;
                playercontroller.Diffence -= 3;
                PlayerController.HP += 10;
                turn_compare = Enemy_controller.turn;
            }
        }
        if(UtypeMagnet_flag == true)
        {
            if (adapt_Utype_M == true)
            {
                playercontroller.Magic += 20;
                adapt_Utype_M = false;
            }
        }
        if(Coffee_flag == true)
        {
            if(adapt_Coffee == true)
            {
                PlayerController.HP -= 20;
                playercontroller.Magic += 30;
                adapt_Coffee = false;
            }
        }
        if(Safetycone_flag == true)
        {
            if(adapt_SafetyCorn == true)
            {
                safetycorn_random = Random.Range(1, 3);
                if(safetycorn_random == 1)
                {
                    adapt_SafetyCorn = false;
                }
                else if(safetycorn_random == 2)
                {
                    playercontroller.Attack += 40;
                    playercontroller.Diffence += 40;
                    adapt_SafetyCorn = false;
                }
            }
        }
        if(USB_flag == true)
        {
            if(adapt_USB == true)
            {
                playercontroller.Magic += 30;
                playercontroller.Magic_Diffence -= 20;
                adapt_USB = false;
            }
        }
        if(Smartphone_flag == true)
        {
            if(adapt_SmartPhone == true)
            {
                playercontroller.Magic_Diffence += playercontroller.Magic / 4;
            }
        }
        if(ItypeMagnet_flag == true)
        {
            if(adapt_Itype_M == true)
            {
                playercontroller.Magic_Diffence += 20;
                adapt_Itype_M = false;
            }
        }
        if(MagnifyingSpeculum_flag == true)
        {
            if(turn_compare < Enemy_controller.turn)
            {
                playercontroller.Diffence += 10;
                playercontroller.Magic_Diffence += 10;
                turn_compare = Enemy_controller.turn;
            }
        }
        if(Mike_flag == true)
        {
            if(adapt_Mike == true)
            {
                playercontroller.Magic += 30;
                adapt_Mike = false;
            }
        }
        if(Megaphone_flag == true)
        {
            if(adapt_Megaphone == true)
            {
                playercontroller.Diffence += 20;
                adapt_Megaphone = false;
            }
        }
        if(HandMill_flag == true)
        {
            if(adapt_HandMill == true && Coffee_flag == true)
            {
                playercontroller.Magic += 60;
                adapt_HandMill = false;
            }
            if(adapt_HandMill == true)
            {
                playercontroller.Magic -= 30;
                adapt_HandMill = false;
            }
        }
    }
}