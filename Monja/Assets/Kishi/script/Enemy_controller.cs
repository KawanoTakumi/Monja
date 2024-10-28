using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_controller : MonoBehaviour
{
    //ステータス
    public int HP = 150;
    public int attack = 5;
    public int deffence = 5;
    public int magic = 0;
    public int magic_Diffence = 5;
    public int money = 0;

    turn_manager turn_Manager;//turnManager読み込み
    Damage_calculate damage_Calculate;
    PlayerController playerController;
    GameObject player;
    public int Enemy_attack;//攻撃力(計算後)
    public int Enemy_deffence;//防御力(計算後)
    int Enemy_act = 0;
    int Enemy_luck = 0;
    bool Enemy_Skelton;
    public int turn = 0;//ターン
    int turn_time = 0;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        turn += 1;
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
            //EnemyAttackを初期化
            Enemy_attack = 0;

            //HPが0になったらがクリア画面を出す
            if(HP <= 0)
            {
                PlayerController.Money += money;
                SceneManager.LoadScene("Win");
            }
            if (Enemy_Skelton == true && turn_time == 0) //敵　スケルトン
            {
                Skelton();
            }
            turn_time++;
            if (turn_time > 400)
            {
                Debug.Log("敵ターン終了");
                turn += 1;
                
                turn_Manager.turn = true;
                //時間の初期化
                turn_time = 0;
                
                if (turn >= 5)
                {
                    money -= 5;//ターンが５よりも大きくなったら獲得金額を５ずつ減らす
                    //moneyが0以下になったら、moneyを0にする
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
                Debug.Log("クリティカル");
            }
        }
        void Defence()
        {
            //int Enemy_Move = 3;
            Enemy_deffence = deffence;
        }

        void Skelton()
        {
            Debug.Log("敵の攻撃");
            Enemy_act = Random.Range(1, 4);//1〜3まで
            switch (Enemy_act)
            {
                case 1:
                    Attack();
                    Debug.Log("攻撃１");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    Attack();
                    Debug.Log("攻撃2");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 3:
                    Defence();
                    Debug.Log("防御");
                    Enemy_deffence = deffence;
                    damage_Calculate.Enemey_Damage_Calculate(playerController.Attack_damage,Enemy_deffence);
                    break;
            }
        }
    }
}