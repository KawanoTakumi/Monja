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
        //�G�ւ̃_���[�W���v���C���[�U���́@�[�@�G�h��͂ŋ��߂�
        Enemy_Damage = Playercontroller.Attack_damage - Enemycontoroller.deffence;
        //�v���C���[�ւ̃_���[�W��G�U���́@�[�@�v���C���[�h��͂ŋ��߂�
        Player_Damage = Enemycontoroller.Enemy_attack - Playercontroller.Diffence;
    }

    void  Change()
    {

    }
}
