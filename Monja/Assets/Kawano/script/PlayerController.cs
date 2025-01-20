using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    //プレイヤーステータス（定数）
    public static int HP     = 100;             //HP
    public static int HP_MAX = 100;             //最高HP
    public static int MP     = 100;             //MP
    public static int MP_MAX = 100;             //最高MP
    public static int HP_POTION = 0;            //HPポーションの数
    public static int MONEY = 0;                //所持金額
    public static int MAX_LUCK = 13;            //最大ラック
    public static int MAGIC_TYPE = 0;         //魔法番号(撃てる魔法の種類)
    static int STATUS_MAX = 9999;               //ステータス上限
    static int STATUS_MIN = 0;                  //ステータス下限
    static int CONSTANT_ATTACK   = 25;          //攻撃の定数
    static int CONSTANT_DEFFENCE = 25;          //防御の定数
    static int CONSTANT_MAGIC    = 25;          //魔法の定数
    static int CONSTANT_MAGIC_DEFFENCE = 25;    //魔法防御の定数

    //プレイヤーステータス（変数）
    public int Attack_damage  = 0;              //攻撃力
    public int Deffence       = 0;              //防御力
    public int Magic_damage   = 0;              //魔法力
    public int Magic_diffence = 0;              //魔法防御力
    public int Calc_attack_damage  = 0;         //攻撃力(計算後)
    public int Calc_magic_damage   = 0;         //魔法力(計算後)
    public int Player_luck         = 0;         //プレイヤーのラック
    int Poison_cnt = 0;                         //毒のターン数
    int OnFire_cnt = 0;                         //延焼のターン数
    int Turn_time  = 0;                         //ターン経過時間
    int Magic_power_up  = 0;                    //マホウ強化変数

    //オブジェクト取得変数
    public Button Item_button;                      //アイテムボタン
    public Button Setting_button;                   //設定ボタン
    public Button Attack_button;                    //ザンゲキボタン
    public Button Concentlation_button;             //シュウチュウボタン
    public Button Magic_button;                     //マホウボタン
    public Button Heal_button;                      //カイフクボタン
    public GameObject Player_object;                //プレイヤーオブジェクト
    public Status_Controller Status_controller;     //ステータスコントローラー
    [SerializeField] GameObject ParentGameObject;   //親オブジェクト
    Animator Animator;                              //プレイヤーアニメーター
    Damage_calculate Damage_calculate;              //ダメージサーキュレーター
    Enemy_controller Enemy_controller;              //エネミーコントローラ
    GameObject Enemey;                              //敵オブジェクト
    public GameObject[] Effect;                     //エフェクト用配列
    public Text[] Log;                              //テキストログ用配列

    //フラグ
    bool Cons_flag     = false;                     //シュウチュウフラグ
    bool Button_check  = false;                     //ボタンチェックフラグ

    public AudioSource Audio_source_SE;             //SEオーディオソース
    [SerializeField] AudioClip[] Audio_clip_SE;     //SEオーディオクリップ

    //スタートメソッド
    //説明・・・オブジェクトのコンポーネントを読み込む、戦闘開始時にステータスを初期化、主人公ターンへ移行
    void Start()
    {
        //オブジェクトのコンポーネントを変数に読み込む
        Animator = GetComponent<Animator>();
        Damage_calculate = GetComponent<Damage_calculate>();
        Enemey = GameObject.Find("Monster");
        Enemy_controller = Enemey.GetComponent<Enemy_controller>();

        //初期の定数を変数に適用
        Attack_damage = CONSTANT_ATTACK;
        Deffence = CONSTANT_DEFFENCE;
        Magic_damage = CONSTANT_MAGIC;
        Magic_diffence = CONSTANT_MAGIC_DEFFENCE;

        //主人公のターンにする true = 主人公、false = 敵
        turn_manager.turn = true;
        Log[0].text = "主人公のターン";
    }

    //アップデートメソッド
    //説明・・・数値を保持させる、各エフェクト作成、プレイヤーのターンを経過させる
    void Update()
    {
        //数値を保存
        CONSTANT_ATTACK         = Attack_damage;
        CONSTANT_DEFFENCE       = Deffence;
        CONSTANT_MAGIC          = Magic_damage;
        CONSTANT_MAGIC_DEFFENCE = Magic_diffence;

        //エフェクト削除
        if (turn_manager.turn == false)
        {
            Destroy(Player_object);
        }
        else if(turn_manager.turn == true)
        {
            Destroy(GameObject.Find("obj_name1"));
        }
        //石化状態
        if(Enemy_controller.Stone_turn == true)
        {
            Enemy_controller.Stone_turn = false;
            turn_manager.turn = false;
        }
        //毒ダメージ
        if (Enemy_controller.poison == true)
        {
            Poison_cnt += 3;
            Enemy_controller.poison = false;
        }
        //延焼ダメージ
        if(Enemy_controller.OnFire == true)
        {
            OnFire_cnt += 2;
            Enemy_controller.OnFire = false;
        }
        //敗北
        if(HP <= 0)
        {
            Animator.SetBool("death",true);
            Log[0].text = "主人公は倒れてしまった";
            ChangeScene.scene_cnt = 1;//最初のシーンがcase :1
        }

       
       
        //ステータス上限
        if (Attack_damage >= STATUS_MAX)
        {
            Attack_damage = STATUS_MAX;
        }
        if(Deffence >= STATUS_MAX)
        {
            Deffence = STATUS_MAX;
        }
        if(Magic_damage >= STATUS_MAX)
        {
            Magic_damage = STATUS_MAX;
        }
        if(Magic_diffence >= STATUS_MAX)
        {
            Magic_diffence = STATUS_MAX;
        }
        if(HP >= HP_MAX)
        {
            HP = HP_MAX;
        }

        //ステータス下限
        if (Attack_damage < STATUS_MIN)
        {
            Attack_damage = STATUS_MIN;
        }
        if (Deffence < STATUS_MIN)
        {
            Deffence = STATUS_MIN;
        }
        if (Magic_damage < STATUS_MIN)
        {
            Magic_damage = STATUS_MIN;
        }
        if (Magic_diffence < STATUS_MIN)
        {
            Magic_diffence = STATUS_MIN;
        }
        if(HP < STATUS_MIN)
        {
            HP = STATUS_MIN;
        }
        if(MAX_LUCK < 2)
        {
            MAX_LUCK = 2;
        }

        //状態異常時の効果
        if(Button_check == true)
        {
            Turn_time++;
            if (Turn_time > turn_manager.turn_time_max)
            {
                Turn_time = 0;
                Button_check = false;
                //毒
                if (Poison_cnt > 0)
                {
                    HP -= 2;
                    Log[0].text = "毒の効果で体力が2減った";
                    Status_controller.Status_Effect(true, 2);
                    Poison_cnt -= 1;
                }
                //炎上
                if (OnFire_cnt > 0)
                {
                    HP -= 8;
                    Log[0].text = "延焼効果で体力が8減った";
                    Status_controller.Status_Effect(true, 3);
                    OnFire_cnt -= 1;
                }

                Log[0].text = "";
                turn_manager.turn = false;
            }
        }
    }
    //ザンゲキ
    public void attack()
    {
        Intaract_False();
        Animator.SetBool("attack", true);
        if (turn_manager.turn == true)
        {
            Button_check = true;
            Log[0].text = "主人公は攻撃した";
            Item_button.interactable = false;
            Player_luck = Random.Range(1,MAX_LUCK);
            if (Player_luck < MAX_LUCK - 1)
            {
                //遅延
                Invoke("SE_Play_Attack", 500.0f);

                Calc_attack_damage = Attack_damage;
            }
            else if (Player_luck == MAX_LUCK -1 || Item_Power.dice_crit == true)
            {
                Calc_attack_damage = Attack_damage + Attack_damage / 2;                
                Log[0].text = ("主人公クリティカルが発生");
                Item_Power.dice_crit = false;
            }
            if (Item_Power.Boxing_flag == true)
            {
                Attack_damage += 3;
            }

            Damage_calculate.Enemey_Damage_Calculate(Calc_attack_damage, Enemy_controller.Enemy_deffence);
        }
    }
    //シュウチュウ
    public void concentration()
    {

        if (turn_manager.turn == true)
        {
            if (MP < 100)
            {
                Button_check = true;
                Item_button.interactable = false;
                Intaract_False();
                Animator.SetBool("cons", true);
                MP += MP_MAX / 2;
                Log[0].text = "主人公は集中した";
                Magic_damage += 10;
                Magic_power_up++;
                Cons_flag = true;
                //MPがMP_maxより大きければMP_maxの値に合わせる
                if (MP > MP_MAX)
                {
                    MP = MP_MAX;
                }
            }
            else
            {
                Log[0].text = ("主人公は十分集中している");
            }
        }
    }
    //マホウ
    public void magic()
    {
        if (turn_manager.turn == true)
        {
            if(MP >= 25)
            {
                Button_check = true;
                Item_button.interactable = false;

                Intaract_False();
                Log[0].text = "主人公は魔法を撃った";
                Animator.SetBool("magic", true);
                switch (MAGIC_TYPE)
                {
                    case 0: Create_Effect_Player(0, 5.7f, 0.9f); break;
                    case 1: Create_Effect_Player(2, 0f, 0f);break;
                    case 2: Create_Effect_Player(3, 0f, 0f);break;
                    case 6: Create_Effect_Player(6, 0f, 0f);break;
                }

                MP -= 25;
                Calc_magic_damage = Magic_damage;
                Damage_calculate.Enemey_Damage_Calculate(Calc_magic_damage, Enemy_controller.magic_Diffence);
                if(Cons_flag == true)
                {
                    Magic_damage -= 10 * Magic_power_up;
                    Magic_power_up = 0;
                    Cons_flag = false;
                }
            }
            else
            {
                Magic_button.interactable = false;
                Log[0].text = ("MPが足りない！");
            }
        }
    }
    //カイフク
    public void Heal()
    {        
        if (turn_manager.turn == true)
        {
            Intaract_False();
            Item_button.interactable = false;
            if (HP != HP_MAX && HP_POTION > 0)
            {
                Animator.SetBool("heal", true);
                Create_Effect_Player(1, -5.1f, 0.1f);

                HP_POTION -= 1;
                HP += HP_MAX / 2;
                
                if (HP > HP_MAX)
                {
                    HP = HP_MAX;
                }
                Log[0].text = ("主人公は回復した");
            }
            else if(HP == HP_MAX)
            {
                Log[0].text = ("体力は満タンだ！！！");
            }
            else if(HP_POTION < 1)
            {
                Log[0].text = ("ポーションが足りない！");
            }
            Intaract_True();
        }
    }
    //ボタンインタラクトfalse
    public void Intaract_False()
    {
        Attack_button.interactable = false;
        Magic_button.interactable = false;
        Heal_button.interactable = false;
        Concentlation_button.interactable = false;
        Item_button.interactable = false;
        Setting_button.interactable = false;
        Destroy(Status_Controller.eff_obj);
    }
    //ボタンインタラクトtrue
    public void Intaract_True()
    {
        Attack_button.interactable = true;
        Magic_button.interactable = true;
        Heal_button.interactable = true;
        Concentlation_button.interactable = true;
        Item_button.interactable = true;
        Setting_button.interactable = true;
    }
    //アイテムデータ削除
    public static void Item_Reset()
    {
        Item_Manager.Item["healdrink"] = false;
        Item_Manager.Item["bowlingball"] = false;
        Item_Manager.Item["CDplayer"] = false;
        Item_Manager.Item["cd"] = false;
        Item_Manager.Item["radio"] = false;
        Item_Manager.Item["hourglass"] = false;
        Item_Manager.Item["kesigomu"] = false;
        Item_Manager.Item["TV"] = false;
        Item_Manager.Item["CreditCard"] = false;
        Item_Manager.Item["Mouse"] = false;

        Item_Manager.Item["HandMirror"] = false;
        Item_Manager.Item["bowlingpin"] = false;
        Item_Manager.Item["baseball_ball"] = false;
        Item_Manager.Item["dice"] = false;
        Item_Manager.Item["Water bucket"] = false;
        Item_Manager.Item["Popcorn"] = false;
        Item_Manager.Item["Apple"] = false;
        Item_Manager.Item["Scissors"]= false;
        Item_Manager.Item["ice"]= false;
        Item_Manager.Item["Pudding"]= false;

        Item_Manager.Item["Drill"]= false;
        Item_Manager.Item["Headphone"]= false;
        Item_Manager.Item["Coffee"]= false;
        Item_Manager.Item["Safetycone"]= false;
        Item_Manager.Item["USB"]= false;
        Item_Manager.Item["UtypeMagnet"]= false;
        Item_Manager.Item["Smartphone"]= false;
        Item_Manager.Item["ItypeMagnet"]= false;
        Item_Manager.Item["Magnifying Speculum"]= false;
        Item_Manager.Item["Mike"]= false;

        Item_Manager.Item["Megaphone"]= false;
        Item_Manager.Item["HandMill"]= false;
        Item_Manager.Item["Poteto"] = false;
        Item_Manager.Item["Scop"] = false;
        Item_Manager.Item["hammer"] = false;
        Item_Manager.Item["Speaker"] = false;
        Item_Manager.Item["Sylinge"] = false;
        Item_Manager.Item["Baseball_glove"] = false;
        Item_Manager.Item["juice"] = false;
        Item_Manager.Item["Boxing_glove"] = false;
        Item_Manager.Item["Gas_burner"] = false;
        Item_Manager.Item["Hamberger"] = false;
        Item_Manager.Item["Pencil"] = false;
        Item_Manager.Item["Mayonnaise"] = false;
        Item_Manager.Item["Watch"] = false;
        Item_Manager.Item["Scythe"]= false;
        Item_Manager.Item["Robe"]= false;
        Item_Manager.Item["Scale"]= false;
        Item_Manager.Item["MagicBook"]= false;
        Item_Manager.Item["Eye"]= false;
        Item_Manager.Item["Tooth"]= false;

    }
    //アニメーションリセット（アニメーションタグ名）
    public void Anim_Reset(string anim_tag)
    {
        Animator.SetBool(anim_tag, false);
    }
    //エフェクトオブジェクト作成関数（魔法番号、位置X、位置Y）
    public void Create_Effect_Player(int number, float fx, float fy)
    {
        Player_object = Instantiate(Effect[number], new Vector3(fx, fy, 0), Quaternion.identity, 
            ParentGameObject.transform);
        Player_object.name = "Effect_image_" + number;
    }
    //マホウのエフェクト
    public void Magic_Effect()
    {
        int eff_random;//ランダム取得変数
        eff_random = Random.Range(0, 5);
        if(eff_random == 4)
        {
            switch(MAGIC_TYPE)
            {
                case 1: 
                    Enemy_controller.Freeze_turn = true;
                    Status_controller.Status_Effect(false, 0);
                    Log[1].text = "相手が凍り次のターンになった";
                    break;
                case 2: Enemy_controller.magic_Diffence -= 3; 
                    Log[1].text = "相手の魔法防御力が3下がった"; 
                    break;
                case 6: Enemy_controller.HP -= 5; Log[1].text = "毒で５ダメージ与えた";
                    Status_controller.Status_Effect(false, 2); 
                    break;
            }
        }
    }
    //クリティカルエフェクト
    public void Crit_Effect(int num)
    {

        if(Player_luck == MAX_LUCK - 1 || Item_Power.dice_crit == true)
        {
            switch (num)
            {
                case 1: Play_Sound(4);break;
                case 2:
                    if(Item_Power.Sinigami_Crit_Effect == true)
                    {
                        Create_Effect_Player(5, 5.0f, 0.0f);
                    }
                    else
                    {
                        Create_Effect_Player(4, 5.0f, 0.0f);
                    }
                    break;
                case 3:Destroy(Player_object);break;
            }
        }
        else 
        {
            switch (num)
            {
                case 2:Create_Effect_Player(7,5.0f,0.0f);break;
                case 3:Destroy(Player_object);break;
            }
        }
    }
    //ステータスリセット
    public static void Status_Reset()
    {
        CONSTANT_ATTACK         = 25;
        CONSTANT_DEFFENCE       = 25;
        CONSTANT_MAGIC     　   = 25;
        CONSTANT_MAGIC_DEFFENCE = 25;
    }
    //負け
    public void Lose()
    {
        Animator.SetBool("death", false);//負けアニメーション終了
        //各種変数を初期化
        HP = HP_MAX;
        MP = MP_MAX;
        Item_Reset();
        Status_Reset();
        MONEY = 0;
        MAGIC_TYPE = 0;
        Shop_manager.shop_max = 2;
        Shop_manager.shop_min = 1;
        Item_Power.turn_compare = 0;
        Item_Power.first_turn = true;
        Item_Power.Sinigami_Crit_Effect = false;
        Item_Power.Boxing_flag = false;
        Enemy_controller.turn = 0;
        Enemy_controller.HP = 150;
        Enemy_controller.Freeze_turn = false;
        Enemy_controller.Stone_turn = false;
        Enemy_controller.tag_get = true;
        SceneManager.LoadScene("Lose");
    }
    //SE再生関数（SEのナンバー）
   public void Play_Sound(int se_number)
    {
        Audio_source_SE.PlayOneShot(Audio_clip_SE[se_number]);
    }
}