using UnityEngine;
using UnityEngine.UI;

public class num_cnt : MonoBehaviour
{
    //�R���|�[�l���g
    public PlayerController Player;     //�v���C���[�R���g���[���[

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

    //�A�b�v�f�[�g���\�b�h
    //�����E�E�E���l�𕶎���ɕϊ����ĕ\������
    void Update()
    {
        //int��string�ɕϊ�
        //�v���C���[�X�e�[�^�X
        HP_text.text             = string.Format("{0}", PlayerController.HP);
        MP_text.text             = string.Format("{0}", PlayerController.MP);
        Heal_drink_num.text      = string.Format("{0}", PlayerController.HP_potion);
        Player_money.text        = string.Format("{0}", PlayerController.Mmoney);
        Attack_text.text         = string.Format("{0}", Player.Attack_damage);
        Diffence_text.text       = string.Format("{0}", Player.Deffence);
        Magic_text.text          = string.Format("{0}", Player.Magic_damage);
        Magic_diffence_text.text = string.Format("{0}", Player.Magic_diffence);
        Turn_text.text           = string.Format("{0}", Enemy_controller.turn);

    }
}