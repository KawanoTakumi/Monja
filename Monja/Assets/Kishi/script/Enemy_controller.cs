using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Enemy_controller : MonoBehaviour
{
    //ステータス
    public static int HP = 100;
    public int attack;
    public int deffence;
    public int magic;
    public int magic_Diffence;
    public int money;
    public  static int HP_MAX = 100;

    public GameObject[] Effect;//エフェクト用
    public GameObject Monster;
    GameObject obj1;
    [SerializeField] GameObject _parentGameObject;

    turn_manager turn_Manager;//turnManager読み込み
    Damage_calculate damage_Calculate;
    PlayerController playerController;
    GameObject player;
    Animator animator;
    public int Enemy_attack;//攻撃力(計算後)
    public int Enemy_deffence;//防御力(計算後)
    public int Enemy_Magic;//魔法攻撃力(計算後)
    int Enemy_act = 0;
    int Enemy_luck = 0;
    static int Enemy_luck_Max;
    bool Enemy_Skelton;
    bool Enemy_Centaurus;
    bool Enemy_Richie;
    bool Enemy_Knight;
    bool Enemy_Minotaurus;
    bool Enemy_Cockatrice;
    bool Boss_Medhusa;
    bool Boss_sinigami;
    bool Boss_Dragon;
    public static int turn = 1;//ターン
    public static bool tag_get = true;
    int turn_time = 0;
    public Text Log;
    public bool poison;
    public static bool End_GAme_Flag = false;
    public GameObject HP_Bar;

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
        GameObject.FindWithTag("centaurus");
        GameObject.FindWithTag("richie");
        GameObject.FindWithTag("minotaurus");
        GameObject.FindWithTag("knight");
        GameObject.FindWithTag("cockatrice");
        GameObject.FindWithTag("medhusa");
        GameObject.FindWithTag("sinigami");
        GameObject.FindWithTag("dragon");

        //持ち物画面から来た時に読み込まれないようにする
        if (tag_get == true)
        {
            tag_get = false;
            //タグの比較
            if (CompareTag("skelton") == true)
            {
                Enemy_Skelton = true;
                HP = 75;
                HP_MAX = 75;
                Enemy_luck_Max = 16;
            }
            else if (CompareTag("centaurus") == true)
            {
               Enemy_Centaurus = true;
                HP = 200;
                HP_MAX = 200;
                Enemy_luck_Max = 11;
            }
            else if (CompareTag("richie") == true)
            {
                Enemy_Richie = true;
                HP = 100;
                HP_MAX = 100;
                Enemy_luck_Max = 0;
            }
            else if (CompareTag("minotaurus") == true)
            {
                Enemy_Minotaurus = true;
                HP = 350;
                HP_MAX = 350;
                Enemy_luck_Max = 9;
            }
            else if (CompareTag("knight") == true)
            {
                Enemy_Knight = true;
                HP = 600;
                HP_MAX = 600;
                Enemy_luck_Max = 9;
            }
            else if (CompareTag("cockatrice") == true)
            {
                Enemy_Cockatrice = true;
                HP = 550;
                HP_MAX = 500;
                Enemy_luck_Max = 16;
            }
            else if (CompareTag("medhusa") == true)
            {
                Boss_Medhusa = true;
                HP =650;
                HP_MAX = 650;
                Enemy_luck_Max = 0;
            }
            else if (CompareTag("sinigami") == true)
            {
                Boss_sinigami = true;
                HP = 500;
                HP_MAX = 500;
                Enemy_luck_Max = 26;
            }
            else if (CompareTag("dragon") == true)
            {
                Boss_Dragon = true;
                HP = 1000;
                HP_MAX = 1000;
                Enemy_luck_Max = 11;
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
            //EnemyAttackを初期化
            Enemy_attack = 0;

            //HPが0になったらクリア画面を出す
            if (HP <= 0)
            {
                PlayerController.MP = 100;
                turn = 1;
                tag_get = true;
                HP_Bar.SetActive(false);//HPバーwo
 
                animator.SetBool("death", true);//deathフラグをtrueにする
            }
            if (Enemy_Skelton == true && turn_time == 35) //敵　スケルトン
            {
                Skelton();
            }
            else if (Enemy_Centaurus == true && turn_time == 35) //敵　メデューサ（ボス）
            {
                Centaurus();
            }
            else if (Enemy_Richie == true && turn_time == 35) //敵　メデューサ（ボス）
            {
                Richie();
            }
            else if (Enemy_Knight == true && turn_time == 35) //敵　メデューサ（ボス）
            {
                Knight();
            }
            else if (Enemy_Cockatrice == true && turn_time == 35) //敵　メデューサ（ボス）
            {
                Cockatrice();
            }
            else if (Enemy_Minotaurus == true && turn_time == 35) //敵　メデューサ（ボス）
            {
                Minotaurus();
            }

            else if (Boss_Medhusa == true && turn_time == 35) //敵　メデューサ（ボス）
            {
                Medhusa();
            }
            else if (Boss_sinigami == true && turn_time == 35) //敵　メデューサ（ボス）
            {
                Sinigami();
            }
            else if (Boss_Dragon == true && turn_time == 35) //敵　メデューサ（ボス）
            {
                Dragon();
            }
            turn_time++;
            if (turn_time >= 150)
            {
                Log.text = ("敵ターン終了");
                Debug.Log("主人公体力" + PlayerController.HP);
                turn += 1;
                playerController.Attack_.interactable = true;
                playerController.Magic_.interactable = true;
                playerController.Heal_.interactable = true;
                playerController.Concentlation_.interactable = true;


                turn_Manager.turn = true;
                Log.text = ("プレイヤーのターン");
                //時間の初期化
                turn_time = 0;
                
                if (turn >= 5)
                {
                    money -= 5;//ターンが５よりも大きくなったら獲得金額を５ずつ減らす
                    //moneyが0以下になったら、moneyを0にする
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
          
            Enemy_luck = Random.Range(1, Enemy_luck_Max);
            if (Enemy_luck <= 9)
            {
                Enemy_attack = attack;
            }
            else if (Enemy_luck == Enemy_luck_Max-1)
            {
                Enemy_attack = attack + attack/2;
              
            }
        }
        void Defence()
        {
            Create_Effect_Enemy(0, 2.3f, 0f);
            
            Enemy_deffence += deffence;
        }

     

        void Magic()
        {
            Log.text = ("敵の魔法攻撃");
            int magic_cnt = 0;
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

        void Heal()
        {
            HP += HP / 10;
        }

        //スケルトン
        void Skelton()
        {
            Enemy_act = Random.Range(1, 4);//1～3まで
            switch (Enemy_act)
            {
                case 1:
                    Attack();
                    Log.text = ("スケルトンの攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    Attack();
                    Log.text = ("スケルトンの攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 3:
                    Defence();
                    Log.text = ("スケルトンは防御した");
                    Enemy_deffence = deffence;
                    break;
            }
        }
        void Minotaurus()
        {
            Enemy_act = Random.Range(1, 4);//1～3まで
            switch (Enemy_act)
            {
                case 1:
                    Attack();
                    Log.text = ("ミノタウロスの攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    Attack();
                    Log.text = ("ミノタウロスの攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 3:
                    Defence();
                    Log.text = ("ミノタウロスは防御した");
                    Enemy_deffence = deffence;
                    break;
            }
        }
        void Cockatrice()
        {
            Enemy_act = Random.Range(1, 4);//1～3まで
            switch (Enemy_act)
            {
                case 1:
                    Magic();
                    Log.text = ("コカトリスの攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                    break;
                case 2:
                    Attack();
                    Log.text = ("コカトリスの攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 3:
                    Defence();
                    Log.text = ("コカトリスは防御した");
                    break;
            }
        }
        void Knight()
        {
            Enemy_act = Random.Range(1, 4);//1～3まで
            switch (Enemy_act)
            {
                case 1:
                    Attack();
                    Log.text = ("ナイトの攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    Heal();
                    Log.text = ("ナイトの攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 3:
                    Defence();
                    Log.text = ("ナイトは防御した");
                    break;
            }
        }
        void Richie()
        {
            Enemy_act = Random.Range(1, 4);//1～3まで
            switch (Enemy_act)
            {
                case 1:
                    Magic();
                    Log.text = ("リッチの魔法攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                    break;
                case 2:
                    Magic();
                    Log.text = ("リッチの魔法攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                    break;
                case 3:
                    Heal();
                    Log.text = ("リッチは回復した");
                    break;
            }
        }
        void Centaurus()
        {
            Enemy_act = Random.Range(1, 4);//1～3まで
            switch (Enemy_act)
            {
                case 1:
                    Attack();
                    Log.text = ("ケンタウロスの弓攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    Attack();
                    Log.text = ("ケンタウロスの弓攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 3:
                    Attack();
                    Log.text = ("ケンタウロスの攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
            }
        }

        //メデューサ
        void Medhusa()
        {
            Enemy_act = Random.Range(1, 5);//1～4まで
            switch (Enemy_act)
            {
                case 1:
                    medhusa_magic();
                    Log.text = ("メデューサの魔法攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                    break;
                case 2:
                    medhusa_magic();
                    Log.text = ("メデューサの魔法攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                    break;
                case 3:
                    Heal();
                    Log.text = ("メデューサは回復した");
                    break;
                case 4:
                    Defence();
                    Log.text = ("メデューサは防御した");
                    break;
            }
        }
        void medhusa_magic()
        {
            Log.text = ("メデューサの魔法攻撃");
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
                Log.text = ("メデューサの毒発動");
            }
        }

        //死神
        void Sinigami()
        {
            Enemy_act = Random.Range(1, 5);//1～4まで
            switch (Enemy_act)
            {
                case 1:
                    sinigami_attack();
                    Log.text = ("死神の攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    sinigami_attack();
                    Log.text = ("死神の攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 3:
                    Defence();
                    Log.text = ("死神は防御した");
                    break;
                case 4:
                    Defence();
                    Log.text = ("死神は防御した");
                    break;
            }
        }
        void sinigami_attack()
        {
            animator.SetBool("Attack", true);
            Enemy_luck = Random.Range(1, 21);
            if (Enemy_luck <= 19)
            {
                Enemy_attack = attack;
            }
            else if (Enemy_luck == 20)
            {
                PlayerController.HP = PlayerController.HP /2;
                Log.text = ("死神の呪い");
                Create_Effect_Enemy(1, 2.5f, 0.3f);
            }
        }
        
       
        void Dragon()
        {
            Enemy_act = Random.Range(1, 5);//1～4まで
            switch (Enemy_act)
            {
                case 1:
                    dragon_attack();
                    Log.text = ("ドラゴンの攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    dragon_magic();
                    Log.text = ("ドラゴンの魔法攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 3:
                    dragon_attack();
                    Log.text = ("ドラゴンの攻撃");
                    Enemy_deffence = deffence;
                    break;
                case 4:
                    dragon_Heal();
                    Log.text = ("ドラゴンは防御した");
                    break;
            }
        }
        void dragon_attack()
        {
            animator.SetBool("Attack", true);
            Enemy_luck = Random.Range(1, 6);
            if (Enemy_luck <= 4)
            {
                Enemy_attack = attack;
            }
            else if (Enemy_luck == 5)
            {
                Enemy_attack += attack;
                Log.text = ("龍の高揚");
                Create_Effect_Enemy(1, 2.5f, 0.3f);
            }
        }
        void dragon_magic()
        {
            Log.text = ("敵の魔法攻撃");
            int magic_cnt = 0;
            if (magic_cnt < 2)
            {
                Enemy_Magic = magic;
                magic_cnt++;
            }
            else if (magic_cnt >= 2)
            {
                Enemy_Magic = magic + Enemy_attack;
            }
        }
        void dragon_Heal()
        {
            HP += HP / 10 + Enemy_attack;
        }


    }

    //アニメーション終了用関数(bool型のみ)
    public void Anim_Reset(string anim_tag)
    {
        animator.SetBool(anim_tag, false);
    }
    public void Turn_Flag()
    {
        turn_Manager.turn = false;
    }

    //エフェクトオブジェクト作成関数
    public void Create_Effect_Enemy(int number, float Fx, float Fy)
    {
        
        {
            obj1 = Instantiate(Effect[number], new Vector3(Fx, Fy, 0), Quaternion.identity, _parentGameObject.transform);
            obj1.name = "Effect_image_"+number;
        }
    }
    public void Win()
    {
        animator.SetBool("death", false);
        Monster.SetActive(false);
        Destroy(obj1);
        if (ChangeScene.scene_cnt >= 9)
        {
            PlayerController.Money += money;
            SceneManager.LoadScene("ending");
        }
        else
        {
            PlayerController.Money += money;
            SceneManager.LoadScene("Win");
        }
    }
}