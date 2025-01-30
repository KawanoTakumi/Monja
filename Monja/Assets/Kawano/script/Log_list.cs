using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log_list : MonoBehaviour
{
    //���O�p�̃��X�g��ǉ�
    public static List<string> LogList = new();
    public Text Text;
    public GameObject Log_list_box;
    bool Hit = false;

    //�{�^���������ꂽ�ꍇ���O���J��
    public void Log_Open()
    {
        if(Hit == false)
        {
            Log_list_box.SetActive(true);
            Log_Get();//���O��ǂݍ���
            Hit = true;
        }
        else
        {
            Text.text = "";//�e�L�X�g��������
            Log_list_box.SetActive(false);//���O�����
            Hit = false;
        }
    }
    //���O���e�L�X�g�ɓ����
    void Log_Get()
    {
        //LogList.Reverse();//list���t���ɂ���
        for (int i = 0; i <LogList.Count; i++)
        {
            Text.text += LogList[i];//LogList[0]���珇�Ԃɓ����
        }
    }
    //���O���X�g�̒��g��j��
    //(�����A�����A�I�����ɌĂяo��)
    public static void Log_Clear()
    {
        LogList.Clear();
    }
}