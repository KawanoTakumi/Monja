using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_calculate : MonoBehaviour
{
    PlayerController Playercontroller;
    GameObject player;
    Enemy_controller Enemycontoroller;
    GameObject enemey;
    Animator Player_animator;
    Animator Enemy_animator;
    int animation_time_E = 0;//エネミーのアニメーションタイム
    int animation_time_P = 0;//プレイヤーのアニメーションタイム

    // Start is called before the first frame update
    void Start()
    {
        Playercontroller = GetComponent<PlayerController>();
        player = GameObject.Find("Player");
        Enemycontoroller = GetComponent<Enemy_controller>();
        enemey = GameObject.Find("Monster");
    }

    // Update is called once per frame
    void Update()
    {
        Playercontroller = player.GetComponent<PlayerController>();
        Enemycontoroller = enemey.GetComponent<Enemy_controller>();
        Player_animator = player.GetComponent<Animator>();
        Enemy_animator = enemey.GetComponent<Animator>();
        
        if(Enemy_animator.GetBool("Damage") == true)
        {
            animation_time_E++;
            if(animation_time_E >= 60)
            {
                animation_time_E = 0;
                Enemy_animator.SetBool("Damage", false);
            }
        }
        if(Player_animator.GetBool("Player_Damage") == true)
        {
            animation_time_P++;
            if(animation_time_P >= 60)
            {
                animation_time_P = 0;
                Player_animator.SetBool("Player_Damage", false);
            }
        }
    }

    public void Player_Damage_Calculate(int attack,int diffence)
    {
        int result;
        result = attack - diffence;
        //数値が0以下になったら0にする
        if(result < 0)
        {
            result = 0;
        }

        Playercontroller.HP -= result;
        Player_animator.SetBool("Player_Damage", true);
        Debug.Log(Playercontroller.HP);
    }
    public void Enemey_Damage_Calculate(int attack,int diffence)
    {
        int result;
        //数値が0以下になったら0にする
        result = attack - diffence;
        if (result < 0)
        {
            result = 0;
        }
        Enemycontoroller.HP -= result;
        Enemy_animator.SetBool("Damage",true);
        Debug.Log(Enemycontoroller.HP);
    }
}