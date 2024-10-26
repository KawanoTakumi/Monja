using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //player status
    public int HP;//体力
    public int HP_max;//最高体力
    public int MP;//MP
    public int MP_max;//最高MP
    public int Attack;//攻撃力
    public int Diffence;//防御力
    public int Magic;//魔法力
    public int Magic_Diffence;//魔法防御力
    public int Attack_damage;//攻撃力(計算後)
    public int Magic_damage;//魔法力(計算後)
    public int HP_Potion;//HPポーションの数
    public int Money;//所持金額
    //その他
    public bool[] ItemFlags;
    turn_manager turn_Manager;
    Animator animator;
    Damage_calculate damage_Calculate;
    Enemy_controller enemy_Controller;
    GameObject Enemey;
    public ChangeScene change;
    int animation_time = 0;//アニメーションタイム
    int turn_time = 0;//ターン経過時間

    //item
    public enum Item
    {
        Healdrink,
        Bowlingball,
        CDPlayer,
        CD,
        Radio,
        Hourglass //砂時計
    }
    // Start is called before the first frame update
    void Start()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        damage_Calculate = GetComponent<Damage_calculate>();
        Enemey = GameObject.Find("Monster");
        enemy_Controller = Enemey.GetComponent<Enemy_controller>();
        ItemFlags = new bool[6];

    }
    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            SceneManager.LoadScene("Win");
        }
        if (animator.GetBool("attack") == true)
        {
            animation_time++;
            turn_time++;
            if (animation_time > 400 && turn_time > 400)
            {
                animator.SetBool("attack", false);
                Debug.Log("アニメーション終了");
                animation_time = 0;
                turn_time = 0;
                turn_Manager.turn = false;
            }
        }
        if (animator.GetBool("magic") == true)
        {
            animation_time++;
            turn_time++;
            if (animation_time > 600 && turn_time > 600)
            {
                animator.SetBool("magic", false);
                Debug.Log("アニメーション終了");
                animation_time = 0;
                turn_time = 0;
                turn_Manager.turn = false;
            }
        }

    }
    public void attack()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        if (turn_Manager.turn == true)
        {
            Debug.Log("攻撃");
            animator.SetBool("attack", true);
            Attack_damage = Attack;
            damage_Calculate.Enemey_Damage_Calculate(Attack_damage,enemy_Controller.Enemy_deffence);
            //turn_Manager.turn = false;
        }
    }
    public void concentration()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        animator.SetBool("attack", false);
        animator.SetBool("magic", false);
        animator.SetBool("heal", false);

        if (turn_Manager.turn == true)
        {
            if (MP < 100)
            {
                Debug.Log("集中");
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
                Debug.Log("集中力は足りている");
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
                Debug.Log("魔法");
                animator.SetBool("magic", true);
                MP -= 25;
                Magic_damage = Magic;
                damage_Calculate.Enemey_Damage_Calculate(Magic_damage, enemy_Controller.magic_Diffence);
                //turn_Manager.turn = false;
            }
            else
            {
                Debug.Log("魔法不発");
                turn_Manager.turn = false;
            }
        }
    }
    public void heal()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        animator.SetBool("attack", false);
        animator.SetBool("magic", false);
        animator.SetBool("heal", false);
        
        if (turn_Manager.turn == true)
        {
            if (HP != HP_max && HP_Potion > 0)
            {
                Debug.Log("回復");
                animator.SetBool("heal", true);
                HP_Potion -= 1;
                HP += HP_max / 4;
                
                if (HP > HP_max)
                {
                    HP = HP_max;
                }
                turn_Manager.turn = false;
            }
            else　if(HP == HP_max)
            {
                Debug.Log("体力は満タンだ！！！");
            }
            else if(HP_Potion < 1)
            {
                Debug.Log("ポーションが足りない");
            }
        }
    }
}