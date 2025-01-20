using UnityEngine;
using UnityEngine.UI;

public class Item_Power : MonoBehaviour
{
    PlayerController playercontroller;//主人公
    Status_Controller status_; //ステータスコントローラ
    public Enemy_controller enemy_Controller;//敵
    public Text log_text;//ログ
    public static int turn_compare = 0;//ターン数比較用()
    public static bool first_turn = true;//最初のターン

    //ターンの最初のみ読み込むためのフラグ（各アイテム毎に１つ設定）
    bool adapt_bowlingball = true;
    bool adapt_cd = true;
    bool adapt_CDplayer = true;
    bool adapt_kesigomu = true;
    bool adapt_TV = true;
    bool adapt_CreditCard = true;
    bool adapt_Mouse = true;
    bool adapt_HandMirror = true;
    bool adapt_bowlingpin = true;
    bool adapt_baseball_ball = true;
    bool adapt_Waterbucket = true;
    bool adapt_Popcorn = true;
    bool adapt_Apple = true;
    bool adapt_Scissors = true;
    bool adapt_ice = true;
    bool adapt_Drill = true;
    bool adapt_Utype_M = true;
    bool adapt_Coffee = true;
    bool adapt_SafetyCorn = true;
    bool adapt_USB = true;
    bool adapt_SmartPhone = true;
    bool adapt_Itype_M = true;
    bool adapt_Mike = true;
    bool adapt_Megaphone = true;
    bool adapt_HandMill = true;
    bool adapt_Poteto = true;
    bool adapt_Scop = true;
    bool adapt_Speaker = true;
    bool adapt_Baseball_glove = true;
    bool adapt_Boxing_glove = true;
    bool adapt_Juice = true;
    bool adapt_Hamberger = true;
    bool adapt_Pencil = true;
    bool adapt_Mayonnaise = true;
    static bool adapt_Pudding = true;
    bool adapt_TheGrimReaper_scythe = true;
    bool adapt_TheGrimReaper_robe = true;
    bool adapt_Medhusa_Eye = true;
    bool adapt_Medhusa_MagicBook = true;
    bool adapt_Dragon_Tooth = true;
    
    int dice_random = 0;
    int safetycorn_random = 0;
    int scop_random = 0;
    int hammer_random = 0;
    int sylinge_random = 0;
    //int gas_burner_turn_multh = 1;
    public static int Pencil_Down_cnt = 0;

