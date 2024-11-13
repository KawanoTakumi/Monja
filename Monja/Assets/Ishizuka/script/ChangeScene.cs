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
    int Boss_Scene_Number;
    public static int scene_cnt = 0;
    public void Start()
    {
        shop = GetComponent<Shop_manager>();
    } 
    //�V�[����ǂݍ���
    public void Load()
    {
        if (Scene_Change == false)
        {
            SceneManager.LoadScene(sceneName);
        }
        else if(Scene_Change == true)
        {
            Scene_Change = false;
            SceneManager.LoadScene("shop");
        }
    }

    public void change_scene()
    {
        Scene_Change = true;
    }
     public void Boss_Change_Scene()
    {
        if(scene_cnt >= 1)
        {
            //�V�[���J�E���g���R�̎��{�X�V�[�����Ăяo�����
            Boss_Number++;
            Boss_Scene_Number = Boss_Number;
            Debug.Log(Boss_Scene_Number);
            scene_cnt = 0;
            //�{�X�̃V�[��
            switch (Boss_Scene_Number)
            {
                case 1: SceneManager.LoadScene("Boss_Battle_01"); break;
            }
        }
    }
    //shop����title�ɖ߂鎞�Ɏg�p
    public void Player_Reset()
    {
        PlayerController.HP = PlayerController.HP_max;
        Item_Manager.Item["healdrink"] = false;
        Item_Manager.Item["bowlingball"] = false;
        Item_Manager.Item["CDplayer"] = false;
        Item_Manager.Item["cd"] = false;
        Item_Manager.Item["radio"] = false;
        Item_Manager.Item["hourglass"] = false;
    }

    public void Item_num_Recet()
    {
        Shop_manager.tmp_1 = -1;
        Shop_manager.tmp_2 = -1;
        Shop_manager.tmp_3 = -1;
    }
    public void Scene_Cnt()
    {
        scene_cnt++;
    }
}