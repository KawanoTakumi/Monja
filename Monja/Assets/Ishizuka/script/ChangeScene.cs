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

    public void Enemy_Change_Scene()
    {
        Debug.Log("現在のシーン" + scene_cnt);
        if(Scene_Change == false)
        {
            //バトルシーン(case: 3,6,9のときはボスシーン)
            switch (scene_cnt)
            {
                default: SceneManager.LoadScene("Battle"); break;//基本時なシーン
                case 1: SceneManager.LoadScene("Battle"); break;//バトル１
                case 2: SceneManager.LoadScene("Battle"); break;//バトル２
                case 3: SceneManager.LoadScene("Boss_Battle_01"); break;//死神 バトル３
                case 4: SceneManager.LoadScene("Battle"); break;//バトル４
                case 5: SceneManager.LoadScene("Battle"); break;//バトル５
                case 6: SceneManager.LoadScene("Boss_Battle_02"); break;//メデューサ バトル６
                case 7: SceneManager.LoadScene("Battle"); break;//バトル７
                case 8: SceneManager.LoadScene("Battle"); break;//バトル８
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
}