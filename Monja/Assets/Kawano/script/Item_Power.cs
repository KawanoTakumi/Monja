using UnityEngine;
using UnityEngine.UI;

public class Item_Power : MonoBehaviour
{
    PlayerController playercontroller;//��l��
    Status_Controller status_; //�X�e�[�^�X�R���g���[��
    public Enemy_controller enemy_Controller;//�G
    public Text log_text;//���O
    public static int turn_compare = 0;//�^�[������r�p()
    public static bool first_turn = true;//�ŏ��̃^�[��

    //�^�[���̍ŏ��̂ݓǂݍ��ނ��߂̃t���O�i�e�A�C�e�����ɂP�ݒ�j
    bool adapt_bowlingball = true;
    bool adapt_cd = true;
    bool adapt_CDplayer = true;
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
    bool adapt_Poteto = true;
    bool adapt_Scop = true;
    bool adapt_Speaker = true;
    bool adapt_Baseball_glove = true;
    bool adapt_Boxing_glove = true;
    bool adapt_Juice = true;
    bool adapt_Hamberger = true;
    bool adapt_Pencil = true;
    bool adapt_Mayonnaise = true;
    static bool adapt_Pudding = true;
    bool adapt_TheGrimReaper_scythe = true;
    bool adapt_TheGrimReaper_robe = true;
    bool adapt_Medhusa_Eye = true;
    bool adapt_Medhusa_MagicBook = true;
    bool adapt_Dragon_Tooth = true;
    
    int dice_random = 0;
    int safetycorn_random = 0;
    int scop_random = 0;
    int hammer_random = 0;
    int sylinge_random = 0;
    public static int MagicBook_cnt = 0;
    public static int MedhusaEye_cnt = 0; 
    public static int Pencil_Down_cnt = 0;

    public static bool Boxing_flag = false;
    public static bool Sinigami_Crit_Effect = false;
    public static bool Medhusa_Magic_flag = false;
    public static bool dice_crit = false;
    public static bool Watch_Add_reset = true;
    public static bool turn_bool = true;

    //�X�^�[�g���\�b�h
    //�����E�E�E�e�R���|�[�l���g���擾
    void Start()
    {
        //�v���C���[��ǂݍ��݁A�v���C���[�R���g���[���[���擾����
        GameObject player = GameObject.Find("Player");
        playercontroller = player.GetComponent<PlayerController>();
        
        //�X�e�[�^�X�G�t�F�N�g��ǂݍ��݁A�R���|�[�l���g�擾
        GameObject Status_effect = GameObject.Find("Effect_manager");
        status_ = Status_effect.GetComponent<Status_Controller>();
    }

