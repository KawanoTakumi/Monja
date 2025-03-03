using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy_controller : MonoBehaviour
{
    //ステータス
    public static int HP = 100;      //エネミーHP
    public int attack;　             //エネミー物理攻撃力
    int deffence = 5;             //エネミー物理防御加算値
    public int magic;                //エネミー魔法攻撃力
    public int magic_Diffence;       //エネミー魔法防御加算値
    public int money;                //エネミードロップ金額
    public  static int HP_MAX = 100; //エネミーHP最大値

    public GameObject[] Effect;//エフェクト用
    public GameObject Monster;//エネミーオブジェクト
    public GameObject obj1;       //エフェクト用オブジェクト
    public GameObject obj2;//エフェクト用オブジェクト
    [SerializeField] GameObject _parentGameObject;//親オブジェクト
    turn_manager turn_Manager;          //turnManager読み込み
    Damage_calculate damage_Calculate;  //ダメージ計算
    Enemy_SE enemy_SE;                  //エネミーSE
    PlayerController playerController;  //プレイヤーコントローラ
    public Status_Controller status_;   //ステータス
    GameObject player;                  //プレイヤーオブジェクト
    Animator animator;                  //アニメーター
    public int Enemy_attack;            //攻撃力(計算後)
    public int Enemy_deffence;          //防御初期値
    public int Enemy_Magic;             //魔法攻撃力(計算後)
    int Enemy_act = 0;                  //エネミー行動判別用
    int Enemy_luck = 0;                 //エネミーラック判定用
    static int Enemy_luck_Max;　　  　　//エネミーラック値
    static int magic_cnt = 0;　　　  　 //魔法攻撃回数カウント
    bool Deffence_flag = false;
    //-------------------------  
    //エネミー判別用
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
    public static int turn = 1;//ターン
    public static bool tag_get = true;//タグ取得用フラグ
    int turn_time = 0;//ターンの時間
    public Text Log;//ログテキスト
    public Text Log_2; 
    public static bool End_Game_Flag = false;//ゲーム終了フラグ
    public GameObject HP_Bar;//体力バー
    //状態異常変数
    public bool poison;                      //毒
    public bool OnFire;                      //炎上
    public static bool Freeze_turn = false;  //凍結
    public static bool Stone_turn = false;   //石化
    public static bool Stun_turn = false;    //気絶

    //各シーン到達後trueにする
    public static bool TheGrimReaper_flag = false;
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

        Enemy_GetTag(); //タグを探す

        //持ち物画面から来た時に読み込まれないようにする
        if (tag_get == true)
        {
            tag_get = false;
            //敵の種類判別　ステータス設定
            if (CompareTag("skelton") == true)
            {
                Enemy_Skelton = true;
                HP = 75;
                HP_MAX = 75;
                Enemy_deffence = 10;
                Enemy_luck_Max = 16;
            }
            else if (CompareTag("Lich") == true)
            {
                Enemy_Lich = true;
                HP = 120;
                HP_MAX = 120;
                Enemy_deffence = 10;
                Enemy_luck_Max = 0;
            }
            else if (CompareTag("TheGrimReaper") == true)
            {
                Boss_TheGrimReaper = true;
                HP = 240;
                HP_MAX = 240;
                Enemy_deffence = 30;
                Enemy_luck_Max = 26;
            }
            else if (CompareTag("minotaurus") == true)
            {
                Enemy_Minotaurus = true;
                HP = 320;
                HP_MAX = 320;
                Enemy_deffence = 30;
                Enemy_luck_Max = 9;
            }
            else if (CompareTag("centaurus") == true)
            {
               Enemy_Centaurus = true;
                HP = 400;
                HP_MAX = 400;
                Enemy_deffence = 35;
                Enemy_luck_Max = 11;
            }
            else if (CompareTag("medhusa") == true)
            {
                Boss_Medhusa = true;
                HP = 460;
                HP_MAX = 460;
                Enemy_deffence = 35;
                Enemy_luck_Max = 0;
            }
            else if (CompareTag("cockatrice") == true)
            {
                Enemy_Cockatrice = true;
                HP = 500;
                HP_MAX = 500;
                Enemy_deffence = 45;
                Enemy_luck_Max = 16;
            }
            else if (CompareTag("knight") == true)
            {
                Enemy_Knight = true;
                HP = 560;
                HP_MAX = 560;
                Enemy_deffence = 55;
                Enemy_luck_Max = 9;
            }
            else if (CompareTag("dragon") == true)
            {
                Boss_Dragon = true;
                HP = 860;
                HP_MAX = 860;
                Enemy_deffence = 60;
                Enemy_luck_Max = 11;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //タグを探す
        Enemy_GetTag();

        //敵行動関数呼び出し
        if (Enemy_Skelton == true && turn_time == 10) //敵　スケルトン
        {
            Skelton();
        }
        else if (Enemy_Centaurus == true && turn_time == 10) //敵　ケンタウロス
        {
            Centaurus();
        }
        else if (Enemy_Lich == true && turn_time == 10) //敵　リッチ
        {
            Lich();
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
        else if (Boss_TheGrimReaper == true && turn_time == 10) //敵　死神（ボス）
        {
            TheGrimReaper();
        }
        else if (Boss_Dragon == true && turn_time == 10) //敵　ドラゴン（ボス）
        {
            Dragon();
        }
        //ターンがtrueの時エフェクトオブジェクトを削除
        if (turn_manager.turn == true)
        {
            Destroy(obj1);
        }
        if (turn_manager.turn == false)
        {
            //EnemyAttackを初期化
            Enemy_attack = 0;
            Enemy_Magic = 0;
            if (Deffence_flag == true)
            {
                Enemy_deffence -= deffence;
                Deffence_flag = false;
            }


            Destroy(playerController.Player_object);
            if (Item_Power.Watch_Add_reset == false)//アイテム：Watchの増加分ステータスリセット
            {
                playerController.Attack_damage -= PlayerController.HP_max - PlayerController.HP;
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
                playerController.Intaract_True();
                Item_Power.first_turn = false;
                Destroy(playerController.Player_object);
                status_.Delete_Effect();
                turn_manager.turn = true;
                Log.text = ("プレイヤーのターン");
                Log_2.text = "";
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
                Enemy_Defeat(); //敵　撃破画面移行
            }
          
            //ターンタイムが数値より大きくなったらターン変更
            turn_time++;
            if (turn_time > turn_manager.turn_time_max)
            {
                Item_Power.turn_bool = true;
                status_.Delete_Effect();
                turn += 1;
                playerController.Intaract_True();
                Item_Power.first_turn = false;
                turn_manager.turn = true;
                playerController.Log[1].text = "";
                playerController.Log[0].text = "";
                //時間の初期化
                turn_time = 0;
                //ターンが５よりも大きくなったら獲得金額を５ずつ減らす
                if (turn >= 5)
                {
                    money -= 5;
                    //moneyが0以下になったら、moneyを0にする
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

    //敵行動関数

    //アタック
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
    //防御
    void Defence()
    {
        Create_Effect_Enemy(0, 2.3f, 0f);
        enemy_SE.SE_Monster(2);//防御SE
        Enemy_deffence += deffence;
        Deffence_flag = true;
    }
    //魔法
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
    //回復
    void Heal()
    {
        HP += HP / 10;
    }

    //スケルトン
    void Skelton()
    {
        Enemy_act = Random.Range(1, 4);//1〜3まで
        switch (Enemy_act)
        {
            case 1:
                Attack(1);
                Log.text = ("スケルトンの攻撃"); Log_list.LogList.Add("　スケルトンの攻撃\n");//ログリストに追加
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Deffence);
                break;
            case 2:
                Attack(1);
                Log.text = ("スケルトンの攻撃"); Log_list.LogList.Add("　スケルトンの攻撃\n");//ログリストに追加
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Deffence);
                break;
            case 3:
                Defence();
                Log.text = ("スケルトンは防御した"); Log_list.LogList.Add("　スケルトンは防御した\n");//ログリストに追加
                break;
        }
    }
    //リッチ
    void Lich()
    {
        Enemy_act = Random.Range(1, 4);//1〜3まで
        switch (Enemy_act)
        {
            case 1:
                Magic();
                Log.text = ("リッチの魔法攻撃"); Log_list.LogList.Add("　リッチの魔法攻撃\n");//ログリストに追加
                Create_Effect_Enemy(1, 5.5f, 0.4f);
                damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_diffence);
                break;
            case 2:
                Magic();
                Log.text = ("リッチの魔法攻撃"); Log_list.LogList.Add("　リッチの魔法攻撃\n");//ログリストに追加
                Create_Effect_Enemy(1, 5.5f, 0.4f);
                damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_diffence);
                break;
            case 3:
                Heal();
                Log.text = ("リッチは回復した"); Log_list.LogList.Add("　リッチは回復した\n");//ログリストに追加
                break;
        }
    }
    //ミノタウロス
    void Minotaurus()
    {
        Enemy_act = Random.Range(1, 4);//1〜3まで
        switch (Enemy_act)
        {
            case 1:
                Attack(1);
                Log.text = ("ミノタウロスの攻撃"); Log_list.LogList.Add("　ミノタウロスの攻撃\n");//ログリストに追加
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Deffence);
                break;
            case 2:
                Attack(1);
                Log.text = ("ミノタウロスの攻撃"); Log_list.LogList.Add("　ミノタウロスの攻撃\n");//ログリストに追加
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Deffence);
                break;
            case 3:
                Defence();
                Log.text = ("ミノタウロスは防御した"); Log_list.LogList.Add("　ミノタウロスは防御した\n");//ログリストに追加
                break;
        }
    }
    //ケンタウロス
    void Centaurus()
    {
        Enemy_act = Random.Range(1, 4);//1〜3まで
        switch (Enemy_act)
        {
            case 1:
                Attack(2);
                Log.text = ("ケンタウロスの弓攻撃"); Log_list.LogList.Add("　ケンタウロスの弓攻撃\n");//ログリストに追加
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Deffence);
                break;
            case 2:
                Attack(2);
                Log.text = ("ケンタウロスの弓攻撃"); Log_list.LogList.Add("　ケンタウロスの弓攻撃\n");//ログリストに追加
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Deffence);
                break;
            case 3:
                Defence();
                Log.text = ("ケンタウロスは防御した"); Log_list.LogList.Add("　ケンタウロスは防御した\n");//ログリストに追加
                break;
        }
    }
    //コカトリス
    void Cockatrice()
    {
        Enemy_act = Random.Range(1, 4);//1〜3まで
        switch (Enemy_act)
        {
            case 1:
                Magic();
                Log.text = ("コカトリスの魔法攻撃"); Log_list.LogList.Add("　コカトリスの魔法攻撃\n");//ログリストに追加
                Create_Effect_Enemy(3, 0.0f, 0.0f);
                damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_diffence);
                break;
            case 2:
                Attack(1);
                Log.text = ("コカトリスの攻撃"); Log_list.LogList.Add("　コカトリスの攻撃\n");//ログリストに追加
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Deffence);
                break;
            case 3:
                Defence();
                Log.text = ("コカトリスは防御した"); Log_list.LogList.Add("　コカトリスは防御した\n");//ログリストに追加
                break;
        }
    }
    //ナイト
    void Knight()
    {
        Enemy_act = Random.Range(1, 4);//1〜3まで
        switch (Enemy_act)
        {
            case 1:
                Attack(2);
                Log.text = ("ナイトは斬撃を飛ばした"); Log_list.LogList.Add("　ナイトは斬撃を飛ばした\n");//ログリストに追加
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Deffence);
                break;
            case 2:
                Heal();
                Log.text = ("ナイトは回復した"); Log_list.LogList.Add("　ナイトは回復した\n");//ログリストに追加
                break;
            case 3:
                Defence();
                Log.text = ("ナイトは防御した"); Log_list.LogList.Add("　ナイトは防御した\n");//ログリストに追加
                break;
        }
    }

    //メデューサ
    void Medhusa()
    {
        int stone_luck;
        stone_luck = Random.Range(0, 5);
        Enemy_act = Random.Range(1, 5);//1〜4まで
        switch (Enemy_act)
        {
            case 1:
                medhusa_magic();
                Log.text = ("メデューサの魔法攻撃"); Log_list.LogList.Add("　メデューサの魔法攻撃\n");//ログリストに追加
                damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_diffence);
                break;
            case 2:
                medhusa_magic();
                Log.text = ("メデューサの石化攻撃"); Log_list.LogList.Add("　メデューサの石化攻撃\n");//ログリストに追加
                switch (stone_luck)
                {
                    case 1:
                    case 2:
                    case 3: Log.text = "石化しなかった"; Log_list.LogList.Add("　石化しなかった\n"); break;
                    case 4: Log.text = "石化してしまった"; Log_list.LogList.Add("　石化してしまった\n");status_.Status_Effect(true, 1); Stone_turn = true; break;
                }
                break;
            case 3:
                Heal();
                Log.text = ("メデューサは回復した"); Log_list.LogList.Add("　メデューサは回復した\n");//ログリストに追加
                break;
            case 4:
                Defence();
                Log.text = ("メデューサは防御した"); Log_list.LogList.Add("　メデューサは防御した\n");//ログリストに追加
                break;
        }
    }
    //メデューサの魔法攻撃
    void medhusa_magic()
    {
        Enemy_luck = Random.Range(1, 6);
        if (Enemy_luck == 6)
        {
            Enemy_Magic = magic;
            poison = true;
            Log.text = ("メデューサの毒発動"); Log_list.LogList.Add("　メデューサの毒発動\n");//ログリストに追加
            Create_Effect_Enemy(1, 2.5f, 0.3f);

        }
    }
    //死神
    void TheGrimReaper()
    {
        Enemy_act = Random.Range(1, 5);//1〜4まで
        switch (Enemy_act)
        {
            case 1:
                TheGrimReaper_attack();
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Deffence);
                break;
            case 2:
                TheGrimReaper_attack();
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Deffence);
                break;
            case 3:
                Defence();
                Log.text = ("死神は防御した"); Log_list.LogList.Add("　死神は防御した\n");//ログリストに追加
                break;
            case 4:
                Defence();
                Log.text = ("死神は防御した"); Log_list.LogList.Add("　死神は防御した\n");//ログリストに追加
                break;
        }
    }
    //死神の攻撃
    void TheGrimReaper_attack()
    {
        animator.SetBool("Attack", true);
        Enemy_luck = Random.Range(1, 21);
        if (Enemy_luck < 20)
        {
            Log.text = ("死神の攻撃"); Log_list.LogList.Add("　死神の攻撃\n");//ログリストに追加
            Enemy_attack = attack;
            Create_Effect_Enemy(1, 2.5f, 0.3f);
        }
        else if (Enemy_luck == 20)
        {
            PlayerController.HP /= 2;
            Log.text = ("死神の呪い"); Log_list.LogList.Add("　死神の呪い\n");//ログリストに追加
            Create_Effect_Enemy(1, 2.5f, 0.3f);
        }
    }
    //ドラゴン
    void Dragon()
    {
        Enemy_act = Random.Range(1, 5);//1〜4まで
        switch (Enemy_act)
        {
            case 1:
                dragon_attack();
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Deffence);
                break;
            case 2:
                dragon_magic();
                Log.text = ("ドラゴンの魔法攻撃"); Log_list.LogList.Add("　ドラゴンの魔法攻撃\n");//ログリストに追加
                damage_Calculate.Player_Damage_Calculate(Enemy_Magic, playerController.Magic_diffence);
                break;
            case 3:
                dragon_attack();
                damage_Calculate.Player_Damage_Calculate(Enemy_attack, playerController.Deffence);
                break;
            case 4:
                dragon_Heal();
                Log.text = ("ドラゴンは回復した"); Log_list.LogList.Add("　ドラゴンは回復した\n");//ログリストに追加
                break;
        }
    }
    //ドラゴンの攻撃
    void dragon_attack()
    {
        Enemy_luck = Random.Range(1, 6);
        if (Enemy_luck <= 4)
        {
            Log.text = ("ドラゴンの攻撃"); Log_list.LogList.Add("　ドラゴンの攻撃\n");//ログリストに追加
            Create_Effect_Enemy(3, -5.4f, 0.3f);
            Enemy_attack = attack;
        }
        else if (Enemy_luck == 5)
        {
            Enemy_attack = attack + 20;
            Log.text = ("龍の高揚"); Log_list.LogList.Add("　龍の高揚\n");//ログリストに追加
            Create_Effect_Enemy(3, -5.4f, 0.3f);
        }
    }
    //ドラゴンの魔法攻撃
    void dragon_magic()
    {
        if (magic_cnt < 2)
        {
            Create_Effect_Enemy(4, 0.0f, 0.2f);
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
    //ドラゴンの回復
    void dragon_Heal()
    {
        HP += HP / 10 + Enemy_attack;
    }

    //アニメーション終了用関数(bool型のみ)
    public void Anim_Reset(string anim_tag)
    {
        animator.SetBool(anim_tag, false);
    }
    //ターンフラグ
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
                    obj1 = Instantiate(Effect[number], new Vector3(_parentGameObject.transform.position.x, _parentGameObject.transform.position.y, 0), Quaternion.identity, _parentGameObject.transform);
                    obj1.name = "obj_name" + number;
                }break;
            case 0:
                {
                    obj2 = Instantiate(Effect[number], new Vector3(_parentGameObject.transform.position.x, _parentGameObject.transform.position.y, 0), Quaternion.identity, _parentGameObject.transform);
                    obj2.name = "obj_name" + number;
                }
                break;
        }
    }
    //勝ち
    public void Win()
    {
        //各種数値を初期化
        animator.SetBool("death", false);
        Monster.SetActive(false);
        Win_Reset();
        PlayerController.Status_Reset();
        Item_Power.turn_compare = 0;
        Item_Power.M_eye_flag = false;
        Item_Power.M_magic_book_flag = false;
        Freeze_turn = false;
        Item_Power.Pencil_Down_cnt = 0;
        Destroy(obj1);
        Destroy(obj2);
        Destroy(Status_Controller.eff_obj);
        magic_cnt = 0;
        turn = 1;
        Log_list.Log_Clear();//ログを初期化
        Cut_In.FIRST_FLAG = true;
        if (ChangeScene.SCENE_CNT >= 9)
        {
            PlayerController.Mmoney += money;
            Item_Power.first_turn = true;
            Item_Power.Sinigami_Crit_Effect = false;
            Dragon_flag = true;
            PlayerController.HP_potion = 0;
            ChangeScene.Title_Reset();
            SceneManager.LoadScene("ending");
        }
        else
        {
            PlayerController.Mmoney += money;
            Item_Power.first_turn = true;
            if(ChangeScene.SCENE_CNT >= 6)
            {
                Medhusa_flag = true;
            }
            else if(ChangeScene.SCENE_CNT >= 3)
            {
                TheGrimReaper_flag = true;
            }
            SceneManager.LoadScene("Win");
        }
    }
    //クリティカルエフェクトを削除
    public void Crit_Del()
    {
        Destroy(obj1);
    }
    //リセット関数
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

    void Enemy_Defeat()
    {
        PlayerController.MP = PlayerController.MP_max;
        tag_get = true;
        Destroy(obj1);
        Destroy(GameObject.Find("Enmey_HP"));
        Destroy(playerController.Player_object);
        HP_Bar.SetActive(false);//HPバー
        animator.SetBool("death", true);//deathフラグをtrueにする
        turn_manager.turn = true;
        Log.text = "戦闘に勝利した！！！";
        Log_list.LogList.Add("　戦闘に勝利した\n");//ログリストに追加
    }
}