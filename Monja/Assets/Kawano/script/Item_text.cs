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
            text.text = "LIFE\n�W���[�X�ʃW���[�X�B\n[����A�C�e��] \n�̗͂��Q�T���񕜂���";
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

    }

}
