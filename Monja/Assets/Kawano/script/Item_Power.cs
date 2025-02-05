using UnityEngine;
using UnityEngine.UI;

public class Item_Power : MonoBehaviour
{
    PlayerController playercontroller;//ålŒö
    Status_Controller status_; //ƒXƒe[ƒ^ƒXƒRƒ“ƒgƒ[ƒ‰
    public Enemy_controller enemy_Controller;//“G
    public Text log_text;//ƒƒO
    public static int turn_compare = 0;//ƒ^[ƒ“””äŠr—p()
    public static bool first_turn = true;//Å‰‚Ìƒ^[ƒ“

    //ƒ^[ƒ“‚ÌÅ‰‚Ì‚İ“Ç‚İ‚Ş‚½‚ß‚Ìƒtƒ‰ƒOiŠeƒAƒCƒeƒ€–ˆ‚É‚P‚Âİ’èj
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
    public static int MagicBook_cnt = 0;
    public static int MedhusaEye_cnt = 0; 
    public static int Pencil_Down_cnt = 0;

    public static bool Boxing_flag = false;
    public static bool Sinigami_Crit_Effect = false;
    public static bool Medhusa_Magic_flag = false;
    public static bool dice_crit = false;
    public static bool Watch_Add_reset = true;
    public static bool turn_bool = true;

    //ƒXƒ^[ƒgƒƒ\ƒbƒh
    //à–¾EEEŠeƒRƒ“ƒ|[ƒlƒ“ƒg‚ğæ“¾
    void Start()
    {
        //ƒvƒŒƒCƒ„[‚ğ“Ç‚İ‚İAƒvƒŒƒCƒ„[ƒRƒ“ƒgƒ[ƒ‰[‚ğæ“¾‚·‚é
        GameObject player = GameObject.Find("Player");
        playercontroller = player.GetComponent<PlayerController>();
        
        //ƒXƒe[ƒ^ƒXƒGƒtƒFƒNƒg‚ğ“Ç‚İ‚İAƒRƒ“ƒ|[ƒlƒ“ƒgæ“¾
        GameObject Status_effect = GameObject.Find("Effect_manager");
        status_ = Status_effect.GetComponent<Status_Controller>();
    }

