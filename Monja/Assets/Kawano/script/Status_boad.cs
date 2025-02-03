using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status_boad : MonoBehaviour
{
    public GameObject Status_boad_obj;//�X�e�[�^�X�{�[�h�I�u�W�F�N�g
    public Text Back_Text;//�߂�
    public Text Change_Text;
    GameObject Enemy;                   //�G�l�~�[�I�u�W�F�N�g
    Enemy_controller Enemy_controller; //�G�l�~�[�R���g���[���[
    GameObject Player;                 //�v���C���[�I�u�W�F�N�g
    PlayerController PlayerController;//�v���C���[�[�R���g���[���[

    //�G�̃X�e�[�^�X
    public Text Enemy_Name;             //�G�̖��O
    public Text Enmey_max_hp;           //�G�ő�̗�
    public Text Enemy_attack;           //�G�̕����U����
    public Text Enmey_deffence;         //�G�̕����h���
    public Text Enmey_magic;            //�G�̖��@�U����
    public Text Enmey_magic_deffence;   //�G�̖��@�h���

    bool Hit = false;//�{�^���������ꂽ���ǂ���
    bool Change = false;//�F��ς��邩�ǂ���

    //�l�̐F�ύX
    Color Normal = new(255, 255, 255);//���i�W���j
    Color Down = new(0.4f, 0.4f, 1, 1);//�F
    Color Up = new(1, 0, 0, 1);        //�ԐF

    //�X�^�[�g���\�b�h
    // �R���|�[�l���g���擾�A�G�̖��O��\��
    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerController = Player.GetComponent<PlayerController>();
        Enemy = GameObject.Find("Monster");
        Enemy_controller = Enemy.GetComponent<Enemy_controller>();
        if      (Enemy.CompareTag("skelton")) Enemy_Name.text = "�X�P���g��";
        else if (Enemy.CompareTag("Lich")) Enemy_Name.text = "���b�`";
        else if (Enemy.CompareTag("TheGrimReaper")) Enemy_Name.text = "���_";
        else if (Enemy.CompareTag("minotaurus")) Enemy_Name.text = "�~�m�^�E���X";
        else if (Enemy.CompareTag("centaurus")) Enemy_Name.text = "�P���^�E���X";
        else if (Enemy.CompareTag("medhusa")) Enemy_Name.text = "���f���[�T";
        else if (Enemy.CompareTag("cockatrice")) Enemy_Name.text = "�R�J�g���X";
        else if (Enemy.CompareTag("knight")) Enemy_Name.text = "�i�C�g";
        else if (Enemy.CompareTag("dragon")) Enemy_Name.text = "�h���S��";
    }

    private void Update()
    {
        //�G�X�e�[�^�X
        Enemy_attack.text = string.Format("{0}", Enemy_controller.attack);                 //�G�̕����U����
        Enmey_deffence.text = string.Format("{0}", Enemy_controller.Enemy_deffence);             //�G�̕����h���
        Enmey_magic.text = string.Format("{0}", Enemy_controller.magic);                   //�G�̖��@�U����
        Enmey_magic_deffence.text = string.Format("{0}", Enemy_controller.magic_Diffence); //�G�̖��@�h���
        Enmey_max_hp.text = string.Format("{0}", Enemy_controller.HP_MAX);                 //�G�̍ő�̗�
    }

    /// <summary>
    /// �{�^���������ꂽ�ꍇ�\�����邩���߂�֐��ł�
    /// </summary>
    public void Get_Button_Frag()
    {
        if (Hit == false)
        {
            Status_boad_obj.SetActive(true);
            Back_Text.text = "�G�X�e�[�^�X�����";
            Hit = true;
        } 
        else
        {
            Status_boad_obj.SetActive(false);
            Back_Text.text = "�G�X�e�[�^�X���J��";
            Hit = false;
        }
    }
    /// <summary>
    /// �{�^���������ꂽ�Ƃ����l�ɉ����ĐF��ύX���郁�\�b�h
    /// </summary>
    public void Color_Change()
    {
        if (Change == false)
        {

            Change_Text.text = "�F�𖳌��ɂ���";
            //�X�e�[�^�X��r
            //�����U����
            if (PlayerController.Attack_damage < Enemy_controller.attack)
                Enemy_attack.color = Up;
            else if (PlayerController.Attack_damage > Enemy_controller.attack)
                Enemy_attack.color = Down;
            //�����h���
            if (PlayerController.Deffence < Enemy_controller.Enemy_deffence)
                Enmey_deffence.color = Up;
            else if (PlayerController.Deffence > Enemy_controller.Enemy_deffence)
                Enmey_deffence.color = Down;
            //���@�U����
            if (PlayerController.Magic_damage < Enemy_controller.magic)
                Enmey_magic.color = Up;
            else if (PlayerController.Magic_damage > Enemy_controller.magic)
                Enmey_magic.color = Down;
            //���@�h���
            if (PlayerController.Magic_diffence < Enemy_controller.magic_Diffence)
                Enmey_magic_deffence.color = Up;
            else if (PlayerController.Magic_diffence > Enemy_controller.magic_Diffence)
                Enmey_magic_deffence.color = Down;
            Change = true;
        }
        else
        {
            //�F��W���ɖ߂�
            Change_Text.text = "�F��L���ɂ���";
            Enemy_attack.color = Normal;
            Enmey_deffence.color = Normal;
            Enmey_magic.color = Normal;
            Enmey_magic_deffence.color = Normal;
            Change = false;
        }
    }
}