    public static bool Boxing_flag = false;
    public static bool Sinigami_Crit_Effect = false;
    public static bool Medhusa_Magic_flag = false;
    public static bool dice_crit = false;
    public static bool Watch_Add_reset = true;
    public static bool turn_bool = true;
    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーを読み込み、プレイヤーコントローラーを取得する
        GameObject player = GameObject.Find("Player");
        playercontroller = player.GetComponent<PlayerController>();
        GameObject Status_effect = GameObject.Find("Effect_manager");
        status_ = Status_effect.GetComponent<Status_Controller>();
    }

    // Update is called once per frame
    public void Update()
    {
       

        //アイテムのフラグ取得
        Item_Manager.Item.TryGetValue("healdrink", out bool healdrink_flag);
        Item_Manager.Item.TryGetValue("bowlingball", out bool bowlingball_flag);
        Item_Manager.Item.TryGetValue("cd", out bool cd_flag);
        Item_Manager.Item.TryGetValue("CDplayer", out bool CDplayer_flag);
        Item_Manager.Item.TryGetValue("radio", out bool radio_flag);
        Item_Manager.Item.TryGetValue("hourglass", out bool hourglass_flag);
        Item_Manager.Item.TryGetValue("kesigomu", out bool kesigomu_flag);
        Item_Manager.Item.TryGetValue("TV", out bool TV_flag);
        Item_Manager.Item.TryGetValue("CreditCard", out bool CreditCard_flag);
        Item_Manager.Item.TryGetValue("Mouse", out bool Mouse_flag);

        Item_Manager.Item.TryGetValue("HandMirror", out bool HandMirror_flag);
        Item_Manager.Item.TryGetValue("bowlingpin", out bool bowlingpin_flag);
        Item_Manager.Item.TryGetValue("baseball_ball", out bool baseball_ball_flag);
        Item_Manager.Item.TryGetValue("dice", out bool dice_flag);
        Item_Manager.Item.TryGetValue("Water bucket", out bool Waterbucket_flag);
        Item_Manager.Item.TryGetValue("Popcorn", out bool Popcorn_flag);
        Item_Manager.Item.TryGetValue("Apple", out bool Apple_flag);
        Item_Manager.Item.TryGetValue("Scissors", out bool Scissors_flag);
        Item_Manager.Item.TryGetValue("ice", out bool ice_flag);
        Item_Manager.Item.TryGetValue("Pudding", out bool Pudding_flag);

        Item_Manager.Item.TryGetValue("Drill", out bool Drill_flag);
        Item_Manager.Item.TryGetValue("Headphone", out bool Headphone_flag);
        Item_Manager.Item.TryGetValue("UtypeMagnet", out bool UtypeMagnet_flag);
        Item_Manager.Item.TryGetValue("Coffee", out bool Coffee_flag);
        Item_Manager.Item.TryGetValue("Safetycone", out bool Safetycone_flag);
        Item_Manager.Item.TryGetValue("USB", out bool USB_flag);
        Item_Manager.Item.TryGetValue("Smartphone", out bool Smartphone_flag);
        Item_Manager.Item.TryGetValue("ItypeMagnet", out bool ItypeMagnet_flag);
        Item_Manager.Item.TryGetValue("Magnifying Speculum", out bool MagnifyingSpeculum_flag);
        Item_Manager.Item.TryGetValue("Mike", out bool Mike_flag);

        Item_Manager.Item.TryGetValue("Megaphone", out bool Megaphone_flag);
        Item_Manager.Item.TryGetValue("HandMill", out bool HandMill_flag);
        Item_Manager.Item.TryGetValue("Poteto", out bool Poteto_flag);
        Item_Manager.Item.TryGetValue("Scop", out bool Scop_flag);
        Item_Manager.Item.TryGetValue("hammer", out bool hammer_flag);
        Item_Manager.Item.TryGetValue("Speaker", out bool Speaker_flag);
        Item_Manager.Item.TryGetValue("Sylinge", out bool Sylinge_flag);
        Item_Manager.Item.TryGetValue("Baseball_glove", out bool Baseball_glove_flag);
        Item_Manager.Item.TryGetValue("Boxing_glove", out bool Boxing_glove_flag);
        Item_Manager.Item.TryGetValue("Juice", out bool Juice_flag);

        Item_Manager.Item.TryGetValue("Gas_burner", out bool Gas_burner_flag);
        Item_Manager.Item.TryGetValue("Hamberger", out bool Hamberger_flag);
        Item_Manager.Item.TryGetValue("Pencil", out bool Pencil_flag);
        Item_Manager.Item.TryGetValue("Mayonnaise", out bool Mayonnaise_flag);
        Item_Manager.Item.TryGetValue("Watch", out bool Watch_flag);
        Item_Manager.Item.TryGetValue("Scythe", out bool TheGrimReaper_Scythe_flag);
        Item_Manager.Item.TryGetValue("Robe", out bool Sinigami_Robe_flag);
        Item_Manager.Item.TryGetValue("Eye", out bool Medhusa_Eye_flag);
        Item_Manager.Item.TryGetValue("MagicBook", out bool Medhusa_MagicBook_flag);
        Item_Manager.Item.TryGetValue("Scale", out bool Dragon_Scale_flag);

        Item_Manager.Item.TryGetValue("Tooth", out bool Dragon_Tooth_flag);

        //-------------------------------
        //   アイテム効果(初回ターンのみ)
        //-------------------------------

        if (healdrink_flag == true)
        {
            PlayerController.HP_Potion += 1;
            Item_Manager.Item["healdrink"] = false;//ヒールドリンクは何個でも持てるためフラグをfalse
            healdrink_flag = false;
        }

        if (bowlingball_flag == true)
        {
            if(adapt_bowlingball == true && first_turn == true)
            {
                playercontroller.Attack += 20;//攻撃力20上昇
                playercontroller.Diffence -= 20;//防御力20減少
                adapt_bowlingball = false;//falseにして一回しか読み込まれ内容にする
            }
        }
        if(cd_flag == true)
        {
            if(adapt_cd == true && first_turn == true)
            {
                playercontroller.Attack += playercontroller.Diffence / 6;//attackにdiffenceの1/6の数字を加算
                adapt_cd = false;
            }
        }
        if(CDplayer_flag == true)
        {
            if(adapt_CDplayer == true && first_turn == true)
            {
                playercontroller.Attack -= 20;//攻撃力20減少
                playercontroller.Diffence += 20;//防御力20上昇
                adapt_CDplayer = false;
            }
        }
        if(kesigomu_flag == true)
        {
            if(adapt_kesigomu == true && first_turn == true)
            {
                playercontroller.Attack += 20;
                playercontroller.Magic -= playercontroller.Attack / 2;
                adapt_kesigomu = false;
            }
        }
        if(TV_flag == true)
        {
            if(adapt_TV == true && first_turn == true)
            {
                playercontroller.Magic += (playercontroller.Magic / 5) * 3;//魔法攻撃力５につき魔法攻撃力を３上昇
                adapt_TV = false;
            }
        }
        if(CreditCard_flag == true)
        {
            if(adapt_CreditCard == true && first_turn == true)
            {
                PlayerController.Money += 20;//戦闘開始後20G入手
                adapt_CreditCard = false;
            }
        }
        if(Mouse_flag == true)
        {
            if(adapt_Mouse == true && first_turn == true)
            {
                playercontroller.Magic += 10;
                adapt_Mouse = false;
            }
        }
        if(HandMirror_flag == true)
        {
            if(adapt_HandMirror == true && first_turn == true)
            {
                playercontroller.Diffence += 15;
                playercontroller.Magic_Diffence += 15;
                adapt_HandMirror = false;
            }
        }
        if(baseball_ball_flag == true)
        {
            if(adapt_baseball_ball == true && first_turn == true)
            {
                playercontroller.Attack += 15;
                playercontroller.Diffence -= 10;
                adapt_baseball_ball = false;
            }
        }
        if(Waterbucket_flag == true)
        {
            if(adapt_Waterbucket == true && first_turn == true)
            {
                playercontroller.Magic_Diffence += 10;
                adapt_Waterbucket = false;
            }
        }
        if(Popcorn_flag == true)
        {
            if (adapt_Popcorn == true && first_turn == true)
            {
                PlayerController.HP += 20;
                adapt_Popcorn = false;
            }
        }
        if(Apple_flag == true)
        {
            if(adapt_Apple == true && first_turn == true)
            {
                PlayerController.HP += 30;
                playercontroller.Magic += 15;
                adapt_Apple = false;
            }
        }
        if(Scissors_flag == true)
        {
            if(adapt_Scissors == true && first_turn == true)
            {
                playercontroller.Attack += 20;
                adapt_Scissors = false;
            }
        }
        if (ice_flag == true)
        {
            if(adapt_ice == true && first_turn == true)
            {
                playercontroller.Magic += 10;
                adapt_ice = false;
            }
        }
        if(Pudding_flag == true)
        {
            if(Apple_flag == true && adapt_Pudding == true && first_turn == true)
            {
                PlayerController.HP_max += 30;
                adapt_Pudding = false;
            }
            if(adapt_Pudding == true && first_turn == true)
            {
                PlayerController.HP += PlayerController.HP_max / 4;
                adapt_Pudding = false;
            }
        }
        if(UtypeMagnet_flag == true)
        {
            if (adapt_Utype_M == true && first_turn == true)
            {
                playercontroller.Magic += 20;
                adapt_Utype_M = false;
            }
        }
        if(Coffee_flag == true)
        {
            if(adapt_Coffee == true && first_turn == true)
            {
                if(PlayerController.HP < 6)
                {
                    PlayerController.HP = 5;
                }
                else
                {
                    PlayerController.HP -= 20;
                }
                playercontroller.Magic += 30;
                adapt_Coffee = false;
            }
        }
        if(Safetycone_flag == true)
        {
            if(adapt_SafetyCorn == true && first_turn == true)
            {
                safetycorn_random = Random.Range(1, 5);
                if(safetycorn_random < 4)
                {
                    adapt_SafetyCorn = false;
                }
                else if(safetycorn_random == 4)
                {
                    playercontroller.Attack += 40;
                    playercontroller.Diffence += 40;
                    adapt_SafetyCorn = false;
                }
            }
        }
        if(USB_flag == true)
        {
            if(adapt_USB == true && first_turn == true)
            {
                playercontroller.Magic += 20;
                playercontroller.Magic_Diffence -= 10;
                adapt_USB = false;
            }
        }
        if(Smartphone_flag == true)
        {
            if(adapt_SmartPhone == true && first_turn == true)
            {
                playercontroller.Magic_Diffence += playercontroller.Magic / 4;
                adapt_SmartPhone = false;
            }
        }
        if(ItypeMagnet_flag == true)
        {
            if(adapt_Itype_M == true && first_turn == true)
            {
                playercontroller.Magic_Diffence += 20;
                adapt_Itype_M = false;
            }
        }
        if(Mike_flag == true)
        {
            if(adapt_Mike == true && first_turn == true)
            {
                playercontroller.Magic += 30;
                adapt_Mike = false;
            }
        }
        if(Megaphone_flag == true)
        {
            if(adapt_Megaphone == true && first_turn == true)
            {
                playercontroller.Diffence += 20;
                adapt_Megaphone = false;
            }
        }
        if(HandMill_flag == true)
        {
            if(adapt_HandMill == true && Coffee_flag == true && first_turn == true)
            {
                playercontroller.Magic += 60;
                adapt_HandMill = false;
            }
            else if(adapt_HandMill == true && first_turn == true)
            {
                playercontroller.Magic -= 30;
                adapt_HandMill = false;
            }
        }
        if(Poteto_flag == true)
        {
            if (adapt_Poteto == true && Hamberger_flag == true && first_turn == true)
            {
                playercontroller.Attack += 60;
                adapt_Poteto = false;
            }
            else if (adapt_Poteto == true && first_turn == true)
            {
                playercontroller.Attack -= 30;
                adapt_Poteto = false;
            }
        }
        if (Scop_flag == true)
        {
            if(adapt_Scop == true && first_turn == true)
            {
                scop_random = Random.Range(1, 5);
                if(scop_random == 4)
                {
                    PlayerController.Money += 30;
                }
                adapt_Scop = false;
            }
        }
        if(Speaker_flag == true)
        {
            if(adapt_Speaker == true && first_turn == true)
            {
                enemy_Controller.deffence -= 25;
                adapt_Speaker = false;
            }
        }
        if(Baseball_glove_flag == true)
        {
            if(adapt_Baseball_glove == true && baseball_ball_flag == true && first_turn == true)
            {
                playercontroller.Attack += 25;
                playercontroller.Diffence += 35;
                adapt_Baseball_glove = false;
            }
            else if (adapt_Baseball_glove == true && first_turn == true)
            {
                playercontroller.Attack += 25;
                adapt_Baseball_glove = false;
            }
        }
        if(Boxing_glove_flag == true)
        {
            if(adapt_Boxing_glove == true && first_turn == true)
            {
                Boxing_flag = true;
                adapt_Boxing_glove = false;
            }
        }
        if(Juice_flag  == true)
        {
            if(adapt_Juice == true && first_turn == true)
            {
                PlayerController.HP += 20;
                adapt_Juice = false;
            }
        }
        if(Gas_burner_flag == true)
        {
            if (Enemy_controller.turn % 2 == 0 && turn_bool == true)
            {
                playercontroller.Attack += 25;
                turn_bool = false;
            }
            else if (Enemy_controller.turn != 1&&Enemy_controller.turn % 2 != 0 && turn_bool == true)
            {
                playercontroller.Attack -= 25;
                turn_bool = false;
            }
        }
        if(Hamberger_flag == true)
        {
            if(adapt_Hamberger == true && Poteto_flag == true && first_turn == true)
            {
                playercontroller.Attack += 40;
                adapt_Hamberger = false;
            }
            else if(adapt_Hamberger == true && first_turn == true)
            {
                playercontroller.Attack += 20;
                adapt_Hamberger = false;
            }
        }
        if (Pencil_flag == true)
        {
            //戦闘開始時の効果
            if (adapt_Pencil == true && first_turn == true)
            {
                playercontroller.Attack += 50;
                adapt_Pencil = false;
            }
        }
        if (Mayonnaise_flag == true)
        {
            if (adapt_Mayonnaise == true && first_turn == true)
            {
                playercontroller.Magic += 50;
                adapt_Mayonnaise = false;
            }
        }
        if (TheGrimReaper_Scythe_flag == true)
        {
            if(adapt_TheGrimReaper_scythe == true && first_turn == true)
            {
                playercontroller.Attack      += 40;
                PlayerController.max_luck    -= 3;
                Sinigami_Crit_Effect = true;//死神のクリティカルエフェクト発生
                adapt_TheGrimReaper_scythe = false;
            }
        }
        if(Sinigami_Robe_flag == true)
        {
            if(adapt_TheGrimReaper_robe == true && first_turn == true)
            {
                playercontroller.Diffence += 40;
                PlayerController.max_luck -= 3;
                adapt_TheGrimReaper_robe = false;
            }
        }
        if(Medhusa_Eye_flag == true)
        {
            if(adapt_Medhusa_Eye == true && first_turn == true)
            {
                playercontroller.Magic_Diffence += 40;
                PlayerController.max_luck       -= 3;
                adapt_Medhusa_Eye = false;
            }
        }
        if(Medhusa_MagicBook_flag == true)
        {
            if(adapt_Medhusa_MagicBook == true && first_turn == true)
            {
                playercontroller.Magic    += 40;
                PlayerController.max_luck -= 3;
                Medhusa_Magic_flag = true;
                adapt_Medhusa_MagicBook = false;
            }
        }
        if(Dragon_Tooth_flag == true)
        {
            if(adapt_Dragon_Tooth = true && first_turn == true)
            {
                playercontroller.Attack    += 100;
                PlayerController.HP_max     = 50;
                adapt_Dragon_Tooth = false;
            }
        }
        if (bowlingpin_flag == true)
        {
            //効果の内容的に一番下
            if (adapt_bowlingpin == true && first_turn == true)
            {
                PlayerController.Money += playercontroller.Attack / 6;
                adapt_bowlingpin = false;
            }
        }

        //-----------------------------
        //アイテム効果（ターン毎に発動）
        //-----------------------------

        if(turn_compare < Enemy_controller.turn)
        {
            if (radio_flag == true)
            {
                if (PlayerController.HP > 6)
                {
                    playercontroller.Diffence += 10;//毎ターン防御力10上昇
                    PlayerController.HP -= 5;//体力を5減らす
                    log_text.text = "ラジオの効果で-5HP";
                }
                else
                {
                    log_text.text = "ラジオの効果は発動しなかった";
                }
            }
            if (hourglass_flag == true)
            {
                if (PlayerController.HP > 6)
                {
                    playercontroller.Attack += 10;//毎ターン攻撃力10上昇
                    PlayerController.HP -= 5;//体力を5減らす
                    log_text.text = "砂時計の効果で-5HP";
                }
                else
                {
                    log_text.text = "効果は発動しなかった";
                }
            }
            if (dice_flag == true)
            {
                dice_random = Random.Range(1, 7);
                switch (dice_random)
                {
                    case 1: playercontroller.Attack += 10; break;
                    case 2: playercontroller.Attack -= 10; break;
                    case 3: playercontroller.Magic += 10; break;
                    case 4: playercontroller.Magic -= 10; break;
                    case 5: PlayerController.Money += 5; break;
                    case 6: dice_crit = true; break;//クリティカル発生
                }
                if (Scissors_flag == true)
                {
                    playercontroller.Diffence -= 2;
                }
                if (Headphone_flag)
                {
                    if (playercontroller.Attack <= 3 || playercontroller.Diffence <= 3)
                    {
                        log_text.text = "ヘッドホンの効果は発動しなかった";
                    }
                    else
                    {
                        playercontroller.Attack -= 3;
                        playercontroller.Diffence -= 3;
                        PlayerController.HP += 10;
                    }
                }
                if (MagnifyingSpeculum_flag == true)
                {
                    playercontroller.Diffence += 3;
                    playercontroller.Magic_Diffence += 3;
                }
                if (hammer_flag == true)
                {
                    hammer_random = Random.Range(1, 11);
                    if (hammer_random <= 10)
                    {
                        Enemy_controller.Stun_turn = true;
                        status_.Status_Effect(false, 4);//気絶エフェクト
                    }
                }
                if (Sylinge_flag == true)
                {
                    sylinge_random = Random.Range(1, 7);
                    if (sylinge_random == 6)
                    {
                        PlayerController.HP += 30;
                    }
                    else
                    {
                        PlayerController.HP += 5;
                    }
                }
                if (Pencil_flag == true)
                {
                    if (Pencil_Down_cnt <= 10)
                    {
                        playercontroller.Attack -= 5;
                        Pencil_Down_cnt++;
                    }
                }
                if (Mayonnaise_flag == true)
                {
                    if (Pencil_Down_cnt <= 10)
                    {
                        playercontroller.Magic -= 5;
                        Pencil_Down_cnt++;
                    }
                }
                if (Watch_flag == true)
                {
                    if (Watch_Add_reset == true)
                    {
                        playercontroller.Attack += PlayerController.HP_max - PlayerController.HP;
                        Watch_Add_reset = false;
                    }
                }
                if (Dragon_Scale_flag == true)
                {
                    playercontroller.Attack += 10;
                    playercontroller.Diffence += 10;
                    playercontroller.Magic += 10;
                    playercontroller.Magic_Diffence += 10;
                }
            }
            turn_compare = Enemy_controller.turn;
        }
    }
}