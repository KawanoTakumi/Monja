using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    //player status
    public int HP = 100;
    public int MP = 100;
    public int Attack = 50;
    public int Diffence = 50;
    public int Magic = 50;
    public int Magic_Diffence = 50;
    public bool player_turn;
    int act = 0;
    Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack_act()
    {
         = 1;
        
    }

    public void Diffence_act()
    {
        select = 3;
    }

    public void Magic_act()
    {
        select = 2;
    }

    public void Magic_diffence_act()
    {
        select = 4;
    }
}