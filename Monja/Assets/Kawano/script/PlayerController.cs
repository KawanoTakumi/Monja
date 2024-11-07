using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //player status
    public static int HP = 100;//体力
    public static int HP_max = 100;//最高体力
    public static int MP = 100;//MP
    public static int MP_max = 100;//最高MP
    public int Attack;//攻撃力
    public int Diffence;//防御力
    public int Magic;//魔法力
    public int Magic_Diffence;//魔法防御力
    public int Attack_damage;//攻撃力(計算後)
    public int Magic_damage;//魔法力(計算後)
    public int HP_Potion;//HPポーションの数
    public static int Money;//所持金額 //別のシーンでも呼ばれる
    public int money;//一時確認用（あとで消す）
    public int player_luck;
    public int max_luck;

    turn_manager turn_Manager;
    Animator animator;//プレイヤーアニメーター
    Damage_calculate damage_Calculate;
    Enemy_controller enemy_Controller;
    GameObject Enemey;
    public ChangeScene change;//チェンジシーン
    int turn_time = 0;//ターン経過時間

    //ボタン関係変数
    public Button Attack_;
    public Button Concentlation_;
    public Button Magic_;
    public Button Heal_;

    public Text Log;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Text = GameObject.Find("LogText");
        Log = Text.GetComponent<Text>();


        money = Money;
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        damage_Calculate = GetComponent<Damage_calculate>();
        Enemey = GameObject.Find("Monster");
        enemy_Controller = Enemey.GetComponent<Enemy_controller>();
    }
    // Update is called once per frame
    void Update()
    {
        //敗北
        if(HP <= 0)
        {
            HP = 100;
            MP = 100;
            Item_Reset();
            Enemy_controller.turn = 0;
            Enemy_controller.HP = 150;
            SceneManager.LoadScene("Lose");
        }

        //ステータス9999上限
        if(Attack >= 9999)
        {
            Attack = 9999;
        }
        if(Diffence >= 9999)
        {
            Diffence = 9999;
        }
        if(Magic >= 9999)
        {
            Magic = 9999;
        }
        if(Magic_Diffence >= 9999)
        {
            Magic_Diffence = 9999;
        }
        //ステータス0下限
        if (Attack < 0)
        {
            Attack = 0;
        }
        if (Diffence < 0)
        {
            Diffence = 0;
        }
        if (Magic < 0)
        {
            Magic = 0;
        }
        if (Magic_Diffence >= 0)
        {
            Magic_Diffence = 0;
        }
    }
    public void attack()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        intaract_false();
        animator.SetBool("attack", true);
        if (turn_Manager.turn == true)
        {
            player_luck = Random.Range(1, max_luck);
            if (player_luck != max_luck-1)
            {
                Attack_damage = Attack;
            }
            else if (player_luck == max_luck - 1)
            {
                Attack_damage = Attack + Attack / 2;
                Debug.Log("主人公クリティカル");
            }

            Attack_damage = Attack;
            damage_Calculate.Enemey_Damage_Calculate(Attack_damage, enemy_Controller.Enemy_deffence);

        }
    }
    public void concentration()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();

        if (turn_Manager.turn == true)
        {
            if (MP < 100)
            {
                intaract_false();
                MP += MP_max / 4;
                //MPがMP_maxより大きければMP_maxの値に合わせる
                if (MP > MP_max)
                {
                    MP = MP_max;
                }
                turn_Manager.turn = false;
            }
            else
            {
                Log.text = ("主人公は十分集中している");

            }
        }
    }
    public void magic()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        if (turn_Manager.turn == true)
        {
            if(MP >= 25)
            {
                intaract_false();
                animator.SetBool("magic", true);
                MP -= 25;
                Magic_damage = Magic;
                damage_Calculate.Enemey_Damage_Calculate(Magic_damage, enemy_Controller.magic_Diffence);
                turn_time++;
                if (turn_time > 60)
                {
                    turn_time = 0;
                    turn_Manager.turn = false;
                }
            }
            else
            {
                Log.text = ("魔法不発");
            }
        }
    }
    public void heal()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        
        if (turn_Manager.turn == true)
        {
            intaract_false();
            if (HP != HP_max && HP_Potion > 0)
            {
                //Debug.Log("回復");
                animator.SetBool("heal", true);
                HP_Potion -= 1;
                HP += HP_max / 4;
                
                if (HP > HP_max)
                {
                    HP = HP_max;
                }
                Log.text = ("主人公は回復した");
                intaract_true();
            }
            else　if(HP == HP_max)
            {
                Log.text = ("体力は満タンだ！！！");


            }
            else if(HP_Potion < 1)
            {
                Log.text = ("ポーションが足りない");
            }
            intaract_true();
        }
    }
    void intaract_false()
    {
        Attack_.interactable = false;
        Magic_.interactable = false;
        Heal_.interactable = false;
        Concentlation_.interactable = false;
    }
    void intaract_true()
    {
        Attack_.interactable = true;
        Magic_.interactable = true;
        Heal_.interactable = true;
        Concentlation_.interactable = true;
    }
    public void Item_Reset()
    {
        Item_Manager.Item["healdrink"] = false;
        Item_Manager.Item["bowlingball"] = false;
        Item_Manager.Item["CDplayer"] = false;
        Item_Manager.Item["cd"] = false;
        Item_Manager.Item["radio"] = false;
        Item_Manager.Item["hourglass"] = false;

    }
    //アニメーションリセット（boolのみ）
    public void Anim_Reset(string anim_tag)
    {
        animator.SetBool(anim_tag, false);
        if(anim_tag != "heal")
        turn_Manager.turn = false;
    }

}