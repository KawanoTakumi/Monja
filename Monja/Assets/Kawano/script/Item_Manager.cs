using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item_Manager : MonoBehaviour
{
    public Button button;//�{�^��
    public Text text;//������
    public void Hit_button()
    {
        if (button == CompareTag("bowlingball"))
        {
            text.text = "�{�[�����O�̋�                        �{�[�����O�Ɏg���Ă����ʁB�����d���B �����U���͂�20�㏸�����A�����h��͂�20����������";
        }
        else if (button == CompareTag("radio"))
        {
            text.text = "���W�I �����𖳐��ʐM�ŖT���ł���@�B�B�ǂ����ő̑����n�܂�B �P�^�[�����Ƃɖh��͂�10���������AHP��5����������";
        }
        else if (button == CompareTag("healdrink"))
        {
            text.text = "LIFE                                                                 �W���[�X�ʃW���[�X�B �̗͂��Q�T���񕜂���";
        }
        else if (button == CompareTag("hourglass"))
        {
            text.text = "�����v                                                 �����g�������v�B���Ԃ͗L���B �P�^�[�����ƂɍU���͂�10�㏸�����A�̗͂�5����������";
        } 
        else if (button == CompareTag("cd"))
        {
            text.text = "CD               �f���≹�y���������ނ��Ƃ��ł���B�����Ă��ɂ����B �����h��͂������قǁA�����U���͂��㏸������";
        }
        else if (button == CompareTag("CDplayer"))
        {
            text.text = "CD�v���[���[ CD���Z�b�g���邱�Ƃŉ��y�𒮂���BCD�͂ǂ��H �����h��͂�20�㏸�����A�����U���͂�20����������";
        }

    }
}