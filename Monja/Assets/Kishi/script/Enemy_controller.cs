using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_controller : MonoBehaviour
{
    //�X�e�[�^�X
    public static int HP = 100;
    public int attack;
    public int deffence;
    public int magic;
    public int magic_Diffence;
    public int money;
    public  static int HP_MAX = 100;

    turn_manager turn_Manager;//turnManager�ǂݍ���
    Damage_calculate damage_Calculate;
    PlayerController playerController;
    GameObject player;
    Animator animator;
    public int Enemy_attack;//�U����(�v�Z��)
    public int Enemy_deffence;//�h���(�v�Z��)
    int Enemy_act = 0;
    int Enemy_luck = 0;
    bool Enemy_Skelton;
    public static int turn = 1;//�^�[��
    int turn_time = 0;
    //int animation_time = 0;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        GameObject obj = GameObject.Find("Player");
        turn_Manager = obj.GetComponent<turn_manager>();
        damage_Calculate = GetComponent<Damage_calculate>();
        animator = GetComponent<Animator>();
        GameObject skelton = GameObject.FindWithTag("skelton");
        if(CompareTag("skelton") == true)
        {
            Enemy_Skelton = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (turn_Manager.turn == false)
        {
            //EnemyAttack��������
            Enemy_attack = 0;

            //HP��0�ɂȂ�����N���A��ʂ��o��
            if (HP <= 0)
            {
                PlayerController.MP = 100;
                HP = 100;
                PlayerController.Money += money;
                turn = 1;
                SceneManager.LoadScene("Win");
            }
            if (Enemy_Skelton == true && turn_time == 35) //�G�@�X�P���g��
            {
                Skelton();
            }


            turn_time++;
            if (turn_time >= 90)
            {
                Debug.Log("�G�^�[���I��");
                Debug.Log("��l���̗�" + PlayerController.HP);
                turn += 1;
                playerController.Attack_.interactable = true;
                playerController.Magic_.interactable = true;
                playerController.Heal_.interactable = true;
                playerController.Concentlation_.interactable = true;


                turn_Manager.turn = true;
                //���Ԃ̏�����
                turn_time = 0;
                
                if (turn >= 5)
                {
                    money -= 5;//�^�[�����T�����傫���Ȃ�����l�����z���T�����炷
                    //money��0�ȉ��ɂȂ�����Amoney��0�ɂ���
                    if (money <= 0)
                    {
                        money = 0;
                    }
                }
            }
        }
        void Attack()
        {
            if(turn_time >= 25)
            {
                animator.SetBool("Attack", true);
            }
            Enemy_luck = Random.Range(1, 11);
            if (Enemy_luck <= 9)
            {
                Enemy_attack = attack;
            }
            else if (Enemy_luck == 10)
            {
                Enemy_attack = attack + attack/2;
                Debug.Log("�N���e�B�J��");
            }
        }
        void Defence()
        {
            Enemy_deffence += deffence;
        }

        void Skelton()
        {
            Debug.Log("�G�̍U��");
            Enemy_act = Random.Range(1, 4);//1�`3�܂�
            switch (Enemy_act)
            {
                case 1:
                    Attack();
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    Attack();
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 3:
                    Defence();
                    Enemy_deffence = deffence;
                    break;
            }
        }
    }
    //�A�j���[�V�����I���p�֐�(bool�^�̂�)
    public void Anim_Reset(string anim_tag)
    {
        animator.SetBool(anim_tag, false);
    }
}