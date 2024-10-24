using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player status
    public int HP;
    public int HP_max;
    public int MP;
    public int MP_max;
    public int Attack;
    public int Diffence;
    public int Magic;
    public int Magic_Diffence;
    public int Attack_damage;
    public int Magic_damage;
    public int HP_Potion;
    public int Money;
    //その他
    public bool[] ItemFlags;
    turn_manager turn_Manager;
    Animator animator;
    Damage_calculate damage_Calculate;
    Enemy_controller enemy_Controller;
    GameObject Enemey;
    public ChangeScene change;

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
            change.Load();
        }
    }
    public void attack()
    {
        
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        animator.SetBool("attack", false);
        animator.SetBool("magic", false);
        animator.SetBool("heal", false);

        if (turn_Manager.turn == true)
        {
            Debug.Log("攻撃");
            animator.SetBool("attack", true);
            Attack_damage = Attack;
            damage_Calculate.Enmey_Damage_Calculate(Attack_damage,enemy_Controller.Enemy_deffence);
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
                //MP
                if (MP > MP_max)
                {
                    MP = MP_max;
                }
                turn_Manager.turn = false;
            }
            else
            {
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
        if (turn_Manager.turn == true)
        {
            Debug.Log("魔法");
            animator.SetBool("magic", true);
            Magic_damage = Magic;
            damage_Calculate.Enmey_Damage_Calculate(Magic_damage, enemy_Controller.magic_Diffence);
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
            else
            {
                turn_Manager.turn = false;
            }
        }
    }
}