using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;//切り替えるシーンの名前を入れる
    public Shop_manager shop;
    public static bool Scene_Change = false;
    public static int Boss_Number = 0;
    public static int scene_cnt = 1;//最初のシーンがcase :1
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
        ////遅延
        //Invoke("DelayMethod", 8000.0f);
        Scene_Change = true;
      

    }
    public void shop_change()
    {
        //shopに戻る時用
        if (Scene_Change == true)
        {
            Debug.Log("shop移行" + Scene_Change);
            SceneManager.LoadScene("shop");
            Scene_Change = false;
        }
    }
    public void add_scene_num()
    {
        //シーンナンバー加算
        scene_cnt++;
    }
    public void Work_Cange_Scene()
    {
        
        switch (scene_cnt)
        {
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
        Debug.Log("現在のシーン" + scene_cnt);
        if(Scene_Change == false)
        {
            //バトルシーン(case: 3,6,9のときはボスシーン)
            switch (scene_cnt)
            {
                case 1: SceneManager.LoadScene("Battle"); break;//バトル１
                case 2: SceneManager.LoadScene("Battle_2"); break;//バトル２
                case 3: SceneManager.LoadScene("Boss_Battle_01"); break;//死神 バトル３
                case 4: SceneManager.LoadScene("Battle_4"); break;//バトル４
                case 5: SceneManager.LoadScene("Battle_5"); break;//バトル５
                case 6: SceneManager.LoadScene("Boss_Battle_02"); break;//メデューサ バトル６
                case 7: SceneManager.LoadScene("Battle_7"); break;//バトル７
                case 8: SceneManager.LoadScene("Battle_8"); break;//バトル８
                case 9: SceneManager.LoadScene("Boss_Battle_03"); break;//ドラゴン バトル９
            }
        }
    }
    //shopからtitleに戻る時に使用
    public void Player_Reset()
    {
        PlayerController.HP = PlayerController.HP_max;
        Item_Manager.Item["healdrink"] = false;
        Item_Manager.Item["bowlingball"] = false;
        Item_Manager.Item["CDplayer"] = false;
        Item_Manager.Item["cd"] = false;
        Item_Manager.Item["radio"] = false;
        Item_Manager.Item["hourglass"] = false;
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
}