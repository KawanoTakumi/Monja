using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_calculate : MonoBehaviour
{
    PlayerController Playercontroller;
    GameObject player;
    Enemy_controller Enemycontoroller;
    GameObject enemey;
    
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
    }

    public void Player_Damage_Calculate(int attack,int diffence)
    {
        int result;
        result = attack - diffence;
        if(result < 0)
        {
            result = 0;
        }

        Playercontroller.HP -= result;
        Debug.Log(Playercontroller.HP);
    }
    public void Enmey_Damage_Calculate(int attack,int diffence)
    {
        int result;
        result = attack - diffence;
        if (result < 0)
        {
            result = 0;
        }
        Enemycontoroller.HP -= result;
        Debug.Log(Enemycontoroller.HP);
    }
}