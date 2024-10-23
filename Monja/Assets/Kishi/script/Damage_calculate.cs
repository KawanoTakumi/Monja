using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_calculate : MonoBehaviour
{
    PlayerController Playercontroller;
    Enemy_controller Enemycontoroller;
    
    // Start is called before the first frame update
    void Start()
    {
        Playercontroller = GetComponent<PlayerController>();
        Enemycontoroller = GetComponent<Enemy_controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Enemy_Damage_Calculate()
    {
        int result;
        result = Playercontroller.Attack_damage - Enemycontoroller.Enemy_deffence;
        Enemycontoroller.HP -= result;
    }

    public void Player_Damage_Calculate()
    {
        int result;
        result = Enemycontoroller.Enemy_attack - Playercontroller.Diffence;
        Playercontroller.HP -= result;
    }
}