    //�A�b�v�f�[�g���\�b�h
    //�����E�E�E�A�C�e���̃t���O���擾���A�A�C�e���̌��ʂ��Ǘ�����
    public void Update()
    {
        //�A�C�e���̃t���O�擾
        Item_Manager.Item.TryGetValue("healdrink",            out bool healdrink_flag);
        Item_Manager.Item.TryGetValue("bowlingball",          out bool bowlingball_flag);
        Item_Manager.Item.TryGetValue("cd",                   out bool cd_flag);
        Item_Manager.Item.TryGetValue("CDplayer",             out bool CDplayer_flag);
        Item_Manager.Item.TryGetValue("radio",                out bool radio_flag);
        Item_Manager.Item.TryGetValue("hourglass",            out bool hourglass_flag);
        Item_Manager.Item.TryGetValue("kesigomu",             out bool kesigomu_flag);
        Item_Manager.Item.TryGetValue("TV",                   out bool TV_flag);
        Item_Manager.Item.TryGetValue("CreditCard",           out bool CreditCard_flag);
        Item_Manager.Item.TryGetValue("Mouse",                out bool Mouse_flag);

        Item_Manager.Item.TryGetValue("HandMirror",           out bool HandMirror_flag);
        Item_Manager.Item.TryGetValue("bowlingpin",           out bool bowlingpin_flag);
        Item_Manager.Item.TryGetValue("baseball_ball",        out bool baseball_ball_flag);
        Item_Manager.Item.TryGetValue("dice",                 out bool dice_flag);
        Item_Manager.Item.TryGetValue("Water bucket",         out bool Waterbucket_flag);
        Item_Manager.Item.TryGetValue("Popcorn",              out bool Popcorn_flag);
        Item_Manager.Item.TryGetValue("Apple",                out bool Apple_flag);
        Item_Manager.Item.TryGetValue("Scissors",             out bool Scissors_flag);
        Item_Manager.Item.TryGetValue("ice",                  out bool ice_flag);
        Item_Manager.Item.TryGetValue("Pudding",              out bool Pudding_flag);

        Item_Manager.Item.TryGetValue("Drill",                out bool Drill_flag);
        Item_Manager.Item.TryGetValue("Headphone",            out bool Headphone_flag);
        Item_Manager.Item.TryGetValue("UtypeMagnet",          out bool UtypeMagnet_flag);
        Item_Manager.Item.TryGetValue("Coffee",               out bool Coffee_flag);
        Item_Manager.Item.TryGetValue("Safetycone",           out bool Safetycone_flag);
        Item_Manager.Item.TryGetValue("USB",                  out bool USB_flag);
        Item_Manager.Item.TryGetValue("Smartphone",           out bool Smartphone_flag);
        Item_Manager.Item.TryGetValue("ItypeMagnet",          out bool ItypeMagnet_flag);
        Item_Manager.Item.TryGetValue("Magnifying Speculum",  out bool MagnifyingSpeculum_flag);
        Item_Manager.Item.TryGetValue("Mike",                 out bool Mike_flag);

        Item_Manager.Item.TryGetValue("Megaphone",            out bool Megaphone_flag);
        Item_Manager.Item.TryGetValue("HandMill",             out bool HandMill_flag);
        Item_Manager.Item.TryGetValue("Poteto",               out bool Poteto_flag);
        Item_Manager.Item.TryGetValue("Scop",                 out bool Scop_flag);
        Item_Manager.Item.TryGetValue("hammer",               out bool hammer_flag);
        Item_Manager.Item.TryGetValue("Speaker",              out bool Speaker_flag);
        Item_Manager.Item.TryGetValue("Sylinge",              out bool Sylinge_flag);
        Item_Manager.Item.TryGetValue("Baseball_glove",       out bool Baseball_glove_flag);
        Item_Manager.Item.TryGetValue("Boxing_glove",         out bool Boxing_glove_flag);
        Item_Manager.Item.TryGetValue("Juice",                out bool Juice_flag);
        Item_Manager.Item.TryGetValue("Gas_burner",           out bool Gas_burner_flag);
        Item_Manager.Item.TryGetValue("Hamberger",            out bool Hamberger_flag);
        Item_Manager.Item.TryGetValue("Pencil",               out bool Pencil_flag);
        Item_Manager.Item.TryGetValue("Mayonnaise",           out bool Mayonnaise_flag);
        Item_Manager.Item.TryGetValue("Watch",                out bool Watch_flag);

        Item_Manager.Item.TryGetValue("Scythe",               out bool TheGrimReaper_Scythe_flag);
        Item_Manager.Item.TryGetValue("Robe",                 out bool Sinigami_Robe_flag);
        Item_Manager.Item.TryGetValue("Eye",                  out bool Medhusa_Eye_flag);
        Item_Manager.Item.TryGetValue("MagicBook",            out bool Medhusa_MagicBook_flag);
        Item_Manager.Item.TryGetValue("Scale",                out bool Dragon_Scale_flag);
        Item_Manager.Item.TryGetValue("Tooth",                out bool Dragon_Tooth_flag);


        //�A�C�e�����O�̃e���v���[�g

        //Log_list.LogList.Add("�@�̌��ʂŁ@\n");

        //-----------------------------
        //�A�C�e�����ʁi�^�[�����ɔ����j
        //-----------------------------
        if (turn_compare < Enemy_controller.turn)
        {
            Log_list.LogList.Add("\n<color=#f3f300>�@------�A�C�e���̌���------</color>\n\n");//���O���X�g�ɒǉ�

            //-------------------------------
            //   �A�C�e������(����^�[���̂�)
            //-------------------------------

            if (healdrink_flag == true)
            {
                PlayerController.HP_POTION += 1;
                Item_Manager.Item["healdrink"] = false;//�q�[���h�����N�͉��ł����Ă邽�߃t���O��false
                healdrink_flag = false;
            }

            if (bowlingball_flag == true)
            {
                if (adapt_bowlingball == true && first_turn == true)
                {
                    Debug.Log("bowlingball");
                    Log_list.LogList.Add("�@�{�E�����O�̋��ŕ��U���Q�O�����A���h���Q�O����\n");//���O���X�g�ɒǉ�
                    playercontroller.Attack_damage += 20;//�U����20�㏸
                    playercontroller.Deffence -= 20;//�h���20����
                    adapt_bowlingball = false;//false�ɂ��Ĉ�񂵂��ǂݍ��܂���e�ɂ���
                }
            }
            if (cd_flag == true)
            {
                if (adapt_cd == true && first_turn == true)
                {
                    int cd_num = 0;
                    Debug.Log("cd");
                    playercontroller.Attack_damage += cd_num = playercontroller.Deffence / 6;//attack��diffence��1/6�̐��������Z
                    Log_list.LogList.Add("�@CD�ŕ��U" + cd_num + "�����@\n");
                    adapt_cd = false;
                }
            }
            if (CDplayer_flag == true)
            {
                if (adapt_CDplayer == true && first_turn == true)
                {
                    Debug.Log("CDplayer");
                    playercontroller.Attack_damage -= 20;//�U����20����
                    playercontroller.Deffence += 20;//�h���20�㏸
                    Log_list.LogList.Add("�@CD�v���C���[�̌��ʂŕ����U���͂��Q�O�������A�����h��͂��Q�O���������@\n");
                    adapt_CDplayer = false;
                }
            }
            if (kesigomu_flag == true)
            {
                if (adapt_kesigomu == true && first_turn == true)
                {
                    int kesigomu_num = 0;
                    Debug.Log("kesigomu");
                    playercontroller.Attack_damage += 20;//�����U����20�㏸
                    playercontroller.Magic_damage -= kesigomu_num = playercontroller.Attack_damage / 2;//���@�U���͂𕨗��U����/�Q�����炷
                    Log_list.LogList.Add("�@�����S���̌��ʂŕ����U���͂��Q�O�������A���@�U���͂�" + kesigomu_num + "���������@\n");
                    adapt_kesigomu = false;
                }
            }
            if (TV_flag == true)
            {
                if (adapt_TV == true && first_turn == true)
                {
                    int TV_num = 0;
                    Debug.Log("TV");
                    playercontroller.Magic_damage += TV_num = (playercontroller.Magic_damage / 5) * 3;//���@�U���͂T�ɂ����@�U���͂��R�㏸
                    Log_list.LogList.Add("�@�e���r�̌��ʂŖ��@�U���͂�" + TV_num + "���������@\n");
                    adapt_TV = false;
                }
            }
            if (CreditCard_flag == true)
            {
                if (adapt_CreditCard == true && first_turn == true)
                {
                    Debug.Log("CreditCard");
                    PlayerController.MONEY += 20;//�퓬�J�n��Q�OG����
                    Log_list.LogList.Add("�@�N���W�b�g�J�[�h�̌��ʂł������Q�O���肵���@\n");
                    adapt_CreditCard = false;
                }
            }
            if (Mouse_flag == true)
            {
                if (adapt_Mouse == true && first_turn == true)
                {
                    Debug.Log("Mouse");
                    playercontroller.Magic_damage += 10;//���@�U���͂P�O�㏸
                    Log_list.LogList.Add("�@�}�E�X�̌��ʂŖ��@�U���͂��P�O���������@\n");
                    adapt_Mouse = false;
                }
            }
            if (HandMirror_flag == true)
            {
                if (adapt_HandMirror == true && first_turn == true)
                {
                    Debug.Log("HandMirror");
                    playercontroller.Deffence += 10;//�����h��͂��P�O����
                    playercontroller.Magic_diffence += 10;//���@�h��͂��P�O����
                    Log_list.LogList.Add("�@�n���h�~���[�̌��ʂŁ@�����h��͂Ɩ��@�h��͂��P�O���������@\n");
                    adapt_HandMirror = false;
                }
            }
            if (baseball_ball_flag == true)
            {
                if (adapt_baseball_ball == true && first_turn == true)
                {
                    Debug.Log("baseball_ball");
                    playercontroller.Attack_damage += 15;//�����U���͂�15����
                    playercontroller.Deffence -= 10;//�����h��͂�10����
                    Log_list.LogList.Add("�@�싅�{�[���̌��ʂŕ����U���͂��P�T�������A�����h��͂��P�O���������@\n");
                    adapt_baseball_ball = false;
                }
            }
            if (Waterbucket_flag == true)
            {
                if (adapt_Waterbucket == true && first_turn == true)
                {
                    Debug.Log("Waterbucket");
                    playercontroller.Magic_diffence += 10;//���@�h��͂�10����
                    Log_list.LogList.Add("�@������̃o�P�c�̌��ʂŖ��@�h��͂��P�O���������@\n");
                    adapt_Waterbucket = false;
                }
            }
            if (Popcorn_flag == true)
            {
                if (adapt_Popcorn == true && first_turn == true)
                {
                    Debug.Log("Popcorn");
                    PlayerController.HP += 20;//�̗͂��Q�O��
                    Log_list.LogList.Add("�@�|�b�v�R�[���̌��ʂő̗͂��Q�O�񕜂����@\n");
                    adapt_Popcorn = false;
                }
            }
            if (Apple_flag == true)
            {
                if (adapt_Apple == true && first_turn == true)
                {
                    Debug.Log("Apple");
                    PlayerController.HP += 30;//�̗͂��R�O��
                    playercontroller.Magic_damage += 15;//���@�U���͂��P�T����
                    Log_list.LogList.Add("�@�����S�̌��ʂő̗͂��R�O�񕜂��A���@�U���͂��P�T���������@\n");
                    adapt_Apple = false;
                }
            }
            if (Scissors_flag == true)
            {
                if (adapt_Scissors == true && first_turn == true)
                {
                    Debug.Log("Scissors");
                    playercontroller.Attack_damage += 20;//�����U���͂��Q�O����
                    Log_list.LogList.Add("�@�n�T�~�̌��ʂŕ����U���͂��Q�O���������@\n");
                    adapt_Scissors = false;
                }
            }
            if (ice_flag == true)
            {
                if (adapt_ice == true && first_turn == true)
                {
                    Debug.Log("ice");
                    playercontroller.Magic_damage += 10;//���@�U���͂��P�O����
                    Log_list.LogList.Add("�@�X�̌��ʂŖ��@�U���͂��P�O���������@\n");
                    adapt_ice = false;
                }
            }
            if (Pudding_flag == true)
            {
                if (Apple_flag == true && adapt_Pudding == true && first_turn == true)
                {
                    PlayerController.HP_MAX += 30;//�ő�̗͂��R�O����
                    Log_list.LogList.Add("�@�����S�ƃv�����̌��ʂōő�̗͂��R�O���������@\n");
                    adapt_Pudding = false;
                }
                if (adapt_Pudding == true && first_turn == true)
                {
                    int Pudding_num;
                    Debug.Log("pudding");
                    PlayerController.HP += Pudding_num = PlayerController.HP_MAX / 4;//�̗͂��P/�S��
                    Log_list.LogList.Add("�@�v�����̌��ʂő̗͂�" + Pudding_num + "�񕜂����@\n");
                    adapt_Pudding = false;
                }
            }
            if (Drill_flag == true)
            {
                if (adapt_Drill == true && first_turn)
                {
                    int Drill_num;
                    //�G�̖h��͂̂Q���̂P�̐��l�����g�̕����U���͂ɉ��Z����
                    playercontroller.Attack_damage += Drill_num = enemy_Controller.Enemy_deffence / 2;
                    Log_list.LogList.Add("�@�h�����̌��ʂŕ����U���͂�" + Drill_num + "���������@\n");
                    adapt_Drill = false;
                }
            }
            if (UtypeMagnet_flag == true)
            {
                if (adapt_Utype_M == true && first_turn == true)
                {
                    Debug.Log("Utype");
                    playercontroller.Magic_damage += 20;//���@�U���͂��Q�O����
                    Log_list.LogList.Add("�@U���^�}�O�l�b�g�̌��ʂŖ��@�U���͂��Q�O���������@\n");
                    adapt_Utype_M = false;
                }
            }
            if (Coffee_flag == true)
            {
                if (adapt_Coffee == true && first_turn == true)
                {
                    Debug.Log("Coffe");
                    //�̗͂��Q�O���傫�������ꍇ
                    if (PlayerController.HP > 20)
                    {
                        PlayerController.HP -= 20;//�̗͂��Q�O����������
                        playercontroller.Magic_damage += 30;//���@�U���͂��R�O����������
                        Log_list.LogList.Add("�@�R�[�q�[�̌��ʂŖ��@�U���͂��R�O�������A�̗͂��Q�O���������@\n");
                    }
                    adapt_Coffee = false;
                }
            }
            if (Safetycone_flag == true)
            {
                if (adapt_SafetyCorn == true && first_turn == true)
                {
                    Debug.Log("safetycone");
                    safetycorn_random = Random.Range(1, 7);//�P/�U�̊m��
                    if (safetycorn_random < 6)
                    {
                        adapt_SafetyCorn = false;
                    }
                    else if (safetycorn_random == 6)
                    {
                        playercontroller.Attack_damage += 40;//�����U���͂��S�O����������
                        playercontroller.Deffence += 40;//�����h��͂��S�O����������
                        Log_list.LogList.Add("�@�O�p�R�[���̌��ʂŕ����U���͂ƕ����h��͂��S�O���������@\n");
                        adapt_SafetyCorn = false;
                    }
                }
            }
            if (USB_flag == true)
            {
                if (adapt_USB == true && first_turn == true)
                {
                    Debug.Log("USB");
                    playercontroller.Magic_damage += 20;//���@�U���͂��Q�O����������
                    playercontroller.Magic_diffence -= 10;//���@�h��͂��P�O����������
                    Log_list.LogList.Add("�@USB�̌��ʂŖ��@�U���͂��Q�O�������A���@�h��͂��P�O���������@\n");
                    adapt_USB = false;
                }
            }
            if (Smartphone_flag == true)
            {
                if (adapt_SmartPhone == true && first_turn == true)
                {
                    int SmartPhone_num;
                    Debug.Log("SmartPhone");
                    playercontroller.Magic_diffence += SmartPhone_num = playercontroller.Magic_damage / 4;//���@�h��͂𖂖@�U���͂̂P/�S������������
                    Log_list.LogList.Add("�@�X�}�[�g�t�H���̌��ʂŖ��@�h��͂�" + SmartPhone_num + "���������@\n");
                    adapt_SmartPhone = false;
                }
            }
            if (ItypeMagnet_flag == true)
            {
                if (adapt_Itype_M == true && first_turn == true)
                {
                    Debug.Log("Itype");
                    playercontroller.Magic_diffence += 20;//���@�h��͂��Q�O����������
                    Log_list.LogList.Add("�@I���^�}�O�l�b�g�̌��ʂŖ��@�h��͂��Q�O���������@\n");
                    adapt_Itype_M = false;
                }
            }
            if (Mike_flag == true)
            {
                if (adapt_Mike == true && first_turn == true)
                {
                    Debug.Log("Mike");
                    playercontroller.Magic_damage += 30;//���@�U���͂��R�O����������
                    Log_list.LogList.Add("�@�}�C�N�̌��ʂŖ��@�U���͂��R�O���������@\n");
                    adapt_Mike = false;
                }
            }
            if (Megaphone_flag == true)
            {
                if (adapt_Megaphone == true && first_turn == true)
                {
                    Debug.Log("Megaphone");
                    playercontroller.Deffence += 20;//�����h��͂��Q�O����������
                    Log_list.LogList.Add("�@���K�z���̌��ʂŕ����h��͂��Q�O���������@\n");
                    adapt_Megaphone = false;
                }
            }
            if (HandMill_flag == true)
            {
                //�R�[�q�[�������Ă���ꍇ���@�U���͂��U�O����
                if (adapt_HandMill == true && Coffee_flag == true && first_turn == true)
                {
                    playercontroller.Magic_damage += 60;
                    Log_list.LogList.Add("�@�R�[�q�[�ƃn���h�~���̌��ʂŖ��@�U���͂��U�O���������@\n");
                    adapt_HandMill = false;
                }
                else if (adapt_HandMill == true && first_turn == true)
                {
                    Debug.Log("HandMill");
                    playercontroller.Magic_damage -= 30;//���@�U���͂��R�O����������
                    Log_list.LogList.Add("�@�n���h�~���̌��ʂŖ��@�U���͂��R�O���������@\n");
                    adapt_HandMill = false;
                }
            }
            if (Poteto_flag == true)
            {
                //�n���o�[�K�[�������Ă���ꍇ�����U���͂��U�O����������
                if (adapt_Poteto == true && Hamberger_flag == true && first_turn == true)
                {
                    playercontroller.Attack_damage += 60;
                    Log_list.LogList.Add("�@�@�|�e�g�ƃn���o�[�K�[�̌��ʂŕ����U���͂��U�O���������@\n");
                    adapt_Poteto = false;
                }
                else if (adapt_Poteto == true && first_turn == true)
                {
                    Debug.Log("Poteto");
                    playercontroller.Attack_damage -= 30;//�����U���͂��R�O����������
                    Log_list.LogList.Add("�@�|�e�g�̌��ʂŕ����U���͂��R�O���������@\n");
                    adapt_Poteto = false;
                }
            }
            if (Scop_flag == true)
            {
                if (adapt_Scop == true && first_turn == true)
                {
                    Debug.Log("Scop");
                    scop_random = Random.Range(1, 5);//�P/�S�̊m��
                    if (scop_random == 4)
                    {
                        PlayerController.MONEY += 30;//�������z���R�O����������
                        Log_list.LogList.Add("�@�X�R�b�v�̌��ʂł������R�O���肵���@\n");
                    }
                    adapt_Scop = false;
                }
            }
            if (Speaker_flag == true)
            {
                if (adapt_Speaker == true && first_turn == true)
                {
                    Debug.Log("Speaker");
                    enemy_Controller.Enemy_deffence -= 25;//�G�̕����h��͂��Q�T����������
                    Log_list.LogList.Add("�@�X�s�[�J�[�̌��ʂŕ����h��͂��Q�T���������@\n");
                    adapt_Speaker = false;
                }
            }
            if (Baseball_glove_flag == true)
            {
                //�싅�{�[���������Ă���ꍇ
                if (adapt_Baseball_glove == true && baseball_ball_flag == true && first_turn == true)
                {
                    playercontroller.Attack_damage += 25;//�����U���͂��Q�T����
                    playercontroller.Deffence += 15;//�����h��͂��P�T����
                    Log_list.LogList.Add("�@�싅�{�[���Ɩ싅�O���[�u�̌��ʂŕ����U���͂��Q�T�������A�����h��͂��P�T���������@\n");
                    adapt_Baseball_glove = false;
                }
                else if (adapt_Baseball_glove == true && first_turn == true)
                {
                    Debug.Log("Baseball_glove");
                    playercontroller.Attack_damage += 25;//�����U���͂��Q�T����
                    Log_list.LogList.Add("�@�싅�O���[�u�̌��ʂŕ����U���͂��Q�T���������@\n");
                    adapt_Baseball_glove = false;
                }
            }
            if (Boxing_glove_flag == true)
            {
                //�U���Q�L��P�������ꂽ�Ƃ��A�����U���͂��R����������
                if (adapt_Boxing_glove == true && first_turn == true)
                {
                    Debug.Log("Boxing_glove");
                    Boxing_flag = true;
                    adapt_Boxing_glove = false;
                    Log_list.LogList.Add("�@�{�N�V���O�O���[�u�̌��ʂŃU���Q�L���������Ƃ��ɕ����U���͂��R��������悤�ɂȂ����@\n");
                }
            }
            if (Juice_flag == true)
            {
                if (adapt_Juice == true && first_turn == true)
                {
                    Debug.Log("Juice");
                    PlayerController.HP += 20;//�̗͂��Q�O����������
                    Log_list.LogList.Add("�@�W���[�X�̌��ʂő̗͂��Q�O�񕜂����@\n");
                    adapt_Juice = false;
                }
            }
            if (Gas_burner_flag == true)
            {
                if (Enemy_controller.turn % 2 == 0 && turn_bool == true)
                {
                    Debug.Log("Gas_burner");
                    playercontroller.Attack_damage += 25;//�����U���͂��Q�T����������
                    Log_list.LogList.Add("�@�K�X�o�[�i�[�̌��ʂŕ����U���͂��Q�T���������@\n");
                    turn_bool = false;
                }
                else if (Enemy_controller.turn != 1 && Enemy_controller.turn % 2 != 0 && turn_bool == true)
                {
                    playercontroller.Attack_damage -= 25;//�����U���͂��Q�T����������
                    Log_list.LogList.Add("�@�K�X�o�[�i�[�̌��ʂŕ����U���͂��Q�T���������@\n");
                    turn_bool = false;
                }
            }
            if (Hamberger_flag == true)
            {
                //�|�e�g�������Ă����ꍇ
                if (adapt_Hamberger == true && Poteto_flag == true && first_turn == true)
                {
                    Debug.Log("Hamberger");
                    playercontroller.Attack_damage += 40;//�����U���͂��S�O����������
                    Log_list.LogList.Add("�@�n���o�[�K�[�ƃ|�e�g�̌��ʂŕ����U���͂��S�O���������@\n");
                    adapt_Hamberger = false;
                }
                else if (adapt_Hamberger == true && first_turn == true)
                {
                    Debug.Log("Hamberger");
                    playercontroller.Attack_damage += 20;//�����U���͂��Q�O����������
                    Log_list.LogList.Add("�@�n���o�[�K�[�̌��ʂŕ����U���͂��Q�O���������@\n");
                    adapt_Hamberger = false;
                }
            }
            if (Pencil_flag == true)
            {
                //�퓬�J�n���̌���
                if (adapt_Pencil == true && first_turn == true)
                {
                    Debug.Log("Pencil");
                    playercontroller.Attack_damage += 50;//�����U���͂��T�O����������
                    Log_list.LogList.Add("�@���M�̌��ʂŕ����U���͂��T�O���������@\n");
                    adapt_Pencil = false;
                }
            }
            if (Mayonnaise_flag == true)
            {
                if (adapt_Mayonnaise == true && first_turn == true)
                {
                    Debug.Log("Mayonnaise");
                    playercontroller.Magic_damage += 50;//���@�U���͂��T�O����������
                    Log_list.LogList.Add("�@�}���l�[�Y�̌��ʂŖ��@�U���͂��T�O���������@\n");
                    adapt_Mayonnaise = false;
                }
            }
            if (TheGrimReaper_Scythe_flag == true)
            {
                if (adapt_TheGrimReaper_scythe == true && first_turn == true)
                {
                    Debug.Log("Scythe");
                    playercontroller.Attack_damage += 40;//�����U���͂��S�O����������
                    PlayerController.MAX_LUCK -= 3;//�N���e�B�J�������m����3����
                    Sinigami_Crit_Effect = true;//���_�̃N���e�B�J���G�t�F�N�g����
                    Log_list.LogList.Add("�@���_�̊��̌��ʂŕ����U���͂��S�O�������A�N���e�B�J�����������₷���Ȃ����@\n");
                    adapt_TheGrimReaper_scythe = false;
                }
            }
            if (Sinigami_Robe_flag == true)
            {
                if (adapt_TheGrimReaper_robe == true && first_turn == true)
                {
                    Debug.Log("Robe");
                    playercontroller.Deffence += 40;//�����h��͂�40����
                    PlayerController.MAX_LUCK -= 3;//�N���e�B�J�������m����3����
                    Log_list.LogList.Add("�@���_�̃��[�u�̌��ʂŕ����h��͂��S�O�������A�N���e�B�J�����������₷���Ȃ����@\n");
                    adapt_TheGrimReaper_robe = false;
                }
            }
            if (Medhusa_Eye_flag == true)
            {
                if (adapt_Medhusa_Eye == true && first_turn == true)
                {
                    Debug.Log("Eye");
                    playercontroller.Magic_diffence += 40;//���@b�h��͂��S�O����������
                    PlayerController.MAX_LUCK -= 3;//�N���e�B�J�������m����3����
                    Log_list.LogList.Add("�@���f���[�T�̖ڂ̌��ʂŖ��@�h��͂��S�O�������A�N���e�B�J�����������₷���Ȃ����@\n");
                    adapt_Medhusa_Eye = false;
                }
            }
            if (Medhusa_MagicBook_flag == true)
            {
                if (adapt_Medhusa_MagicBook == true && first_turn == true)
                {
                    Debug.Log("Magic_Book");
                    playercontroller.Magic_damage += 40;//���@�U���͂�40����������
                    PlayerController.MAX_LUCK -= 3;//�N���e�B�J�������m����3����
                    Log_list.LogList.Add("�@���f���[�T�̖������̌��ʂŖ��@�U���͂��S�O�������A�N���e�B�J�����������₷���Ȃ����@\n");
                    Medhusa_Magic_flag = true;
                    adapt_Medhusa_MagicBook = false;
                }
            }
            if (Dragon_Tooth_flag == true)
            {
                if (adapt_Dragon_Tooth = true && first_turn == true)
                {
                    Debug.Log("Tooth");
                    playercontroller.Attack_damage += 100;//�����U���͂�100����
                    PlayerController.HP_MAX += 50;//�ő�̗͂�50�ǉ�
                    Log_list.LogList.Add("�@�h���S���̉�̌��ʂŕ����U���͂��P�O�O�������A�ő�̗͂��T�O���������@\n");
                    adapt_Dragon_Tooth = false;
                }
            }
            if (bowlingpin_flag == true)
            {
                //���ʂ̓��e�I�Ɉ�ԉ�
                if (adapt_bowlingpin == true && first_turn == true)
                {
                    int bowlingpin_num = 0;
                    Debug.Log("bowlingpin");
                    PlayerController.MONEY += bowlingpin_num = playercontroller.Attack_damage / 6;//�������z�𕨗��U���͂̂P/�U������������
                    Log_list.LogList.Add("�@�{�E�����O�̃s���̌��ʂŏ������z��" + bowlingpin_num + "���肵���@\n");
                    adapt_bowlingpin = false;
                }
            }
            first_turn = false;




            if (radio_flag == true)
            {
                if (PlayerController.HP > 11)
                {
                    Debug.Log("radio");
                    playercontroller.Deffence += 10;//���^�[���h���10�㏸
                    PlayerController.HP -= 5;//�̗͂�5���炷
                    log_text.text = "���W�I�̌��ʂő̗͂��T������";
                    Log_list.LogList.Add("�@���W�I�̌��ʂő̗͂��T������\n");//���O���X�g�ɒǉ�
                }
                else
                {
                    log_text.text = "���W�I�̌��ʂ͔������Ȃ�����";
                    Log_list.LogList.Add("�@���W�I�̌��ʂ͔������Ȃ�����\n");//���O���X�g�ɒǉ�
                }
            }
            if (hourglass_flag == true)
            {
                if (PlayerController.HP >11)
                {
                    Debug.Log("hourglass");
                    playercontroller.Attack_damage += 10;//���^�[���U����10�㏸
                    PlayerController.HP -= 5;//�̗͂�5���炷
                    log_text.text = "�����v�̌��ʂő̗͂��T������";
                    Log_list.LogList.Add("�@�����v�̌��ʂő̗͂��T������\n");//���O���X�g�ɒǉ�
                }
                else
                {
                    log_text.text = "�����v�̌��ʂ͔������Ȃ�����";
                    Log_list.LogList.Add("�@�����v�̌��ʂ͔������Ȃ�����\n");//���O���X�g�ɒǉ�
                }
            }
            if (dice_flag == true)
            {
                Debug.Log("dice");
                dice_random = Random.Range(1, 7);
                switch (dice_random)
                {
                    case 1: playercontroller.Attack_damage += 10; Log_list.LogList.Add("�@�_�C�X�̌��ʂŕ����U���͂��P�O�㏸����\n"); break;//�����U���͂��P�O����
                    case 2: playercontroller.Attack_damage -= 10; Log_list.LogList.Add("�@�_�C�X�̌��ʂŕ����U���͂��P�O��������\n"); break;//�����U���͂��P�O����
                    case 3: playercontroller.Magic_damage += 10; Log_list.LogList.Add("�@�_�C�X�̌��ʂŖ��@�U���͂��P�O�㏸����\n"); break;//���@�U���͂��P�O����
                    case 4: playercontroller.Magic_damage -= 10; Log_list.LogList.Add("�@�_�C�X�̌��ʂŖ��@�U���͂��P�O��������\n"); break;//���@�U���͂��P�O����
                    case 5: PlayerController.MONEY += 5; Log_list.LogList.Add("�@�_�C�X�̌��ʂł������T�f���肵��\n"); break;//�������z���T����������
                    case 6: dice_crit = true; Log_list.LogList.Add("�@�_�C�X�̌��ʂŃN���e�B�J�����������₷���Ȃ���\n"); break;//�N���e�B�J������
                }
            }
            if (Scissors_flag == true)
            {
                Debug.Log("Scissors");
                Log_list.LogList.Add("�@�n�T�~�̌��ʂŕ����h��͂��Q��������\n");
                playercontroller.Deffence -= 2;//�����h��͂��Q����������
            }
            if (Headphone_flag)
            {
                Debug.Log("Headphone");
                if (playercontroller.Attack_damage <= 3 || playercontroller.Deffence <= 3)
                {
                    log_text.text = "�w�b�h�z���̌��ʂ͔������Ȃ�����";
                    Log_list.LogList.Add("�@�w�b�h�z���̌��ʂ͔������Ȃ�����\n");//���O���X�g�ɒǉ�
                }
                else
                {
                    Log_list.LogList.Add("�@�w�b�h�z���̌��ʂŕ����U���͂ƕ����h��͂��R��������\n");
                    playercontroller.Attack_damage -= 3;//�����U���͂��R����������
                    playercontroller.Deffence -= 3;//�����h��͂��R����������
                    Log_list.LogList.Add("�@�w�b�h�z���̌��ʂő̗͂��P�O�񕜂���\n");
                    PlayerController.HP += 10;//�̗͂��P�O�񕜂�����
                }
            }
            if (MagnifyingSpeculum_flag == true)
            {
                Debug.Log("Magnifying");
                Log_list.LogList.Add("�@���ዾ�̌��ʂŕ����h��͂Ɩ��@�h��͂��R��������\n");
                playercontroller.Deffence += 3;//�����h��͂��R����������
                playercontroller.Magic_diffence += 3;//���@�h��͂��R����������
            }
            if (hammer_flag == true)
            {
                Debug.Log("hammer");
                hammer_random = Random.Range(1, 11);//�P/�P�O�̊m��
                if (hammer_random == 10)
                {
                    //�G���C�₳����
                    Enemy_controller.Stun_turn = true;
                    Log_list.LogList.Add("�@�n���}�[�̌��ʂœG���X�^������\n");
                    status_.Status_Effect(false, 4);//�C��G�t�F�N�g
                }
            }
            if (Sylinge_flag == true)
            {
                Debug.Log("Sylinge");
                sylinge_random = Random.Range(1, 7);//�P/�U�̊m��
                if (sylinge_random == 6)
                {
                    Log_list.LogList.Add("�@���ˊ�̌��ʂő̗͂��R�O�񕜂���\n");
                    PlayerController.HP += 30;//�̗͂��R�O�񕜂�����
                }
                else
                {
                    Log_list.LogList.Add("�@���ˊ�̌��ʂő̗͂��T�񕜂���\n");
                    PlayerController.HP += 5;//�̗͂��T�񕜂�����
                }
            }
            if (Pencil_flag == true)
            {
                Debug.Log("Pencil");
                //�P�O�^�[���̊�
                if (Pencil_Down_cnt <= 10)
                {
                    Log_list.LogList.Add("�@���M�̌��ʂŕ����U���͂��T��������(����\n");
                    playercontroller.Attack_damage -= 5;//�����U���͂��T����������
                    Pencil_Down_cnt++;
                }
            }
            if (Mayonnaise_flag == true)
            {
                Debug.Log("Mayonnaise");
                //�P�O�^�[���̊�
                if (Pencil_Down_cnt <= 10)
                {
                    Log_list.LogList.Add("�@�}���l�[�Y�̌��ʂŖ��@�U���͂��T��������\n");
                    playercontroller.Magic_damage -= 5;//���@�U���͂��T����
                    Pencil_Down_cnt++;
                }
            }
            if (Watch_flag == true)
            {
                Debug.Log("Watch");
                if (Watch_Add_reset == true)
                {
                    //�����U����
                    Log_list.LogList.Add("�@�r���v�̌��ʂŕ����U���͂�"+ (PlayerController.HP_MAX - PlayerController.HP) +"�㏸����\n");
                    playercontroller.Attack_damage += PlayerController.HP_MAX - PlayerController.HP;
                    Watch_Add_reset = false;
                }
            }
            if (Dragon_Scale_flag == true)
            {
                Debug.Log("Dragon_Scale");
                Log_list.LogList.Add("�@�h���S���̗؂̌��ʂőS�X�e�[�^�X���P�O�㏸����\n");
                playercontroller.Attack_damage += 10;//�����U���͂��P�O����
                playercontroller.Deffence += 10;//�����h��ʂ��P�O����
                playercontroller.Magic_damage += 10;//���@�U���͂��P�O����
                playercontroller.Magic_diffence += 10;//���@�h��͂��P�O����
            }
            Log_list.LogList.Add("--------------------------------------------------------------�@\n");
            turn_compare = Enemy_controller.turn;
        }
    }
}