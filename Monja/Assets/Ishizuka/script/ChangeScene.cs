using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;//切り替えるシーンの名前を入れる
    public Shop_manager shop;
    public static bool Scene_Change = false;
    public static int Boss_Number = 0;
    public static int scene_cnt = 0;

    public void Start()
    {
        shop = GetComponent<Shop_manager>();
        
    } 
    //シーンを読み込む
    public void Load()
    {
            SceneManager.LoadScene(sceneName);
    }

    public void change_scene()
    {
        Scene_Change = true;
    }
    public void shop_change()
    {
        //shopに戻る時用
        if (Scene_Change == true)
        {
            SceneManager.LoadScene("shop");
            Scene_Change = false;
        }
    }
    public void add_scene_num()
    {
        //シーンナンバー加算
        scene_cnt++;
    }
    public void reset_scene_num()
    {
        scene_cnt = 0;
    }
    public void first_turn_flag()
    {
        Item_Power.first_turn = false;
    }
    public void Work_Cange_Scene()
    {
        
        switch (scene_cnt)
        {
            case 0: SceneManager.LoadScene("Title"); break;           //タイトル
            case 1: SceneManager.LoadScene("work_01"); break;
            case 2: SceneManager.LoadScene("work_01"); break;
            case 3: SceneManager.LoadScene("work_01"); break;
            case 4: SceneManager.LoadScene("work_02"); break;
            case 5: SceneManager.LoadScene("work_02"); break;
            case 6: SceneManager.LoadScene("work_02"); break;
            case 7: SceneManager.LoadScene("work_03"); break;
            case 8: SceneManager.LoadScene("work_03"); break;
            case 9: SceneManager.LoadScene("work_03"); break;

        }
    }
    public void Enemy_Change_Scene()
    {
        if(Scene_Change == false)
        {
            //バトルシーン(case: 3,6,9のときはボスシーン)
            switch (scene_cnt)
            {
                case 0: SceneManager.LoadScene("Title");break;           //タイトル
                case 1: SceneManager.LoadScene("Battle"); break;         //スケルトン　  バトル１
                case 2: SceneManager.LoadScene("Battle_2"); break;       //リッチ　      バトル２
                case 3: SceneManager.LoadScene("Boss_Battle_01"); break; //死神　        バトル３
                case 4: SceneManager.LoadScene("Battle_4"); break;       //ミノタウロス　バトル４
                case 5: SceneManager.LoadScene("Battle_5"); break;       //ケンタウロス　バトル５
                case 6: SceneManager.LoadScene("Boss_Battle_02"); break; //メデューサ    バトル６
                case 7: SceneManager.LoadScene("Battle_7"); break;       //コカトリス　  バトル７
                case 8: SceneManager.LoadScene("Battle_8"); break;       //ナイト　      バトル８
                case 9: SceneManager.LoadScene("Boss_Battle_03"); break; //ドラゴン      バトル９
            }
        }
    }
    //titleに戻る時に使用
    public void Player_Reset()
    {
        PlayerController.HP = PlayerController.HP_max;
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
        Item_Manager.Item["Scissors"] = false;
        Item_Manager.Item["ice"] = false;
        Item_Manager.Item["Pudding"] = false;
        Item_Manager.Item["Drill"] = false;
        Item_Manager.Item["Headphone"] = false;
        Item_Manager.Item["Coffee"] = false;
        Item_Manager.Item["Safetycone"] = false;
        Item_Manager.Item["USB"] = false;
        Item_Manager.Item["UtypeMagnet"] = false;
        Item_Manager.Item["Smartphone"] = false;
        Item_Manager.Item["ItypeMagnet"] = false;
        Item_Manager.Item["Magnifying Speculum"] = false;
        Item_Manager.Item["Mike"] = false;
        Item_Manager.Item["Megaphone"] = false;
        Item_Manager.Item["HandMill"] = false;
        scene_cnt = 0;
    }

    public void Item_num_Recet()
    {
        Shop_manager.tmp_1 = -1;
        Shop_manager.tmp_2 = -1;
        Shop_manager.tmp_3 = -1;
    }
    public void shop_go()
    {
        SceneManager.LoadScene("shop");
    }
    public void back_shop()
    {
        SceneManager.LoadScene("shop_back");
    }
    public static void Title_Reset()
    {
        PlayerController.HP = PlayerController.HP_max;
        PlayerController.MP = PlayerController.MP_max;
        PlayerController.magic_number = 0;
        PlayerController.Money = 0;
        PlayerController.Status_reset();
        PlayerController.Item_Reset();
        //各種数値を初期化
        Item_Power.turn_compare = 0;
        Item_Power.first_turn = true;
        Enemy_controller.turn = 0;
        Enemy_controller.HP = 150;
        Enemy_controller.tag_get = true;
    }
}