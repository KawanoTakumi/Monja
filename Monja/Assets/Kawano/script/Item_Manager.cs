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
            Item.Add("healdrink", false);//0
            Item.Add("bowlingball", false);//1
            Item.Add("CDplayer", false);//2
            Item.Add("cd", false);//3
            Item.Add("radio", false);//4
            Item.Add("hourglass", false);//5

            Item.Add("kesigomu", false);//6
            Item.Add("TV", false);//7
            Item.Add("CreditCard", false);//8
            Item.Add("Mouse", false);//9
            Item.Add("HandMirror", false);//10
            Item.Add("bowlingpin", false);//11
            Item.Add("baseball_ball", false);//12
            Item.Add("dice", false);//13
            Item.Add("dice", false);//14
            Item.Add("dice", false);//15
            Item.Add("dice", false);//16
        }
    }
    public void Start()
    {
       
    }
}