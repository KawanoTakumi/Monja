using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;//切り替えるシーンの名前を入れる
    public Shop_manager shop;
    public static bool SceneChange = false;
    public static int BossNumber = 0;
    public static int scene_cnt  = 0;
    public enum Scene
    {
        Title          = 0,
        Battle         = 1,
        Battle_2       = 2,
        Boss_Battle_01 = 3,
        Battle_4       = 4,
        Battle_5       = 5,
        Boss_Battle_02 = 6,
        Battle_7       = 7,
        Battle_8       = 8,
        Boss_Battle_03 = 9
    }
    Scene scene = Scene.Title;
    void Start()
    {
        Debug.Log(scene);
        shop = GetComponent<Shop_manager>();
    }
    //ロードシーンを読み込む
    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
    //change_sceneを読み込む
    public void change_scene()
    {
        //shop_changeを有効にする
        SceneChange = true;
    }
    //ショップに戻る時の関数
    public void shop_change()
    {
        //shopに戻る時用
        if (SceneChange == true)
        {
            SceneManager.LoadScene("shop");
            SceneChange = false;
        }
    }
    //シーンカウント増加関数
    public void add_scene_num()
    {
        //シーンナンバー加算
        scene_cnt++;
        scene++;
    }
    //シーンカウントリセット関数
    public void reset_scene_num()
    {
        scene = Scene.Title;
    }
    //最初のターン経過取得フラグ
    public void first_turn_flag()
    {
        Item_Power.first_turn = false;
    }
    //workシーン変更関数
    public void Work_Cange_Scene()
    {
        //各シーンカウントで移動シーンを変更
        switch (scene_cnt)
        {
            case (int)Scene.Title: SceneManager.LoadScene("Title"); break;                //タイトル
            case (int)Scene.Battle:   case (int)Scene.Battle_2: case (int)Scene.Boss_Battle_01: SceneManager.LoadScene("work_01"); break;//歩行シーン1
            case (int)Scene.Battle_4: case (int)Scene.Battle_5: case (int)Scene.Boss_Battle_02: SceneManager.LoadScene("work_02"); break;//歩行シーン2
            case (int)Scene.Battle_7: case (int)Scene.Battle_8: case (int)Scene.Boss_Battle_03: SceneManager.LoadScene("work_03"); break;//歩行シーン3
        }
    }
    //戦闘シーンをscene_cntに基づいて変更
    public void Enemy_Change_Scene()
    {
        if (SceneChange == false)
        {
            //バトルシーン(case: 3,6,9のときはボスシーン)
            switch (scene_cnt)
            {
                case (int)Scene.Title:          SceneManager.LoadScene("Title");          break; //タイトル
                case (int)Scene.Battle:         SceneManager.LoadScene("Battle");         break; //スケルトン　  バトル１
                case (int)Scene.Battle_2:       SceneManager.LoadScene("Battle_2");       break; //リッチ　      バトル２
                case (int)Scene.Boss_Battle_01: SceneManager.LoadScene("Boss_Battle_01"); break; //死神　        バトル３
                case (int)Scene.Battle_4:       SceneManager.LoadScene("Battle_4");       break; //ミノタウロス　バトル４
                case (int)Scene.Battle_5:       SceneManager.LoadScene("Battle_5");       break; //ケンタウロス　バトル５
                case (int)Scene.Boss_Battle_02: SceneManager.LoadScene("Boss_Battle_02"); break; //メデューサ    バトル６
                case (int)Scene.Battle_7:       SceneManager.LoadScene("Battle_7");       break; //コカトリス　  バトル７
                case (int)Scene.Battle_8:       SceneManager.LoadScene("Battle_8");       break; //ナイト　      バトル８
                case (int)Scene.Boss_Battle_03: SceneManager.LoadScene("Boss_Battle_03"); break; //ドラゴン      バトル９
            }
        }
    }
    //titleに戻る時に使用
    //アイテムとHPとシーンカウントをリセット
    public void Player_Reset()
    {
        PlayerController.HP = PlayerController.HP_MAX;
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
        Item_Manager.Item["Poteto"] = false;
        Item_Manager.Item["Scop"] = false;
        Item_Manager.Item["hammer"] = false;
        Item_Manager.Item["Speaker"] = false;
        Item_Manager.Item["Sylinge"] = false;
        Item_Manager.Item["Baseball_glove"] = false;
        Item_Manager.Item["Juice"] = false;
        Item_Manager.Item["Boxing_glove"] = false;
        Item_Manager.Item["Gas_burner"] = false;
        Item_Manager.Item["Hamberger"] = false;
        Item_Manager.Item["Pencil"] = false;
        Item_Manager.Item["Mayonnaise"] = false;
        Item_Manager.Item["Watch"] = false;
        Item_Manager.Item["Scythe"] = false;
        Item_Manager.Item["Robe"] = false;
        Item_Manager.Item["Scale"] = false;
        Item_Manager.Item["MagicBook"] = false;
        Item_Manager.Item["Eye"] = false;
        Item_Manager.Item["Tooth"] = false;

        scene_cnt = 0;
    }
    //shopシーンのアイテム表示をリセット
    public void Item_num_Reset()
    {
        Shop_manager.tmp_1 = -1;
        Shop_manager.tmp_2 = -1;
        Shop_manager.tmp_3 = -1;
    }
    //shop移行
    public void shop_go()
    {
        SceneManager.LoadScene("shop");
    }
    //shopから移動
    public void back_shop()
    {
        SceneManager.LoadScene("shop_back");
    }
    //数値初期化
    public static void Title_Reset()
    {
        PlayerController.HP = PlayerController.HP_MAX;
        PlayerController.MP = PlayerController.MP_MAX;
        PlayerController.MAGIC_TYPE = 0;
        PlayerController.MONEY = 0;
        PlayerController.Status_Reset();
        PlayerController.Item_Reset();
        //各種数値を初期化
        Item_Power.turn_compare = 0;
        Item_Power.first_turn = true;
        Item_Power.Boxing_flag = false;
        Enemy_controller.turn = 0;
        Enemy_controller.HP = Enemy_controller.HP_MAX;
        Enemy_controller.tag_get = true;
    }
    //リトライした時数値を変更
    public void Retry_Num_Tmp()
    {
        switch (scene_cnt)
        {
            case (int)Scene.Battle:   case (int)Scene.Battle_2: case (int)Scene.Boss_Battle_01: scene = Scene.Battle; break;
            case (int)Scene.Battle_4: case (int)Scene.Battle_5: case (int)Scene.Boss_Battle_02: scene = Scene.Battle_4; break;
            case (int)Scene.Battle_7: case (int)Scene.Battle_8: case (int)Scene.Boss_Battle_03: scene = Scene.Battle_7; break;
        }
    }
}