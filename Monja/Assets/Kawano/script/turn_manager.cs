using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turn_manager : MonoBehaviour
{
    public bool turn = true;//turn == true�̎��v���C���[�̃^�[���Afalse�̎��G�̃^�[��
    public Text turn_text;
    Color p_turn = new(0, 0, 1, 1);//�F
    Color e_turn = new(1, 0, 0, 1);//�ԐF

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //true = �F�Afalse = �ԐF
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