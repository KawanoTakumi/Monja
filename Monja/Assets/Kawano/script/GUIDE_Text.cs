using UnityEngine;
using UnityEngine.UI;

public class GUIDE_Text : MonoBehaviour
{
    public Text Guide_text;             //������
    public Text Guide_title;            //�����̃^�C�g��
    public Image Guide_image_target;    //�\����摜
    public Sprite[] Guide_image_source; //�\�����摜

    //�X�^�[�g�֐�
    //�����E�E�E�R���|�[�l���g���擾
    public void Start()
    {
        Guide_image_target = GetComponent<Image>();
    }
    //�{�^���������ꂽ���A�\������摜�ƃe�L�X�g��ύX����(�ύX����ԍ�)
    public void Text_Change_Guide(int change_num)
    {
        switch (change_num)
        {
            case 1:
                {
                    //�퓬���
                    Guide_image_target.sprite = Guide_image_source[0];
                    Guide_title.text = "�퓬���";
                    Guide_text.text = "��{����̓}�E�X�̍��N���b�N�̂�\n�U���Q�L�A�}�z�E�A�V���E�`���E�A�J�C�t�N�̎l�̃{�^����I�����ēG��|���Ă���\n\n" +
                                    "�@�@�U���Q�L�E�E�E�����̍U���͂��瑊��̖h��͂̐��l���������_���[�W��^����\n�@�@�@�}�z�E�E�E�E�l�o������ă}�z�E�U���͂��瑊��̃}�z�E�h��͂��������_���[�W��^����\n" +
                                    "�V���E�`���E�E�E�E�l�o�𔼕��J�C�t�N���A�}�z�E�U���͂��P�^�[������������\n�@�@�J�C�t�N�E�E�E�񕜃A�C�e���������Ă���ꍇ�����̗̑͂��񕜂���\n\n" +
                                    "��ʂ̍������̐Ԃ��Q�[�W�̗͑́A���Q�[�W�͂l�o��\��\n" +
                                    "���̉��̂S�̐��l�͍��オ�����U���́A�E�オ�����h��́A���������@�U���́A�E�������@�h��͂�\���Ă���\n" +
                                    "�^�񒆂̊ʂ͉񕜃A�C�e���̏�������\���Ă���";
                }
                break;
            case 2:
                {
                    //�V���b�v���
                    Guide_image_target.sprite = Guide_image_source[1];
                    Guide_title.text = "�V���b�v���";
                    Guide_text.text = "��{����̓}�E�X�̍��N���b�N�̂�\n�G��|���ē��肵�������ŃA�C�e���𔃂���\n�V���b�v�ɕ��ԃA�C�e���̓����_���ł���A�w������̂ɕK�v�ȋ��z�͍��ɕ��ԃA�C�e��������������\n\n" +
                        "�w���ς݂̃A�C�e�������Ȃ��Ƃ���A�ق����A�C�e�����Ȃ��Ƃ��͉�ʍ��ɂ��郊���[���{�^������A�C�e����ύX���邱�Ƃ��ł���\n" +
                        "�܂��A�Ƃ�������𖞂����Ȃ��Əo�����Ȃ��A�C�e�����E�E�E\n";
                }
                break;
        }
    }
}