using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_controller : MonoBehaviour
{
    public int HP = 150;
    public int attack = 5;
    public int deffence = 5;
    public int magic = 0;
    public int magic_Diffence = 5;
    turn_manager turn_Manager;//turnManager�ǂݍ���
    int Enemy_attack;
    int Enemy_deffence;
    int Enemy_act = 0;
    int Enemy_luck = 0;
    //int EnemyMove = 0;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        turn_Manager = GetComponent<turn_manager>();
        if (turn_Manager.turn == false)
        {
            Debug.Log("�G�̍U��");
            Enemy_act = Random.Range(1, 4);
            //Debug.Log(Enemy_act);
            switch (Enemy_act)
            {
                case 1:
                    Attack();
                    turn_Manager.turn = true;
                    break;
                case 2:
                    Attack();
                    turn_Manager.turn = true;
                    break;
                case 3:
                    Defence();
                    Enemy_deffence = deffence;
                    turn_Manager.turn = true;
                    break;
            }

        }
        void Attack()
        {
            //int Enemy_Move = 1;

            Enemy_luck = Random.Range(1, 11);
            if (Enemy_luck <= 9)
                Enemy_attack = attack;
            else if (Enemy_luck == 10)
            {
                Enemy_attack = attack * 2;
                Debug.Log("�N���e�B�J��");
            }
        }
        void Magic()
        {
            //int Enemy_Move = 2;
            Debug.Log("���@");
        }
        void Defence()
        {
            //int Enemy_Move = 3;
            Debug.Log("�h��");

            Enemy_deffence = deffence;
        }
    }
}