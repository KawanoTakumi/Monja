using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player status
    public int HP = 100;
    public int HP_max = 100;
    public int MP = 100;
    public int MP_max = 100;
    public int Attack = 50;
    public int Diffence = 50;
    public int Magic = 50;
    public int Magic_Diffence = 50;
    public int Attack_damage = 0;
    public int Magic_damage = 0;
    public int HP_Potion = 0;
    turn_manager turn_Manager;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //読み込み
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //ダメージ値を初期化
        Attack_damage = 0;
        if(turn_Manager.turn == false)
        {
            
        }
    }
    public void attack()
    {
        //読み込み
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        //アニメーション処理を初期化
        animator.SetBool("attack", false);
        animator.SetBool("magic", false);
        animator.SetBool("heal", false);
        if (turn_Manager.turn == true)
        {
            Debug.Log("攻撃");
            animator.SetBool("attack", true);
            Attack_damage = Attack;
            turn_Manager.turn = false;
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
                //MPが最大値よりも大きくなった時数値を最大値に合わせる
                if (MP > MP_max)
                {
                    MP = MP_max;
                }
                turn_Manager.turn = false;
            }
        }
    }
    public void magic()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        animator.SetBool("attack", false);
        animator.SetBool("magic", false);
        animator.SetBool("heal", false);

        //アニメーション処理を初期化
        if (turn_Manager.turn == true)
        {
            Debug.Log("魔法");
            animator.SetBool("magic", true);
            Magic_damage = Magic;
            turn_Manager.turn = false;
        }
    }
    public void heal()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        animator.SetBool("attack", false);
        animator.SetBool("magic", false);
        animator.SetBool("heal", false);
        //アニメーション処理を初期化
        if (turn_Manager.turn == true)
        {
            if (HP != HP_max && HP_Potion > 0)
            {
                Debug.Log("回復");
                animator.SetBool("heal", true);
                HP_Potion -= 1;
                HP += HP_max / 4;
                //HPが最大値よりも大きくなった時数値を最大値に合わせる
                if (HP > HP_max)
                {
                    HP = HP_max;
                }
                turn_Manager.turn = false;
            }
            else
            {
                turn_Manager.turn = false;
            }
        }
    }
}