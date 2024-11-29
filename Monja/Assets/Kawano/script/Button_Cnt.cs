using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Cnt : MonoBehaviour
{
    public Button title_button;//タイトルに戻るボタン
    // Update is called once per frame
    void Update()
    {
        if(ChangeScene.scene_cnt == 0)
        {
            title_button.interactable = false;
        }
        else
        {
            title_button.interactable = true;
        }
    }
}