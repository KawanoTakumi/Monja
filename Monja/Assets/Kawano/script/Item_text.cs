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
            text.text = "�����S��\n���������̂�������B���ʂȂ��̂�������\n";
        }
        else if (button == CompareTag("TV"))
        {
            text.text = "�e���r\n�f���������ł���@�B�B���Ȃ��̂��D���Ȕԑg�͉��H\n";
        }
        else if (button == CompareTag("CreditCard"))
        {
            text.text = "�N���W�b�g�J�[�h\n���������Ă�����J�[�h�B�F�ł��̐l�̉��l���킩��B\n";
        }
        else if (button == CompareTag("Mouse"))
        {
            text.text = "�}�E�X\n�p�\�R�����g���Ƃ��ɕK�{�̋@�B�B�}�E�X�Ȃ��͍l�����Ȃ�\n";
        }
        else if (button == CompareTag("HandMirror"))
        {
            text.text = "�n���h�~���[\n��y�ɗe�p���m�F�ł���R���p�N�g�ȋ��B���拾�A�������̂͒N�H\n";
        }
        else if (button == CompareTag("bowlingpin"))
        {
            text.text = "�{�E�����O�s��\n�{�E�����O�œ��_�����߂邽�߂̂��́B�l�ɂ͂��ĂȂ���\n";
        }
        else if (button == CompareTag("baseball_ball"))
        {
            text.text = "�싅�{�[��\n�싅�p�̃{�[���B�X�g���[�C�N�A�o�b�^�[�A�E�g\n";
        }
        else if (button == CompareTag("dice"))
        {
            text.text = "�T�C�R��\n�����_���Ő��������߂邽�߂̓���B�����_�����Ă������\n";
        }
        else if (button == CompareTag("Water bucket"))
        {
            text.text = "������̃o�P�c\n�����������o�P�c�B�A�C�X�o�P�c�`�������W�I�I�I\n";
        }
        else if (button == CompareTag("Popcorn"))
        {
            text.text = "�|�b�v�R�[��\n�g�E�����R�V�������ł͂������������َq�B�f��̂���\n";
        }
        else if (button == CompareTag("Apple"))
        {
            text.text = "�����S\n�Ԃ��ĊÂ��؂Ɏ���ʎ��B�Ђ�߂��̎�\n";
        }
        else if (button == CompareTag("Scissors"))
        {
            text.text = "�n�T�~\n���Ȃǂ�؂邽�߂�����B�ǂ�ȃJ�b�g�����D�݁H\n";
        }
        else if (button == CompareTag("ice"))
        {
            text.text = "�X\n���𓀂点��Ƃł��镨�́B�悭�X�x��\n";
        }
        else if (button == CompareTag("Pudding"))
        {
            text.text = "�v����\n���������Ȃǂƈꏏ�Ɍł߂��Â����َq�B�����̎���\n";
        }
        else if (button == CompareTag("Drill"))
        {
            text.text = "�h����\n���Ɍ����J���铹��B����������ďΊ�̂�͊�Ȃ�����\n";
        }
        else if (button == CompareTag("Headphone"))
        {
            text.text = "�w�b�h�t�H��\n���ɂ��邱�Ƃŉ��y�𕷂����Ƃ��ł��铹��B�����̐��E�ɓ����Ă��܂�\n";
        }
        else if (button == CompareTag("UtypeMagnet"))
        {
            text.text = "U���^�}�O�l�b�g\nU���^�̃}�O�l�b�g�B���͂Ȏ��͂�ттĂ���B�G�̕���������t��\n";
        }
        else if (button == CompareTag("Coffee"))
        {
            text.text = "�R�[�q�[\n�������������������B�ƂĂ��ꂢ�B\nChill Time !!!\n";
        }
        else if (button == CompareTag("Safetycone"))
        {
            text.text = "�O�p�R�[��\n�댯�ȏꏊ�ɐݒu���Ă�����́B���܂ɂ�������s�^�ȓz\n";
        }
        else if (button == CompareTag("USB"))
        {
            text.text = "USB������\n�p�\�R���������ۑ��ł���@�B�B�Ȃ�������I���\n";
        }
        else if (button == CompareTag("Smartphone"))
        {
            text.text = "�X�}�[�g�t�H��\n�l�i�������l�X�ȋ@�\�̂����d�b�@��B��񂲂̃}�[�N�B\n";
        }
        else if (button == CompareTag("ItypeMagnet"))
        {
            text.text = "I���^�}�O�l�b�g\nI���^�̃}�O�l�b�g�BU���^�Ƃ������ĕς��Ȃ��B\n";
        }
        else if (button == CompareTag("Magnifying Speculum"))
        {
            text.text = "���ዾ\n�����g�債�Č��邱�Ƃ��ł���c�[���B�����Ƌ󂪐���Ă����炳���������I�I\n";
        }
        else if (button == CompareTag("Mike"))
        {
            text.text = "�}�C�N\n�����E�����Ƃ��ł���@�B�BSay Yeah!!\n";
        }
        else if (button == CompareTag("Megaphon"))
        {
            text.text = "���K�z��\n����傫������@�B�B�����吺���o���Ȃ��Ă�����\n";
        }
        else if (button == CompareTag("HandMill"))
        {
            text.text = "�n���h�~��\n����҂����߂̓���B���΂������肪���Ă邺�B\n";
        }

    }
}
