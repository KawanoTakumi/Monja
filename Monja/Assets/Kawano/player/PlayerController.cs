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
    public bool Player_turn = true;//主人公のターン
    private int Attack_damage = 0;
    private int Magic_damage = 0;
    public int HP_Potion = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
// Update is called once per frame
    void Update()
    {
        turn_manager turn_Manager = GetComponent<turn_manager>();
        if (Player_turn == false)
        {
            turn_Manager.turn = false;
        }
    }
    public void attack()
    {
        if(Player_turn == true)
        {
            Debug.Log("攻撃");
            Attack_damage = Attack;
            Player_turn = false;
        }
    }
    public void concentration()
    {
        if(Player_turn == true)
        {
            if (MP < 100)
            {
                Debug.Log("集中");
                MP += MP_max / 4;
                if (MP > MP_max)
                {
                    MP = MP_max;
                }
                Player_turn = false;
            }
        }
    }
    public void magic()
    {
        if(Player_turn == true)
        {
            Debug.Log("魔法");
            Magic_damage = Magic;
            Player_turn = false;
        }
    }
    public void heal()
    {
        if(Player_turn == true)
        {
            Debug.Log("回復");
            if (HP != HP_max && HP_Potion > 0)
            {
                HP += HP_max / 4;
                Player_turn = false;
            }
            else
            {
                Player_turn = false;
            }
        }
    }
}