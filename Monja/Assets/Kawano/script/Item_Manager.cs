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
            text.text = "aaa";
        }
        else if (button == CompareTag("radio"))
        {
            text.text = "bbb";
        }
        else if (button == CompareTag("healdrink"))
        {
            text.text = "ccc";
        }
    }
}