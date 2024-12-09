using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turn_manager : MonoBehaviour
{
    public static bool turn = true;//turn == trueの時プレイヤーのターン、falseの時敵のターン
    public static int turn_time_max = 80;
    public Text turn_text;
    public Text Log_text;
    Color p_turn = new(0.4f, 0.4f, 1, 1);//青色
    Color e_turn = new(1, 0, 0, 1);//赤色

    // Update is called once per frame
    void Update()
    {
        //true = 青色、false = 赤色
        if(turn == true)
        {
            turn_text.color = p_turn;
            Log_text.color = p_turn;
        }
        else
        {
            turn_text.color = e_turn;
            Log_text.color = e_turn;
        }
    }
}