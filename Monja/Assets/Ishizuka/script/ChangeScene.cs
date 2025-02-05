using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Shop_manager Shop;
    public static bool SceneChange = false;
    public static int SCENE_CNT  = 0;
    public enum Scene
    {
        Title          = 0,
        Battle         = 1,
        Battle_2       = 2,
        Boss_Battle_01 = 3,
        Battle_4       = 4,
        Battle_5       = 5,
        Boss_Battle_02 = 6,
        Battle_7       = 7,
        Battle_8       = 8,
        Boss_Battle_03 = 9
    }
    Scene scene = Scene.Title;

    //�X�^�[�g���\�b�h
    //�����@�R���|�[�l���g���擾���܂�
    void Start()
    {
        //Debug.Log(SceneName);
        Shop = GetComponent<Shop_manager>();
    }
    /// <summary>
    /// �V�[����ǂݍ��ފ֐��ł��B
    /// </summary>
    /// <param name="Scenename">�V�[����</param>
    public void Load(string Scenename)
    {
        SceneManager.LoadScene(Scenename);
    }
    //change_scene��ǂݍ���
    public void Change_Scene()
    {
        //shop_change��L���ɂ���
        SceneChange = true;
    }
    //�V���b�v�ɖ߂鎞�̊֐�
    /// <summary>
    /// �C���x���g����ʂ���V���b�v�ɖ߂�Ƃ��p�̊֐��ł�
    /// </summary>>
    public void Shop_Change()
    {
        //shop�ɖ߂鎞�p
        if (SceneChange == true)
        {
            SceneManager.LoadScene("shop");
            SceneChange = false;
        }
    }
    //�V�[���J�E���g�����֐�
    /// <summary>
    /// �V�[���p�̃J�E���g��i�߂�֐��ł�
    /// </summary>
    public void Add_Scene_Num()
    {
        //�V�[���i���o�[���Z
        SCENE_CNT++;
        scene++;
    }
    //�V�[���J�E���g���Z�b�g�֐�
    /// <summary>
    /// �V�[���p�̃J�E���g�����Z�b�g����֐��ł�
    /// </summary>
    public void Reset_Scene_Num()
    {
        scene = Scene.Title;
    }
    //�ŏ��̃^�[���o�ߎ擾�t���O
    /// <summary>
    /// �ŏ��̃^�[���������ꍇ�t���O��false�ɂ��܂�
    /// </summary>
    public void First_Turn_Flag()
    {
        Item_Power.first_turn = false;
    }
    //work�V�[���ύX�֐�
    /// <summary>
    /// �V�[���J�E���g�ɉ����Ď�l���������V�[����ݒ肵�܂�
    /// </summary>
    public void Work_Cange_Scene()
    {
        //�e�V�[���J�E���g�ňړ��V�[����ύX
        switch (SCENE_CNT)
        {
            case (int)Scene.Title: SceneManager.LoadScene("Title"); break;                //�^�C�g��
            case (int)Scene.Battle:   case (int)Scene.Battle_2: case (int)Scene.Boss_Battle_01: SceneManager.LoadScene("work_01"); break;//���s�V�[��1
            case (int)Scene.Battle_4: case (int)Scene.Battle_5: case (int)Scene.Boss_Battle_02: SceneManager.LoadScene("work_02"); break;//���s�V�[��2
            case (int)Scene.Battle_7: case (int)Scene.Battle_8: case (int)Scene.Boss_Battle_03: SceneManager.LoadScene("work_03"); break;//���s�V�[��3
        }
    }
    //�퓬�V�[����scene_cnt�Ɋ�Â��ĕύX
    /// <summary>
    /// �퓬�V�[�����V�[���J�E���g�ɉ����ĕύX���܂�
    /// </summary>
    public void Enemy_Change_Scene()
    {
        if (SceneChange == false)
        {
            //�o�g���V�[��(case: 3,6,9�̂Ƃ��̓{�X�V�[��)
            switch (SCENE_CNT)
            {
                case (int)Scene.Title:          SceneManager.LoadScene("Title");          break; //�^�C�g��
                case (int)Scene.Battle:         SceneManager.LoadScene("Battle");         break; //�X�P���g���@  �o�g���P
                case (int)Scene.Battle_2:       SceneManager.LoadScene("Battle_2");       break; //���b�`�@      �o�g���Q
                case (int)Scene.Boss_Battle_01: SceneManager.LoadScene("Boss_Battle_01"); break; //���_�@        �o�g���R
                case (int)Scene.Battle_4:       SceneManager.LoadScene("Battle_4");       break; //�~�m�^�E���X�@�o�g���S
                case (int)Scene.Battle_5:       SceneManager.LoadScene("Battle_5");       break; //�P���^�E���X�@�o�g���T
                case (int)Scene.Boss_Battle_02: SceneManager.LoadScene("Boss_Battle_02"); break; //���f���[�T    �o�g���U
                case (int)Scene.Battle_7:       SceneManager.LoadScene("Battle_7");       break; //�R�J�g���X�@  �o�g���V
                case (int)Scene.Battle_8:       SceneManager.LoadScene("Battle_8");       break; //�i�C�g�@      �o�g���W
                case (int)Scene.Boss_Battle_03: SceneManager.LoadScene("Boss_Battle_03"); break; //�h���S��      �o�g���X
            }
        }
    }
    //title�ɖ߂鎞�Ɏg�p
    //�A�C�e����HP�ƃV�[���J�E���g�����Z�b�g
    /// <summary>
    /// �v���C���[�̊e��X�e�[�^�X�����Z�b�g���܂�
    /// </summary>
    public void Player_Reset()
    {
        PlayerController.HP = PlayerController.HP_max;
        Item_Manager.Item["healdrink"]        = false;
        Item_Manager.Item["bowlingball"]      = false;
        Item_Manager.Item["CDplayer"]         = false;
        Item_Manager.Item["cd"]               = false;
        Item_Manager.Item["radio"]            = false;
        Item_Manager.Item["hourglass"]        = false;
        Item_Manager.Item["kesigomu"]         = false;
        Item_Manager.Item["TV"]               = false;
        Item_Manager.Item["CreditCard"]       = false;
        Item_Manager.Item["Mouse"]            = false;
        Item_Manager.Item["HandMirror"]       = false;
        Item_Manager.Item["bowlingpin"]       = false;
        Item_Manager.Item["baseball_ball"]    = false;
        Item_Manager.Item["dice"]             = false;
        Item_Manager.Item["Water bucket"]     = false;
        Item_Manager.Item["Popcorn"]          = false;
        Item_Manager.Item["Apple"]            = false;
        Item_Manager.Item["Scissors"]         = false;
        Item_Manager.Item["ice"]              = false;
        Item_Manager.Item["Pudding"]          = false;
        Item_Manager.Item["Drill"]            = false;
        Item_Manager.Item["Headphone"]        = false;
        Item_Manager.Item["Coffee"]           = false;
        Item_Manager.Item["Safetycone"]       = false;
        Item_Manager.Item["USB"]              = false;
        Item_Manager.Item["UtypeMagnet"]      = false;
        Item_Manager.Item["Smartphone"]       = false;
        Item_Manager.Item["ItypeMagnet"]      = false;
        Item_Manager.Item["Magnifying Speculum"] = false;
        Item_Manager.Item["Mike"]             = false;
        Item_Manager.Item["Megaphone"]        = false;
        Item_Manager.Item["HandMill"]         = false;
        Item_Manager.Item["Poteto"]           = false;
        Item_Manager.Item["Scop"]             = false;
        Item_Manager.Item["hammer"]           = false;
        Item_Manager.Item["Speaker"]          = false;
        Item_Manager.Item["Sylinge"]          = false;
        Item_Manager.Item["Baseball_glove"]   = false;
        Item_Manager.Item["Juice"]            = false;
        Item_Manager.Item["Boxing_glove"]     = false;
        Item_Manager.Item["Gas_burner"]       = false;
        Item_Manager.Item["Hamberger"]        = false;
        Item_Manager.Item["Pencil"]           = false;
        Item_Manager.Item["Mayonnaise"]       = false;
        Item_Manager.Item["Watch"]            = false;
        Item_Manager.Item["Scythe"]           = false;
        Item_Manager.Item["Robe"]             = false;
        Item_Manager.Item["Scale"]            = false;
        Item_Manager.Item["MagicBook"]        = false;
        Item_Manager.Item["Eye"]              = false;
        Item_Manager.Item["Tooth"]            = false;
        PlayerController.Mmax_luck = 13;//�N���e�B�J�������m��������
        SCENE_CNT = 0;
    }
    //shop�V�[���̃A�C�e���\�������Z�b�g
    /// <summary>
    /// �V���b�v�V�[���Ŏg�p�����A�C�e���p�̕ϐ������Z�b�g���܂�
    /// </summary>
    public void Item_Num_Reset()
    {
        for (int i = 0; i < 3; i++)
            Shop_manager.Shop_tmp[i] = -1;
    }
    //shop�ڍs
    /// <summary>
    /// �V���b�v�Ɉړ����܂�
    /// </summary>
    public void Shop_Go()
    {
        SceneManager.LoadScene("shop");
    }
    //shop����ړ�
    /// <summary>
    /// �V���b�v���玟�̃V�[���ֈړ����܂�
    /// </summary>
    public void Back_Shop()
    {
        SceneManager.LoadScene("shop_back");
    }
    //���l������
    /// <summary>
    /// �^�C�g���p�ɕϐ������������܂�
    /// </summary>
    public static void Title_Reset()
    {
        PlayerController.HP_max = 100;//�ő�̗͂������̒l�ɂ���
        PlayerController.HP = PlayerController.HP_max;
        PlayerController.MP = PlayerController.MP_max;
        PlayerController.Magic_number = 0;
        PlayerController.Mmoney = 0;
        PlayerController.Status_Reset();
        PlayerController.Item_Reset();
        //�e�퐔�l��������
        Item_Power.turn_compare = 0;
        Item_Power.first_turn = true;
        Item_Power.Boxing_flag = false;
        Enemy_controller.turn = 0;
        Enemy_controller.HP = Enemy_controller.HP_MAX;
        Enemy_controller.tag_get = true;
        Log_list.Log_Clear();//���O��������
    }
    //���g���C���������l��ύX
    public void Retry_Num_Tmp()
    {
        switch (SCENE_CNT)
        {
            case (int)Scene.Battle:   case (int)Scene.Battle_2: case (int)Scene.Boss_Battle_01: scene = Scene.Battle; break;
            case (int)Scene.Battle_4: case (int)Scene.Battle_5: case (int)Scene.Boss_Battle_02: scene = Scene.Battle_4; break;
            case (int)Scene.Battle_7: case (int)Scene.Battle_8: case (int)Scene.Boss_Battle_03: scene = Scene.Battle_7; break;
        }
    }
}