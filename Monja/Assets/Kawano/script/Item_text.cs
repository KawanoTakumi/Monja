using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_text : MonoBehaviour
{
    public Button button;//�{�^��
    Text text;//������
    // Start is called before the first frame update
    void Start()
    {
        GameObject Text = GameObject.Find("Item_Text");
        text = Text.GetComponent<Text>();

        button = GetComponent<Button>();
        button.interactable = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit_button()
    {

        if (button == CompareTag("bowlingball"))
        {
            text.text = "�{�[�����O�̋�\n�{�[�����O�Ɏg���Ă����ʁB�����d���B\n�����U���͂�20�㏸�����A�����h��͂�20����������";
        }
        else if (button == CompareTag("radio"))
        {
            text.text = "���W�I\n�����𖳐��ʐM�ŖT���ł���@�B�B�ǂ����ő̑����n�܂�B\n�P�^�[�����Ƃɖh��͂�10���������AHP��5����������";
        }
        else if (button == CompareTag("healdrink"))
        {
            text.text = "LIFE\n�W���[�X�ʃW���[�X�B\n[����A�C�e��] �@�̗͂��Q�T���񕜂���";
        }
        else if (button == CompareTag("hourglass"))
        {
            text.text = "�����v\n�����g�������v�B���Ԃ͗L���B\n�P�^�[�����ƂɍU���͂�10�㏸�����A�̗͂�5����������";
        }
        else if (button == CompareTag("cd"))
        {
            text.text = "CD\n�f���≹�y���������ނ��Ƃ��ł���B�����Ă��ɂ����B\n�����h��͂������قǁA�����U���͂��㏸������";
        }
        else if (button == CompareTag("CDplayer"))
        {
            text.text = "CD�v���[���[\nCD���Z�b�g���邱�Ƃŉ��y�𒮂���BCD�͂ǂ��H\n�����h��͂�20�㏸�����A�����U���͂�20����������";
        }
        else if (button == CompareTag("kesigomu"))
        {
            text.text = "�����S��\n���������̂�������B���ʂȂ��̂�������\n�����U���͂��Q�T���������A�����U���͂������قǖ��@�U���͂�������";
        }
        else if (button == CompareTag("TV"))
        {
            text.text = "�e���r\n�f���������ł���@�B�B���Ȃ��̂��D���Ȕԑg�͉��H\n���@�U���͂Q�O�ɂ����@�U���͂��Q�㏸������";
        }
        else if (button == CompareTag("CreditCard"))
        {
            text.text = "�N���W�b�g�J�[�h\n���������Ă�����J�[�h�B�F�ł��̐l�̉��l���킩��B\n�l�����z���S�O����������\n";
        }
        else if (button == CompareTag("Mouse"))
        {
            text.text = "�}�E�X\n�p�\�R�����g���Ƃ��ɕK�{�̋@�B�B�}�E�X�Ȃ��͍l�����Ȃ�\n���@�U���͂��Q�O����������";
        }
        else if (button == CompareTag("HandMirror"))
        {
            text.text = "�n���h�~���[\n��y�ɗe�p���m�F�ł���R���p�N�g�ȋ��B���拾�A�������̂͒N�H\n�����h��͂Ɩ��@�h��͂��R�O����������\n";
        }
        else if (button == CompareTag("bowlingpin"))
        {
            text.text = "�{�E�����O�s��\n�{�E�����O�œ��_�����߂邽�߂̂��́B�l�ɂ͂��ĂȂ���\n�퓬�J�n���A�����U���͂������قǊl�����z������";
        }
        else if (button == CompareTag("baseball_ball"))
        {
            text.text = "�싅�{�[��\n�싅�p�̃{�[���B�X�g���[�C�N�A�o�b�^�[�A�E�g\n�����U���͂��R�O�����������h��͂��R�O����������";
        }
        else if (button == CompareTag("dice"))
        {
            text.text = "�T�C�R��\n�����_���Ő��������߂邽�߂̓���B1d6? 2d6?\n�P�^�[�����ƂɃ����_���Ȍ��ʂ𔭓�";
        }
        else if (button == CompareTag("Water bucket"))
        {
            text.text = "������̃o�P�c\n�����������o�P�c�B�A�C�X�o�P�c�`�������W�I�I�I\n���@�h��͂��Q�O����������";
        }
        else if (button == CompareTag("Popcorn"))
        {
            text.text = "�|�b�v�R�[��\n�g�E�����R�V�������ł͂������������َq�B�f��ɂ͕K�{�̂���\n�퓬�J�n���A�̗͂��S�O�񕜂�����";
        }
        else if (button == CompareTag("Apple"))
        {
            text.text = "�����S\n�Ԃ��ĊÂ��؂Ɏ���ʎ��B�Ђ�߂��̎�\n�퓬�J�n���A�̗͂��R�O�񕜂��A���@�U���͂��P�T����������";
        }
        else if (button == CompareTag("Scissors"))
        {
            text.text = "�n�T�~\n���Ȃǂ�؂邽�߂�����B�ǂ�ȃJ�b�g�����D�݁H\n�����U���͂��Q�O����������";
        }
        else if (button == CompareTag("ice"))
        {
            text.text = "�X\n���𓀂点��Ƃł��镨�́B�����X�ɂ��܂����H\n���@�U���͂��Q�O���������A�X�̒e�ōU������i�A�C�e����ʂŃA�C�e���������Ɩ��@�U�����ω��j";
        }
        else if (button == CompareTag("Pudding"))
        {
            text.text = "�v����\n���������Ȃǂƈꏏ�Ɍł߂��Â����َq�B�����̎���\n�퓬�J�n���̗͂��ő�l��25%���񕜂���B\n�����S�������Ă���Ɛ퓬���Ƃɍő�̗͂�30��������";
        }
        else if (button == CompareTag("Drill"))
        {
            text.text = "�h����\n���Ɍ����J���铹��B���̊J�������ɂ͒���\n�G�l�~�[�̕����U���͕��v���C���[�U���͂𑝉������A�G�l�~�[�̕����h��͕��v���C���[�̕����h��͂�����������";
        }
        else if (button == CompareTag("Headphone"))
        {
            text.text = "�w�b�h�t�H��\n���ɂ��邱�Ƃŉ��y�𕷂����Ƃ��ł��铹��B�����̐��E�ɓ����Ă��܂�\n�^�[�����ɕ����U���͂ƕ����h��͂��R����\n�̗͂��P�O��";
        }
        else if (button == CompareTag("UtypeMagnet"))
        {
            text.text = "U���^�}�O�l�b�g\nU���^�̃}�O�l�b�g�B���͂Ȏ��͂�ттĂ���B\n�G�̕���������t��\n���@�U���͂Q�O��������";
        }
        else if (button == CompareTag("Coffee"))
        {
            text.text = "�R�[�q�[\n�������������������B�ƂĂ��ꂢ�B\nChill Time !!!\n�̗͂��Q�O���炵���@�U���͂��R�O����������";
        }
        else if (button == CompareTag("Safetycone"))
        {
            text.text = "�O�p�R�[��\n�댯�ȏꏊ�ɐݒu���Ă�����́B\n���܂ɏR����s�^�ȓz\n�T�O���̊m���ŕ����U���͂ƕ����h��͂��S�O����";
        }
        else if (button == CompareTag("USB"))
        {
            text.text = "USB������\n�p�\�R���������ۑ��ł���@�B�B�Ȃ�������I���\n���@�U���͂��R�O�����������@�h��͂��Q�O����������";
        }
        else if (button == CompareTag("Smartphone"))
        {
            text.text = "�X�}�[�g�t�H��\n�l�i�������l�X�ȋ@�\�̂����d�b�@��B��񂲂̃}�[�N�B\n���@�U���͂������قǖ��@�h��͂𑝉�������";
        }
        else if (button == CompareTag("ItypeMagnet"))
        {
            text.text = "I���^�}�O�l�b�g\nI���^�̃}�O�l�b�g�BU���^�Ƃ������ĕς��Ȃ��B\n���@�h��͂��Q�O����������";
        }
        else if (button == CompareTag("Magnifying Speculum"))
        {
            text.text = "���ዾ\n�����g�債�Č��邱�Ƃ��ł���c�[���B�����Ƌ󂪐���Ă�����ō�da�I�I\n�����h��͂Ɩ��@�h��͂𖈃^�[���P�O����������";
        }
        else if (button == CompareTag("Mike"))
        {
            text.text = "�}�C�N\n�����E�����Ƃ��ł���@�B�BSay Yeah!!\n���@�U���͂��R�O�����������̃m�C�Y�ōU������i�A�C�e����ʂŃA�C�e���������Ɩ��@�U�����ω��j";
        }
        else if (button == CompareTag("Megaphone"))
        {
            text.text = "���K�z��\n����傫������@�B�B�����吺���o���Ȃ��Ă�����\n�����h��͂��Q�O����������";
        }
        else if (button == CompareTag("HandMill"))
        {
            text.text = "�n���h�~��\n����҂����߂̓���B���΂������肪���Ă邺�B\n�R�[�q�[�������Ă��鎞���@�U���͂��U�O����������\n�����Ă��Ȃ����͖��@�U���͂��R�O����������";
        }
    }

    //���@�U�����ォ��ύX���邽�߂̊֐��i�A�C�e����ʂŃ{�^�����������炻�̖��@�U���ɂȂ�j
    public void magic_number(int num_M)
    {
        PlayerController.magic_number = num_M;
    }


}
