using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //player status
    public static int HP = 100;//体力
    public static int HP_max = 100;//最高体力
    public static int MP = 100;//MP
    public static int MP_max = 100;//最高MP
    public int Attack;//攻撃力
    public int Diffence;//防御力
    public int Magic;//魔法力
    public int Magic_Diffence;//魔法防御力
    public int Attack_damage;//攻撃力(計算後)
    public int Magic_damage;//魔法力(計算後)
    public static int HP_Potion;//HPポーションの数
    public static int Money; //所持金額 //別のシーンでも呼ばれる
    public int money;//一時確認用（あとで消す）
    public int player_luck;//プレイヤーのラック
    public static int max_luck = 13;//最大ラック
    public static int magic_number = 0;//魔法番号(撃てる魔法の種類)
    int poison_cnt;//毒のターン数
    int OnFire_cnt;//延焼のターン数
    bool cons_flag = false;//シュウチュウフラグ
    public Button Item_button;//アイテムボタン
    public Button Setting_Button;//設定ボタン

    public GameObject[] Effect;//エフェクト用
    public GameObject obj_player;//プレイヤーオブジェクト
    [SerializeField] GameObject _parentGameObject;//親オブジェクト
    public Status_Controller status_;//ステータスコントローラー
    turn_manager turn_Manager;//ターンマネージャー
    Status_Controller status;
    Animator animator;//プレイヤーアニメーター
    Damage_calculate damage_Calculate;//ダメージサーキュレーター
    Enemy_controller enemy_Controller;
    GameObject Enemey;
    public ChangeScene change;//チェンジシーン
    int turn_time = 0;//ターン経過時間
    bool button_check = false;

    //ボタン関係変数
    public Button Attack_;
    public Button Concentlation_;
    public Button Magic_;
    public Button Heal_;
    static int Attack_tmp = 25;
    static int Deffence_tmp = 25;
    static int Magic_tmp = 25;
    static int MagicDeffence_tmp = 25;

    public Text Log;//テキストログ
    public Text Log_2;

    //オーディオ
    public AudioSource audioSource_Attack;
    [SerializeField] AudioClip clip_attack;
    public AudioSource audioSource_Magic;
    [SerializeField] AudioClip clip_magic;
    public AudioSource audioSource_Conce;
    [SerializeField] AudioClip clip_conce;
    public AudioSource audioSource_Heal;
    [SerializeField] AudioClip clip_heal;
    public AudioSource audioSource_Critical;
    [SerializeField] AudioClip clip_critical;

    void Start()
    {
        GameObject Text = GameObject.Find("LogText");
        Log = Text.GetComponent<Text>();
        //数値を適用
        Attack = Attack_tmp;
        Diffence = Deffence_tmp;
        Magic = Magic_tmp;
        Magic_Diffence = MagicDeffence_tmp;
        Log.text = "主人公のターン";
        money = Money;
        turn_Manager = GetComponent<turn_manager>();
        turn_manager.turn = true;
        animator = GetComponent<Animator>();
        damage_Calculate = GetComponent<Damage_calculate>();
        Enemey = GameObject.Find("Monster");
        enemy_Controller = Enemey.GetComponent<Enemy_controller>();
    }
    void Update()
    {
        //数値を保存
        Attack_tmp = Attack;
        Deffence_tmp = Diffence;
        Magic_tmp = Magic;
        MagicDeffence_tmp = Magic_Diffence;
        //エフェクト削除
        if (turn_manager.turn == false)
        {
            Destroy(obj_player);
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
        if (enemy_Controller.poison == true)
        {
            poison_cnt += 3;
            Log_2.text = "毒の効果で３ダメージくらった";
            enemy_Controller.poison = false;
        }
        //延焼ダメージ
        if(enemy_Controller.OnFire == true)
        {
            OnFire_cnt += 2;
            enemy_Controller.OnFire = false;
        }
        //敗北
        if(HP <= 0)
        {
            animator.SetBool("death",true);
            Log.text = "主人公は倒れてしまった";
            ChangeScene.scene_cnt = 1;//最初のシーンがcase :1
        }

        //ステータス999上限
        if(Attack >= 999)
        {
            Attack = 999;
        }
        if(Diffence >= 999)
        {
            Diffence = 999;
        }
        if(Magic >= 999)
        {
            Magic = 999;
        }
        if(Magic_Diffence >= 999)
        {
            Magic_Diffence = 999;
        }
        if(HP >= HP_max)
        {
            HP = HP_max;
        }
        //ステータス0下限
        if (Attack < 0)
        {
            Attack = 0;
        }
        if (Diffence < 0)
        {
            Diffence = 0;
        }
        if (Magic < 0)
        {
            Magic = 0;
        }
        if (Magic_Diffence < 0)
        {
            Magic_Diffence = 0;
        }
        if(max_luck < 2)
        {
            max_luck = 2;
        }
        if(button_check == true)
        {
            turn_time++;
            if (turn_time > turn_manager.turn_time_max)
            {
                turn_time = 0;
                button_check = false;
                if (poison_cnt > 0)
                {
                    HP -= 2;
                    Log.text = "毒の効果で体力が2減った";
                    status_.Status_Effect(true, 2);
                    poison_cnt -= 1;
                }
                if (OnFire_cnt > 0)
                {
                    HP -= 8;
                    Log.text = "延焼効果で体力が8減った";
                    status_.Status_Effect(true, 3);
                    OnFire_cnt -= 1;
                }

                Log.text = "";
                turn_manager.turn = false;
            }
        }
    }
    //ザンゲキ
    public void attack()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        intaract_false();
        animator.SetBool("attack", true);
        if (turn_manager.turn == true)
        {
            button_check = true;
            Log.text = "主人公は攻撃した";
            Item_button.interactable = false;
            player_luck = Random.Range(1,max_luck);
            if (player_luck < max_luck - 1)
            {
                //遅延
                Invoke("SE_Play_Attack", 500.0f);

                Attack_damage = Attack;
            }
            else if (player_luck == max_luck -1 || Item_Power.dice_crit == true)
            {
                Attack_damage = Attack + Attack / 2;                
                Log.text = ("主人公クリティカルが発生");
                Item_Power.dice_crit = false;
            }

            damage_Calculate.Enemey_Damage_Calculate(Attack_damage, enemy_Controller.Enemy_deffence);
        }
    }
    //シュウリュウ
    public void concentration()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();

        if (turn_manager.turn == true)
        {
            if (MP < 100)
            {
                button_check = true;
                Item_button.interactable = false;
                intaract_false();
                animator.SetBool("cons", true);
                MP += MP_max / 2;
                Magic += 10;
                Log.text = "主人公は集中した";
                cons_flag = true;
                //MPがMP_maxより大きければMP_maxの値に合わせる
                if (MP > MP_max)
                {
                    MP = MP_max;
                }
            }
            else
            {
                Log.text = ("主人公は十分集中している");
            }
        }
    }
    //マホウ
    public void magic()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        if (turn_manager.turn == true)
        {
            if(MP >= 25)
            {
                button_check = true;
                Item_button.interactable = false;

                intaract_false();
                Log.text = "主人公は魔法を撃った";
                animator.SetBool("magic", true);
                switch (magic_number)
                {
                    case 0: Create_Effect_Player(0, 5.7f, 0.9f); break;
                    case 1: Create_Effect_Player(2, 0f, 0f);break;
                    case 2: Create_Effect_Player(3, 0f, 0f);break;
                    case 6: Create_Effect_Player(6, 0f, 0f);break;
                }

                MP -= 25;
                Magic_damage = Magic;
                damage_Calculate.Enemey_Damage_Calculate(Magic_damage, enemy_Controller.magic_Diffence);
                if(cons_flag == true)
                {
                    Magic -= 10;
                    cons_flag = false;
                }
                //遅延
                Invoke("SE_Play_Magic", 30.0f);
            }
            else
            {
                Log.text = ("MPが足りない！");
            }
        }
    }
    //カイフク
    public void heal()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        
        if (turn_manager.turn == true)
        {
            intaract_false();
            Item_button.interactable = false;
            if (HP != HP_max && HP_Potion > 0)
            {
                //遅延
                Invoke("SE_Play_Heal", 1.0f);

                animator.SetBool("heal", true);
                //Debug.Log("回復");
                Create_Effect_Player(1, -5.1f, 0.1f);

                HP_Potion -= 1;
                HP += HP_max / 2;
                
                if (HP > HP_max)
                {
                    HP = HP_max;
                }
                Log.text = ("主人公は回復した");
            }
            else if(HP == HP_max)
            {
                Log.text = ("体力は満タンだ！！！");
            }
            else if(HP_Potion < 1)
            {
                Log.text = ("ポーションが足りない！");
            }
            intaract_true();
        }
    }
    //ボタンインタラクトfalse
    public void intaract_false()
    {
        Attack_.interactable = false;
        Magic_.interactable = false;
        Heal_.interactable = false;
        Concentlation_.interactable = false;
        Item_button.interactable = false;
        Setting_Button.interactable = false;
        Destroy(Status_Controller.eff_obj);
    }
    //ボタンインタラクトtrue
    public void intaract_true()
    {
        Attack_.interactable = true;
        Magic_.interactable = true;
        Heal_.interactable = true;
        Concentlation_.interactable = true;
        Item_button.interactable = true;
        Setting_Button.interactable = true;
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
        Item_Manager.Item["Kama"]= false;
        Item_Manager.Item["Robe"]= false;
        Item_Manager.Item["Scale"]= false;
        Item_Manager.Item["MagicBook"]= false;
        Item_Manager.Item["Juwel"]= false;
        Item_Manager.Item["Tooth"]= false;

    }
    //アニメーションリセット（boolのみ）
    public void Anim_Reset(string anim_tag)
    {
        animator.SetBool(anim_tag, false);
    }
    //エフェクトオブジェクト作成関数
    public void Create_Effect_Player(int number, float Fx, float Fy)
    {
        obj_player = Instantiate(Effect[number], new Vector3(Fx, Fy, 0), Quaternion.identity, _parentGameObject.transform);
        obj_player.name = "Effect_image_" + number;
    }
    //マホウのエフェクト
    public void Magic_Effect()
    {
        int eff_random = 0;
        eff_random = Random.Range(0, 5);
        if(eff_random == 4)
        {
            switch(magic_number)
            {
                case 1: Enemy_controller.Freeze_turn = true; status_.Status_Effect(false, 0); Log_2.text = "相手が凍り次のターンになった"; break;
                case 2: enemy_Controller.magic_Diffence -= 3; Log_2.text = "相手の魔法防御力が3下がった"; break;
                case 6: Enemy_controller.HP -= 5; Log_2.text = "毒で５ダメージ与えた"; status_.Status_Effect(false, 2); break;
            }
        }
    }
    //クリティカルエフェクト
    public void Crit_Effect(int num)
    {

        if(player_luck == max_luck - 1 || Item_Power.dice_crit == true)
        {
            switch (num)
            {
                case 1: SE_Play_Critical();break;
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
                case 3:Destroy(obj_player);break;
            }
        }
    }
    //ステータスリセット
    public static void Status_reset()
    {
        Attack_tmp = 25;
        Deffence_tmp = 25;
        Magic_tmp = 25;
        MagicDeffence_tmp = 25;
    }
    //負け
    public void Lose()
    {
        animator.SetBool("death", false);
        HP = HP_max;
        MP = MP_max;
        Item_Reset();
        Status_reset();
        magic_number = 0;
        Shop_manager.shop_max = 2;
        Shop_manager.shop_min = 1;
        //各種数値を初期化
        Item_Power.turn_compare = 0;
        Item_Power.first_turn = true;
        Item_Power.Sinigami_Crit_Effect = false;
        Enemy_controller.turn = 0;
        Enemy_controller.HP = 150;
        Enemy_controller.Freeze_turn = false;
        Enemy_controller.Stone_turn = false;
        Enemy_controller.tag_get = true;
        Money = 0;
        SceneManager.LoadScene("Lose");
    }
    public void SE_Play_Attack()
    {
        audioSource_Attack.PlayOneShot(clip_attack);
        Destroy(enemy_Controller.obj2);
    }
    public void SE_Play_Magic()
    {
        audioSource_Magic.PlayOneShot(clip_magic);
        Destroy(enemy_Controller.obj2);
    }
    public void SE_Play_Conce()
    {
        audioSource_Conce.PlayOneShot(clip_conce);
    }
    public void SE_Play_Heal()
    {
        audioSource_Heal.PlayOneShot(clip_heal);
    }
    public void SE_Play_Critical()
    {
        audioSource_Critical.PlayOneShot(clip_critical);
    }
}
