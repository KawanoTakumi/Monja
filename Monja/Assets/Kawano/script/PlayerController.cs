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
    public static int Money;//所持金額 //別のシーンでも呼ばれる
    public int money;//一時確認用（あとで消す）
    public int player_luck;
    public int max_luck;
    public static int magic_number = 0;//魔法番号(撃てる魔法の種類)
    int poison_cnt;

    public GameObject[] Effect;//エフェクト用
    GameObject obj_player;
    [SerializeField] GameObject _parentGameObject;


    turn_manager turn_Manager;
    Animator animator;//プレイヤーアニメーター
    Damage_calculate damage_Calculate;//ダメージサーキュレーター
    Enemy_controller enemy_Controller;
    GameObject Enemey;
    public ChangeScene change;//チェンジシーン
    int turn_time = 0;//ターン経過時間

    //ボタン関係変数
    public Button Attack_;
    public Button Concentlation_;
    public Button Magic_;
    public Button Heal_;

    public Text Log;//テキストログ
    // Start is called before the first frame update

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


        money = Money;
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        damage_Calculate = GetComponent<Damage_calculate>();
        Enemey = GameObject.Find("Monster");
        enemy_Controller = Enemey.GetComponent<Enemy_controller>();
    }
    // Update is called once per frame
    void Update()
    {
        //エフェクト削除
        if(turn_Manager.turn == false)
        {
            Destroy(obj_player);
        }
        //毒ダメージ
        if(enemy_Controller.poison == true)
        {
            poison_cnt += 5;
            enemy_Controller.poison = false;
        }
        //敗北
        if(HP <= 0)
        {
            animator.SetBool("death",true);
            ChangeScene.scene_cnt = 1;//最初のシーンがcase :1
        }

        //ステータス9999上限
        if(Attack >= 9999)
        {
            Attack = 9999;
        }
        if(Diffence >= 9999)
        {
            Diffence = 9999;
        }
        if(Magic >= 9999)
        {
            Magic = 9999;
        }
        if(Magic_Diffence >= 9999)
        {
            Magic_Diffence = 9999;
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
        if (Magic_Diffence >= 0)
        {
            Magic_Diffence = 0;
        }
    }
    public void attack()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        intaract_false();
        animator.SetBool("attack", true);
        if (turn_Manager.turn == true)
        {
            player_luck = Random.Range(1, max_luck);
            if (player_luck != max_luck-1)
            {
                Attack_damage = Attack;
            }
            else if (player_luck == max_luck - 1 || Item_Power.dice_crit == true)
            {
                Attack_damage = Attack + Attack / 2;
                Log.text = ("主人公クリティカル");
                Item_Power.dice_crit = false;
            }

            Attack_damage = Attack;
            damage_Calculate.Enemey_Damage_Calculate(Attack_damage, enemy_Controller.Enemy_deffence);
        }
    }
    public void concentration()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();

        if (turn_Manager.turn == true)
        {
            if (MP < 100)
            {
                intaract_false();
                animator.SetBool("cons", true);
                MP += MP_max / 4;
                //MPがMP_maxより大きければMP_maxの値に合わせる
                if (MP > MP_max)
                {
                    MP = MP_max;
                }
                if(poison_cnt > 0)
                {
                    HP -= 5;
                    poison_cnt -= 1;
                }
                turn_Manager.turn = false;
            }
            else
            {
                Log.text = ("主人公は十分集中している");

            }
        }
    }
    public void magic()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        if (turn_Manager.turn == true)
        {
            if(MP >= 25)
            {
                intaract_false();
                animator.SetBool("magic", true);
                switch (magic_number)
                {
                    case 0: Create_Effect_Player(0, 5.7f, 0.9f); break;
                    case 1: Create_Effect_Player(2, 0f, 0f);break;
                    case 2: Create_Effect_Player(3, 0f, 0f);break;
                }

                MP -= 25;
                Magic_damage = Magic;
                damage_Calculate.Enemey_Damage_Calculate(Magic_damage, enemy_Controller.magic_Diffence);
                turn_time++;
                if (turn_time > 300)
                {
                    turn_time = 0;
                    if (poison_cnt > 0)
                    {
                        HP -= 5;
                        poison_cnt -= 1;
                    }
                    turn_Manager.turn = false;
                }
            }
            else
            {
                Log.text = ("魔法は打てない");
            }
        }
    }
    public void heal()
    {
        turn_Manager = GetComponent<turn_manager>();
        animator = GetComponent<Animator>();
        
        if (turn_Manager.turn == true)
        {
            intaract_false();
            if (HP != HP_max && HP_Potion > 0)
            {
                animator.SetBool("heal", true);
                //Debug.Log("回復");
                Create_Effect_Player(0, -5.1f, 0.1f);

                HP_Potion -= 1;
                HP += HP_max / 2;
                
                if (HP > HP_max)
                {
                    HP = HP_max;
                }
                Log.text = ("主人公は回復した");
                //intaract_true();
            }
            else　if(HP == HP_max)
            {
                Log.text = ("体力は満タンだ！！！");
            }
            else if(HP_Potion < 1)
            {
                Log.text = ("ポーションが足りない");
            }
            intaract_true();
        }
    }
    void intaract_false()
    {
        Attack_.interactable = false;
        Magic_.interactable = false;
        Heal_.interactable = false;
        Concentlation_.interactable = false;
    }
    void intaract_true()
    {
        Attack_.interactable = true;
        Magic_.interactable = true;
        Heal_.interactable = true;
        Concentlation_.interactable = true;
    }
    public void Item_Reset()
    {
        Item_Manager.Item["healdrink"] = false;
        Item_Manager.Item["bowlingball"] = false;
        Item_Manager.Item["CDplayer"] = false;
        Item_Manager.Item["cd"] = false;
        Item_Manager.Item["radio"] = false;
        Item_Manager.Item["hourglass"] = false;

    }
    //アニメーションリセット（boolのみ）
    public void Anim_Reset(string anim_tag)
    {
        animator.SetBool(anim_tag, false);
        if(anim_tag != "heal")
            if (poison_cnt > 0)
            {
                HP -= 5;
                poison_cnt -= 1;
            }
        turn_Manager.turn = false;
    }
    //エフェクトオブジェクト作成関数
    public void Create_Effect_Player(int number, float Fx, float Fy)
    {
        obj_player = Instantiate(Effect[number], new Vector3(Fx, Fy, 0), Quaternion.identity, _parentGameObject.transform);
        obj_player.name = "Effect_image_" + number;
    }

    public void Lose()
    {
        animator.SetBool("death", false);
        HP = 100;
        MP = 100;
        Item_Reset();
        //各種数値を初期化
        Enemy_controller.turn = 0;
        Enemy_controller.HP = 150;
        Enemy_controller.tag_get = true;
        Money = 0;
        SceneManager.LoadScene("Lose");
    }
    public void SE_Play_Attack()
    {
        //遅延
        Invoke("DelayMethod", 80.0f);

        audioSource_Attack.PlayOneShot(clip_attack);
    }
    public void SE_Play_Magic()
    {
        //遅延
        Invoke("DelayMethod", 1.0f);

        audioSource_Magic.PlayOneShot(clip_magic);
    }
    public void SE_Play_Conce()
    {
        //遅延
        Invoke("DelayMethod", 1.0f);

        audioSource_Conce.PlayOneShot(clip_conce);
    }
    public void SE_Play_Heal()
    {
        //遅延
        Invoke("DelayMethod", 1.0f);

        audioSource_Heal.PlayOneShot(clip_heal);
    }
    public void SE_Play_Critical()
    {
        //遅延
        Invoke("DelayMethod", 180.0f);

        audioSource_Critical.PlayOneShot(clip_critical);
    }
}
