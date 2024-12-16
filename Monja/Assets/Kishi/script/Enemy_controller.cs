using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Enemy_controller : MonoBehaviour
{
    //ステータス
    public static int HP = 100; //エネミーHP
    public int attack;　//エネミー物理攻撃力
    public int deffence;  //エネミー物理防御力
    public int magic; //エネミーマホウ攻撃力
    public int magic_Diffence; //エネミーマホウ防御力
    public int money;          //エネミードロップ金額
    public  static int HP_MAX = 100; //エネミーHP最大値

    public GameObject[] Effect;//エフェクト用
    public GameObject Monster;
    GameObject obj1;
    public GameObject obj2;
    [SerializeField] GameObject _parentGameObject;
    turn_manager turn_Manager;//turnManager読み込み
    Damage_calculate damage_Calculate;
    Enemy_SE enemy_SE;
    PlayerController playerController;
    public Status_Controller status_;
    GameObject player;
    Animator animator;
    public int Enemy_attack;//攻撃力(計算後)
    public int Enemy_deffence;//防御力(計算後)
    public int Enemy_Magic;//魔法攻撃力(計算後)
    int Enemy_act = 0;  //エネミー行動判別用
    int Enemy_luck = 0; //エネミーラック判定用
    static int Enemy_luck_Max;　　　　//エネミーラック値
    static int magic_cnt = 0;　　　　//魔法攻撃回数カウント
    //-------------------------
    //エネミー判別用
    static bool Enemy_Skelton;  
    static bool Enemy_Centaurus;
    static bool Enemy_Richie;
    static bool Enemy_Knight;
    static bool Enemy_Minotaurus;
    static bool Enemy_Cockatrice;
    static bool Boss_Medhusa;
    static bool Boss_sinigami;
    static bool Boss_Dragon;
    //----------------------------
    public static int turn = 1;//ターン
    public static bool tag_get = true;
    int turn_time = 0;
    public Text Log;
    public static bool End_Game_Flag = false;
    public GameObject HP_Bar;
    //状態異常変数
    public bool poison;
    public bool OnFire;
    public static bool Freeze_turn = false;
    public static bool Stone_turn = false;

    //各シーン到達後trueにする
    public static bool Sinigami_flag = false;
    public static bool Medhusa_flag = false;
    public static bool Dragon_flag = false;

    // Start is called before the first frame update
    void Start()
    {

        //エネミーオブジェクトタグ取得
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        GameObject obj = GameObject.Find("Player");
        turn_Manager = obj.GetComponent<turn_manager>();
        enemy_SE = GetComponent<Enemy_SE>();
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
            
            if (CompareTag("skelton") == true)
            {
                Enemy_Skelton = true;
                HP = 75;
                HP_MAX = 75;
                Enemy_luck_Max = 16;
            }
            else if (CompareTag("richie") == true)
            {
                Enemy_Richie = true;
                HP = 120;
                HP_MAX = 120;
                Enemy_luck_Max = 0;
            }
            else if (CompareTag("sinigami") == true)
            {
                Boss_sinigami = true;
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
                HP = 570;
                HP_MAX = 570;
                Enemy_luck_Max = 16;
            }
            else if (CompareTag("knight") == true)
            {
                Enemy_Knight = true;
                HP = 680;
                HP_MAX = 680;
                Enemy_luck_Max = 9;
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
        //タグを探す
        GameObject.FindWithTag("skelton");
        GameObject.FindWithTag("centaurus");
        GameObject.FindWithTag("richie");
        GameObject.FindWithTag("minotaurus");
        GameObject.FindWithTag("knight");
        GameObject.FindWithTag("cockatrice");
        GameObject.FindWithTag("medhusa");
        GameObject.FindWithTag("sinigami");
        GameObject.FindWithTag("dragon");

        if (turn_manager.turn == true)
        {
            Destroy(obj1);
        }
        if (turn_manager.turn == false)
        {
            //EnemyAttackを初期化
            Enemy_attack = 0;
            Enemy_Magic = 0;
            if(Freeze_turn == true)
            {
                Freeze_turn = false;
                if(HP > 0)
                {
                    turn += 1;
                }
                playerController.intaract_true();
                Item_Power.first_turn = false;
                Destroy(playerController.obj_player);
                turn_manager.turn = true;
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
            //HPが0になったらクリア画面を出す
            if (HP <= 0)
            {
                PlayerController.MP = PlayerController.MP_max;
                tag_get = true;
                Destroy(obj1);
                Destroy(GameObject.Find("Enmey_HP"));
                Destroy(playerController.obj_player);
                HP_Bar.SetActive(false);//HPバー
                animator.SetBool("death", true);//deathフラグをtrueにする
                turn_manager.turn = true;
                Log.text = "戦闘に勝利した！！！";
            }
            if (Enemy_Skelton == true && turn_time == 10) //敵　スケルトン
            {
                Skelton();
            }
            else if (Enemy_Centaurus == true && turn_time == 10) //敵　ケンタウロス
            {
                Centaurus();
            }
            else if (Enemy_Richie == true && turn_time == 10) //敵　リッチ
            {
                Richie();
            }
            else if (Enemy_Knight == true && turn_time == 10) //敵　ナイト
            {
                Knight();
            }
            else if (Enemy_Cockatrice == true && turn_time == 10) //敵　コカトリス
            {
                Cockatrice();
            }
            else if (Enemy_Minotaurus == true && turn_time == 10) //敵　ミノタウロス
            {
                Minotaurus();
            }

            else if (Boss_Medhusa == true && turn_time == 10) //敵　メデューサ（ボス）
            {
                Medhusa();
            }
            else if (Boss_sinigami == true && turn_time == 10) //敵　死神（ボス）
            {
                Sinigami();
            }
            else if (Boss_Dragon == true && turn_time == 10) //敵　ドラゴン（ボス）
            {
                Dragon();
            }
            //ターンタイムが数値より大きくなったらターン変更
            turn_time++;
            if (turn_time > turn_manager.turn_time_max)
            {
                Log.text = ("敵ターン終了");
                turn += 1;
                playerController.intaract_true();
                Item_Power.first_turn = false;
                turn_manager.turn = true;
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
        void Attack(int paturn)
        {
            switch(paturn)
            {
                case 1: animator.SetBool("Attack", true);break;
                case 2:Create_Effect_Enemy(1, 0.0f,0.0f);break;
            }

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
            enemy_SE.SE_Monster(2);
            Enemy_deffence = deffence;
        }

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
                    Attack(1);
                    Log.text = ("スケルトンの攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    Attack(1);
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
        //リッチ
        void Richie()
        {
            Enemy_act = Random.Range(1, 4);//1～3まで
            switch (Enemy_act)
            {
                case 1:
                    Magic();
                    Log.text = ("リッチの魔法攻撃");
                    Create_Effect_Enemy(1, 5.5f, 0.4f);
                    damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                    break;
                case 2:
                    Magic();
                    Log.text = ("リッチの魔法攻撃");
                    Create_Effect_Enemy(1, 5.5f, 0.4f);
                    damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                    break;
                case 3:
                    Heal();
                    Log.text = ("リッチは回復した");
                    break;
            }
        }

        void Minotaurus()
        {
            Enemy_act = Random.Range(1, 4);//1～3まで
            switch (Enemy_act)
            {
                case 1:
                    Attack(1);
                    Log.text = ("ミノタウロスの攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    Attack(1);
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
        void Centaurus()
        {
            Enemy_act = Random.Range(1, 4);//1～3まで
            switch (Enemy_act)
            {
                case 1:
                    Attack(2);
                    Log.text = ("ケンタウロスの弓攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    Attack(2);
                    Log.text = ("ケンタウロスの弓攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 3:
                    Defence();
                    Log.text = ("ケンタウロスは防御した");
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
                    Log.text = ("コカトリスの魔法攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                    break;
                case 2:
                    Attack(1);
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
                    Attack(2);
                    Log.text = ("ナイトは斬撃を飛ばした");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    Heal();
                    Log.text = ("ナイトは回復した");
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 3:
                    Defence();
                    Log.text = ("ナイトは防御した");
                    break;
            }
        }

        //メデューサ
        void Medhusa()
        {
            int stone_luck;
            stone_luck = Random.Range(0, 5);
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
                    Log.text = ("メデューサの石化攻撃");
                    switch(stone_luck)
                    {
                        case 1:
                        case 2:
                        case 3:Log.text = "石化しなかった";break;
                        case 4: Log.text = "石化してしまった";status_.Status_Effect(true, 1); Stone_turn = true;break;
                    }
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
            if (Enemy_luck > 0)
            {
                Enemy_Magic = magic;
                poison = true;
                Log.text = ("メデューサの毒発動");
                Create_Effect_Enemy(1, 2.5f, 0.3f);
                
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
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    sinigami_attack();
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
                Log.text = ("死神の攻撃");
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
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 2:
                    dragon_magic();
                    Log.text = ("ドラゴンの魔法攻撃");
                    damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_Diffence);
                    break;
                case 3:
                    dragon_attack();
                    damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Diffence);
                    break;
                case 4:
                    dragon_Heal();
                    Log.text = ("ドラゴンは回復した");
                    break;
            }
        }
        void dragon_attack()
        {
            Enemy_luck = Random.Range(1, 6);
            if (Enemy_luck <= 4)
            {
                animator.SetBool("Attack", true);
                Log.text = ("ドラゴンの攻撃");
                Enemy_attack = attack;
            }
            else if (Enemy_luck == 5)
            {
                Enemy_attack = attack + 20;
                Log.text = ("龍の高揚");
                Create_Effect_Enemy(1, 2.5f, 0.3f);
            }
        }
        void dragon_magic()
        {
            if (magic_cnt < 2)
            {
                Enemy_Magic = magic;
                magic_cnt++;
            }
            else if (magic_cnt >= 2)
            {
                OnFire = true;
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
        turn_manager.turn = false;
    }

    //エフェクトオブジェクト作成関数
    public void Create_Effect_Enemy(int number, float Fx, float Fy)
    {
        switch(number)
        {
            default:
                {
                    obj1 = Instantiate(Effect[number], new Vector3(Fx, Fy, 0), Quaternion.identity, _parentGameObject.transform);
                    obj1.name = "Effect_image_" + number;
                }break;
            case 0:
                {
                    obj2 = Instantiate(Effect[number], new Vector3(Fx, Fy, 0), Quaternion.identity, _parentGameObject.transform);
                    obj2.name = "Effect_image_" + number;
                }
                break;
        }
    }
    public void Win()
    {
        animator.SetBool("death", false);
        Monster.SetActive(false);
        Win_Reset();
        PlayerController.Status_reset();
        Item_Power.turn_compare = 0;
        Freeze_turn = false;
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
                Sinigami_flag = true;
            }
            SceneManager.LoadScene("Win");
        }
    }
    public void Crit_Del()
    {
        Destroy(obj1);
    }
    void Win_Reset()
    {
        Enemy_Skelton = false;
        Enemy_Centaurus = false;
        Enemy_Richie = false;
        Enemy_Knight = false;
        Enemy_Minotaurus = false;
        Enemy_Cockatrice = false;
        Boss_Medhusa = false;
        Boss_sinigami = false;
        Boss_Dragon = false;
    }
    public void Attack_Effect()
    {
        obj1 = Instantiate(Effect[1], new Vector3(0.0f, 0.0f, 0), Quaternion.identity, _parentGameObject.transform);
    }
}