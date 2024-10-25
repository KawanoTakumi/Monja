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
    turn_manager turn_Manager;//turnManager“Ç‚İ‚İ
    Damage_calculate damage_Calculate;
    PlayerController playerController;
    GameObject player;
    public int Enemy_attack;
    public int Enemy_deffence;
    int Enemy_act = 0;
    int Enemy_luck = 0;
    //int EnemyMove = 0;
    bool Enemy_Skelton;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        GameObject skelton = GameObject.FindWithTag("skelton");
        if(tag == "skelton")
        {
            Enemy_Skelton = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = GameObject.Find("Player");
        turn_Manager = obj.GetComponent<turn_manager>();
        damage_Calculate = GetComponent<Damage_calculate>();
        if (turn_Manager.turn == false)
        {
            //EnemyAttack‚ğ‰Šú‰»
            Enemy_attack = 0;

            if (Enemy_Skelton == true) //“G@ƒXƒPƒ‹ƒgƒ“
            {
                Skelton();
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
                Debug.Log("ƒNƒŠƒeƒBƒJƒ‹");
            }
        }
        //void Magic()
        //{
        //    //int Enemy_Move = 2;
        //    Debug.Log("–‚–@");
        //}
        void Defence()
        {
            //int Enemy_Move = 3;
            Enemy_deffence = deffence;
        }

        void Skelton()
        {
            Debug.Log("“G‚ÌUŒ‚");
            Enemy_act = Random.Range(1, 4);
            //Debug.Log(Enemy_act);
            switch (Enemy_act)
            {
                case 1:
                    Attack();
                    Debug.Log("UŒ‚‚P");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    turn_Manager.turn = true;
                    break;
                case 2:
                    Attack();
                    Debug.Log("UŒ‚2");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    turn_Manager.turn = true;
                    break;
                case 3:
                    Defence();
                    Debug.Log("–hŒä");
                    Enemy_deffence = deffence;
                    damage_Calculate.Enmey_Damage_Calculate(playerController.Attack_damage,Enemy_deffence);
                    turn_Manager.turn = true;
                    break;
            }
        }
    }
}