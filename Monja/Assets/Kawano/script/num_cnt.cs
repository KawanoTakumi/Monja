using UnityEngine;
using UnityEngine.UI;

public class num_cnt : MonoBehaviour
{
    //�R���|�[�l���g
    public PlayerController Player;     //�v���C���[�R���g���[���[
    GameObject Enemy;                   //�G�l�~�[�I�u�W�F�N�g
    Enemy_controller Enemy_controller; //�G�l�~�[�R���g���[���[

    //�e�L�X�g
    public Text Attack_text;            //�U����
    public Text Diffence_text;          //�h���
    public Text Magic_text;             //���@��
    public Text Magic_diffence_text;    //���@�h���
    public Text Turn_text;              //�^�[����
    public Text Player_money;           //�������z
    public Text Heal_drink_num;         //�q�[���h�����N�̏�����
    public Text HP_text;                //�v���C���[�̗�
    public Text MP_text;                //�v���C���[MP

    //�G�̃X�e�[�^�X
    public Text Enmey_max_hp;           //�G�ő�̗�
    public Text Enemy_attack;           //�G�̕����U����
    public Text Enmey_deffence;         //�G�̕����h���
    public Text Enmey_magic;            //�G�̖��@�U����
    public Text Enmey_magic_deffence;   //�G�̖��@�h���

    //�X�^�[�g���\�b�h
    //�G�̃X�e�[�^�X���擾
    private void Start()
    {
        Enemy = GameObject.Find("Monster");
        Enemy_controller = Enemy.GetComponent<Enemy_controller>();
    }

    //�A�b�v�f�[�g���\�b�h
    //�����E�E�E���l�𕶎���ɕϊ����ĕ\������
    void Update()
    {
        //int��string�ɕϊ�
        //�v���C���[�X�e�[�^�X
        HP_text.text             = string.Format("{0}", PlayerController.HP);
        MP_text.text             = string.Format("{0}", PlayerController.MP);
        Heal_drink_num.text      = string.Format("{0}", PlayerController.HP_POTION);
        Player_money.text        = string.Format("{0}", PlayerController.MONEY);
        Attack_text.text         = string.Format("{0}", Player.Attack_damage);
        Diffence_text.text       = string.Format("{0}", Player.Deffence);
        Magic_text.text          = string.Format("{0}", Player.Magic_damage);
        Magic_diffence_text.text = string.Format("{0}", Player.Magic_diffence);
        Turn_text.text           = string.Format("{0}", Enemy_controller.turn);

        //�G�X�e�[�^�X
        Enemy_attack.text = string.Format("{0}", Enemy_controller.attack);//�G�̕����U����
        Enmey_deffence.text = string.Format("{0}", Enemy_controller.deffence);//�G�̕����U����
        Enmey_magic.text = string.Format("{0}", Enemy_controller.magic);//�G�̕����U����
        Enmey_magic_deffence.text = string.Format("{0}", Enemy_controller.magic_Diffence);//�G�̖��@�h���
        Enmey_max_hp.text = string.Format("{0}", Enemy_controller.HP_MAX);//�G�̍ő�̗�

    }
}