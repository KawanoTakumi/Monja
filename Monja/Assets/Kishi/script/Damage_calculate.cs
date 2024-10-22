using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_calculate : MonoBehaviour
{
    PlayerController Playercontroller;
    Enemy_controller Enemycontoroller;
    int Enemy_Damage;
    int Player_Damage;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Playercontroller = GetComponent<PlayerController>();
        //Playercontroller.Attack_damage
    }

    void  Change()
    {

    }
}
