using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy_controller : MonoBehaviour
{
    //ステータス
    public static int HP = 100;
    public int attack;
    public int deffence;
    public int magic;
    public int magic_Diffence;
    public int money;
    public  static int HP_MAX = 100;

    turn_manager turn_Manager;//turnManager読み込み
    Damage_calculate damage_Calculate;
    PlayerController playerController;
    GameObject player;
    Animator animator;
    public int Enemy_attack;//攻撃力(計算後)
    public int Enemy_deffence;//防御力(計算後)
    public int Enemy_Magic;//魔法攻撃力(計算後)
    int Enemy_act = 0;
    int Enemy_luck = 0;
    bool Enemy_Skelton;
    bool Boss_Medhusa;
    bool Boss_sinigami;
    public static int turn = 1;//ターン
    int turn_time = 0;
    public Text Log;
    public bool poison;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        GameObject obj = GameObject.Find("Player");
        turn_Manager = obj.GetComponent<turn_manager>();
        damage_Calculate = GetComponent<Damage_calculate>();
        animator = GetComponent<Animator>();
         GameObject.FindWithTag("skelton");
        GameObject.FindWithTag("medhusa");
        GameObject.FindWithTag("sinigami");
        


        if (CompareTag("skelton") == true)
        {
            Enemy_Skelton = true;
            HP = 100;
            HP_MAX = 100;
        }
       else if(CompareTag("medhusa")==true)
        {
            Boss_Medhusa = true;
            HP = 500;
            HP_MAX = 500;
        }
        else if (CompareTag("sinigami") == true)
        {
            Boss_sinigami = true;
            HP = 500;
            HP_MAX = 500;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if (turn_Manager.turn == false)
        {
            //EnemyAttackを初期化
            Enemy_attack = 0;

            //HPが0になったらクリア画面を出す
            if (HP <= 0)
            {
                PlayerController.MP = 100;
                HP = 100;
                PlayerController.Money += money;
                turn = 1;
                SceneManager.LoadScene("Win");
            }
            if (Enemy_Skelton == true && turn_time == 35) //敵　スケルトン
            {
                Skelton();
            }
            else if (Boss_Medhusa == true && turn_time == 35) //敵　メデューサ（ボス）
            {
                Medhusa();
            }
            else if (Boss_sinigami == true && turn_time == 35) //敵　メデューサ（ボス）
            {
                Sinigami();
            }
            turn_time++;
            if (turn_time >= 120)
            {
                Log.text = ("敵ターン終了");
                Debug.Log("主人公体力" + PlayerController.HP);
                turn += 1;
                playerController.Attack_.interactable = true;
                playerController.Magic_.interactable = true;
                playerController.Heal_.interactable = true;
                playerController.Concentlation_.interactable = true;


                turn_Manager.turn = true;
                Log.text = ("プレイヤーのターン");
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
            animator.SetBool("Attack", true);
            Log.text = ("敵の攻撃");
            Enemy_luck = Random.Range(1, 11);
            if (Enemy_luck <= 9)
            {
                Enemy_attack = attack;
            }
            else if (Enemy_luck == 10)
            {
                Enemy_attack = attack + attack/2;
                Log.text = ("敵クリティカル発生");
            }
        }
        void Defence()
        {
            animator.SetBool("Guard", true);
            Enemy_deffence += deffence;
        }

        void Magic()
        {
            Log.text = ("敵の魔法攻撃");
            Enemy_luck = Random.Range(1, 11);
            if (Enemy_luck <= 9)
            {
                Enemy_Magic = magic;
            }
            else if (Enemy_luck == 10)
            {
                Enemy_Magic = 0;
                poison = true;
                Log.text = ("メデューサ毒発動");
            }
        }
        void sinigami_attack()
        {
            animator.SetBool("Attack", true);
            Log.text = ("敵の攻撃");
            Enemy_luck = Random.Range(1, 51);
            if (Enemy_luck <=49)
            {
                Enemy_attack = attack;
            }
            else if (Enemy_luck == 50)
            {
                Enemy_attack = attack *666;
                Log.text = ("死神クリティカル発生");
                Debug.Log(Enemy_attack + "被ダメージ");
            }
        }

        void Skelton()
        {
            Enemy_act = Random.Range(1, 4);//1〜3まで
            switch (Enemy_act)
            {
                case 1:
                    Attack();
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    Attack();
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 3:
                    Defence();
                    Log.text = ("敵は防御した");
                    Enemy_deffence = deffence;
                    break;
            }
        }

        void Medhusa()
        {
            Enemy_act = Random.Range(1, 5);//1〜4まで
            switch (Enemy_act)
            {
                case 1:
                    Magic();
                    damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                    break;
                case 2:
                    Magic();
                    damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                    break;
                case 3:
                    Defence();
                    Log.text = ("敵は防御した");
                    Enemy_deffence = deffence;
                    break;
                case 4:
                    Defence();
                    Log.text = ("敵は防御した");
                    Enemy_deffence = deffence;
                    break;
            }
        }

        void Sinigami()
        {
            Enemy_act = Random.Range(1, 5);//1〜4まで
            switch (Enemy_act)
            {
                case 1:
                    sinigami_attack();
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    Attack();
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 3:
                    Attack();
                    Log.text = ("敵は防御した");
                    Enemy_deffence = deffence;
                    break;
                case 4:
                    Defence();
                    Log.text = ("敵は防御した");
                    Enemy_deffence = deffence;
                    break;
            }
        }
    }
    
    //アニメーション終了用関数(bool型のみ)
    public void Anim_Reset(string anim_tag)
    {
        animator.SetBool(anim_tag, false);
    }
    public void Turn_Flag()
    {
        turn_Manager.turn = false;
    }
}