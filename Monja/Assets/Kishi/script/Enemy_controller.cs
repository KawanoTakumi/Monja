using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy_controller : MonoBehaviour
{
    //�X�e�[�^�X
    public static int HP = 100;      //�G�l�~�[HP
    public int attack;�@             //�G�l�~�[�����U����
    public int deffence;             //�G�l�~�[�����h���
    public int magic;                //�G�l�~�[���@�U����
    public int magic_Diffence;       //�G�l�~�[���@�h���
    public int money;                //�G�l�~�[�h���b�v���z
    public  static int HP_MAX = 100; //�G�l�~�[HP�ő�l

    public GameObject[] Effect;//�G�t�F�N�g�p
    public GameObject Monster;//�G�l�~�[�I�u�W�F�N�g
    public GameObject obj1;       //�G�t�F�N�g�p�I�u�W�F�N�g
    public GameObject obj2;//�G�t�F�N�g�p�I�u�W�F�N�g
    [SerializeField] GameObject _parentGameObject;//�e�I�u�W�F�N�g
    turn_manager turn_Manager;          //turnManager�ǂݍ���
    Damage_calculate damage_Calculate;  //�_���[�W�v�Z
    Enemy_SE enemy_SE;                  //�G�l�~�[SE
    PlayerController playerController;  //�v���C���[�R���g���[��
    public Status_Controller status_;   //�X�e�[�^�X
    GameObject player;                  //�v���C���[�I�u�W�F�N�g
    Animator animator;                  //�A�j���[�^�[
    public int Enemy_attack;            //�U����(�v�Z��)
    public int Enemy_deffence;          //�h���(�v�Z��)
    public int Enemy_Magic;             //���@�U����(�v�Z��)
    int Enemy_act = 0;                  //�G�l�~�[�s�����ʗp
    int Enemy_luck = 0;                 //�G�l�~�[���b�N����p
    static int Enemy_luck_Max;�@�@  �@�@//�G�l�~�[���b�N�l
    static int magic_cnt = 0;�@�@�@  �@ //���@�U���񐔃J�E���g
    //-------------------------  
    //�G�l�~�[���ʗp
    static bool Enemy_Skelton;  
    static bool Enemy_Centaurus;
    static bool Enemy_Lich;
    static bool Enemy_Knight;
    static bool Enemy_Minotaurus;
    static bool Enemy_Cockatrice;
    static bool Boss_Medhusa;
    static bool Boss_TheGrimReaper;
    static bool Boss_Dragon;
    //----------------------------
    public static int turn = 1;//�^�[��
    public static bool tag_get = true;//�^�O�擾�p�t���O
    int turn_time = 0;//�^�[���̎���
    public Text Log;//���O�e�L�X�g
    public Text Log_2; 
    public static bool End_Game_Flag = false;//�Q�[���I���t���O
    public GameObject HP_Bar;//�̗̓o�[
    //��Ԉُ�ϐ�
    public bool poison;                      //��
    public bool OnFire;                      //����
    public static bool Freeze_turn = false;  //����
    public static bool Stone_turn = false;   //�Ή�
    public static bool Stun_turn = false;    //�C��

    //�e�V�[�����B��true�ɂ���
    public static bool TheGrimReaper_flag = false;
    public static bool Medhusa_flag = false;
    public static bool Dragon_flag = false;

    // Start is called before the first frame update
    void Start()
    {

        //�G�l�~�[�I�u�W�F�N�g�^�O�擾
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        GameObject obj = GameObject.Find("Player");
        turn_Manager = obj.GetComponent<turn_manager>();
        enemy_SE = GetComponent<Enemy_SE>();
        damage_Calculate = GetComponent<Damage_calculate>();
        animator = GetComponent<Animator>();

        Enemy_GetTag(); //�^�O��T��

        //��������ʂ��痈�����ɓǂݍ��܂�Ȃ��悤�ɂ���
        if (tag_get == true)
        {
            tag_get = false;
            //�G�̎�ޔ��ʁ@�X�e�[�^�X�ݒ�
            if (CompareTag("skelton") == true)
            {
                Enemy_Skelton = true;
                HP = 75;
                HP_MAX = 75;
                Enemy_luck_Max = 16;
            }
            else if (CompareTag("Lich") == true)
            {
                Enemy_Lich = true;
                HP = 120;
                HP_MAX = 120;
                Enemy_luck_Max = 0;
            }
            else if (CompareTag("TheGrimReaper") == true)
            {
                Boss_TheGrimReaper = true;
                HP = 240;
                HP_MAX = 240;
                Enemy_luck_Max = 26;
            }
            else if (CompareTag("minotaurus") == true)
            {
                Enemy_Minotaurus = true;
                HP = 320;
                HP_MAX = 320;
                Enemy_luck_Max = 9;
            }
            else if (CompareTag("centaurus") == true)
            {
               Enemy_Centaurus = true;
                HP = 400;
                HP_MAX = 400;
                Enemy_luck_Max = 11;
            }
            else if (CompareTag("medhusa") == true)
            {
                Boss_Medhusa = true;
                HP = 460;
                HP_MAX = 460;
                Enemy_luck_Max = 0;
            }
            else if (CompareTag("cockatrice") == true)
            {
                Enemy_Cockatrice = true;
                HP = 530;
                HP_MAX = 530;
                Enemy_luck_Max = 16;
            }
            else if (CompareTag("knight") == true)
            {
                Enemy_Knight = true;
                HP = 600;
                HP_MAX = 600;
                Enemy_luck_Max = 9;
            }
            else if (CompareTag("dragon") == true)
            {
                Boss_Dragon = true;
                HP = 860;
                HP_MAX = 860;
                Enemy_luck_Max = 11;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�^�O��T��
        Enemy_GetTag();

        //�G�s���֐��Ăяo��
        if (Enemy_Skelton == true && turn_time == 10) //�G�@�X�P���g��
        {
            Skelton();
        }
        else if (Enemy_Centaurus == true && turn_time == 10) //�G�@�P���^�E���X
        {
            Centaurus();
        }
        else if (Enemy_Lich == true && turn_time == 10) //�G�@���b�`
        {
            Lich();
        }
        else if (Enemy_Knight == true && turn_time == 10) //�G�@�i�C�g
        {
            Knight();
        }
        else if (Enemy_Cockatrice == true && turn_time == 10) //�G�@�R�J�g���X
        {
            Cockatrice();
        }
        else if (Enemy_Minotaurus == true && turn_time == 10) //�G�@�~�m�^�E���X
        {
            Minotaurus();
        }
        else if (Boss_Medhusa == true && turn_time == 10) //�G�@���f���[�T�i�{�X�j
        {
            Medhusa();
        }
        else if (Boss_TheGrimReaper == true && turn_time == 10) //�G�@���_�i�{�X�j
        {
            TheGrimReaper();
        }
        else if (Boss_Dragon == true && turn_time == 10) //�G�@�h���S���i�{�X�j
        {
            Dragon();
        }
        //�^�[����true�̎��G�t�F�N�g�I�u�W�F�N�g���폜
        if (turn_manager.turn == true)
        {
            Destroy(obj1);
        }
        if (turn_manager.turn == false)
        {
            //EnemyAttack��������
            Enemy_attack = 0;
            Enemy_Magic = 0;
            Destroy(playerController.obj_player);
            if (Item_Power.Watch_Add_reset == false)//�A�C�e���FWatch�̑������X�e�[�^�X���Z�b�g
            {
                playerController.Attack -= PlayerController.HP_max - PlayerController.HP;
                Item_Power.Watch_Add_reset = true;
            }
            if (Freeze_turn == true || Stone_turn == true || Stun_turn == true)
            {
                Freeze_turn = false;
                Stone_turn = false;
                Stun_turn = false;
                if(HP > 0)
                {
                    turn += 1;
                }
                playerController.intaract_true();
                Item_Power.first_turn = false;
                Destroy(playerController.obj_player);
                status_.Delete_Effect();
                turn_manager.turn = true;
                Log.text = ("�v���C���[�̃^�[��");
                Log_2.text = "";
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
            //HP��0�ɂȂ�����N���A��ʂ��o��
            if (HP <= 0)
            {
                Enemy_Defeat(); //�G�@���j��ʈڍs
            }
          
            //�^�[���^�C�������l���傫���Ȃ�����^�[���ύX
            turn_time++;
            if (turn_time > turn_manager.turn_time_max)
            {
                Item_Power.turn_bool = true;
                Log.text = ("�G�^�[���I��");
                status_.Delete_Effect();
                turn += 1;
                playerController.intaract_true();
                Item_Power.first_turn = false;
                Enemy_deffence -=Enemy_deffence;
                turn_manager.turn = true;
                playerController.Log_2.text = "";
                Log.text = ("�v���C���[�̃^�[��");
                //���Ԃ̏�����
                turn_time = 0;
                //�^�[�����T�����傫���Ȃ�����l�����z���T�����炷
                if (turn >= 5)
                {
                    money -= 5;
                    //money��0�ȉ��ɂȂ�����Amoney��0�ɂ���
                    if (money <= 0)
                    {
                        money = 0;
                    }
                }
            }
        }
       
    }

    void Enemy_GetTag()
    {
        GameObject.FindWithTag("skelton");
        GameObject.FindWithTag("centaurus");
        GameObject.FindWithTag("Lich");
        GameObject.FindWithTag("minotaurus");
        GameObject.FindWithTag("knight");
        GameObject.FindWithTag("cockatrice");
        GameObject.FindWithTag("medhusa");
        GameObject.FindWithTag("TheGrimReaper");
        GameObject.FindWithTag("dragon");

    }

    //�G�s���֐�

    //�A�^�b�N
    void Attack(int paturn)
    {
        switch (paturn)
        {
            case 1: animator.SetBool("Attack", true); break;
            case 2: Create_Effect_Enemy(1, 0.0f, 0.0f); break;
        }

        Enemy_luck = Random.Range(1, Enemy_luck_Max);
        if (Enemy_luck <= 9)
        {
            Enemy_attack = attack;
        }
        else if (Enemy_luck == Enemy_luck_Max - 1)
        {
            Enemy_attack = attack + attack / 2;

        }
    }
    //�h��
    void Defence()
    {
        Create_Effect_Enemy(0, 2.3f, 0f);
        enemy_SE.SE_Monster(2);
        Enemy_deffence = deffence;
    }
    //���@
    void Magic()
    {
        if (magic_cnt < 3)
        {
            Enemy_Magic = magic;
            magic_cnt++;
        }
        else if (magic_cnt == 3)
        {
            Enemy_Magic = Enemy_Magic + magic;
        }
    }
    //��
    void Heal()
    {
        HP += HP / 10;
    }

    //�X�P���g��
    void Skelton()
    {
        Enemy_act = Random.Range(1, 4);//1�`3�܂�
        switch (Enemy_act)
        {
            case 1:
                Attack(1);
                Log.text = ("�X�P���g���̍U��");
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                break;
            case 2:
                Attack(1);
                Log.text = ("�X�P���g���̍U��");
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                break;
            case 3:
                Defence();
                Log.text = ("�X�P���g���͖h�䂵��");
                Enemy_deffence = deffence;
                break;
        }
    }
    //���b�`
    void Lich()
    {
        Enemy_act = Random.Range(1, 4);//1�`3�܂�
        switch (Enemy_act)
        {
            case 1:
                Magic();
                Log.text = ("���b�`�̖��@�U��");
                Create_Effect_Enemy(1, 5.5f, 0.4f);
                damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                break;
            case 2:
                Magic();
                Log.text = ("���b�`�̖��@�U��");
                Create_Effect_Enemy(1, 5.5f, 0.4f);
                damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                break;
            case 3:
                Heal();
                Log.text = ("���b�`�͉񕜂���");
                break;
        }
    }
    //�~�m�^�E���X
    void Minotaurus()
    {
        Enemy_act = Random.Range(1, 4);//1�`3�܂�
        switch (Enemy_act)
        {
            case 1:
                Attack(1);
                Log.text = ("�~�m�^�E���X�̍U��");
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                break;
            case 2:
                Attack(1);
                Log.text = ("�~�m�^�E���X�̍U��");
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                break;
            case 3:
                Defence();
                Log.text = ("�~�m�^�E���X�͖h�䂵��");
                Enemy_deffence = deffence;
                break;
        }
    }
    //�P���^�E���X
    void Centaurus()
    {
        Enemy_act = Random.Range(1, 4);//1�`3�܂�
        switch (Enemy_act)
        {
            case 1:
                Attack(2);
                Log.text = ("�P���^�E���X�̋|�U��");
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                break;
            case 2:
                Attack(2);
                Log.text = ("�P���^�E���X�̋|�U��");
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                break;
            case 3:
                Defence();
                Log.text = ("�P���^�E���X�͖h�䂵��");
                break;
        }
    }
    //�R�J�g���X
    void Cockatrice()
    {
        Enemy_act = Random.Range(1, 4);//1�`3�܂�
        switch (Enemy_act)
        {
            case 1:
                Magic();
                Log.text = ("�R�J�g���X�̖��@�U��");
                Create_Effect_Enemy(3, 0.0f, 0.0f);
                damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                break;
            case 2:
                Attack(1);
                Log.text = ("�R�J�g���X�̍U��");
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                break;
            case 3:
                Defence();
                Log.text = ("�R�J�g���X�͖h�䂵��");
                break;
        }
    }
    //�i�C�g
    void Knight()
    {
        Enemy_act = Random.Range(1, 4);//1�`3�܂�
        switch (Enemy_act)
        {
            case 1:
                Attack(2);
                Log.text = ("�i�C�g�͎a�����΂���");
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                break;
            case 2:
                Heal();
                Log.text = ("�i�C�g�͉񕜂���");
                break;
            case 3:
                Defence();
                Log.text = ("�i�C�g�͖h�䂵��");
                break;
        }
    }

    //���f���[�T
    void Medhusa()
    {
        int stone_luck;
        stone_luck = Random.Range(0, 5);
        Enemy_act = Random.Range(1, 5);//1�`4�܂�
        switch (Enemy_act)
        {
            case 1:
                medhusa_magic();
                Log.text = ("���f���[�T�̖��@�U��");
                damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                break;
            case 2:
                medhusa_magic();
                Log.text = ("���f���[�T�̐Ή��U��");
                switch (stone_luck)
                {
                    case 1:
                    case 2:
                    case 3: Log.text = "�Ή����Ȃ�����"; break;
                    case 4: Log.text = "�Ή����Ă��܂���"; status_.Status_Effect(true, 1); Stone_turn = true; break;
                }
                break;
            case 3:
                Heal();
                Log.text = ("���f���[�T�͉񕜂���");
                break;
            case 4:
                Defence();
                Log.text = ("���f���[�T�͖h�䂵��");
                break;
        }
    }
    //���f���[�T�̖��@�U��
    void medhusa_magic()
    {
        Log.text = ("���f���[�T�̖��@�U��");
        Enemy_luck = Random.Range(1, 6);
        if (Enemy_luck > 0)
        {
            Enemy_Magic = magic;
            poison = true;
            Log.text = ("���f���[�T�̓Ŕ���");
            Create_Effect_Enemy(1, 2.5f, 0.3f);

        }
    }
    //���_
    void TheGrimReaper()
    {
        Enemy_act = Random.Range(1, 5);//1�`4�܂�
        switch (Enemy_act)
        {
            case 1:
                TheGrimReaper_attack();
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                break;
            case 2:
                TheGrimReaper_attack();
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                break;
            case 3:
                Defence();
                Log.text = ("���_�͖h�䂵��");
                break;
            case 4:
                Defence();
                Log.text = ("���_�͖h�䂵��");
                break;
        }
    }
    //���_�̍U��
    void TheGrimReaper_attack()
    {
        animator.SetBool("Attack", true);
        Enemy_luck = Random.Range(1, 21);
        if (Enemy_luck < 20)
        {
            Log.text = ("���_�̍U��");
            Enemy_attack = attack;
        }
        else if (Enemy_luck == 20)
        {
            PlayerController.HP /= 2;
            Log.text = ("���_�̎�");
            Create_Effect_Enemy(1, 2.5f, 0.3f);
        }
    }
    //�h���S��
    void Dragon()
    {
        Enemy_act = Random.Range(1, 5);//1�`4�܂�
        switch (Enemy_act)
        {
            case 1:
                dragon_attack();
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                break;
            case 2:
                dragon_magic();
                Log.text = ("�h���S���̖��@�U��");
                damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                break;
            case 3:
                dragon_attack();
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                break;
            case 4:
                dragon_Heal();
                Log.text = ("�h���S���͉񕜂���");
                break;
        }
    }
    //�h���S���̍U��
    void dragon_attack()
    {
        Enemy_luck = Random.Range(1, 6);
        if (Enemy_luck <= 4)
        {
            Log.text = ("�h���S���̍U��");
            Create_Effect_Enemy(3, -5.4f, 0.3f);
            Enemy_attack = attack;
        }
        else if (Enemy_luck == 5)
        {
            Enemy_attack = attack + 20;
            Log.text = ("���̍��g");
            Create_Effect_Enemy(3, -5.4f, 0.3f);
        }
    }
    //�h���S���̖��@�U��
    void dragon_magic()
    {
        if (magic_cnt < 2)
        {
            Enemy_Magic = magic;
            magic_cnt++;
        }
        else if (magic_cnt >= 2)
        {
            Create_Effect_Enemy(1, 2.5f, 0.3f);
            OnFire = true;
            Enemy_Magic = magic + Enemy_attack;
        }
    }
    //�h���S���̉�
    void dragon_Heal()
    {
        HP += HP / 10 + Enemy_attack;
    }

    //�A�j���[�V�����I���p�֐�(bool�^�̂�)
    public void Anim_Reset(string anim_tag)
    {
        animator.SetBool(anim_tag, false);
    }
    //�^�[���t���O
    public void Turn_Flag()
    {
        turn_manager.turn = false;
    }

    //�G�t�F�N�g�I�u�W�F�N�g�쐬�֐�
    public void Create_Effect_Enemy(int number, float Fx, float Fy)
    {
        switch(number)
        {
            default:
                {
                    obj1 = Instantiate(Effect[number], new Vector3(Fx, Fy, 0), Quaternion.identity, _parentGameObject.transform);
                    obj1.name = "obj_name" + number;
                }break;
            case 0:
                {
                    obj2 = Instantiate(Effect[number], new Vector3(Fx, Fy, 0), Quaternion.identity, _parentGameObject.transform);
                    obj2.name = "obj_name" + number;
                }
                break;
        }
    }
    //����
    public void Win()
    {
        //�e�퐔�l��������
        animator.SetBool("death", false);
        Monster.SetActive(false);
        Win_Reset();
        PlayerController.Status_reset();
        Item_Power.turn_compare = 0;
        Freeze_turn = false;
        Item_Power.Pencil_Down_cnt = 0;
        Destroy(obj1);
        Destroy(obj2);
        Destroy(Status_Controller.eff_obj);
        magic_cnt = 0;
        turn = 1;
        Shop_manager.shop_max = 2;
        Cut_In.first_flag = true;
        if (ChangeScene.scene_cnt >= 9)
        {
            PlayerController.Money += money;
            Item_Power.first_turn = true;
            Item_Power.Sinigami_Crit_Effect = false;
            Dragon_flag = true;
            PlayerController.HP_Potion = 0;
            ChangeScene.Title_Reset();
            SceneManager.LoadScene("ending");
        }
        else
        {
            PlayerController.Money += money;
            Item_Power.first_turn = true;
            if(ChangeScene.scene_cnt >= 6)
            {
                Medhusa_flag = true;
            }
            else if(ChangeScene.scene_cnt >= 3)
            {
                TheGrimReaper_flag = true;
            }
            SceneManager.LoadScene("Win");
        }
    }
    //�N���e�B�J���G�t�F�N�g���폜
    public void Crit_Del()
    {
        Destroy(obj1);
    }
    //���Z�b�g�֐�
    void Win_Reset()
    {
        Enemy_Skelton = false;
        Enemy_Centaurus = false;
        Enemy_Lich = false;
        Enemy_Knight = false;
        Enemy_Minotaurus = false;
        Enemy_Cockatrice = false;
        Boss_Medhusa = false;
        Boss_TheGrimReaper = false;
        Boss_Dragon = false;
    }
    //�A�^�b�N�G�t�F�N�g�֐�
    public void Attack_Effect()
    {
        obj1 = Instantiate(Effect[1], new Vector3(0.0f, 0.0f, 0), Quaternion.identity, _parentGameObject.transform);
    }

    void Enemy_Defeat()
    {
        PlayerController.MP = PlayerController.MP_max;
        tag_get = true;
        Destroy(obj1);
        Destroy(GameObject.Find("Enmey_HP"));
        Destroy(playerController.obj_player);
        HP_Bar.SetActive(false);//HP�o�[
        animator.SetBool("death", true);//death�t���O��true�ɂ���
        turn_manager.turn = true;
        Log.text = "�퓬�ɏ��������I�I�I";
    }
}