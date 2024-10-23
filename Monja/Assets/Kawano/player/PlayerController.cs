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
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //�ǂݍ���
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //�_���[�W�l��������
        Attack_damage = 0;
        if(turn_Manager.turn == false)
        {
            
        }
    }
    public void attack()
    {
        //�ǂݍ���
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        //�A�j���[�V����������������
        animator.SetBool("attack", false);
        animator.SetBool("magic", false);
        animator.SetBool("heal", false);
        if (turn_Manager.turn == true)
        {
            Debug.Log("�U��");
            animator.SetBool("attack", true);
            Attack_damage = Attack;
            turn_Manager.turn = false;
        }
    }
    public void concentration()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        animator.SetBool("attack", false);
        animator.SetBool("magic", false);
        animator.SetBool("heal", false);

        if (turn_Manager.turn == true)
        {
            if (MP < 100)
            {
                Debug.Log("�W��");
                MP += MP_max / 4;
                //MP���ő�l�����傫���Ȃ��������l���ő�l�ɍ��킹��
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
        animator = GetComponent<Animator>();
        animator.SetBool("attack", false);
        animator.SetBool("magic", false);
        animator.SetBool("heal", false);

        //�A�j���[�V����������������
        if (turn_Manager.turn == true)
        {
            Debug.Log("���@");
            animator.SetBool("magic", true);
            Magic_damage = Magic;
            turn_Manager.turn = false;
        }
    }
    public void heal()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        animator.SetBool("attack", false);
        animator.SetBool("magic", false);
        animator.SetBool("heal", false);
        //�A�j���[�V����������������
        if (turn_Manager.turn == true)
        {
            if (HP != HP_max && HP_Potion > 0)
            {
                Debug.Log("��");
                animator.SetBool("heal", true);
                HP_Potion -= 1;
                HP += HP_max / 4;
                //HP���ő�l�����傫���Ȃ��������l���ő�l�ɍ��킹��
                if (HP > HP_max)
                {
                    HP = HP_max;
                }
                turn_Manager.turn = false;
            }
            else
            {
                turn_Manager.turn = false;
            }
        }
    }
}