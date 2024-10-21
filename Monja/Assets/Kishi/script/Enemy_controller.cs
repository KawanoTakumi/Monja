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
    public bool Enemy_turn = true;
    int Enemy_attack;
    int Enemy_deffence;
    int Enemy_act = 0;
    int Enemy_luck = 0;
   


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy_turn == true)
        {
            Enemy_act = Random.Range(1, 4);
            Debug.Log(Enemy_act);
           

            switch(Enemy_act)
            { 
            case 1:           
                    Attack();
                    Enemy_turn = false;
                break;
            case 2:
            Enemy_attack = attack;
                    Enemy_turn = false;
                    break;
            case 3:
            Enemy_deffence = deffence;
                    Enemy_turn = false;
                    break;
            }
        }  
    }
    void Attack()
    {
        Enemy_luck = Random.Range(1, 11);
        Debug.Log(Enemy_luck);
        if (Enemy_luck <= 9)
        Enemy_attack = attack;
        else if(Enemy_luck == 10)
        {
            Enemy_attack = attack * 2;
        }
    }
    void Magic()
    {

    }
    void Defence()
    {
        Enemy_deffence = deffence;
    }
}
