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
    bool Adapt_bowlingball = true;
    bool Adapt_cd = true;
    bool Adapt_CDplayer = true;
    bool Adapt_kesigomu = true;
    bool Adapt_TV = true;
    bool Adapt_CreditCard = true;
    bool Adapt_Mouse = true;
    bool Adapt_HandMirror = true;
    bool Adapt_bowlingpin = true;
    bool Adapt_baseball_ball = true;
    bool Adapt_Waterbucket = true;
    bool Adapt_Popcorn = true;
    bool Adapt_Apple = true;
    bool Adapt_Scissors = true;
    bool Adapt_ice = true;
    bool Adapt_Drill = true;
    bool Adapt_Utype_M = true;
    bool Adapt_Coffee = true;
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
    public static int MagicBook_cnt = 0;
    public static int MedhusaEye_cnt = 0; 
    public static int Pencil_Down_cnt = 0;

    public static bool Boxing_flag = false;
    public static bool Sinigami_Crit_Effect = false;
    public static bool Medhusa_Magic_flag = false;
    public static bool M_magic_book_flag = false;
    public static bool M_eye_flag = false;
    public static bool dice_crit = false;
    public static bool Watch_Add_reset = true;
    public static bool turn_bool = true;

    //スタートメソッド
    //説明・・・各コンポーネントを取得
    void Start()
    {
        //プレイヤーを読み込み、プレイヤーコントローラーを取得する
        GameObject player = GameObject.Find("Player");
        playercontroller = player.GetComponent<PlayerController>();
        
        //ステータスエフェクトを読み込み、コンポーネント取得
        GameObject Status_effect = GameObject.Find("Effect_manager");
        status_ = Status_effect.GetComponent<Status_Controller>();
    }

    //アップデートメソッド
    //説明・・・アイテムのフラグを取得し、アイテムの効果を管理する
    public void Update()
    {
        //アイテムのフラグ取得
        Item_Manager.Item.TryGetValue("healdrink",            out bool healdrink_flag);
        Item_Manager.Item.TryGetValue("bowlingball",          out bool bowlingball_flag);
        Item_Manager.Item.TryGetValue("cd",                   out bool cd_flag);
        Item_Manager.Item.TryGetValue("CDplayer",             out bool CDplayer_flag);
        Item_Manager.Item.TryGetValue("radio",                out bool radio_flag);
        Item_Manager.Item.TryGetValue("hourglass",            out bool hourglass_flag);
        Item_Manager.Item.TryGetValue("kesigomu",             out bool kesigomu_flag);
        Item_Manager.Item.TryGetValue("TV",                   out bool TV_flag);
        Item_Manager.Item.TryGetValue("CreditCard",           out bool CreditCard_flag);
        Item_Manager.Item.TryGetValue("Mouse",                out bool Mouse_flag);

        Item_Manager.Item.TryGetValue("HandMirror",           out bool HandMirror_flag);
        Item_Manager.Item.TryGetValue("bowlingpin",           out bool bowlingpin_flag);
        Item_Manager.Item.TryGetValue("baseball_ball",        out bool baseball_ball_flag);
        Item_Manager.Item.TryGetValue("dice",                 out bool dice_flag);
        Item_Manager.Item.TryGetValue("Water bucket",         out bool Waterbucket_flag);
        Item_Manager.Item.TryGetValue("Popcorn",              out bool Popcorn_flag);
        Item_Manager.Item.TryGetValue("Apple",                out bool Apple_flag);
        Item_Manager.Item.TryGetValue("Scissors",             out bool Scissors_flag);
        Item_Manager.Item.TryGetValue("ice",                  out bool ice_flag);
        Item_Manager.Item.TryGetValue("Pudding",              out bool Pudding_flag);

        Item_Manager.Item.TryGetValue("Drill",                out bool Drill_flag);
        Item_Manager.Item.TryGetValue("Headphone",            out bool Headphone_flag);
        Item_Manager.Item.TryGetValue("UtypeMagnet",          out bool UtypeMagnet_flag);
        Item_Manager.Item.TryGetValue("Coffee",               out bool Coffee_flag);
        Item_Manager.Item.TryGetValue("Safetycone",           out bool Safetycone_flag);
        Item_Manager.Item.TryGetValue("USB",                  out bool USB_flag);
        Item_Manager.Item.TryGetValue("Smartphone",           out bool Smartphone_flag);
        Item_Manager.Item.TryGetValue("ItypeMagnet",          out bool ItypeMagnet_flag);
        Item_Manager.Item.TryGetValue("Magnifying Speculum",  out bool MagnifyingSpeculum_flag);
        Item_Manager.Item.TryGetValue("Mike",                 out bool Mike_flag);

        Item_Manager.Item.TryGetValue("Megaphone",            out bool Megaphone_flag);
        Item_Manager.Item.TryGetValue("HandMill",             out bool HandMill_flag);
        Item_Manager.Item.TryGetValue("Poteto",               out bool Poteto_flag);
        Item_Manager.Item.TryGetValue("Scop",                 out bool Scop_flag);
        Item_Manager.Item.TryGetValue("hammer",               out bool hammer_flag);
        Item_Manager.Item.TryGetValue("Speaker",              out bool Speaker_flag);
        Item_Manager.Item.TryGetValue("Sylinge",              out bool Sylinge_flag);
        Item_Manager.Item.TryGetValue("Baseball_glove",       out bool Baseball_glove_flag);
        Item_Manager.Item.TryGetValue("Boxing_glove",         out bool Boxing_glove_flag);
        Item_Manager.Item.TryGetValue("Juice",                out bool Juice_flag);
        Item_Manager.Item.TryGetValue("Gas_burner",           out bool Gas_burner_flag);
        Item_Manager.Item.TryGetValue("Hamberger",            out bool Hamberger_flag);
        Item_Manager.Item.TryGetValue("Pencil",               out bool Pencil_flag);
        Item_Manager.Item.TryGetValue("Mayonnaise",           out bool Mayonnaise_flag);
        Item_Manager.Item.TryGetValue("Watch",                out bool Watch_flag);

        Item_Manager.Item.TryGetValue("Scythe",               out bool TheGrimReaper_Scythe_flag);
        Item_Manager.Item.TryGetValue("Robe",                 out bool Sinigami_Robe_flag);
        Item_Manager.Item.TryGetValue("Eye",                  out bool Medhusa_Eye_flag);
        Item_Manager.Item.TryGetValue("MagicBook",            out bool Medhusa_MagicBook_flag);
        Item_Manager.Item.TryGetValue("Scale",                out bool Dragon_Scale_flag);
        Item_Manager.Item.TryGetValue("Tooth",                out bool Dragon_Tooth_flag);


        //アイテムログのテンプレート

        //Log_list.LogList.Add("　の効果で　\n");

        //-----------------------------
        //アイテム効果（ターン毎に発動）
        //-----------------------------
        if (turn_compare < Enemy_controller.turn)
        {
            Log_list.LogList.Add("\n<color=#f3f300>　------アイテムの効果---------------------------</color>\n\n");//ログリストに追加

            //-------------------------------
            //   アイテム効果(初回ターンのみ)
            //-------------------------------

            if (healdrink_flag == true)
            {
                PlayerController.HP_potion += 1;
                Item_Manager.Item["healdrink"] = false;//ヒールドリンクは何個でも持てるためフラグをfalse
                healdrink_flag = false;
            }

            if (bowlingball_flag == true)
            {
                if (Adapt_bowlingball == true && first_turn == true)
                {
                    Debug.Log("bowlingball");
                    Log_list.LogList.Add("　ボウリングの球で物攻が２０増加、物防が２０減少\n");//ログリストに追加
                    playercontroller.Attack_damage += 20;//攻撃力20上昇
                    playercontroller.Deffence -= 20;//防御力20減少
                    Adapt_bowlingball = false;//falseにして一回しか読み込まれ内容にする
                }
            }
            if (cd_flag == true)
            {
                if (Adapt_cd == true && first_turn == true)
                {
                    int cd_num = 0;
                    Debug.Log("cd");
                    playercontroller.Attack_damage += cd_num = playercontroller.Deffence / 6;//attackにdiffenceの1/6の数字を加算
                    Log_list.LogList.Add("　CDで物攻" + cd_num + "が増加　\n");
                    Adapt_cd = false;
                }
            }
            if (CDplayer_flag == true)
            {
                if (Adapt_CDplayer == true && first_turn == true)
                {
                    Debug.Log("CDplayer");
                    playercontroller.Attack_damage -= 20;//攻撃力20減少
                    playercontroller.Deffence += 20;//防御力20上昇
                    Log_list.LogList.Add("　CDプレイヤーで物攻２０減少、物防２０増加　\n");
                    Adapt_CDplayer = false;
                }
            }
            if (kesigomu_flag == true)
            {
                if (Adapt_kesigomu == true && first_turn == true)
                {
                    int kesigomu_num = 0;
                    Debug.Log("kesigomu");
                    playercontroller.Attack_damage += 20;//物理攻撃力20上昇
                    playercontroller.Magic_damage -= kesigomu_num = playercontroller.Attack_damage / 2;//魔法攻撃力を物理攻撃力/２分減らす
                    Log_list.LogList.Add("　消しゴムで物攻２０増加、魔攻" + kesigomu_num + "減少　\n");
                    Adapt_kesigomu = false;
                }
            }
            if (TV_flag == true)
            {
                if (Adapt_TV == true && first_turn == true)
                {
                    int TV_num = 0;
                    Debug.Log("TV");
                    playercontroller.Magic_damage += TV_num = (playercontroller.Magic_damage / 5) * 3;//魔法攻撃力５につき魔法攻撃力を３上昇
                    Log_list.LogList.Add("　テレビで魔攻" + TV_num + "増加　\n");
                    Adapt_TV = false;
                }
            }
            if (CreditCard_flag == true)
            {
                if (Adapt_CreditCard == true && first_turn == true)
                {
                    Debug.Log("CreditCard");
                    PlayerController.Mmoney += 20;//戦闘開始後２０G入手
                    Log_list.LogList.Add("　クレジットカードで２０G入手　\n");
                    Adapt_CreditCard = false;
                }
            }
            if (Mouse_flag == true)
            {
                if (Adapt_Mouse == true && first_turn == true)
                {
                    Debug.Log("Mouse");
                    playercontroller.Magic_damage += 10;//魔法攻撃力１０上昇
                    Log_list.LogList.Add("　マウスで魔攻１０増加　\n");
                    Adapt_Mouse = false;
                }
            }
            if (HandMirror_flag == true)
            {
                if (Adapt_HandMirror == true && first_turn == true)
                {
                    Debug.Log("HandMirror");
                    playercontroller.Deffence += 10;//物理防御力を１０増加
                    playercontroller.Magic_diffence += 10;//魔法防御力を１０増加
                    Log_list.LogList.Add("　ハンドミラーで物防と魔防１０増加　\n");
                    Adapt_HandMirror = false;
                }
            }
            if (baseball_ball_flag == true)
            {
                if (Adapt_baseball_ball == true && first_turn == true)
                {
                    Debug.Log("baseball_ball");
                    playercontroller.Attack_damage += 15;//物理攻撃力を15増加
                    playercontroller.Deffence -= 10;//物理防御力を10減少
                    Log_list.LogList.Add("　野球ボールで物攻１５増加、物防１０減少　\n");
                    Adapt_baseball_ball = false;
                }
            }
            if (Waterbucket_flag == true)
            {
                if (Adapt_Waterbucket == true && first_turn == true)
                {
                    Debug.Log("Waterbucket");
                    playercontroller.Magic_diffence += 10;//魔法防御力を10増加
                    Log_list.LogList.Add("　水入りのバケツで魔防１０増加　\n");
                    Adapt_Waterbucket = false;
                }
            }
            if (Popcorn_flag == true)
            {
                if (Adapt_Popcorn == true && first_turn == true)
                {
                    Debug.Log("Popcorn");
                    PlayerController.HP += 20;//体力を２０回復
                    Log_list.LogList.Add("　ポップコーンで体力を２０回復　\n");
                    Adapt_Popcorn = false;
                }
            }
            if (Apple_flag == true)
            {
                if (Adapt_Apple == true && first_turn == true)
                {
                    Debug.Log("Apple");
                    PlayerController.HP += 30;//体力を３０回復
                    playercontroller.Magic_damage += 15;//魔法攻撃力を１５増加
                    Log_list.LogList.Add("　リンゴで体力を３０回復、魔攻１５増加　\n");
                    Adapt_Apple = false;
                }
            }
            if (Scissors_flag == true)
            {
                if (Adapt_Scissors == true && first_turn == true)
                {
                    Debug.Log("Scissors");
                    playercontroller.Attack_damage += 20;//物理攻撃力を２０増加
                    Log_list.LogList.Add("　ハサミで物攻２０増加　\n");
                    Adapt_Scissors = false;
                }
            }
            if (ice_flag == true)
            {
                if (Adapt_ice == true && first_turn == true)
                {
                    Debug.Log("ice");
                    playercontroller.Magic_damage += 10;//魔法攻撃力を１０増加
                    Log_list.LogList.Add("　氷で魔攻１０増加　\n");
                    Adapt_ice = false;
                }
            }
            if (Pudding_flag == true)
            {
                if (Apple_flag == true && adapt_Pudding == true && first_turn == true)
                {
                    PlayerController.HP_max += 30;//最大体力を３０増加
                    Log_list.LogList.Add("　リンゴとプリンで最大体力が３０増加　\n");
                    adapt_Pudding = false;
                }
                if (adapt_Pudding == true && first_turn == true)
                {
                    int Pudding_num;
                    Debug.Log("pudding");
                    PlayerController.HP += Pudding_num = PlayerController.HP_max / 4;//体力を１/４回復
                    Log_list.LogList.Add("　プリンで体力" + Pudding_num + "回復　\n");
                    adapt_Pudding = false;
                }
            }
            if (Drill_flag == true)
            {
                if (Adapt_Drill == true && first_turn)
                {
                    int Drill_num;
                    //敵の防御力の２分の１の数値を自身の物理攻撃力に加算する
                    playercontroller.Attack_damage += Drill_num = enemy_Controller.Enemy_deffence / 2;
                    Log_list.LogList.Add("　ドリルで物攻" + Drill_num + "増加　\n");
                    Adapt_Drill = false;
                }
            }
            if (UtypeMagnet_flag == true)
            {
                if (Adapt_Utype_M == true && first_turn == true)
                {
                    Debug.Log("Utype");
                    playercontroller.Magic_damage += 20;//魔法攻撃力を２０増加
                    Log_list.LogList.Add("　U字型マグネットで魔攻２０増加　\n");
                    Adapt_Utype_M = false;
                }
            }
            if (Coffee_flag == true)
            {
                if (Adapt_Coffee == true && first_turn == true)
                {
                    Debug.Log("Coffe");
                    //体力が２０より大きかった場合
                    if (PlayerController.HP > 20)
                    {
                        PlayerController.HP -= 20;//体力を２０減少させる
                        playercontroller.Magic_damage += 30;//魔法攻撃力を３０増加させる
                        Log_list.LogList.Add("　コーヒーで魔攻３０増加、体力２０減少　\n");
                    }
                    Adapt_Coffee = false;
                }
            }
            if (Safetycone_flag == true)
            {
                if (adapt_SafetyCorn == true && first_turn == true)
                {
                    Debug.Log("safetycone");
                    safetycorn_random = Random.Range(1, 7);//１/６の確率
                    if (safetycorn_random < 6)
                    {
                        adapt_SafetyCorn = false;
                    }
                    else if (safetycorn_random == 6)
                    {
                        playercontroller.Attack_damage += 40;//物理攻撃力を４０増加させる
                        playercontroller.Deffence += 40;//物理防御力を４０増加させる
                        Log_list.LogList.Add("　三角コーンで物攻と物防４０増加　\n");
                        adapt_SafetyCorn = false;
                    }
                }
            }
            if (USB_flag == true)
            {
                if (adapt_USB == true && first_turn == true)
                {
                    Debug.Log("USB");
                    playercontroller.Magic_damage += 20;//魔法攻撃力を２０増加させる
                    playercontroller.Magic_diffence -= 10;//魔法防御力を１０減少させる
                    Log_list.LogList.Add("　USBで魔攻２０増加、魔防１０減少　\n");
                    adapt_USB = false;
                }
            }
            if (Smartphone_flag == true)
            {
                if (adapt_SmartPhone == true && first_turn == true)
                {
                    int SmartPhone_num;
                    Debug.Log("SmartPhone");
                    playercontroller.Magic_diffence += SmartPhone_num = playercontroller.Magic_damage / 4;//魔法防御力を魔法攻撃力の１/４分増加させる
                    Log_list.LogList.Add("　スマートフォンで魔防" + SmartPhone_num + "増加　\n");
                    adapt_SmartPhone = false;
                }
            }
            if (ItypeMagnet_flag == true)
            {
                if (adapt_Itype_M == true && first_turn == true)
                {
                    Debug.Log("Itype");
                    playercontroller.Magic_diffence += 20;//魔法防御力を２０増加させる
                    Log_list.LogList.Add("　I字型マグネットで魔防２０増加　\n");
                    adapt_Itype_M = false;
                }
            }
            if (Mike_flag == true)
            {
                if (adapt_Mike == true && first_turn == true)
                {
                    Debug.Log("Mike");
                    playercontroller.Magic_damage += 30;//魔法攻撃力を３０増加させる
                    Log_list.LogList.Add("　マイクで魔攻３０増加　\n");
                    adapt_Mike = false;
                }
            }
            if (Megaphone_flag == true)
            {
                if (adapt_Megaphone == true && first_turn == true)
                {
                    Debug.Log("Megaphone");
                    playercontroller.Deffence += 20;//物理防御力を２０増加させる
                    Log_list.LogList.Add("　メガホンで物防２０増加　\n");
                    adapt_Megaphone = false;
                }
            }
            if (HandMill_flag == true)
            {
                //コーヒーを持っている場合魔法攻撃力を６０増加
                if (adapt_HandMill == true && Coffee_flag == true && first_turn == true)
                {
                    playercontroller.Magic_damage += 60;
                    Log_list.LogList.Add("　コーヒーとハンドミルで魔攻６０増加　\n");
                    adapt_HandMill = false;
                }
                else if (adapt_HandMill == true && first_turn == true)
                {
                    Debug.Log("HandMill");
                    playercontroller.Magic_damage -= 30;//魔法攻撃力を３０減少させる
                    Log_list.LogList.Add("　ハンドミルで魔攻３０増加　\n");
                    adapt_HandMill = false;
                }
            }
            if (Poteto_flag == true)
            {
                //ハンバーガーを持っている場合物理攻撃力を６０増加させる
                if (adapt_Poteto == true && Hamberger_flag == true && first_turn == true)
                {
                    playercontroller.Attack_damage += 60;
                    Log_list.LogList.Add("　　ポテトとハンバーガーで物攻６０増加　\n");
                    adapt_Poteto = false;
                }
                else if (adapt_Poteto == true && first_turn == true)
                {
                    Debug.Log("Poteto");
                    playercontroller.Attack_damage -= 30;//物理攻撃力を３０減少させる
                    Log_list.LogList.Add("　ポテトで物攻３０減少　\n");
                    adapt_Poteto = false;
                }
            }
            if (Scop_flag == true)
            {
                if (adapt_Scop == true && first_turn == true)
                {
                    Debug.Log("Scop");
                    scop_random = Random.Range(1, 5);//１/４の確率
                    if (scop_random == 4)
                    {
                        PlayerController.Mmoney += 30;//所持金額を３０増加させる
                        Log_list.LogList.Add("　スコップで３０G入手　\n");
                    }
                    adapt_Scop = false;
                }
            }
            if (Speaker_flag == true)
            {
                if (adapt_Speaker == true && first_turn == true)
                {
                    Debug.Log("Speaker");
                    enemy_Controller.Enemy_deffence -= 25;//敵の物理防御力を２５減少させる
                    Log_list.LogList.Add("　スピーカーで敵の物防２５減少　\n");
                    adapt_Speaker = false;
                }
            }
            if (Baseball_glove_flag == true)
            {
                //野球ボールを持っている場合
                if (adapt_Baseball_glove == true && baseball_ball_flag == true && first_turn == true)
                {
                    playercontroller.Attack_damage += 25;//物理攻撃力を２５増加
                    playercontroller.Deffence += 15;//物理防御力を１５増加
                    Log_list.LogList.Add("　野球ボールと野球グローブで物攻２５増加、物防１５増加　\n");
                    adapt_Baseball_glove = false;
                }
                else if (adapt_Baseball_glove == true && first_turn == true)
                {
                    Debug.Log("Baseball_glove");
                    playercontroller.Attack_damage += 25;//物理攻撃力を２５増加
                    Log_list.LogList.Add("　野球グローブで物攻２５増加　\n");
                    adapt_Baseball_glove = false;
                }
            }
            if (Boxing_glove_flag == true)
            {
                //ザンゲキ場単がおされたとき、物理攻撃力を３増加させる
                if (adapt_Boxing_glove == true && first_turn == true)
                {
                    Debug.Log("Boxing_glove");
                    Boxing_flag = true;
                    adapt_Boxing_glove = false;
                    Log_list.LogList.Add("　ボクシンググローブでザンゲキを押すと物攻が３増加　\n");
                }
            }
            if (Juice_flag == true)
            {
                if (adapt_Juice == true && first_turn == true)
                {
                    Debug.Log("Juice");
                    PlayerController.HP += 20;//体力を２０増加させる
                    Log_list.LogList.Add("　ジュースで体力を２０回復　\n");
                    adapt_Juice = false;
                }
            }
            if (Gas_burner_flag == true)
            {
                if (Enemy_controller.turn % 2 == 0 && turn_bool == true)
                {
                    Debug.Log("Gas_burner");
                    playercontroller.Attack_damage += 25;//物理攻撃力を２５増加させる
                    Log_list.LogList.Add("　ガスバーナーで物攻２５増加　\n");
                    turn_bool = false;
                }
                else if (Enemy_controller.turn != 1 && Enemy_controller.turn % 2 != 0 && turn_bool == true)
                {
                    playercontroller.Attack_damage -= 25;//物理攻撃力を２５減少させる
                    Log_list.LogList.Add("　ガスバーナーで物攻２５減少　\n");
                    turn_bool = false;
                }
            }
            if (Hamberger_flag == true)
            {
                //ポテトを持っていた場合
                if (adapt_Hamberger == true && Poteto_flag == true && first_turn == true)
                {
                    Debug.Log("Hamberger");
                    playercontroller.Attack_damage += 40;//物理攻撃力を４０増加させる
                    Log_list.LogList.Add("　ハンバーガーとポテトで物攻４０増加　\n");
                    adapt_Hamberger = false;
                }
                else if (adapt_Hamberger == true && first_turn == true)
                {
                    Debug.Log("Hamberger");
                    playercontroller.Attack_damage += 20;//物理攻撃力を２０増加させる
                    Log_list.LogList.Add("　ハンバーガーで物攻２０増加　\n");
                    adapt_Hamberger = false;
                }
            }
            if (Pencil_flag == true)
            {
                //戦闘開始時の効果
                if (adapt_Pencil == true && first_turn == true)
                {
                    Debug.Log("Pencil");
                    playercontroller.Attack_damage += 50;//物理攻撃力を５０増加させる
                    Log_list.LogList.Add("　鉛筆で物攻５０増加　\n");
                    adapt_Pencil = false;
                }
            }
            if (Mayonnaise_flag == true)
            {
                if (adapt_Mayonnaise == true && first_turn == true)
                {
                    Debug.Log("Mayonnaise");
                    playercontroller.Magic_damage += 50;//魔法攻撃力を５０増加させる
                    Log_list.LogList.Add("　マヨネーズで魔攻５０増加　\n");
                    adapt_Mayonnaise = false;
                }
            }
            if (TheGrimReaper_Scythe_flag == true)
            {
                if (adapt_TheGrimReaper_scythe == true && first_turn == true)
                {
                    Debug.Log("Scythe");
                    playercontroller.Attack_damage += 40;//物理攻撃力を４０増加させる
                    PlayerController.Mmax_luck -= 3;//クリティカル発生確率を3増加
                    Sinigami_Crit_Effect = true;//死神のクリティカルエフェクト発生
                    Log_list.LogList.Add("　死神の鎌で物攻４０増加　\n");
                    adapt_TheGrimReaper_scythe = false;
                }
            }
            if (Sinigami_Robe_flag == true)
            {
                if (adapt_TheGrimReaper_robe == true && first_turn == true)
                {
                    Debug.Log("Robe");
                    playercontroller.Deffence += 40;//物理防御力を40増加
                    PlayerController.Mmax_luck -= 3;//クリティカル発生確率を3増加
                    Log_list.LogList.Add("　死神のローブで物防４０増加　\n");
                    adapt_TheGrimReaper_robe = false;
                }
            }
            if (Medhusa_Eye_flag == true)
            {
                if (adapt_Medhusa_Eye == true && first_turn == true)
                {
                    Debug.Log("Eye");
                    enemy_Controller.magic_Diffence -= 40;//相手の魔法防御力を４０減少させる
                    PlayerController.Mmax_luck -= 3;//クリティカル発生確率を3増加
                    Log_list.LogList.Add("　メデューサの目で敵の魔防４０減少　\n");
                    M_eye_flag = true;
                    adapt_Medhusa_Eye = false;
                }
            }
            if (Medhusa_MagicBook_flag == true)
            {
                if (adapt_Medhusa_MagicBook == true && first_turn == true)
                {
                    Debug.Log("Magic_Book");
                    playercontroller.Magic_damage += 40;//魔法攻撃力を40増加させる
                    PlayerController.Mmax_luck -= 3;//クリティカル発生確率を3増加
                    Log_list.LogList.Add("　メデューサの魔導書で魔攻４０増加　\n");
                    Medhusa_Magic_flag = true;
                    M_magic_book_flag = true;
                    adapt_Medhusa_MagicBook = false;
                }
            }
            if (Dragon_Tooth_flag == true)
            {
                if (adapt_Dragon_Tooth = true && first_turn == true)
                {
                    Debug.Log("Tooth");
                    playercontroller.Attack_damage += 100;//物理攻撃力を100増加
                    PlayerController.HP_max += 50;//最大体力を50追加
                    Log_list.LogList.Add("　ドラゴンの牙で物攻１００増加、最大体力５０増加　\n");
                    adapt_Dragon_Tooth = false;
                }
            }
            if (bowlingpin_flag == true)
            {
                //効果の内容的に一番下
                if (Adapt_bowlingpin == true && first_turn == true)
                {
                    int bowlingpin_num = 0;
                    Debug.Log("bowlingpin");
                    PlayerController.Mmoney += bowlingpin_num = playercontroller.Attack_damage / 6;//所持金額を物理攻撃力の１/６分増加させる
                    Log_list.LogList.Add("　ボウリングのピンで" + bowlingpin_num + "G入手　\n");
                    Adapt_bowlingpin = false;
                }
            }
            first_turn = false;




            if (radio_flag == true)
            {
                if (PlayerController.HP > 11)
                {
                    Debug.Log("radio");
                    playercontroller.Deffence += 10;//毎ターン防御力10上昇
                    PlayerController.HP -= 5;//体力を5減らす
                    log_text.text = "ラジオで体力が５減少";
                    Log_list.LogList.Add("　ラジオで体力が５減少\n");//ログリストに追加
                }
                else
                {
                    log_text.text = "ラジオの効果は発動しなかった";
                }
            }
            if (hourglass_flag == true)
            {
                if (PlayerController.HP >11)
                {
                    Debug.Log("hourglass");
                    playercontroller.Attack_damage += 10;//毎ターン攻撃力10上昇
                    PlayerController.HP -= 5;//体力を5減らす
                    log_text.text = "砂時計の効果で体力が５減った";
                    Log_list.LogList.Add("　砂時計で体力が５減少\n");//ログリストに追加
                }
                else
                {
                    log_text.text = "砂時計の効果は発動しなかった";
                }
            }
            if (dice_flag == true)
            {
                Debug.Log("dice");
                dice_random = Random.Range(1, 7);
                switch (dice_random)
                {
                    case 1: playercontroller.Attack_damage += 10; Log_list.LogList.Add("　ダイスで物攻１０増加\n"); break;//物理攻撃力を１０増加
                    case 2: playercontroller.Attack_damage -= 10; Log_list.LogList.Add("　ダイスで物攻１０減少\n"); break;//物理攻撃力を１０減少
                    case 3: playercontroller.Magic_damage  += 10; Log_list.LogList.Add("　ダイスで魔攻１０上昇\n"); break;//魔法攻撃力を１０増加
                    case 4: playercontroller.Magic_damage  -= 10; Log_list.LogList.Add("　ダイスで魔攻１０減少\n"); break;//魔法攻撃力を１０減少
                    case 5: PlayerController.Mmoney        +=  5; Log_list.LogList.Add("　ダイスで５G入手\n");      break;//所持金額を５増加させる
                    case 6: dice_crit = true; Log_list.LogList.Add("　ダイスでクリティカルが発生率増加\n"); break;//クリティカル発生
                }
            }
            if (Scissors_flag == true)
            {
                Debug.Log("Scissors");
                Log_list.LogList.Add("　ハサミで物防２減少\n");
                playercontroller.Deffence -= 2;//物理防御力を２減少させる
            }
            if (Headphone_flag)
            {
                Debug.Log("Headphone");
                if (playercontroller.Attack_damage <= 3 || playercontroller.Deffence <= 3)
                {
                    log_text.text = "ヘッドホンの効果は発動しなかった";
                }
                else
                {
                    playercontroller.Attack_damage -= 3;//物理攻撃力を３減少させる
                    playercontroller.Deffence -= 3;//物理防御力を３減少させる
                    PlayerController.HP += 10;//体力を１０回復させる
                    Log_list.LogList.Add("　ヘッドホンで体力を１０回復し、物攻と物防３減少\n");
                }
            }
            if (MagnifyingSpeculum_flag == true)
            {
                Debug.Log("Magnifying");
                Log_list.LogList.Add("　虫眼鏡で物防と魔防３増加\n");
                playercontroller.Deffence += 3;//物理防御力を３増加させる
                playercontroller.Magic_diffence += 3;//魔法防御力を３増加させる
            }
            if (hammer_flag == true)
            {
                Debug.Log("hammer");
                hammer_random = Random.Range(1, 11);//１/１０の確率
                if (hammer_random == 10)
                {
                    //敵を気絶させる
                    Enemy_controller.Stun_turn = true;
                    Log_list.LogList.Add("　ハンマーの効果で敵がスタンした\n");
                    status_.Status_Effect(false, 4);//気絶エフェクト
                }
            }
            if (Sylinge_flag == true)
            {
                Debug.Log("Sylinge");
                sylinge_random = Random.Range(1, 7);//１/６の確率
                if (sylinge_random == 6)
                {
                    Log_list.LogList.Add("　注射器で体力が３０回復\n");
                    PlayerController.HP += 30;//体力を３０回復させる
                }
                else
                {
                    Log_list.LogList.Add("　注射器で体力が５回復\n");
                    PlayerController.HP += 5;//体力を５回復させる
                }
            }
            if (Pencil_flag == true)
            {
                Debug.Log("Pencil");
                //１０ターンの間
                if (Pencil_Down_cnt <= 10)
                {
                    Log_list.LogList.Add("　鉛筆で物攻５減少\n");
                    playercontroller.Attack_damage -= 5;//物理攻撃力を５減少させる
                    Pencil_Down_cnt++;
                }
            }
            if (Mayonnaise_flag == true)
            {
                Debug.Log("Mayonnaise");
                //１０ターンの間
                if (Pencil_Down_cnt <= 10)
                {
                    Log_list.LogList.Add("　マヨネーズで魔攻５減少\n");
                    playercontroller.Magic_damage -= 5;//魔法攻撃力を５減少
                    Pencil_Down_cnt++;
                }
            }
            if (Watch_flag == true)
            {
                Debug.Log("Watch");
                if (Watch_Add_reset == true)
                {
                    //物理攻撃力
                    Log_list.LogList.Add("　腕時計で物攻"+ (PlayerController.HP_max - PlayerController.HP) +"上昇\n");
                    playercontroller.Attack_damage += PlayerController.HP_max - PlayerController.HP;
                    Watch_Add_reset = false;
                }
            }
            if (Dragon_Scale_flag == true)
            {
                Debug.Log("Dragon_Scale");
                Log_list.LogList.Add("　ドラゴンの鱗で全ステータス１０上昇\n");
                playercontroller.Attack_damage += 10;//物理攻撃力を１０増加
                playercontroller.Deffence += 10;//物理防御量を１０増加
                playercontroller.Magic_damage += 10;//魔法攻撃力を１０増加
                playercontroller.Magic_diffence += 10;//魔法防御力を１０増加
            }
            Log_list.LogList.Add("　<color=#f3f300>----------------------------------------------</color>　\n");
            turn_compare = Enemy_controller.turn;
        }
    }
}