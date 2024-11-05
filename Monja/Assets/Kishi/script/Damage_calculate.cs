using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_calculate : MonoBehaviour
{
    PlayerController Playercontroller;
    GameObject player;//�v���C���[�I�u�W�F�N�g
    Enemy_controller Enemycontoroller;
    GameObject enemey;//�G�l�~�[�I�u�W�F�N�g
    Animator Player_animator;
    Animator Enemy_animator;
    int animation_time_E = 0;//�G�l�~�[�̃A�j���[�V�����^�C��
    int animation_time_P = 0;//�v���C���[�̃A�j���[�V�����^�C��
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
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
            if(animation_time_E >= 30)
            {
                Enemy_animator.SetBool("Damage", false);
                animation_time_E = 0;
            }
        }
        if(Player_animator.GetBool("Player_Damage") == true)
        {
            animation_time_P++;
            if(animation_time_P >= 30)
            {
                Player_animator.SetBool("Player_Damage", false);
                animation_time_P = 0;
            }
        }
    }

    public void Player_Damage_Calculate(int attack,int diffence)
    {
        int result;
        result = attack - diffence;
        //���l��0�ȉ��ɂȂ�����0�ɂ���
        if(result < 0)
        {
            result = 0;
        }
        PlayerController.HP -= result;
        Player_animator.SetBool("Player_Damage", true);
    }
    public void Enemey_Damage_Calculate(int attack,int diffence)
    {
        int result;
        //���l��0�ȉ��ɂȂ�����0�ɂ���
        result = attack - diffence;
        Debug.Log("�_���[�W" + result);
        if (result < 0)
        {
            result = 0;
        }
        Enemy_controller.HP -= result;
        Enemy_animator.SetBool("Damage",true);
    }
}