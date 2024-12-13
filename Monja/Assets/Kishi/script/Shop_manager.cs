using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Shop_manager: MonoBehaviour
{
    // オブジェクトを生成する元となるPrefabへの参照を保持します。
    public GameObject[] prefab;
    int number1;
    int number2;
    int number3;
    GameObject obj1;
    GameObject obj2;
    GameObject obj3;
    public bool item_flag;
    public Item_Library Item_Library;
    public Button button1;
    public Button button2;
    public Button button3;
    public static int shop_min = 1;
    public static int shop_max = 2;
    public static int tmp_1 = -1;
    public static int tmp_2 = -1;
    public static int tmp_3 = -1;
    public Text text;
    [SerializeField] GameObject _parentGameObject;

    void Start()
    {
        shop_select();
    }

    public void Update()
    {
        //アイテムライブラリのGetFlagがtrueの時DictionalyのItem.valueをtrueにする
        if (Item_Library.GetFlag1 == true)
        {
            Item_Manager.Item[button1.tag] = true;
        }
    
        if (Item_Library.GetFlag2 == true)
        {
            Item_Manager.Item[button2.tag] = true;
        }
   
        if (Item_Library.GetFlag3 == true)
        {
            Item_Manager.Item[button3.tag] = true;
        }


        Item_Manager.Item.TryGetValue(button1.tag, out bool flag_1);
        Item_Manager.Item.TryGetValue(button2.tag, out bool flag_2);
        Item_Manager.Item.TryGetValue(button3.tag, out bool flag_3);

        if (flag_1 == true && button1.interactable == true)
        {
            button1.interactable = false;
        }

        if (flag_2 == true && button2.interactable == true)
        {
            button2.interactable = false;
        }

        if (flag_3 == true && button3.interactable == true)
        {
            button3.interactable = false;
        }
    }
    public void CreateObject1()
    {
        if(tmp_1 == -1)
        {
            // ゲームオブジェクトを生成します。
            obj1 = Instantiate(prefab[number1], new Vector3(-3.6f, 1.55f, 0), Quaternion.identity, _parentGameObject.transform);
            button1 = obj1.GetComponent<Button>();
            obj1.name = "Item_Image_1";
            tmp_1 = number1;
            Item_Get_Check(button1);
        }
        else
        {
            // ゲームオブジェクトを生成します。
            obj1 = Instantiate(prefab[tmp_1], new Vector3(-3.6f, 1.55f, 0), Quaternion.identity, _parentGameObject.transform);
            button1 = obj1.GetComponent<Button>();
            obj1.name = "Item_Image_1";
            Item_Get_Check(button1);
        }

    }
    public void CreateObject2()
    {
        if(tmp_2 == -1)
        {
            obj2 = Instantiate(prefab[number2], new Vector3(-0.15f, 1.55f, 0), Quaternion.identity, _parentGameObject.transform);
            button2 = obj2.GetComponent<Button>();
            obj2.name = "Item_Image_2";
            tmp_2 = number2;
            Item_Get_Check(button2);
        }
        else
        {
            obj2 = Instantiate(prefab[tmp_2], new Vector3(-0.15f, 1.55f, 0), Quaternion.identity, _parentGameObject.transform);
            button2 = obj2.GetComponent<Button>();
            obj2.name = "Item_Image_2";
            Item_Get_Check(button2);
        }
    }
    public void CreateObject3()
    {
        if(tmp_3 == -1)
        {
            obj3 = Instantiate(prefab[number3], new Vector3(3.6f, 1.55f, 0), Quaternion.identity, _parentGameObject.transform);
            button3 = obj3.GetComponent<Button>();
            obj3.name = "Item_Image_3";
            tmp_3 = number3;
            Item_Get_Check(button3);
        }
        else
        {
            obj3 = Instantiate(prefab[tmp_3], new Vector3(3.6f, 1.55f, 0), Quaternion.identity, _parentGameObject.transform);
            button3 = obj3.GetComponent<Button>();
            obj3.name = "Item_Image_3";
            Item_Get_Check(button3);
        }
    }

    void Item_Get_Check(Button button)
    {
        Item_Manager.Item.TryGetValue(button.tag, out bool tag_bool);
        if (tag_bool == true)
        {
            button.interactable = false;
        }
    }
    public void shop_select()
    {
        int switch_num;
        Item_Library = GetComponent<Item_Library>();
        switch (ChangeScene.scene_cnt)
        {
            case 3: shop_max = 3; break;
            case 6: shop_max = 4; break;
            case 9: shop_min = 0; break;
        }
        switch_num = Random.Range(shop_min, shop_max);
        switch (switch_num)
        {
            case 0: number1 = Random.Range(36, 38); break;
            case 1: number1 = Random.Range(0, prefab.Length - 6); break;
            case 2: number1 = Random.Range(0, prefab.Length - 4); break;
            case 3: number1 = Random.Range(0, prefab.Length - 2); break;
        }
        CreateObject1();
        do
        {
            switch_num = Random.Range(shop_min, shop_max);
            switch (switch_num)
            {
                case 0: number2 = Random.Range(36, 38); break;
                case 1: number2 = Random.Range(0, prefab.Length - 6); break;
                case 2: number2 = Random.Range(0, prefab.Length - 4); break;
                case 3: number2 = Random.Range(0, prefab.Length - 2); break;
            }
        } while (number2 == number1);
        CreateObject2();

        do
        {
            switch_num = Random.Range(shop_min, shop_max);
            switch (switch_num)
            {
                case 0: number3 = Random.Range(36, 38); break;
                case 1: number3 = Random.Range(0, prefab.Length - 6); break;
                case 2: number3 = Random.Range(0, prefab.Length - 4); break;
                case 3: number3 = Random.Range(0, prefab.Length - 2); break;
            }
        } while (number3 == number2 || number3 == number1);
        CreateObject3();
    }
    public void Getflag_reset()
    {
        Item_Library.GetFlag1 = false;
        Item_Library.GetFlag2 = false;
        Item_Library.GetFlag3 = false;
    }
    public void shop_reroll()
    {

        if (PlayerController.Money >= 40)
        {
            PlayerController.Money -= 40;
            
            Destroy(obj1);
            Item_Library.GetFlag1 = false;
            Destroy(obj2);
            Item_Library.GetFlag2 = false;
            Destroy(obj3);
            Item_Library.GetFlag3 = false;
            tmp_1 = -1;
            tmp_2 = -1;
            tmp_3 = -1;
            shop_select();
        }
        else
        {
            text.text = ("リロールは40G必要です");
        }
    }
}