using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turn_manager : MonoBehaviour
{
    public bool turn = true;//turn == trueの時プレイヤーのターン、falseの時敵のターン
    public Text turn_text;
    Color p_turn = new(0, 0, 1, 1);//青色
    Color e_turn = new(1, 0, 0, 1);//赤色

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(turn == true)
        {
            turn_text.color = p_turn;
        }
        else
        {
            turn_text.color = e_turn;
        }
    }
}