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
    // Start is called before the first frame update
    void Start()
    {

    }
// Update is called once per frame
    void Update()
    {

    }
    public void attack()
    {
        turn_Manager = GetComponent<turn_manager>();
        if (turn_Manager.turn == true)
        {
            Debug.Log("UŒ‚");
            Attack_damage = Attack;
            turn_Manager.turn = false;
        }
        else
        {
            Debug.Log("‘I‘ğ‚Å‚«‚Ü‚¹‚ñ");
        }
            
    }
    public void concentration()
    {
        turn_Manager = GetComponent<turn_manager>();
        if (turn_Manager.turn == true)
        {
            if (MP < 100)
            {
                Debug.Log("W’†");
                MP += MP_max / 4;
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
        if (turn_Manager.turn == true)
        {
            Debug.Log("–‚–@");
            Magic_damage = Magic;
            turn_Manager.turn = false;
        }
    }
    public void heal()
    {
        turn_Manager = GetComponent<turn_manager>();
        if (turn_Manager.turn == true)
        {
            Debug.Log("‰ñ•œ");
            if (HP != HP_max && HP_Potion > 0)
            {
                HP += HP_max / 4;
                turn_Manager.turn = false;
            }
            else
            {
                turn_Manager.turn = false;
            }
        }
    }
}