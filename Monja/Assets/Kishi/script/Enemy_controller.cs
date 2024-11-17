using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

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

    public GameObject[] Effect;//�G�t�F�N�g�p
    GameObject obj1;
    [SerializeField] GameObject _parentGameObject;

    turn_manager turn_Manager;//turnManager�ǂݍ���
    Damage_calculate damage_Calculate;
    PlayerController playerController;
    GameObject player;
    Animator animator;
    public int Enemy_attack;//�U����(�v�Z��)
    public int Enemy_deffence;//�h���(�v�Z��)
    public int Enemy_Magic;//���@�U����(�v�Z��)
    int Enemy_act = 0;
    int Enemy_luck = 0;
    bool Enemy_Skelton;
    bool Boss_Medhusa;
    bool Boss_sinigami;
    public static int turn = 1;//�^�[��
    public static bool tag_get = true;
    int turn_time = 0;
    public Text Log;
    public bool poison;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        GameObject obj = GameObject.Find("Player");
        turn_Manager = obj.GetComponent<turn_manager>();
        damage_Calculate = GetComponent<Damage_calculate>();
        animator = GetComponent<Animator>();
         GameObject.FindWithTag("skelton");
        GameObject.FindWithTag("medhusa");
        GameObject.FindWithTag("sinigami");
        
        //��������ʂ��痈�����ɓǂݍ��܂�Ȃ��悤�ɂ���
        if(tag_get == true)
        {
            tag_get = false;
            //�^�O�̔�r
            if (CompareTag("skelton") == true)
            {
                Enemy_Skelton = true;
                HP = 100;
                HP_MAX = 100;
            }
            else if (CompareTag("medhusa") == true)
            {
                Boss_Medhusa = true;
                HP = 500;
                HP_MAX = 500;
            }
            else if (CompareTag("sinigami") == true)
            {
                Boss_sinigami = true;
                HP = 500;
                HP_MAX = 500;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (turn_Manager.turn == true)
        {
            Destroy(obj1);
        }
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
                tag_get = false;
                SceneManager.LoadScene("Win");
            }
            if (Enemy_Skelton == true && turn_time == 35) //�G�@�X�P���g��
            {
                Skelton();
            }
            else if (Boss_Medhusa == true && turn_time == 35) //�G�@���f���[�T�i�{�X�j
            {
                Medhusa();
            }
            else if (Boss_sinigami == true && turn_time == 35) //�G�@���f���[�T�i�{�X�j
            {
                Sinigami();
            }
            turn_time++;
            if (turn_time >= 120)
            {
                Log.text = ("�G�^�[���I��");
                Debug.Log("��l���̗�" + PlayerController.HP);
                turn += 1;
                playerController.Attack_.interactable = true;
                playerController.Magic_.interactable = true;
                playerController.Heal_.interactable = true;
                playerController.Concentlation_.interactable = true;


                turn_Manager.turn = true;
                Log.text = ("�v���C���[�̃^�[��");
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
            animator.SetBool("Attack", true);
            Log.text = ("�G�̍U��");
            Enemy_luck = Random.Range(1, 11);
            if (Enemy_luck <= 9)
            {
                Enemy_attack = attack;
            }
            else if (Enemy_luck == 10)
            {
                Enemy_attack = attack + attack/2;
                Log.text = ("�G�N���e�B�J������");
            }
        }
        void Defence()
        {
            Create_Effect_Enemy(0, 2.3f, 0f);
            
            Enemy_deffence += deffence;
        }

        //��U�g��Ȃ��̂ŃR�����g�A�E�g
        
        //void Magic()
        //{
        //    Log.text = ("�G�̖��@�U��");
        //    int magic_cnt = 0;
        //    if(magic_cnt<3)
        //    {
        //        Enemy_Magic = magic;
        //    }
        //    else if(magic_cnt == 3)
        //    {
        //        Enemy_Magic = Enemy_Magic + magic;
        //    }
        //}

        //�X�P���g��
        void Skelton()
        {
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
                    Log.text = ("�G�͖h�䂵��");
                    Enemy_deffence = deffence;
                    break;
            }
        }

        //���f���[�T
        void Medhusa()
        {
            Enemy_act = Random.Range(1, 5);//1�`4�܂�
            switch (Enemy_act)
            {
                case 1:
                    medhusa_magic();
                    damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                    break;
                case 2:
                    medhusa_magic();
                    damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                    break;
                case 3:
                    Defence();
                    Log.text = ("�G�͖h�䂵��");
                    Enemy_deffence = deffence;
                    break;
                case 4:
                    Defence();
                    Log.text = ("�G�͖h�䂵��");
                    Enemy_deffence = deffence;
                    break;
            }
        }
        void medhusa_magic()
        {
            Log.text = ("�G�̖��@�U��");
            Enemy_luck = Random.Range(1, 6);
            if (Enemy_luck <= 1)
            {
                Enemy_Magic = magic;
            }
            else if (Enemy_luck > 1)
            {
                Enemy_Magic = 0;
                Create_Effect_Enemy(1, 2.5f, 0.3f);
                poison = true;
                Log.text = ("���f���[�T�Ŕ���");
            }
        }

        //���_
        void Sinigami()
        {
            Enemy_act = Random.Range(1, 5);//1�`4�܂�
            switch (Enemy_act)
            {
                case 1:
                    sinigami_attack();
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    Attack();
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 3:
                    Defence();
                    Log.text = ("�G�͖h�䂵��");
                    Enemy_deffence = deffence;
                    break;
                case 4:
                    Defence();
                    Log.text = ("�G�͖h�䂵��");
                    Enemy_deffence = deffence;
                    break;
            }
        }
        void sinigami_attack()
        {
            animator.SetBool("Attack", true);
            Log.text = ("�G�̍U��");
            Enemy_luck = Random.Range(1, 51);
            if (Enemy_luck <= 49)
            {
                Enemy_attack = attack;
            }
            else if (Enemy_luck == 50)
            {
                Enemy_attack = attack * 666;
                Log.text = ("���_�N���e�B�J������");
                Debug.Log(Enemy_attack + "��_���[�W");
            }
        }

    }

    //�A�j���[�V�����I���p�֐�(bool�^�̂�)
    public void Anim_Reset(string anim_tag)
    {
        animator.SetBool(anim_tag, false);
    }
    public void Turn_Flag()
    {
        turn_Manager.turn = false;
    }

    //�G�t�F�N�g�I�u�W�F�N�g�쐬�֐�
    public void Create_Effect_Enemy(int number, float Fx, float Fy)
    {
        
        {
            obj1 = Instantiate(Effect[number], new Vector3(Fx, Fy, 0), Quaternion.identity, _parentGameObject.transform);
            obj1.name = "Effect_image_"+number;
        }
    }
}