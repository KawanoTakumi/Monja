using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    //プレイヤーステータス（定数）
    static int STATUS_MAX = 9999;               //ステータス上限
    static int STATUS_MIN = 0;                  //ステータス下限
    static int CONSTANT_ATTACK   = 25;          //攻撃の定数
    static int CONSTANT_DEFFENCE = 25;          //防御の定数
    static int CONSTANT_MAGIC    = 25;          //魔法の定数
    static int CONSTANT_MAGIC_DEFFENCE = 25;    //魔法防御の定数

    //プレイヤーステータス（変数）
    public static int HP = 100;             //HP
    public static int HP_max = 100;             //最高HP
    public static int MP = 100;             //MP
    public static int MP_max = 100;             //最高MP
    public static int HP_potion = 0;            //HPポーションの数
    public static int Mmoney = 0;                //所持金額
    public static int Mmax_luck = 13;            //最大ラック
    public static int Magic_number = 0;           //魔法番号(撃てる魔法の種類)
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

    //オーディオ
    public AudioSource Audio_source_SE;             //SEオーディオソース
    [SerializeField] AudioClip[] Audio_clip_SE;     //SEオーディオクリップ

    //スタートメソッド
    //説明・・・オブジェクトのコンポーネントを読み込む、戦闘開始時にステータスを初期化、主人公ターンへ移行
    void Start()
    {
        //オブジェクトのコンポーネントを変数に読み込む
        Enemey           = GameObject.Find("Monster");
        Enemy_controller = Enemey.GetComponent<Enemy_controller>();
        Animator         = GetComponent<Animator>();
        Damage_calculate = GetComponent<Damage_calculate>();

        //初期の定数を変数に適用
        Attack_damage  = CONSTANT_ATTACK;
        Deffence       = CONSTANT_DEFFENCE;
        Magic_damage   = CONSTANT_MAGIC;
        Magic_diffence = CONSTANT_MAGIC_DEFFENCE;
        //主人公のターンにする true = 主人公、false = 敵
        turn_manager.turn = true;
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
            turn_manager.turn = false;//ターンを経過させる
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
            //死亡アニメーションを再生、ログを更新
            Animator.SetBool("death",true);
            Log[0].text = "主人公は倒れてしまった";
            Log_list.LogList.Add("主人公は倒れてしまった\n");//ログリストに追加
            ChangeScene.SCENE_CNT = 1;//最初のシーンがcase :1
        }

        //ステータス上限
        if (Attack_damage  > STATUS_MAX)
        {
            Attack_damage  = STATUS_MAX;
        }
        if(Deffence        > STATUS_MAX)
        {
            Deffence       = STATUS_MAX;
        }
        if(Magic_damage    > STATUS_MAX)
        {
            Magic_damage   = STATUS_MAX;
        }
        if(Magic_diffence  > STATUS_MAX)
        {
            Magic_diffence = STATUS_MAX;
        }
        if(HP >= HP_max)
        {
            HP = HP_max;
        }

        //ステータス下限
        if (Attack_damage  < STATUS_MIN)
        {
            Attack_damage  = STATUS_MIN;
        }
        if (Deffence       < STATUS_MIN)
        {
            Deffence       = STATUS_MIN;
        }
        if (Magic_damage   < STATUS_MIN)
        {
            Magic_damage   = STATUS_MIN;
        }
        if (Magic_diffence < STATUS_MIN)
        {
            Magic_diffence = STATUS_MIN;
        }
        if(HP < STATUS_MIN)
        {
            HP = STATUS_MIN;
        }
        if(Mmax_luck < 2)
        {
            Mmax_luck = 2;
        }

        //状態異常時の効果
        if(Button_check == true)
        {
            //ターンタイムを増加させタイムが最大値より大きくなったら
            Turn_time++;
            if (Turn_time > turn_manager.turn_time_max)
            {
                Turn_time = 0;//ターンタイムを初期化
                Log[0].text = "";
                Button_check = false;
                //毒
                if (Poison_cnt > 0)
                {
                    //体力を減らして、ログ更新、エフェクトを作成
                    HP -= 2;
                    Log[0].text = "　毒の効果で体力が２減った";
                    Log_list.LogList.Add("毒の効果で体力が２減った\n");//ログリストに追加
                    Status_controller.Status_Effect(true, 2);
                    Poison_cnt -= 1;
                }
                //炎上
                if (OnFire_cnt > 0)
                {
                    //体力を減らして、ログ更新、エフェクトを作成
                    HP -= 8;
                    Log[0].text = "延焼効果で体力が８減った";
                    Log_list.LogList.Add("　延焼効果で体力が８減った\n");//ログリストに追加
                    Status_controller.Status_Effect(true, 3);
                    OnFire_cnt -= 1;
                }
                //ログの初期化、ターンを経過させる
                Log[0].text = "";
                Log_list.LogList.Add("\n<color=#f369e1>　　敵のターン</color>\n");//ログリストに追加
                turn_manager.turn = false;
            }
        }
    }
    /// <summary>
    /// ザンゲキボタンを押されたときに作動させるメソッドです
    /// </summary>
    //ザンゲキ
    public void Attack()
    {
        //ボタンを押せなくする、アニメーションを再生
        Intaract_False();
        Animator.SetBool("attack", true);

        //主人公のターンの時
        if (turn_manager.turn == true)
        {
            Log_list.LogList.Add("\n<color=#24e1f3>　　プレイヤーのターン</color>\n");//ログリストに追加

            //ボタンが押されたことを確認して、ログを更新、ボタンを押せなくする
            Button_check = true;
            Log[0].text = "主人公は攻撃した";
            Log_list.LogList.Add("　主人公は攻撃した\n");//ログリストに追加

            //主人公の幸運値をランダムで変更して、値に応じてクリティカルを発生させる
            Player_luck = Random.Range(1,Mmax_luck);
            if (Player_luck < Mmax_luck - 1)
            {
                //SEを遅延させる
                Invoke("SE_Play_Attack", 500.0f);

                //計算後の攻撃値を取得
                Calc_attack_damage = Attack_damage;
            }
            else if (Player_luck == Mmax_luck -1 || Item_Power.dice_crit == true)
            {
                Calc_attack_damage = Attack_damage + Attack_damage / 2;//計算後の攻撃値に１．５倍の攻撃値を取得    
                Log[0].text = ("主人公クリティカルが発生");//ログ更新
                Log_list.LogList.Add("　主人公クリティカルが発生\n");//ログリストに追加
                Item_Power.dice_crit = false;//サイコロのクリティカルフラグを初期化
            }

            //敵のエフェクトを削除する
            Destroy(Enemy_controller.obj1);
            Destroy(Enemy_controller.obj2);

            //主人公がボクシンググローブを持っていた場合
            if (Item_Power.Boxing_flag == true)
            {
                Attack_damage += 3;//攻撃値に毎ターン＋３する
            }

            //敵に与える攻撃値を（計算後の攻撃値）ー（敵の防御力）で計算する
            Damage_calculate.Enemey_Damage_Calculate(Calc_attack_damage, Enemy_controller.Enemy_deffence);
        }
    }
    /// <summary>
    /// シュウチュウボタンを押された時に発動させるメソッドです
    /// </summary>
    //シュウチュウ
    public void Concentration()
    {

        if (turn_manager.turn == true)
        {
            Log_list.LogList.Add("\n<color=#24e1f3>　　プレイヤーのターン</color>\n");//ログリストに追加
            //MPが最大値より小さい時
            if (MP < MP_max)
            {
                //ボタンが押されたことを確認し、ボタンを押せなくする
                Button_check = true;
                Intaract_False();

                Animator.SetBool("cons", true);                //アニメーションを再生
                MP += MP_max / 2;　　　　　　　　　　　　　　　//MPを半分回復
                Log[0].text = "主人公は集中した";       //ログを更新
                Log_list.LogList.Add("　主人公は集中した\n");//ログリストに追加
                //敵のエフェクトを削除する
                Destroy(Enemy_controller.obj1);
                Destroy(Enemy_controller.obj2);

                //魔法攻撃力を上昇させて、カウントを進める
                Magic_damage += 10;
                Magic_power_up++;
                Cons_flag = true;

                //MPがMP_maxより大きければMP_maxの値に合わせる
                if (MP > MP_max)
                {
                    MP = MP_max;
                }
            }
            else
            {
                Log[0].text = "主人公は十分集中している";
                Log_list.LogList.Add("　主人公は十分集中している\n");//ログリストに追加
            }
        }
    }
    /// <summary>
    /// マホウボタンをおされた時に発動させるメソッドです
    /// </summary>
    //マホウ
    public void Magic()
    {
        //主人公ターンの時
        if (turn_manager.turn == true)
        {
            Log_list.LogList.Add("\n<color=#24e1f3>　　プレイヤーのターン</color>\n");//ログリストに追加

            //MPが25より大きかったら
            if (MP >= 25)
            {
                //ボタンが押されたことを確認、ボタンを押せなくする、ログを更新
                Debug.Log("Magic");
                Button_check = true;
                Intaract_False();
                Log[0].text = "主人公は魔法を撃った";
                Log_list.LogList.Add("　主人公は魔法を撃った\n");//ログリストに追加

                //敵のエフェクトを削除する
                Destroy(Enemy_controller.obj1);
                Destroy(Enemy_controller.obj2);

                //魔法のアニメーションを魔法のタイプに応じて変化させる
                Animator.SetBool("magic", true);
                switch (Magic_number)
                {
                    case 0: Create_Effect_Player(0, 5.7f, 0.9f); break;
                    case 1: Create_Effect_Player(2, 0f, 0f);break;
                    case 2: Create_Effect_Player(3, 0f, 0f);break;
                    case 3: Create_Effect_Player(6, 0f, 0f);break;
                }

                //MPを減少させて、計算後の魔法攻撃値を取得
                MP -= 25;
                Calc_magic_damage = Magic_damage;

                //敵に与えるダメージを計算（魔法攻撃値）ー（敵魔法防御）
                Damage_calculate.Enemey_Damage_Calculate(Calc_magic_damage, Enemy_controller.magic_Diffence);


                if (Item_Power.M_magic_book_flag == true)
                {
                    Item_Power.MagicBook_cnt++;
                    if(Item_Power.MagicBook_cnt == 2)
                    {
                        MP += 25;
                        Item_Power.MagicBook_cnt = 0;

                    }

                }
                if (Item_Power.M_eye_flag == true)
                {
                    Item_Power.MedhusaEye_cnt++;
                    if (Item_Power.MedhusaEye_cnt == 2)
                    {
                        MP += 25;
                        Item_Power.MedhusaEye_cnt = 0;
                    }
                }
                if(MP > MP_max)
                {
                    MP = MP_max;
                }

                //シュウチュウフラグがtrueの時
                if (Cons_flag == true)
                {
                    //シュウチュウで増加させた魔法攻撃力分減少させる
                    Magic_damage -= 10 * Magic_power_up;
                    Magic_power_up = 0;//増加量を初期化
                    Cons_flag = false;//シュウチュウフラグを初期化
                }
            }
            else
            {
                //MPが足りない時、魔法を不発させ、ターンを消費させる
                Magic_button.interactable = false;
                Log[0].text = ("MPが足りない！");
                Log_list.LogList.Add("　MPが足りない！\n");//ログリストに追加
            }
        }
    }

    /// <summary>
    /// カイフクボタンを押したときに発動させるメソッドです
    /// </summary>
    //カイフク
    public void Heal()
    {
        //主人公ターンの時
        if (turn_manager.turn == true)
        {
            Log_list.LogList.Add("\n<color=#24e1f3>　　プレイヤーのターン</color>\n");//ログリストに追加
            //ボタンを押せなくする
            Intaract_False();

            //HPが最大値より少ない　かつ　HPポーションを所持している時
            if (HP != HP_max && HP_potion > 0)
            {
                //回復アニメーションを作動させ、回復エフェクトを作成
                Animator.SetBool("heal", true);
                Create_Effect_Player(1, -5.1f, 0.1f);

                //HPポーションの所持数を減らし、体力を最大値の半分回復させる
                HP_potion -= 1;
                HP += HP_max / 2;
                
                //HPが最大値より大きくなったら、最大値に合わせる
                if (HP > HP_max)
                {
                    HP = HP_max;
                }
                Log[0].text = ("主人公は回復した");//ログを更新
                Log_list.LogList.Add("　主人公は回復した\n");//ログリストに追加
            }
            else if(HP == HP_max)
            {
                Log[0].text = ("体力は満タンだ！！！");
                Log_list.LogList.Add("　体力は満タンだ！！！\n");//ログリストに追加
            }
            else if(HP_potion < 1)
            {
                Log[0].text = ("ポーションが足りない！");
                Log_list.LogList.Add("　ポーションが足りない！\n");//ログリストに追加
            }
            Intaract_True();//ボタンを押せるようにする
        }
    }

    /// <summary>
    /// ボタンを押せなくするメソッドです
    /// </summary>
    public void Intaract_False()
    {
        Attack_button.interactable          = false;
        Magic_button.interactable           = false;
        Heal_button.interactable            = false;
        Concentlation_button.interactable   = false;
        Item_button.interactable            = false;
        Setting_button.interactable         = false;
        Destroy(Status_Controller.eff_obj);//エフェクトを削除
    }

    /// <summary>
    /// ボタンを押せるようにするメソッドです
    /// </summary>
    public void Intaract_True()
    {
        Attack_button.interactable           = true;
        Magic_button.interactable            = true;
        Heal_button.interactable             = true;
        Concentlation_button.interactable    = true;
        Item_button.interactable             = true;
        Setting_button.interactable          = true;
    }
    /// <summary>
    /// アイテムの取得データを初期化させるメソッドです
    /// </summary>
    /// <remarks>
    /// このメソッドは負けた時、ゲームをクリアした時に使用します
    /// </remarks>>
    public static void Item_Reset()
    {
        Item_Manager.Item["healdrink"]           = false;
        Item_Manager.Item["bowlingball"]         = false;
        Item_Manager.Item["CDplayer"]            = false;
        Item_Manager.Item["cd"]                  = false;
        Item_Manager.Item["radio"]               = false;
        Item_Manager.Item["hourglass"]           = false;
        Item_Manager.Item["kesigomu"]            = false;
        Item_Manager.Item["TV"]                  = false;
        Item_Manager.Item["CreditCard"]          = false;
        Item_Manager.Item["Mouse"]               = false;

        Item_Manager.Item["HandMirror"]          = false;
        Item_Manager.Item["bowlingpin"]          = false;
        Item_Manager.Item["baseball_ball"]       = false;
        Item_Manager.Item["dice"]                = false;
        Item_Manager.Item["Water bucket"]        = false;
        Item_Manager.Item["Popcorn"]             = false;
        Item_Manager.Item["Apple"]               = false;
        Item_Manager.Item["Scissors"]            = false;
        Item_Manager.Item["ice"]                 = false;
        Item_Manager.Item["Pudding"]             = false;

        Item_Manager.Item["Drill"]               = false;
        Item_Manager.Item["Headphone"]           = false;
        Item_Manager.Item["Coffee"]              = false;
        Item_Manager.Item["Safetycone"]          = false;
        Item_Manager.Item["USB"]                 = false;
        Item_Manager.Item["UtypeMagnet"]         = false;
        Item_Manager.Item["Smartphone"]          = false;
        Item_Manager.Item["ItypeMagnet"]         = false;
        Item_Manager.Item["Magnifying Speculum"] = false;
        Item_Manager.Item["Mike"]                = false;

        Item_Manager.Item["Megaphone"]           = false;
        Item_Manager.Item["HandMill"]            = false;
        Item_Manager.Item["Poteto"]              = false;
        Item_Manager.Item["Scop"]                = false;
        Item_Manager.Item["hammer"]              = false;
        Item_Manager.Item["Speaker"]             = false;
        Item_Manager.Item["Sylinge"]             = false;
        Item_Manager.Item["Baseball_glove"]      = false;
        Item_Manager.Item["juice"]               = false;
        Item_Manager.Item["Boxing_glove"]        = false;

        Item_Manager.Item["Gas_burner"]          = false;
        Item_Manager.Item["Hamberger"]           = false;
        Item_Manager.Item["Pencil"]              = false;
        Item_Manager.Item["Mayonnaise"]          = false;
        Item_Manager.Item["Watch"]               = false;
        Item_Manager.Item["Scythe"]              = false;
        Item_Manager.Item["Robe"]                = false;
        Item_Manager.Item["Scale"]               = false;
        Item_Manager.Item["MagicBook"]           = false;
        Item_Manager.Item["Eye"]                 = false;

        Item_Manager.Item["Tooth"]               = false;

    }
    /// <summary>
    /// アニメーションを終了させるメソッドです
    /// </summary>
    /// <param name="anim_tag">アニメーションの名前</param>
    public void Anim_Reset(string anim_tag)
    {
        Animator.SetBool(anim_tag, false);
    }
    /// <summary>
    /// エフェクトオブジェクトを作成するメソッドです
    /// </summary>
    /// <param name="number">作成するエフェクトの番号</param>
    /// <param name="fx">X座標</param>
    /// <param name="fy">Y座標</param>
    public void Create_Effect_Player(int number, float fx, float fy)
    {
        Player_object = Instantiate(Effect[number], new Vector3(fx, fy, 0), Quaternion.identity, 
            ParentGameObject.transform);
        Player_object.name = "Effect_image_" + number;
    }
    /// <summary>
    /// 魔法を打った際の状態異常を４分の１で発生させるメソッドです
    /// </summary>
    public void Magic_Effect()
    {
        int Eff_random;//ランダム取得変数
        Eff_random = Random.Range(0, 5);//1/4の確率
        if(Eff_random == 4)
        {
            switch(Magic_number)
            {
                case 1: 
                    Enemy_controller.Freeze_turn = true;
                    Status_controller.Status_Effect(false, 0);
                    Log[1].text = "相手が凍り次のターンになった";
                    Log_list.LogList.Add("相手が凍り次のターンになった\n");//ログリストに追加
                    break;
                case 2: Enemy_controller.magic_Diffence -= 3; 
                    Log[1].text = "相手の魔法防御力が３下がった"; 
                    Log_list.LogList.Add("相手の魔法防御力が３下がった\n");//ログリストに追加
                    break;
                case 6: Enemy_controller.HP -= 5; Log[1].text = "毒で５ダメージ与えた";
                    Log_list.LogList.Add("毒で５ダメージ与えた\n");//ログリストに追加
                    Status_controller.Status_Effect(false, 2); 
                    break;
            }
        }
    }
    /// <summary>
    /// クリティカルエフェクトを発生させるメソッドです
    /// </summary>
    /// <param name="Play_act">実行する行動の番号</param>
    public void Crit_Effect(int Play_act)
    {

        if(Player_luck == Mmax_luck - 1 || Item_Power.dice_crit == true)
        {
            switch (Play_act)
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
            switch (Play_act)
            {
                case 2:Create_Effect_Player(7,5.0f,0.0f);break;
                case 3:Destroy(Player_object);break;
            }
        }
    }
    /// <summary>
    /// ステータスを初期値に戻すメソッドです
    /// </summary>
    //ステータスリセット関数
    public static void Status_Reset()
    {
        CONSTANT_ATTACK         = 25;
        CONSTANT_DEFFENCE       = 25;
        CONSTANT_MAGIC     　   = 25;
        CONSTANT_MAGIC_DEFFENCE = 25;
    }
    /// <summary>
    /// 負けた時に実行するメソッドです
    /// </summary>
    /// <remarks>
    /// 負けた時以外では使用しないでください
    /// </remarks>>
    //負け関数
    public void Lose()
    {
        Animator.SetBool("death", false);//負けアニメーション終了
        //主人公のステータスを初期化
        Item_Reset();
        Status_Reset();
        Mmax_luck = 13;//クリティカル発生確率初期化
        HP_max = 100;//最大体力を初期化
        HP = HP_max;
        MP = MP_max;
        Mmoney = 0;
        Magic_number = 0;
        Log_list.Log_Clear();//ログを初期化
        //ショップの選択範囲を初期化
        Shop_manager.Shop_limit = 6;
        Shop_manager.TheGrimreaper_flag = false;
        Shop_manager.Medhusa_flag = false;
        Shop_manager.Dragon_flag = false;
        Item_Power.turn_compare = 0;
        Item_Power.first_turn = true;
        Item_Power.Sinigami_Crit_Effect = false;
        Item_Power.Boxing_flag = false;
        Item_Power.M_eye_flag = false;
        Item_Power.M_magic_book_flag = false;
        //敵のステータスを初期化
        Enemy_controller.turn = 0;
        Enemy_controller.HP = 150;
        Enemy_controller.Freeze_turn = false;
        Enemy_controller.Stone_turn = false;
        Enemy_controller.tag_get = true;
        SceneManager.LoadScene("Lose");
    }

    /// <summary>
    /// SEを再生するメソッドです
    /// </summary>
    /// <param name="se_number">SEの番号</param>
   public void Play_Sound(int se_number)
    {
        Audio_source_SE.PlayOneShot(Audio_clip_SE[se_number]);
    }
}