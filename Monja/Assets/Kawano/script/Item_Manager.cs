using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item_Manager : MonoBehaviour
{
    //�O�̂���static�ɂ��Ăǂ��ł��l���ێ������悤�ɂ���
    public static IDictionary<string, bool> Item = new Dictionary<string, bool>();
    private void Awake()
    {
        DontDestroyOnLoad(this);
        Application.targetFrameRate = 60;
        //�����ɃL�[��ݒ�
        if (Item.ContainsKey("healdrink") == false)
        {
            Item.Add("none", false);//��̃L�[��ݒ�i�A�C�e�����Ȃ��Ƃ��̏�ԁj
            //�A�C�e����Item�����ɓo�^
            Item.Add("healdrink", false);
            Item.Add("bowlingball", false);
            Item.Add("CDplayer", false);
            Item.Add("cd", false);
            Item.Add("radio", false);
            Item.Add("hourglass", false);
        }
    }
    public void Start()
    {
       
    }
}