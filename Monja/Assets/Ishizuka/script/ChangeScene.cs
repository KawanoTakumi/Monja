using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;//�؂�ւ���V�[���̖��O������
    public Shop_manager shop;
    public static bool Scene_Change = false;
    public static int Boss_Number = 0;
    public static int scene_cnt = 0;

    public void Start()
    {
        shop = GetComponent<Shop_manager>();
        
    } 
    //�V�[����ǂݍ���
    public void Load()
    {
            SceneManager.LoadScene(sceneName);
    }
    //shop_change��L���ɂ���
    public void change_scene()
    {
        Scene_Change = true;
    }
    //�V���b�v�ɖ߂鎞�p�֐�
    public void shop_change()
    {
        //shop�ɖ߂鎞�p
        if (Scene_Change == true)
        {
            SceneManager.LoadScene("shop");
            Scene_Change = false;
        }
    }
    //�V�[���J�E���g�����֐�
    public void add_scene_num()
    {
        //�V�[���i���o�[���Z
        scene_cnt++;
    }
    //�V�[���J�E���g���Z�b�g�֐�
    public void reset_scene_num()
    {
        scene_cnt = 0;
    }
    //�ŏ��̃^�[���o�ߎ擾�t���O
    public void first_turn_flag()
    {
        Item_Power.first_turn = false;
    }
    //work�V�[���ύX�֐�
    public void Work_Cange_Scene()
    {
        //�e�V�[���J�E���g�ňړ��V�[����ύX
        switch (scene_cnt)
        {
            case 0: SceneManager.LoadScene("Title"); break;                //�^�C�g��
            case 1:case 2:case 3: SceneManager.LoadScene("work_01"); break;//���s�V�[��1
            case 4:case 5:case 6: SceneManager.LoadScene("work_02"); break;//���s�V�[��2
            case 7:case 8:case 9: SceneManager.LoadScene("work_03"); break;//���s�V�[��3
        }
    }
    //�퓬�V�[����scene_cnt�Ɋ�Â��ĕύX
    public void Enemy_Change_Scene()
    {
        if(Scene_Change == false)
        {
            //�o�g���V�[��(case: 3,6,9�̂Ƃ��̓{�X�V�[��)
            switch (scene_cnt)
            {
                case 0: SceneManager.LoadScene("Title");            break; //�^�C�g��
                case 1: SceneManager.LoadScene("Battle");           break; //�X�P���g���@  �o�g���P
                case 2: SceneManager.LoadScene("Battle_2");         break; //���b�`�@      �o�g���Q
                case 3: SceneManager.LoadScene("Boss_Battle_01");   break; //���_�@        �o�g���R
                case 4: SceneManager.LoadScene("Battle_4");         break; //�~�m�^�E���X�@�o�g���S
                case 5: SceneManager.LoadScene("Battle_5");         break; //�P���^�E���X�@�o�g���T
                case 6: SceneManager.LoadScene("Boss_Battle_02");   break; //���f���[�T    �o�g���U
                case 7: SceneManager.LoadScene("Battle_7");         break; //�R�J�g���X�@  �o�g���V
                case 8: SceneManager.LoadScene("Battle_8");         break; //�i�C�g�@      �o�g���W
                case 9: SceneManager.LoadScene("Boss_Battle_03");   break; //�h���S��      �o�g���X
            }
        }
    }
    //title�ɖ߂鎞�Ɏg�p
    public void Player_Reset()
    {
        PlayerController.HP = PlayerController.HP_max;
        Item_Manager.Item["healdrink"] = false;
        Item_Manager.Item["bowlingball"] = false;
        Item_Manager.Item["CDplayer"] = false;
        Item_Manager.Item["cd"] = false;
        Item_Manager.Item["radio"] = false;
        Item_Manager.Item["hourglass"] = false;
        Item_Manager.Item["kesigomu"] = false;
        Item_Manager.Item["TV"] = false;
        Item_Manager.Item["CreditCard"] = false;
        Item_Manager.Item["Mouse"] = false;
        Item_Manager.Item["HandMirror"] = false;
        Item_Manager.Item["bowlingpin"] = false;
        Item_Manager.Item["baseball_ball"] = false;
        Item_Manager.Item["dice"] = false;
        Item_Manager.Item["Water bucket"] = false;
        Item_Manager.Item["Popcorn"] = false;
        Item_Manager.Item["Apple"] = false;
        Item_Manager.Item["Scissors"] = false;
        Item_Manager.Item["ice"] = false;
        Item_Manager.Item["Pudding"] = false;
        Item_Manager.Item["Drill"] = false;
        Item_Manager.Item["Headphone"] = false;
        Item_Manager.Item["Coffee"] = false;
        Item_Manager.Item["Safetycone"] = false;
        Item_Manager.Item["USB"] = false;
        Item_Manager.Item["UtypeMagnet"] = false;
        Item_Manager.Item["Smartphone"] = false;
        Item_Manager.Item["ItypeMagnet"] = false;
        Item_Manager.Item["Magnifying Speculum"] = false;
        Item_Manager.Item["Mike"] = false;
        Item_Manager.Item["Megaphone"] = false;
        Item_Manager.Item["HandMill"] = false;
        Item_Manager.Item["Kama"] = false;
        Item_Manager.Item["Robe"] = false;
        Item_Manager.Item["Scale"] = false;
        Item_Manager.Item["MagicBook"] = false;
        Item_Manager.Item["Juwel"] = false;
        Item_Manager.Item["Tooth"] = false;

        scene_cnt = 0;
    }
    public void Item_num_Recet()
    {
        Shop_manager.tmp_1 = -1;
        Shop_manager.tmp_2 = -1;
        Shop_manager.tmp_3 = -1;
    }
    //shop�ڍs
    public void shop_go()
    {
        SceneManager.LoadScene("shop");
    }
    //shop����ړ�
    public void back_shop()
    {
        SceneManager.LoadScene("shop_back");
    }
    //
    public static void Title_Reset()
    {
        PlayerController.HP = PlayerController.HP_max;
        PlayerController.MP = PlayerController.MP_max;
        PlayerController.magic_number = 0;
        PlayerController.Money = 0;
        PlayerController.Status_reset();
        PlayerController.Item_Reset();
        //�e�퐔�l��������
        Item_Power.turn_compare = 0;
        Item_Power.first_turn = true;
        Enemy_controller.turn = 0;
        Enemy_controller.HP = 150;
        Enemy_controller.tag_get = true;
    }
}