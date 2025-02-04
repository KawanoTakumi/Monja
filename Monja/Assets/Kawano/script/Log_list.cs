using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Log_list : MonoBehaviour
{
    //���O�p�̃��X�g��ǉ�
    public static List<string> LogList = new();
    public TextMeshProUGUI Log_text;
    public GameObject Log_list_box;
    bool Hit = false;
    Vector3 pos;

    private void Start()
    {
        pos = Log_text.GetComponent<RectTransform>().anchoredPosition;
    }
    public void Update()
    {
        //Log_text��Pos.y���O����ɂ����Ȃ��悤�ɂ���
        if (Log_text.GetComponent<RectTransform>().anchoredPosition.y > 0)
            Log_text.GetComponent<RectTransform>().anchoredPosition = pos;
    }
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
            Log_text.text = "";//�e�L�X�g��������
            pos.y = 0f;
            Log_text.GetComponent<RectTransform>().anchoredPosition = pos;
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
            Log_text.text += LogList[i];//LogList[0]���珇�Ԃɓ����
        }
    }
    //���O���X�g�̒��g��j��
    //(�����A�����A�I�����ɌĂяo��)
    public static void Log_Clear()
    {
        LogList.Clear();
    }
}