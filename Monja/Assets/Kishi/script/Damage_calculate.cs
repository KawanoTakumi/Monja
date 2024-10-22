using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_calculate : MonoBehaviour
{
    PlayerController Playercontroller;
    Enemy_controller Enemycontoroller;
    
    public int Enemy_Damage;
    public int Player_Damage;
   
    // Start is called before the first frame update
    void Start()
    {
        Playercontroller = GetComponent<PlayerController>();
        Enemycontoroller = GetComponent<Enemy_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        //敵へのダメージをプレイヤー攻撃力　ー　敵防御力で求める
        Enemy_Damage = Playercontroller.Attack_damage - Enemycontoroller.deffence;
        //プレイヤーへのダメージを敵攻撃力　ー　プレイヤー防御力で求める
        Player_Damage = Enemycontoroller.Enemy_attack - Playercontroller.Diffence;
    }

    void  Change()
    {

    }
}
