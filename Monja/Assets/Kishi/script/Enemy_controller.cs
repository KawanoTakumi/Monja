using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_controller : MonoBehaviour
{
    //ƒXƒe[ƒ^ƒX
    public static int HP = 150;
    public int attack = 30;
    public int deffence = 25;
    public int magic = 0;
    public int magic_Diffence = 5;
    public int money = 30;

    turn_manager turn_Manager;//turnManager“Ç‚İ‚İ
    Damage_calculate damage_Calculate;
    PlayerController playerController;
    GameObject player;
    public int Enemy_attack;//UŒ‚—Í(ŒvZŒã)
    public int Enemy_deffence;//–hŒä—Í(ŒvZŒã)
    int Enemy_act = 0;
    int Enemy_luck = 0;
    bool Enemy_Skelton;
    public static int turn = 1;//ƒ^[ƒ“
    int turn_time = 0;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        GameObject obj = GameObject.Find("Player");
        turn_Manager = obj.GetComponent<turn_manager>();
        damage_Calculate = GetComponent<Damage_calculate>();
        GameObject skelton = GameObject.FindWithTag("skelton");
        if(CompareTag("skelton") == true)
        {
            Enemy_Skelton = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (turn_Manager.turn == false)
        {
            //EnemyAttack‚ğ‰Šú‰»
            Enemy_attack = 0;

            //HP‚ª0‚É‚È‚Á‚½‚çƒNƒŠƒA‰æ–Ê‚ğo‚·
            if(HP <= 0)
            {
                PlayerController.HP = 100;
                PlayerController.MP = 100;
                HP = 150;
                Debug.Log(PlayerController.HP);
                PlayerController.Money += money;
                turn = 1;
                SceneManager.LoadScene("Win");
            }
            if (Enemy_Skelton == true && turn_time == 0) //“G@ƒXƒPƒ‹ƒgƒ“
            {
                Skelton();
            }
            turn_time++;
            if (turn_time > 400)
            {
                Debug.Log("“Gƒ^[ƒ“I—¹");
                turn += 1;
                playerController.Attack_.interactable = true;
                playerController.Magic_.interactable = true;
                playerController.Heal_.interactable = true;
                playerController.Concentlation_.interactable = true;


                turn_Manager.turn = true;
                //ŠÔ‚Ì‰Šú‰»
                turn_time = 0;
                
                if (turn >= 5)
                {
                    money -= 5;//ƒ^[ƒ“‚ª‚T‚æ‚è‚à‘å‚«‚­‚È‚Á‚½‚çŠl“¾‹àŠz‚ğ‚T‚¸‚ÂŒ¸‚ç‚·
                    //money‚ª0ˆÈ‰º‚É‚È‚Á‚½‚çAmoney‚ğ0‚É‚·‚é
                    if (money <= 0)
                    {
                        money = 0;
                    }
                }
            }
        }
        void Attack()
        {
            //int Enemy_Move = 1;
            Enemy_luck = Random.Range(1, 11);
            if (Enemy_luck <= 9)
            {
                Enemy_attack = attack;
            }
            else if (Enemy_luck == 10)
            {
                Enemy_attack = attack * 2;
                Debug.Log("ƒNƒŠƒeƒBƒJƒ‹");
            }
        }
        void Defence()
        {
            //int Enemy_Move = 3;
            Enemy_deffence = deffence;
        }

        void Skelton()
        {
            Debug.Log("“G‚ÌUŒ‚");
            Enemy_act = Random.Range(1, 4);//1`3‚Ü‚Å
            switch (Enemy_act)
            {
                case 1:
                    Attack();
                    Debug.Log("UŒ‚‚P");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    Attack();
                    Debug.Log("UŒ‚2");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 3:
                    Defence();
                    Debug.Log("–hŒä");
                    Enemy_deffence = deffence;
                    damage_Calculate.Enemey_Damage_Calculate(playerController.Attack_damage,Enemy_deffence);
                    break;
            }
        }
    }
}