    //ƒAƒbƒvƒf[ƒgƒƒ\ƒbƒh
    //à–¾EEEƒAƒCƒeƒ€‚Ìƒtƒ‰ƒO‚ğæ“¾‚µAƒAƒCƒeƒ€‚ÌŒø‰Ê‚ğŠÇ—‚·‚é
    public void Update()
    {
        //ƒAƒCƒeƒ€‚Ìƒtƒ‰ƒOæ“¾
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


        //ƒAƒCƒeƒ€ƒƒO‚Ìƒeƒ“ƒvƒŒ[ƒg

        //Log_list.LogList.Add("@‚ÌŒø‰Ê‚Å@\n");

        //-----------------------------
        //ƒAƒCƒeƒ€Œø‰Êiƒ^[ƒ“–ˆ‚É”­“®j
        //-----------------------------
        if (turn_compare < Enemy_controller.turn)
        {
            Log_list.LogList.Add("\n<color=#f3f300>@------ƒAƒCƒeƒ€‚ÌŒø‰Ê------</color>\n\n");//ƒƒOƒŠƒXƒg‚É’Ç‰Á

            //-------------------------------
            //   ƒAƒCƒeƒ€Œø‰Ê(‰‰ñƒ^[ƒ“‚Ì‚İ)
            //-------------------------------

            if (healdrink_flag == true)
            {
                PlayerController.HP_POTION += 1;
                Item_Manager.Item["healdrink"] = false;//ƒq[ƒ‹ƒhƒŠƒ“ƒN‚Í‰½ŒÂ‚Å‚à‚Ä‚é‚½‚ßƒtƒ‰ƒO‚ğfalse
                healdrink_flag = false;
            }

            if (bowlingball_flag == true)
            {
                if (adapt_bowlingball == true && first_turn == true)
                {
                    Debug.Log("bowlingball");
                    Log_list.LogList.Add("@ƒ{ƒEƒŠƒ“ƒO‚Ì‹…‚Å•¨U‚ª‚Q‚O‘‰ÁA•¨–h‚ª‚Q‚OŒ¸­\n");//ƒƒOƒŠƒXƒg‚É’Ç‰Á
                    playercontroller.Attack_damage += 20;//UŒ‚—Í20ã¸
                    playercontroller.Deffence -= 20;//–hŒä—Í20Œ¸­
                    adapt_bowlingball = false;//false‚É‚µ‚Äˆê‰ñ‚µ‚©“Ç‚İ‚Ü‚ê“à—e‚É‚·‚é
                }
            }
            if (cd_flag == true)
            {
                if (adapt_cd == true && first_turn == true)
                {
                    int cd_num = 0;
                    Debug.Log("cd");
                    playercontroller.Attack_damage += cd_num = playercontroller.Deffence / 6;//attack‚Édiffence‚Ì1/6‚Ì”š‚ğ‰ÁZ
                    Log_list.LogList.Add("@CD‚Å•¨U" + cd_num + "‘‰Á@\n");
                    adapt_cd = false;
                }
            }
            if (CDplayer_flag == true)
            {
                if (adapt_CDplayer == true && first_turn == true)
                {
                    Debug.Log("CDplayer");
                    playercontroller.Attack_damage -= 20;//UŒ‚—Í20Œ¸­
                    playercontroller.Deffence += 20;//–hŒä—Í20ã¸
                    Log_list.LogList.Add("@CDƒvƒŒƒCƒ„[‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚Q‚OŒ¸­‚µA•¨—–hŒä—Í‚ª‚Q‚O‘‰Á‚µ‚½@\n");
                    adapt_CDplayer = false;
                }
            }
            if (kesigomu_flag == true)
            {
                if (adapt_kesigomu == true && first_turn == true)
                {
                    int kesigomu_num = 0;
                    Debug.Log("kesigomu");
                    playercontroller.Attack_damage += 20;//•¨—UŒ‚—Í20ã¸
                    playercontroller.Magic_damage -= kesigomu_num = playercontroller.Attack_damage / 2;//–‚–@UŒ‚—Í‚ğ•¨—UŒ‚—Í/‚Q•ªŒ¸‚ç‚·
                    Log_list.LogList.Add("@Á‚µƒSƒ€‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚Q‚O‘‰Á‚µA–‚–@UŒ‚—Í‚ª" + kesigomu_num + "‘‰Á‚µ‚½@\n");
                    adapt_kesigomu = false;
                }
            }
            if (TV_flag == true)
            {
                if (adapt_TV == true && first_turn == true)
                {
                    int TV_num = 0;
                    Debug.Log("TV");
                    playercontroller.Magic_damage += TV_num = (playercontroller.Magic_damage / 5) * 3;//–‚–@UŒ‚—Í‚T‚É‚Â‚«–‚–@UŒ‚—Í‚ğ‚Rã¸
                    Log_list.LogList.Add("@ƒeƒŒƒr‚ÌŒø‰Ê‚Å–‚–@UŒ‚—Í‚ª" + TV_num + "‘‰Á‚µ‚½@\n");
                    adapt_TV = false;
                }
            }
            if (CreditCard_flag == true)
            {
                if (adapt_CreditCard == true && first_turn == true)
                {
                    Debug.Log("CreditCard");
                    PlayerController.MONEY += 20;//í“¬ŠJnŒã‚Q‚OG“üè
                    Log_list.LogList.Add("@ƒNƒŒƒWƒbƒgƒJ[ƒh‚ÌŒø‰Ê‚Å‚¨‹à‚ğ‚Q‚O“üè‚µ‚½@\n");
                    adapt_CreditCard = false;
                }
            }
            if (Mouse_flag == true)
            {
                if (adapt_Mouse == true && first_turn == true)
                {
                    Debug.Log("Mouse");
                    playercontroller.Magic_damage += 10;//–‚–@UŒ‚—Í‚P‚Oã¸
                    Log_list.LogList.Add("@ƒ}ƒEƒX‚ÌŒø‰Ê‚Å–‚–@UŒ‚—Í‚ª‚P‚O‘‰Á‚µ‚½@\n");
                    adapt_Mouse = false;
                }
            }
            if (HandMirror_flag == true)
            {
                if (adapt_HandMirror == true && first_turn == true)
                {
                    Debug.Log("HandMirror");
                    playercontroller.Deffence += 10;//•¨—–hŒä—Í‚ğ‚P‚O‘‰Á
                    playercontroller.Magic_diffence += 10;//–‚–@–hŒä—Í‚ğ‚P‚O‘‰Á
                    Log_list.LogList.Add("@ƒnƒ“ƒhƒ~ƒ‰[‚ÌŒø‰Ê‚Å@•¨—–hŒä—Í‚Æ–‚–@–hŒä—Í‚ª‚P‚O‘‰Á‚µ‚½@\n");
                    adapt_HandMirror = false;
                }
            }
            if (baseball_ball_flag == true)
            {
                if (adapt_baseball_ball == true && first_turn == true)
                {
                    Debug.Log("baseball_ball");
                    playercontroller.Attack_damage += 15;//•¨—UŒ‚—Í‚ğ15‘‰Á
                    playercontroller.Deffence -= 10;//•¨—–hŒä—Í‚ğ10Œ¸­
                    Log_list.LogList.Add("@–ì‹…ƒ{[ƒ‹‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚P‚T‘‰Á‚µA•¨—–hŒä—Í‚ª‚P‚OŒ¸­‚µ‚½@\n");
                    adapt_baseball_ball = false;
                }
            }
            if (Waterbucket_flag == true)
            {
                if (adapt_Waterbucket == true && first_turn == true)
                {
                    Debug.Log("Waterbucket");
                    playercontroller.Magic_diffence += 10;//–‚–@–hŒä—Í‚ğ10‘‰Á
                    Log_list.LogList.Add("@…“ü‚è‚ÌƒoƒPƒc‚ÌŒø‰Ê‚Å–‚–@–hŒä—Í‚ª‚P‚O‘‰Á‚µ‚½@\n");
                    adapt_Waterbucket = false;
                }
            }
            if (Popcorn_flag == true)
            {
                if (adapt_Popcorn == true && first_turn == true)
                {
                    Debug.Log("Popcorn");
                    PlayerController.HP += 20;//‘Ì—Í‚ğ‚Q‚O‰ñ•œ
                    Log_list.LogList.Add("@ƒ|ƒbƒvƒR[ƒ“‚ÌŒø‰Ê‚Å‘Ì—Í‚ğ‚Q‚O‰ñ•œ‚µ‚½@\n");
                    adapt_Popcorn = false;
                }
            }
            if (Apple_flag == true)
            {
                if (adapt_Apple == true && first_turn == true)
                {
                    Debug.Log("Apple");
                    PlayerController.HP += 30;//‘Ì—Í‚ğ‚R‚O‰ñ•œ
                    playercontroller.Magic_damage += 15;//–‚–@UŒ‚—Í‚ğ‚P‚T‘‰Á
                    Log_list.LogList.Add("@ƒŠƒ“ƒS‚ÌŒø‰Ê‚Å‘Ì—Í‚ğ‚R‚O‰ñ•œ‚µA–‚–@UŒ‚—Í‚ª‚P‚T‘‰Á‚µ‚½@\n");
                    adapt_Apple = false;
                }
            }
            if (Scissors_flag == true)
            {
                if (adapt_Scissors == true && first_turn == true)
                {
                    Debug.Log("Scissors");
                    playercontroller.Attack_damage += 20;//•¨—UŒ‚—Í‚ğ‚Q‚O‘‰Á
                    Log_list.LogList.Add("@ƒnƒTƒ~‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚Q‚O‘‰Á‚µ‚½@\n");
                    adapt_Scissors = false;
                }
            }
            if (ice_flag == true)
            {
                if (adapt_ice == true && first_turn == true)
                {
                    Debug.Log("ice");
                    playercontroller.Magic_damage += 10;//–‚–@UŒ‚—Í‚ğ‚P‚O‘‰Á
                    Log_list.LogList.Add("@•X‚ÌŒø‰Ê‚Å–‚–@UŒ‚—Í‚ª‚P‚O‘‰Á‚µ‚½@\n");
                    adapt_ice = false;
                }
            }
            if (Pudding_flag == true)
            {
                if (Apple_flag == true && adapt_Pudding == true && first_turn == true)
                {
                    PlayerController.HP_MAX += 30;//Å‘å‘Ì—Í‚ğ‚R‚O‘‰Á
                    Log_list.LogList.Add("@ƒŠƒ“ƒS‚ÆƒvƒŠƒ“‚ÌŒø‰Ê‚ÅÅ‘å‘Ì—Í‚ª‚R‚O‘‰Á‚µ‚½@\n");
                    adapt_Pudding = false;
                }
                if (adapt_Pudding == true && first_turn == true)
                {
                    int Pudding_num;
                    Debug.Log("pudding");
                    PlayerController.HP += Pudding_num = PlayerController.HP_MAX / 4;//‘Ì—Í‚ğ‚P/‚S‰ñ•œ
                    Log_list.LogList.Add("@ƒvƒŠƒ“‚ÌŒø‰Ê‚Å‘Ì—Í‚ª" + Pudding_num + "‰ñ•œ‚µ‚½@\n");
                    adapt_Pudding = false;
                }
            }
            if (Drill_flag == true)
            {
                if (adapt_Drill == true && first_turn)
                {
                    int Drill_num;
                    //“G‚Ì–hŒä—Í‚Ì‚Q•ª‚Ì‚P‚Ì”’l‚ğ©g‚Ì•¨—UŒ‚—Í‚É‰ÁZ‚·‚é
                    playercontroller.Attack_damage += Drill_num = enemy_Controller.Enemy_deffence / 2;
                    Log_list.LogList.Add("@ƒhƒŠƒ‹‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª" + Drill_num + "‘‰Á‚µ‚½@\n");
                    adapt_Drill = false;
                }
            }
            if (UtypeMagnet_flag == true)
            {
                if (adapt_Utype_M == true && first_turn == true)
                {
                    Debug.Log("Utype");
                    playercontroller.Magic_damage += 20;//–‚–@UŒ‚—Í‚ğ‚Q‚O‘‰Á
                    Log_list.LogList.Add("@UšŒ^ƒ}ƒOƒlƒbƒg‚ÌŒø‰Ê‚Å–‚–@UŒ‚—Í‚ª‚Q‚O‘‰Á‚µ‚½@\n");
                    adapt_Utype_M = false;
                }
            }
            if (Coffee_flag == true)
            {
                if (adapt_Coffee == true && first_turn == true)
                {
                    Debug.Log("Coffe");
                    //‘Ì—Í‚ª‚Q‚O‚æ‚è‘å‚«‚©‚Á‚½ê‡
                    if (PlayerController.HP > 20)
                    {
                        PlayerController.HP -= 20;//‘Ì—Í‚ğ‚Q‚OŒ¸­‚³‚¹‚é
                        playercontroller.Magic_damage += 30;//–‚–@UŒ‚—Í‚ğ‚R‚O‘‰Á‚³‚¹‚é
                        Log_list.LogList.Add("@ƒR[ƒq[‚ÌŒø‰Ê‚Å–‚–@UŒ‚—Í‚ª‚R‚O‘‰Á‚µA‘Ì—Í‚ª‚Q‚OŒ¸­‚µ‚½@\n");
                    }
                    adapt_Coffee = false;
                }
            }
            if (Safetycone_flag == true)
            {
                if (adapt_SafetyCorn == true && first_turn == true)
                {
                    Debug.Log("safetycone");
                    safetycorn_random = Random.Range(1, 7);//‚P/‚U‚ÌŠm—¦
                    if (safetycorn_random < 6)
                    {
                        adapt_SafetyCorn = false;
                    }
                    else if (safetycorn_random == 6)
                    {
                        playercontroller.Attack_damage += 40;//•¨—UŒ‚—Í‚ğ‚S‚O‘‰Á‚³‚¹‚é
                        playercontroller.Deffence += 40;//•¨—–hŒä—Í‚ğ‚S‚O‘‰Á‚³‚¹‚é
                        Log_list.LogList.Add("@OŠpƒR[ƒ“‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚Æ•¨—–hŒä—Í‚ª‚S‚O‘‰Á‚µ‚½@\n");
                        adapt_SafetyCorn = false;
                    }
                }
            }
            if (USB_flag == true)
            {
                if (adapt_USB == true && first_turn == true)
                {
                    Debug.Log("USB");
                    playercontroller.Magic_damage += 20;//–‚–@UŒ‚—Í‚ğ‚Q‚O‘‰Á‚³‚¹‚é
                    playercontroller.Magic_diffence -= 10;//–‚–@–hŒä—Í‚ğ‚P‚OŒ¸­‚³‚¹‚é
                    Log_list.LogList.Add("@USB‚ÌŒø‰Ê‚Å–‚–@UŒ‚—Í‚ª‚Q‚O‘‰Á‚µA–‚–@–hŒä—Í‚ª‚P‚OŒ¸­‚µ‚½@\n");
                    adapt_USB = false;
                }
            }
            if (Smartphone_flag == true)
            {
                if (adapt_SmartPhone == true && first_turn == true)
                {
                    int SmartPhone_num;
                    Debug.Log("SmartPhone");
                    playercontroller.Magic_diffence += SmartPhone_num = playercontroller.Magic_damage / 4;//–‚–@–hŒä—Í‚ğ–‚–@UŒ‚—Í‚Ì‚P/‚S•ª‘‰Á‚³‚¹‚é
                    Log_list.LogList.Add("@ƒXƒ}[ƒgƒtƒHƒ“‚ÌŒø‰Ê‚Å–‚–@–hŒä—Í‚ª" + SmartPhone_num + "‘‰Á‚µ‚½@\n");
                    adapt_SmartPhone = false;
                }
            }
            if (ItypeMagnet_flag == true)
            {
                if (adapt_Itype_M == true && first_turn == true)
                {
                    Debug.Log("Itype");
                    playercontroller.Magic_diffence += 20;//–‚–@–hŒä—Í‚ğ‚Q‚O‘‰Á‚³‚¹‚é
                    Log_list.LogList.Add("@IšŒ^ƒ}ƒOƒlƒbƒg‚ÌŒø‰Ê‚Å–‚–@–hŒä—Í‚ª‚Q‚O‘‰Á‚µ‚½@\n");
                    adapt_Itype_M = false;
                }
            }
            if (Mike_flag == true)
            {
                if (adapt_Mike == true && first_turn == true)
                {
                    Debug.Log("Mike");
                    playercontroller.Magic_damage += 30;//–‚–@UŒ‚—Í‚ğ‚R‚O‘‰Á‚³‚¹‚é
                    Log_list.LogList.Add("@ƒ}ƒCƒN‚ÌŒø‰Ê‚Å–‚–@UŒ‚—Í‚ª‚R‚O‘‰Á‚µ‚½@\n");
                    adapt_Mike = false;
                }
            }
            if (Megaphone_flag == true)
            {
                if (adapt_Megaphone == true && first_turn == true)
                {
                    Debug.Log("Megaphone");
                    playercontroller.Deffence += 20;//•¨—–hŒä—Í‚ğ‚Q‚O‘‰Á‚³‚¹‚é
                    Log_list.LogList.Add("@ƒƒKƒzƒ“‚ÌŒø‰Ê‚Å•¨—–hŒä—Í‚ª‚Q‚O‘‰Á‚µ‚½@\n");
                    adapt_Megaphone = false;
                }
            }
            if (HandMill_flag == true)
            {
                //ƒR[ƒq[‚ğ‚Á‚Ä‚¢‚éê‡–‚–@UŒ‚—Í‚ğ‚U‚O‘‰Á
                if (adapt_HandMill == true && Coffee_flag == true && first_turn == true)
                {
                    playercontroller.Magic_damage += 60;
                    Log_list.LogList.Add("@ƒR[ƒq[‚Æƒnƒ“ƒhƒ~ƒ‹‚ÌŒø‰Ê‚Å–‚–@UŒ‚—Í‚ª‚U‚O‘‰Á‚µ‚½@\n");
                    adapt_HandMill = false;
                }
                else if (adapt_HandMill == true && first_turn == true)
                {
                    Debug.Log("HandMill");
                    playercontroller.Magic_damage -= 30;//–‚–@UŒ‚—Í‚ğ‚R‚OŒ¸­‚³‚¹‚é
                    Log_list.LogList.Add("@ƒnƒ“ƒhƒ~ƒ‹‚ÌŒø‰Ê‚Å–‚–@UŒ‚—Í‚ª‚R‚O‘‰Á‚µ‚½@\n");
                    adapt_HandMill = false;
                }
            }
            if (Poteto_flag == true)
            {
                //ƒnƒ“ƒo[ƒK[‚ğ‚Á‚Ä‚¢‚éê‡•¨—UŒ‚—Í‚ğ‚U‚O‘‰Á‚³‚¹‚é
                if (adapt_Poteto == true && Hamberger_flag == true && first_turn == true)
                {
                    playercontroller.Attack_damage += 60;
                    Log_list.LogList.Add("@@ƒ|ƒeƒg‚Æƒnƒ“ƒo[ƒK[‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚U‚O‘‰Á‚µ‚½@\n");
                    adapt_Poteto = false;
                }
                else if (adapt_Poteto == true && first_turn == true)
                {
                    Debug.Log("Poteto");
                    playercontroller.Attack_damage -= 30;//•¨—UŒ‚—Í‚ğ‚R‚OŒ¸­‚³‚¹‚é
                    Log_list.LogList.Add("@ƒ|ƒeƒg‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚R‚OŒ¸­‚µ‚½@\n");
                    adapt_Poteto = false;
                }
            }
            if (Scop_flag == true)
            {
                if (adapt_Scop == true && first_turn == true)
                {
                    Debug.Log("Scop");
                    scop_random = Random.Range(1, 5);//‚P/‚S‚ÌŠm—¦
                    if (scop_random == 4)
                    {
                        PlayerController.MONEY += 30;//Š‹àŠz‚ğ‚R‚O‘‰Á‚³‚¹‚é
                        Log_list.LogList.Add("@ƒXƒRƒbƒv‚ÌŒø‰Ê‚Å‚¨‹à‚ğ‚R‚O“üè‚µ‚½@\n");
                    }
                    adapt_Scop = false;
                }
            }
            if (Speaker_flag == true)
            {
                if (adapt_Speaker == true && first_turn == true)
                {
                    Debug.Log("Speaker");
                    enemy_Controller.Enemy_deffence -= 25;//“G‚Ì•¨—–hŒä—Í‚ğ‚Q‚TŒ¸­‚³‚¹‚é
                    Log_list.LogList.Add("@ƒXƒs[ƒJ[‚ÌŒø‰Ê‚Å•¨—–hŒä—Í‚ª‚Q‚TŒ¸­‚µ‚½@\n");
                    adapt_Speaker = false;
                }
            }
            if (Baseball_glove_flag == true)
            {
                //–ì‹…ƒ{[ƒ‹‚ğ‚Á‚Ä‚¢‚éê‡
                if (adapt_Baseball_glove == true && baseball_ball_flag == true && first_turn == true)
                {
                    playercontroller.Attack_damage += 25;//•¨—UŒ‚—Í‚ğ‚Q‚T‘‰Á
                    playercontroller.Deffence += 15;//•¨—–hŒä—Í‚ğ‚P‚T‘‰Á
                    Log_list.LogList.Add("@–ì‹…ƒ{[ƒ‹‚Æ–ì‹…ƒOƒ[ƒu‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚Q‚T‘‰Á‚µA•¨—–hŒä—Í‚ª‚P‚T‘‰Á‚µ‚½@\n");
                    adapt_Baseball_glove = false;
                }
                else if (adapt_Baseball_glove == true && first_turn == true)
                {
                    Debug.Log("Baseball_glove");
                    playercontroller.Attack_damage += 25;//•¨—UŒ‚—Í‚ğ‚Q‚T‘‰Á
                    Log_list.LogList.Add("@–ì‹…ƒOƒ[ƒu‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚Q‚T‘‰Á‚µ‚½@\n");
                    adapt_Baseball_glove = false;
                }
            }
            if (Boxing_glove_flag == true)
            {
                //ƒUƒ“ƒQƒLê’P‚ª‚¨‚³‚ê‚½‚Æ‚«A•¨—UŒ‚—Í‚ğ‚R‘‰Á‚³‚¹‚é
                if (adapt_Boxing_glove == true && first_turn == true)
                {
                    Debug.Log("Boxing_glove");
                    Boxing_flag = true;
                    adapt_Boxing_glove = false;
                    Log_list.LogList.Add("@ƒ{ƒNƒVƒ“ƒOƒOƒ[ƒu‚ÌŒø‰Ê‚ÅƒUƒ“ƒQƒL‚ğ‰Ÿ‚µ‚½‚Æ‚«‚É•¨—UŒ‚—Í‚ª‚R‘‰Á‚·‚é‚æ‚¤‚É‚È‚Á‚½@\n");
                }
            }
            if (Juice_flag == true)
            {
                if (adapt_Juice == true && first_turn == true)
                {
                    Debug.Log("Juice");
                    PlayerController.HP += 20;//‘Ì—Í‚ğ‚Q‚O‘‰Á‚³‚¹‚é
                    Log_list.LogList.Add("@ƒWƒ…[ƒX‚ÌŒø‰Ê‚Å‘Ì—Í‚ğ‚Q‚O‰ñ•œ‚µ‚½@\n");
                    adapt_Juice = false;
                }
            }
            if (Gas_burner_flag == true)
            {
                if (Enemy_controller.turn % 2 == 0 && turn_bool == true)
                {
                    Debug.Log("Gas_burner");
                    playercontroller.Attack_damage += 25;//•¨—UŒ‚—Í‚ğ‚Q‚T‘‰Á‚³‚¹‚é
                    Log_list.LogList.Add("@ƒKƒXƒo[ƒi[‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚Q‚T‘‰Á‚µ‚½@\n");
                    turn_bool = false;
                }
                else if (Enemy_controller.turn != 1 && Enemy_controller.turn % 2 != 0 && turn_bool == true)
                {
                    playercontroller.Attack_damage -= 25;//•¨—UŒ‚—Í‚ğ‚Q‚TŒ¸­‚³‚¹‚é
                    Log_list.LogList.Add("@ƒKƒXƒo[ƒi[‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚Q‚TŒ¸­‚µ‚½@\n");
                    turn_bool = false;
                }
            }
            if (Hamberger_flag == true)
            {
                //ƒ|ƒeƒg‚ğ‚Á‚Ä‚¢‚½ê‡
                if (adapt_Hamberger == true && Poteto_flag == true && first_turn == true)
                {
                    Debug.Log("Hamberger");
                    playercontroller.Attack_damage += 40;//•¨—UŒ‚—Í‚ğ‚S‚O‘‰Á‚³‚¹‚é
                    Log_list.LogList.Add("@ƒnƒ“ƒo[ƒK[‚Æƒ|ƒeƒg‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚S‚O‘‰Á‚µ‚½@\n");
                    adapt_Hamberger = false;
                }
                else if (adapt_Hamberger == true && first_turn == true)
                {
                    Debug.Log("Hamberger");
                    playercontroller.Attack_damage += 20;//•¨—UŒ‚—Í‚ğ‚Q‚O‘‰Á‚³‚¹‚é
                    Log_list.LogList.Add("@ƒnƒ“ƒo[ƒK[‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚Q‚O‘‰Á‚µ‚½@\n");
                    adapt_Hamberger = false;
                }
            }
            if (Pencil_flag == true)
            {
                //í“¬ŠJn‚ÌŒø‰Ê
                if (adapt_Pencil == true && first_turn == true)
                {
                    Debug.Log("Pencil");
                    playercontroller.Attack_damage += 50;//•¨—UŒ‚—Í‚ğ‚T‚O‘‰Á‚³‚¹‚é
                    Log_list.LogList.Add("@‰”•M‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚T‚O‘‰Á‚µ‚½@\n");
                    adapt_Pencil = false;
                }
            }
            if (Mayonnaise_flag == true)
            {
                if (adapt_Mayonnaise == true && first_turn == true)
                {
                    Debug.Log("Mayonnaise");
                    playercontroller.Magic_damage += 50;//–‚–@UŒ‚—Í‚ğ‚T‚O‘‰Á‚³‚¹‚é
                    Log_list.LogList.Add("@ƒ}ƒˆƒl[ƒY‚ÌŒø‰Ê‚Å–‚–@UŒ‚—Í‚ª‚T‚O‘‰Á‚µ‚½@\n");
                    adapt_Mayonnaise = false;
                }
            }
            if (TheGrimReaper_Scythe_flag == true)
            {
                if (adapt_TheGrimReaper_scythe == true && first_turn == true)
                {
                    Debug.Log("Scythe");
                    playercontroller.Attack_damage += 40;//•¨—UŒ‚—Í‚ğ‚S‚O‘‰Á‚³‚¹‚é
                    PlayerController.MAX_LUCK -= 3;//ƒNƒŠƒeƒBƒJƒ‹”­¶Šm—¦‚ğ3‘‰Á
                    Sinigami_Crit_Effect = true;//€_‚ÌƒNƒŠƒeƒBƒJƒ‹ƒGƒtƒFƒNƒg”­¶
                    Log_list.LogList.Add("@€_‚ÌŠ™‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚S‚O‘‰Á‚µAƒNƒŠƒeƒBƒJƒ‹‚ª”­¶‚µ‚â‚·‚­‚È‚Á‚½@\n");
                    adapt_TheGrimReaper_scythe = false;
                }
            }
            if (Sinigami_Robe_flag == true)
            {
                if (adapt_TheGrimReaper_robe == true && first_turn == true)
                {
                    Debug.Log("Robe");
                    playercontroller.Deffence += 40;//•¨—–hŒä—Í‚ğ40‘‰Á
                    PlayerController.MAX_LUCK -= 3;//ƒNƒŠƒeƒBƒJƒ‹”­¶Šm—¦‚ğ3‘‰Á
                    Log_list.LogList.Add("@€_‚Ìƒ[ƒu‚ÌŒø‰Ê‚Å•¨—–hŒä—Í‚ª‚S‚O‘‰Á‚µAƒNƒŠƒeƒBƒJƒ‹‚ª”­¶‚µ‚â‚·‚­‚È‚Á‚½@\n");
                    adapt_TheGrimReaper_robe = false;
                }
            }
            if (Medhusa_Eye_flag == true)
            {
                if (adapt_Medhusa_Eye == true && first_turn == true)
                {
                    Debug.Log("Eye");
                    playercontroller.Magic_diffence += 40;//–‚–@b–hŒä—Í‚ğ‚S‚O‘‰Á‚³‚¹‚é
                    PlayerController.MAX_LUCK -= 3;//ƒNƒŠƒeƒBƒJƒ‹”­¶Šm—¦‚ğ3‘‰Á
                    Log_list.LogList.Add("@ƒƒfƒ…[ƒT‚Ì–Ú‚ÌŒø‰Ê‚Å–‚–@–hŒä—Í‚ª‚S‚O‘‰Á‚µAƒNƒŠƒeƒBƒJƒ‹‚ª”­¶‚µ‚â‚·‚­‚È‚Á‚½@\n");
                    adapt_Medhusa_Eye = false;
                }
            }
            if (Medhusa_MagicBook_flag == true)
            {
                if (adapt_Medhusa_MagicBook == true && first_turn == true)
                {
                    Debug.Log("Magic_Book");
                    playercontroller.Magic_damage += 40;//–‚–@UŒ‚—Í‚ğ40‘‰Á‚³‚¹‚é
                    PlayerController.MAX_LUCK -= 3;//ƒNƒŠƒeƒBƒJƒ‹”­¶Šm—¦‚ğ3‘‰Á
                    Log_list.LogList.Add("@ƒƒfƒ…[ƒT‚Ì–‚“±‘‚ÌŒø‰Ê‚Å–‚–@UŒ‚—Í‚ª‚S‚O‘‰Á‚µAƒNƒŠƒeƒBƒJƒ‹‚ª”­¶‚µ‚â‚·‚­‚È‚Á‚½@\n");
                    Medhusa_Magic_flag = true;
                    adapt_Medhusa_MagicBook = false;
                }
            }
            if (Dragon_Tooth_flag == true)
            {
                if (adapt_Dragon_Tooth = true && first_turn == true)
                {
                    Debug.Log("Tooth");
                    playercontroller.Attack_damage += 100;//•¨—UŒ‚—Í‚ğ100‘‰Á
                    PlayerController.HP_MAX += 50;//Å‘å‘Ì—Í‚ğ50’Ç‰Á
                    Log_list.LogList.Add("@ƒhƒ‰ƒSƒ“‚Ì‰å‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚P‚O‚O‘‰Á‚µAÅ‘å‘Ì—Í‚ª‚T‚O‘‰Á‚µ‚½@\n");
                    adapt_Dragon_Tooth = false;
                }
            }
            if (bowlingpin_flag == true)
            {
                //Œø‰Ê‚Ì“à—e“I‚Éˆê”Ô‰º
                if (adapt_bowlingpin == true && first_turn == true)
                {
                    int bowlingpin_num = 0;
                    Debug.Log("bowlingpin");
                    PlayerController.MONEY += bowlingpin_num = playercontroller.Attack_damage / 6;//Š‹àŠz‚ğ•¨—UŒ‚—Í‚Ì‚P/‚U•ª‘‰Á‚³‚¹‚é
                    Log_list.LogList.Add("@ƒ{ƒEƒŠƒ“ƒO‚Ìƒsƒ“‚ÌŒø‰Ê‚ÅŠ‹àŠz‚ğ" + bowlingpin_num + "“üè‚µ‚½@\n");
                    adapt_bowlingpin = false;
                }
            }
            first_turn = false;




            if (radio_flag == true)
            {
                if (PlayerController.HP > 11)
                {
                    Debug.Log("radio");
                    playercontroller.Deffence += 10;//–ˆƒ^[ƒ“–hŒä—Í10ã¸
                    PlayerController.HP -= 5;//‘Ì—Í‚ğ5Œ¸‚ç‚·
                    log_text.text = "ƒ‰ƒWƒI‚ÌŒø‰Ê‚Å‘Ì—Í‚ª‚TŒ¸‚Á‚½";
                    Log_list.LogList.Add("@ƒ‰ƒWƒI‚ÌŒø‰Ê‚Å‘Ì—Í‚ª‚TŒ¸‚Á‚½\n");//ƒƒOƒŠƒXƒg‚É’Ç‰Á
                }
                else
                {
                    log_text.text = "ƒ‰ƒWƒI‚ÌŒø‰Ê‚Í”­“®‚µ‚È‚©‚Á‚½";
                    Log_list.LogList.Add("@ƒ‰ƒWƒI‚ÌŒø‰Ê‚Í”­“®‚µ‚È‚©‚Á‚½\n");//ƒƒOƒŠƒXƒg‚É’Ç‰Á
                }
            }
            if (hourglass_flag == true)
            {
                if (PlayerController.HP >11)
                {
                    Debug.Log("hourglass");
                    playercontroller.Attack_damage += 10;//–ˆƒ^[ƒ“UŒ‚—Í10ã¸
                    PlayerController.HP -= 5;//‘Ì—Í‚ğ5Œ¸‚ç‚·
                    log_text.text = "»Œv‚ÌŒø‰Ê‚Å‘Ì—Í‚ª‚TŒ¸‚Á‚½";
                    Log_list.LogList.Add("@»Œv‚ÌŒø‰Ê‚Å‘Ì—Í‚ª‚TŒ¸‚Á‚½\n");//ƒƒOƒŠƒXƒg‚É’Ç‰Á
                }
                else
                {
                    log_text.text = "»Œv‚ÌŒø‰Ê‚Í”­“®‚µ‚È‚©‚Á‚½";
                    Log_list.LogList.Add("@»Œv‚ÌŒø‰Ê‚Í”­“®‚µ‚È‚©‚Á‚½\n");//ƒƒOƒŠƒXƒg‚É’Ç‰Á
                }
            }
            if (dice_flag == true)
            {
                Debug.Log("dice");
                dice_random = Random.Range(1, 7);
                switch (dice_random)
                {
                    case 1: playercontroller.Attack_damage += 10; Log_list.LogList.Add("@ƒ_ƒCƒX‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚P‚Oã¸‚µ‚½\n"); break;//•¨—UŒ‚—Í‚ğ‚P‚O‘‰Á
                    case 2: playercontroller.Attack_damage -= 10; Log_list.LogList.Add("@ƒ_ƒCƒX‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚P‚OŒ¸­‚µ‚½\n"); break;//•¨—UŒ‚—Í‚ğ‚P‚OŒ¸­
                    case 3: playercontroller.Magic_damage += 10; Log_list.LogList.Add("@ƒ_ƒCƒX‚ÌŒø‰Ê‚Å–‚–@UŒ‚—Í‚ª‚P‚Oã¸‚µ‚½\n"); break;//–‚–@UŒ‚—Í‚ğ‚P‚O‘‰Á
                    case 4: playercontroller.Magic_damage -= 10; Log_list.LogList.Add("@ƒ_ƒCƒX‚ÌŒø‰Ê‚Å–‚–@UŒ‚—Í‚ª‚P‚OŒ¸­‚µ‚½\n"); break;//–‚–@UŒ‚—Í‚ğ‚P‚OŒ¸­
                    case 5: PlayerController.MONEY += 5; Log_list.LogList.Add("@ƒ_ƒCƒX‚ÌŒø‰Ê‚Å‚¨‹à‚ğ‚T‚f“üè‚µ‚½\n"); break;//Š‹àŠz‚ğ‚T‘‰Á‚³‚¹‚é
                    case 6: dice_crit = true; Log_list.LogList.Add("@ƒ_ƒCƒX‚ÌŒø‰Ê‚ÅƒNƒŠƒeƒBƒJƒ‹‚ª”­¶‚µ‚â‚·‚­‚È‚Á‚½\n"); break;//ƒNƒŠƒeƒBƒJƒ‹”­¶
                }
            }
            if (Scissors_flag == true)
            {
                Debug.Log("Scissors");
                Log_list.LogList.Add("@ƒnƒTƒ~‚ÌŒø‰Ê‚Å•¨—–hŒä—Í‚ª‚QŒ¸­‚µ‚½\n");
                playercontroller.Deffence -= 2;//•¨—–hŒä—Í‚ğ‚QŒ¸­‚³‚¹‚é
            }
            if (Headphone_flag)
            {
                Debug.Log("Headphone");
                if (playercontroller.Attack_damage <= 3 || playercontroller.Deffence <= 3)
                {
                    log_text.text = "ƒwƒbƒhƒzƒ“‚ÌŒø‰Ê‚Í”­“®‚µ‚È‚©‚Á‚½";
                    Log_list.LogList.Add("@ƒwƒbƒhƒzƒ“‚ÌŒø‰Ê‚Í”­“®‚µ‚È‚©‚Á‚½\n");//ƒƒOƒŠƒXƒg‚É’Ç‰Á
                }
                else
                {
                    Log_list.LogList.Add("@ƒwƒbƒhƒzƒ“‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚Æ•¨—–hŒä—Í‚ª‚RŒ¸­‚µ‚½\n");
                    playercontroller.Attack_damage -= 3;//•¨—UŒ‚—Í‚ğ‚RŒ¸­‚³‚¹‚é
                    playercontroller.Deffence -= 3;//•¨—–hŒä—Í‚ğ‚RŒ¸­‚³‚¹‚é
                    Log_list.LogList.Add("@ƒwƒbƒhƒzƒ“‚ÌŒø‰Ê‚Å‘Ì—Í‚ª‚P‚O‰ñ•œ‚µ‚½\n");
                    PlayerController.HP += 10;//‘Ì—Í‚ğ‚P‚O‰ñ•œ‚³‚¹‚é
                }
            }
            if (MagnifyingSpeculum_flag == true)
            {
                Debug.Log("Magnifying");
                Log_list.LogList.Add("@’Šá‹¾‚ÌŒø‰Ê‚Å•¨—–hŒä—Í‚Æ–‚–@–hŒä—Í‚ª‚R‘‰Á‚µ‚½\n");
                playercontroller.Deffence += 3;//•¨—–hŒä—Í‚ğ‚R‘‰Á‚³‚¹‚é
                playercontroller.Magic_diffence += 3;//–‚–@–hŒä—Í‚ğ‚R‘‰Á‚³‚¹‚é
            }
            if (hammer_flag == true)
            {
                Debug.Log("hammer");
                hammer_random = Random.Range(1, 11);//‚P/‚P‚O‚ÌŠm—¦
                if (hammer_random == 10)
                {
                    //“G‚ğ‹Câ‚³‚¹‚é
                    Enemy_controller.Stun_turn = true;
                    Log_list.LogList.Add("@ƒnƒ“ƒ}[‚ÌŒø‰Ê‚Å“G‚ªƒXƒ^ƒ“‚µ‚½\n");
                    status_.Status_Effect(false, 4);//‹CâƒGƒtƒFƒNƒg
                }
            }
            if (Sylinge_flag == true)
            {
                Debug.Log("Sylinge");
                sylinge_random = Random.Range(1, 7);//‚P/‚U‚ÌŠm—¦
                if (sylinge_random == 6)
                {
                    Log_list.LogList.Add("@’ËŠí‚ÌŒø‰Ê‚Å‘Ì—Í‚ª‚R‚O‰ñ•œ‚µ‚½\n");
                    PlayerController.HP += 30;//‘Ì—Í‚ğ‚R‚O‰ñ•œ‚³‚¹‚é
                }
                else
                {
                    Log_list.LogList.Add("@’ËŠí‚ÌŒø‰Ê‚Å‘Ì—Í‚ª‚T‰ñ•œ‚µ‚½\n");
                    PlayerController.HP += 5;//‘Ì—Í‚ğ‚T‰ñ•œ‚³‚¹‚é
                }
            }
            if (Pencil_flag == true)
            {
                Debug.Log("Pencil");
                //‚P‚Oƒ^[ƒ“‚ÌŠÔ
                if (Pencil_Down_cnt <= 10)
                {
                    Log_list.LogList.Add("@‰”•M‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª‚TŒ¸­‚µ‚½(‚ ‚Æ\n");
                    playercontroller.Attack_damage -= 5;//•¨—UŒ‚—Í‚ğ‚TŒ¸­‚³‚¹‚é
                    Pencil_Down_cnt++;
                }
            }
            if (Mayonnaise_flag == true)
            {
                Debug.Log("Mayonnaise");
                //‚P‚Oƒ^[ƒ“‚ÌŠÔ
                if (Pencil_Down_cnt <= 10)
                {
                    Log_list.LogList.Add("@ƒ}ƒˆƒl[ƒY‚ÌŒø‰Ê‚Å–‚–@UŒ‚—Í‚ª‚TŒ¸­‚µ‚½\n");
                    playercontroller.Magic_damage -= 5;//–‚–@UŒ‚—Í‚ğ‚TŒ¸­
                    Pencil_Down_cnt++;
                }
            }
            if (Watch_flag == true)
            {
                Debug.Log("Watch");
                if (Watch_Add_reset == true)
                {
                    //•¨—UŒ‚—Í
                    Log_list.LogList.Add("@˜rŒv‚ÌŒø‰Ê‚Å•¨—UŒ‚—Í‚ª"+ (PlayerController.HP_MAX - PlayerController.HP) +"ã¸‚µ‚½\n");
                    playercontroller.Attack_damage += PlayerController.HP_MAX - PlayerController.HP;
                    Watch_Add_reset = false;
                }
            }
            if (Dragon_Scale_flag == true)
            {
                Debug.Log("Dragon_Scale");
                Log_list.LogList.Add("@ƒhƒ‰ƒSƒ“‚Ì—Ø‚ÌŒø‰Ê‚Å‘SƒXƒe[ƒ^ƒX‚ª‚P‚Oã¸‚µ‚½\n");
                playercontroller.Attack_damage += 10;//•¨—UŒ‚—Í‚ğ‚P‚O‘‰Á
                playercontroller.Deffence += 10;//•¨—–hŒä—Ê‚ğ‚P‚O‘‰Á
                playercontroller.Magic_damage += 10;//–‚–@UŒ‚—Í‚ğ‚P‚O‘‰Á
                playercontroller.Magic_diffence += 10;//–‚–@–hŒä—Í‚ğ‚P‚O‘‰Á
            }
            Log_list.LogList.Add("--------------------------------------------------------------@\n");
            turn_compare = Enemy_controller.turn;
        }
    }
}