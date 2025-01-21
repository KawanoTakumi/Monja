using UnityEngine;
using UnityEngine.UI;

public class Bar_controller : MonoBehaviour
{
    public Slider HP_bar;//��l��HP
    public Slider MP_bar;//��l��MP
    public Slider Enemy_HP_bar;//�GHP

    //�X�^�[�g���\�b�h
    //�����E�E�E�e�퐔�l���擾
    void Start()
    {
        //�e���l���X���C�_�[�� Varue�ɓ����
        HP_bar.value          = PlayerController.HP_MAX;
        HP_bar.maxValue       = PlayerController.HP_MAX;
        MP_bar.value          = PlayerController.MP_MAX;
        MP_bar.maxValue       = PlayerController.MP_MAX;
        Enemy_HP_bar.maxValue = Enemy_controller.HP_MAX;
    }
    //�A�b�v�f�[�g���\�b�h
    //�����E�E�E���l���X�V����
    void Update()
    {
        HP_bar.value            = PlayerController.HP;
        MP_bar.value            = PlayerController.MP;
        Enemy_HP_bar.value      = Enemy_controller.HP;
        Enemy_HP_bar.maxValue   = Enemy_controller.HP_MAX;
    }
}