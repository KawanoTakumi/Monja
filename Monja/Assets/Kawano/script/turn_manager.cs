using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turn_manager : MonoBehaviour
{
    public static bool turn = true;//turn == true�̎��v���C���[�̃^�[���Afalse�̎��G�̃^�[��
    public static int turn_time_max = 80;
    public Text turn_text;
    public Text Log_text;
    Color p_turn = new(0.4f, 0.4f, 1, 1);//�F
    Color e_turn = new(1, 0, 0, 1);//�ԐF

    // Update is called once per frame
    void Update()
    {
        //true = �F�Afalse = �ԐF
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