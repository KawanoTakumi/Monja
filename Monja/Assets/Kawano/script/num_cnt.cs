using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class num_cnt : MonoBehaviour
{
    public PlayerController player;//�v���C���[�R���g���[���[
    public Enemy_controller enemy;//�G�l�~�[�R���g���[���[
    public Text attack_Text;//�U����
    public Text diffence_Text;//�h���
    public Text magic_Text;//���@��
    public Text magic_diffence_Text;//���@�h���
    public Text turn_Text;//�^�[����
    public Text player_money;//�������z
    public Text Heal_drink_num;//�q�[���h�����N�̏�����
    public Text HP_Text;//�v���C���[�̗�
    public Text MP_Text;//�v���C���[MP
    void Update()
    {
        //int��string�ɕϊ�
        attack_Text.text = string.Format("{0}",player.Attack);
        diffence_Text.text = string.Format("{0}",player.Diffence);
        magic_Text.text = string.Format("{0}",player.Magic);
        magic_diffence_Text.text = string.Format("{0}",player.Magic_diffence);
        turn_Text.text = string.Format("{0}", Enemy_controller.turn);
        player_money.text = string.Format("{0}", PlayerController.MONEY);
        Heal_drink_num.text = string.Format("{0}", PlayerController.HP_POTION);
        HP_Text.text = string.Format("{0}",PlayerController.HP);
        MP_Text.text = string.Format("{0}",PlayerController.MP);
    }
}