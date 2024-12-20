using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_text : MonoBehaviour
{
    public Button button;//�{�^��
    Text itemname;//���O
    Text text;//������
    void Start()
    {
        GameObject Name = GameObject.Find("Item_Name");
        itemname = Name.GetComponent<Text>();
        GameObject Text = GameObject.Find("Item_Text");
        text = Text.GetComponent<Text>();
        button = GetComponent<Button>();
        button.interactable = true;
    }
    public void Hit_button()
    {

        if (button == CompareTag("bowlingball"))
        {
            itemname.text = "�{�E�����O�̋�";
            text.text = "�{�E�����O�Ɏg���Ă����ʁB�����d���B\n\n�����U���͂�20�㏸�����A�����h��͂�20����������";
        }
        else if (button == CompareTag("radio"))
        {
            itemname.text = "���W�I";
            text.text = "�����𖳐��ʐM�ŖT���ł���@�B�B�ǂ����ő̑����n�܂�B\n\n�P�^�[�����Ƃɖh��͂�10���������AHP��5����������";
        }
        else if (button == CompareTag("healdrink"))
        {
            itemname.text = "LIFE";
            text.text = "�ʃW���[�X�B�Â��Ă�������\n\n[����A�C�e��] �̗͂𔼕��񕜂���";
        }
        else if (button == CompareTag("hourglass"))
        {
            itemname.text = "�����v";
            text.text = "�����g�������v�B���Ԃ͗L���B\n\n�P�^�[�����Ƃɕ����U���͂�10�㏸�����A�̗͂�5����������";
        }
        else if (button == CompareTag("cd"))
        {
            itemname.text = "CD";
            text.text = "�f���≹�y���������ނ��Ƃ��ł���B�����Ă��ɂ����B\n\n�����h��͂������قǁA�����U���͂��㏸������";
        }
        else if (button == CompareTag("CDplayer"))
        {
            itemname.text = "CD�v���[���[";
            text.text = "CD���Z�b�g���邱�Ƃŉ��y�𒮂���BCD�͂ǂ��H\n\n�����h��͂�20�㏸�����A�����U���͂�20����������";
        }
        else if (button == CompareTag("kesigomu"))
        {
            itemname.text = "�����S��";
            text.text = "���������̂�������B���ʂȂ��̂�������\n\n�����U���͂��Q�O���������A�����U���͂������قǖ��@�U���͂�������";
        }
        else if (button == CompareTag("TV"))
        {
            itemname.text = "�e���r";
            text.text = "�f���������ł���@�B�B���Ȃ��̂��D���Ȕԑg�͉��H\n\n���@�U���͂T�ɂ����@�U���͂��R�㏸������";
        }
        else if (button == CompareTag("CreditCard"))
        {
            itemname.text = "�N���W�b�g�J�[�h";
            text.text = "���������Ă�����J�[�h�B�F�ł��̐l�̉��l���킩��B\n\n�퓬�J�n��Q�OG�������ɒǉ�����\n";
        }
        else if (button == CompareTag("Mouse"))
        {
            itemname.text = "�}�E�X";
            text.text = "�p�\�R�����g���Ƃ��ɕK�{�̋@�B�B�}�E�X�Ȃ��͍l�����Ȃ�\n\n���@�U���͂��P�O����������";
        }
        else if (button == CompareTag("HandMirror"))
        {
            itemname.text = "�n���h�~���[";
            text.text = "��y�ɗe�p���m�F�ł���R���p�N�g�ȋ��B���拾�A�������̂͒N�H\n\n�����h��͂Ɩ��@�h��͂��P�T����������";
        }
        else if (button == CompareTag("bowlingpin"))
        {
            itemname.text = "�{�E�����O�s��";
            text.text = "�{�E�����O�œ��_�����߂邽�߂̂��́B�l�ɂ͂��ĂȂ���\n\n�퓬�J�n���A�����U���͂������قǊl�����z������";
        }
        else if (button == CompareTag("baseball_ball"))
        {
            itemname.text = "�싅�{�[��";
            text.text = "�싅�p�̃{�[���B�X�g���[�C�N�A�o�b�^�[�A�E�g\n\n�����U���͂��P�T�����������h��͂��P�O����������";
        }
        else if (button == CompareTag("dice"))
        {
            itemname.text = "�T�C�R��";
            text.text = "�����_���Ő��������߂邽�߂̓���B1d6? 2d6?\n\n�P�^�[�����ƂɃ����_���Ȍ��ʂ𔭓�";
        }
        else if (button == CompareTag("Water bucket"))
        {
            itemname.text = "������̃o�P�c";
            text.text = "�����������o�P�c�B�A�C�X�o�P�c�`�������W�I�I�I\n\n���@�h��͂��P�O����������";
        }
        else if (button == CompareTag("Popcorn"))
        {
            itemname.text = "�|�b�v�R�[��";
            text.text = "�g�E�����R�V�������ł͂������������َq�B�f��ɂ͕K�{�̂���\n\n�퓬�J�n���A�̗͂��Q�O�񕜂�����";
        }
        else if (button == CompareTag("Apple"))
        {
            itemname.text = "�����S";
            text.text = "�Ԃ��ĊÂ��؂Ɏ���ʎ��B�Ђ�߂��̎�\n\n�퓬�J�n���A�̗͂��R�O�񕜂��A���@�U���͂��P�T����������";
        }
        else if (button == CompareTag("Scissors"))
        {
            itemname.text = "�n�T�~";
            text.text = "���Ȃǂ�؂邽�߂�����B�ǂ�ȃJ�b�g�����D�݁H\n\n�����U���͂�30���������邪�^�[�����ɕ����h��͂�2����������";
        }
        else if (button == CompareTag("ice"))
        {
            itemname.text = "�X";
            text.text = "���𓀂点��Ƃł��镨�́B�����X�ɂ��܂����H\n\n���@�U���͂��P�O���������A�X�̒e�ōU������i�A�C�e����ʂŃA�C�e���������Ɩ��@�U�����ω��j";
        }
        else if (button == CompareTag("Pudding"))
        {
            itemname.text = "�v����";
            text.text = "���������Ȃǂƈꏏ�Ɍł߂��Â����َq�B�����̎���\n\n�퓬�J�n���̗͂��ő�l��25%���񕜂���B\n�܂��A�����S�������Ă���Ɛ퓬���Ƃɍő�̗͂�30��������";
        }
        else if (button == CompareTag("Drill"))
        {
            itemname.text = "�h����";
            text.text = "���Ɍ����J���铹��B���̊J�������ɂ͒���\n\n�퓬�J�n���A�G�l�~�[�̕����U���͕��v���C���[�U���͂𑝉������A�G�l�~�[�̕����h��͕��v���C���[�̕����h��͂�����������";
        }
        else if (button == CompareTag("Headphone"))
        {
            itemname.text = "�w�b�h�t�H��";
            text.text = "���ɂ��邱�Ƃŉ��y�𕷂����Ƃ��ł��铹��B�����̐��E�ɓ����Ă��܂�\n\n�^�[�����ɕ����U���͂ƕ����h��͂��R����\n�̗͂��P�O��";
        }
        else if (button == CompareTag("UtypeMagnet"))
        {
            itemname.text = "U���^�}�O�l�b�g";
            text.text = "U���^�̃}�O�l�b�g�B���͂Ȏ��͂�ттĂ���B�G�̕���������t��\n\n���@�U���͂Q�O��������";
        }
        else if (button == CompareTag("Coffee"))
        {
            itemname.text = "�R�[�q�[";
            text.text = "�������������������B�ƂĂ��ꂢ�BChill Time !!!\n\n�̗͂��Q�O���炵���@�U���͂��R�O����������";
        }
        else if (button == CompareTag("Safetycone"))
        {
            itemname.text = "�O�p�R�[��";
            text.text = "�댯�ȏꏊ�ɐݒu���Ă�����́B���܂ɏR����s�^�ȓz\n\n�퓬�J�n���A�Q�T���̊m���ŕ����U���͂ƕ����h��͂��S�O����";
        }
        else if (button == CompareTag("USB"))
        {
            itemname.text = "USB������";
            text.text = "�p�\�R���������ۑ��ł���@�B�B�Ȃ�������I���\n\n���@�U���͂��Q�O�����������@�h��͂��P�O����������";
        }
        else if (button == CompareTag("Smartphone"))
        {
            itemname.text = "�X�}�[�g�t�H��";
            text.text = "�l�i�������l�X�ȋ@�\�̂����d�b�@��B��񂲂̃}�[�N�B\n\n���@�U���͂������قǖ��@�h��͂𑝉�������";
        }
        else if (button == CompareTag("ItypeMagnet"))
        {
            itemname.text = "I���^�}�O�l�b�g";
            text.text = "I���^�̃}�O�l�b�g�BU���^�Ƃ������ĕς��Ȃ��B\n\n���@�h��͂��Q�O����������";
        }
        else if (button == CompareTag("Magnifying Speculum"))
        {
            itemname.text = "���ዾ";
            text.text = "�����g�債�Č��邱�Ƃ��ł��铹��B�����Y���P��\n\n���^�[�������h��͂Ɩ��@�h��͂�3����������";
        }
        else if (button == CompareTag("Mike"))
        {
            itemname.text = "�}�C�N";
            text.text = "�����E�����Ƃ��ł���@�B�BSay Yeah!!\n\n���@�U���͂��R�O�����������̃m�C�Y�ōU������\n�i�A�C�e����ʂŃA�C�e���������Ɩ��@�U�����ω��j";
        }
        else if (button == CompareTag("Megaphone"))
        {
            itemname.text = "���K�z��";
            text.text = "����傫������@�B�B�����吺���o���Ȃ��Ă�����\n\n�����h��͂��Q�O����������";
        }
        else if (button == CompareTag("HandMill"))
        {
            itemname.text = "�n���h�~��";
            text.text = "����҂����߂̓���B���΂������肪���Ă邺�B\n\n�R�[�q�[�������Ă��鎞�A���@�U���͂��U�O����������\n�����Ă��Ȃ����͖��@�U���͂��R�O����������";
        }
        else if(button == CompareTag("Poteto"))
        {
            itemname.text = "�|�e�g";
            text.text = "�W���K�C������ŗg�����H�ו��B�H�ׂ�̂���߂��Ȃ�\n\n�n���o�[�K�[�������Ă��鎞�����U���͂�60���������A�����Ă��Ȃ����͕����U���͂��R�O����������";
        }
        else if (button == CompareTag("Scop"))
        {
            itemname.text = "�V���x��";
            text.text = "�y���@������A�炵����ł���B\n\n�S���̂P�̊m���ł������R�O���肷��";
        }
        else if (button == CompareTag("hammer"))
        {
            itemname.text = "�n���}�[";
            text.text = "�l�X�ȗp�r�����閜�\�ȓ���\n\n�P�O���̂P�̊m���ő�����C�₳����";
        }
        else if (button == CompareTag("Bugle"))
        {
            itemname.text = "���b�p";
            text.text = "�l�X�ȉ���t�ł���������̊y��B�J���e�b�g�H\n\n";
        }
        else if (button == CompareTag("Sylinge"))
        {
            itemname.text = "���ˊ�";
            text.text = "��ÖړI�Ŏg����A��[�����������\n\n�U���̂P�̊m���ő̗͂��R�O�񕜂����A����ȊO�̎��͂T�񕜂�����";
        }
        else if (button == CompareTag("Baseball_glove"))
        {
            itemname.text = "�싅�O���[�u";
            text.text = "�싅�Ŏg����O���[�u�B��ɂ悭�t�B�b�g����\n\n�����U���͂��Q�T����������B�싅�{�[�����������Ă���A\n���@�U���͂��Q�T����������";
        }
        else if (button == CompareTag("Boxing_glove"))
        {
            itemname.text = "�{�N�V���O�O���[�u";
            text.text = "�{�N�V���O�Ŏg�p�����O���[�u,�ꔭKO\n\n�R�E�Q�L���������Ƃ������U���͂��P����������";
        }
        else if (button == CompareTag("Juice"))
        {
            itemname.text = "�W���[�X";
            text.text = "�ʏ`�Ȃǂ��������������B�������͂킩��Ȃ�\n\n";
        }
        else if (button == CompareTag("Gas_burner"))
        {
            itemname.text = "�K�X�o�[�i�[";
            text.text = "�K�X�ŔM�𐶂ݏo������B�_�f�����u���R�₹�I�I�I\n\n";
        }
        else if (button == CompareTag("Hamberger"))
        {
            itemname.text = "�n���o�[�K�[";
            text.text = "�W�����N�t�[�h�̉��l�B�J�����[�������B����O�H������\n\n";
        }
        else if (button == CompareTag("Pencil"))
        {
            itemname.text = "���M";
            text.text = "�����������A�F��d���Ɏ�ނ�����BH ore HB ore B?\n\n";
        }
        else if (button == CompareTag("Mayonnaise"))
        {
            itemname.text = "�}���l�[�Y";
            text.text = "���Ɩ��ō�钲�����B�ꕔ�̐l�͂�����������Ƃ����肷��Ƃ�\n\n";
        }
        else if (button == CompareTag("Watch"))
        {
            itemname.text = "�r���v";
            text.text = "";
        }
        else if (button == CompareTag("Kama"))
        {
            itemname.text = "���_�̊�";
            text.text = "�؂ꖡ���������B���܂Ŋ����Ă��܂�\n\n�����U���͂�40���������A�N���e�B�J�������Ȃ蔭�����₷���Ȃ�";
        }
        else if (button == CompareTag("Robe"))
        {
            itemname.text = "���_�̃��[�u";
            text.text = "���_�����Ă������[�u�B�Ђ���Ɨ₽��\n\n�����h��͂�40���������A�N���e�B�J�����������₷���Ȃ�";
        }
        else if (button == CompareTag("Scale"))
        {
            itemname.text = "���f���[�T�̗�";
            text.text = "���f���[�T�̐K���̕����̗؁B�ƂĂ��d��\n\n���@�U���͂�40���������A�N���e�B�J�����o�₷���Ȃ�";
        }
        else if (button == CompareTag("MagicBook"))
        {
            itemname.text = "���f���[�T�̖�����";
            text.text = "���f���[�T���g���Ă����������B������Ă��镶���͉�ǂł��Ȃ�\n\n���@�h��͂�40���������A�N���e�B�J�����o�₷���Ȃ�\n�i�A�C�e����ʂŃA�C�e���������Ɩ��@�U�����ω��j";
        }
        else if (button == CompareTag("Juwel"))
        {
            itemname.text = "�h���S���̉��̌���";
            text.text = "�h���S���̑̓��Ő������ꂽ�����B�ق�̂�ƒg����\n\n�ő�̗͂�20����������";
        }
        else if (button == CompareTag("Tooth"))
        {
            itemname.text = "�h���S���̉�";
            text.text = "�h���S���̉s����B��舵���ɂ͒���\n\n�ő��20����������";
        }
    }

    //���@�U�����ォ��ύX���邽�߂̊֐��i�A�C�e����ʂŃ{�^�����������炻�̖��@�U���ɂȂ�j
    public void magic_number(int num_M)
    {
        PlayerController.magic_number = num_M;
    }
}