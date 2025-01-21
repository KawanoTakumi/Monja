using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Shop_manager : MonoBehaviour
{
    // オブジェクトを生成する元となるPrefabへの参照を保持します。
    public GameObject[] prefab;
    //ショップ陳列アイテム選出
    int number1;
    int number2;
    int number3;
    //ショップ陳列アイテム
    GameObject obj1;
    GameObject obj2;
    GameObject obj3;
    GameObject Healobj;
    public bool item_flag;//アイテムフラグ
    public Item_Library Item_Library;//アイテムライブラリ
    //購入ボタン
    public Button button1;
    public Button button2;
    public Button button3;
    public Button healbutton;
    //ボスアイテム除外用
    public static int shop_min = 1;//ショップ最小値
    public static int shop_max = 2;//ショップ最大値
    //ショップ選出アイテム保存用
    public static int tmp_1 = -1;
    public static int tmp_2 = -1;
    public static int tmp_3 = -1;
    //説明テキスト
    public Text text;
    [SerializeField] GameObject _parentGameObject;

    //テスト
    int[] Item_number = new int[4];
    public static int[] Shop_tmp = new int[3] {-1,-1,-1};
    public Button[] Obj_button = new Button[4];
    GameObject[] Item_obj = new GameObject[4];
    int Shop_limit = 6;

    void Start()
    {

        for(int i=0;i<=3;i++)
        {
           
            switch (i)
            {
                case 0: item_select(i); Create_ShopItem(i); break;
                case 1: item_select(i); Create_ShopItem(i); break;
                case 2: item_select(i); Create_ShopItem(i); break;
                case 3: item_select(i); CreateObjectHeal();                               break;
            }
        }
        for(int i=0;i<=2;i++)
        {
            Debug.Log(Shop_tmp[i]);
        }
        // shop_select();
       
    }

    public void Update()
    {
        for (int i = 0; i <= 3; i++)
        {
            Item_Manager.Item.TryGetValue(Obj_button[i].tag, out bool flag);
            if (flag == true && Obj_button[i].interactable == true)
                Obj_button[i].interactable = false;
        }



        //アイテムライブラリのGetFlagがtrueの時DictionalyのItem.valueをtrueにする
        //if (Item_Library.GetFlag1 == true)
        //{
        //    Item_Manager.Item[button1.tag] = true;
        //}

        //if (Item_Library.GetFlag2 == true)
        //{
        //    Item_Manager.Item[button2.tag] = true;
        //}

        //if (Item_Library.GetFlag3 == true)
        //{
        //    Item_Manager.Item[button3.tag] = true;
        //}
        for (int i = 0; i <= 2; i++)
        {
            if (Item_Library.GetFlag[i] == true)
                Item_Manager.Item[Obj_button[i].tag] = true;
        }


        //Dictionaryから値を取得
        Item_Manager.Item.TryGetValue(button1.tag, out bool flag_1);
        Item_Manager.Item.TryGetValue(button2.tag, out bool flag_2);
        Item_Manager.Item.TryGetValue(button3.tag, out bool flag_3);

        //if (flag_1 == true && button1.interactable == true)
        //{
        //    button1.interactable = false;
        //}

        //if (flag_2 == true && button2.interactable == true)
        //{
        //    button2.interactable = false;
        //}

        //if (flag_3 == true && button3.interactable == true)
        //{
        //    button3.interactable = false;
        //}
      
       

        if (Item_Library.Heal_Get_Flag == true)
        {
            healbutton.interactable = false;
        }
    }
    //public void CreateObject1()
    //{
    //    if (tmp_1 == -1)
    //    {
    //        // ゲームオブジェクトを生成します。
    //        obj1 = Instantiate(prefab[number1], new Vector3(-3.7f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
    //        button1 = obj1.GetComponent<Button>();
    //        obj1.name = "Item_Image_1";
    //        tmp_1 = number1;
    //        Item_Get_Check(button1);
    //    }
    //    else
    //    {
    //        // ゲームオブジェクトを生成します。
    //        obj1 = Instantiate(prefab[tmp_1], new Vector3(-3.7f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
    //        button1 = obj1.GetComponent<Button>();
    //        obj1.name = "Item_Image_1";
    //        Item_Get_Check(button1);
    //    }

    //}
    //public void CreateObject2()
    //{
    //    if (tmp_2 == -1)
    //    {
    //        // ゲームオブジェクトを生成します。
    //        obj2 = Instantiate(prefab[number2], new Vector3(-0.15f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
    //        button2 = obj2.GetComponent<Button>();
    //        obj2.name = "Item_Image_2";
    //        tmp_2 = number2;
    //        Item_Get_Check(button2);
    //    }
    //    else
    //    {
    //        // ゲームオブジェクトを生成します。
    //        obj2 = Instantiate(prefab[tmp_2], new Vector3(-0.15f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
    //        button2 = obj2.GetComponent<Button>();
    //        obj2.name = "Item_Image_2";
    //        Item_Get_Check(button2);
    //    }
    //}
    //public void CreateObject3()
    //{
    //    if (tmp_3 == -1)
    //    {
    //        // ゲームオブジェクトを生成します。
    //        obj3 = Instantiate(prefab[number3], new Vector3(3.45f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
    //        button3 = obj3.GetComponent<Button>();
    //        obj3.name = "Item_Image_3";
    //        tmp_3 = number3;
    //        Item_Get_Check(button3);
    //    }
    //    else
    //    {
    //        // ゲームオブジェクトを生成します。
    //        obj3 = Instantiate(prefab[tmp_3], new Vector3(3.45f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
    //        button3 = obj3.GetComponent<Button>();
    //        obj3.name = "Item_Image_3";
    //        Item_Get_Check(button3);
    //    }
    //}
    public void CreateObjectHeal()
    {
        Item_obj[3] = Instantiate(prefab[Item_number[3]], new Vector3(7.75f, -1.2f, 0), Quaternion.identity, _parentGameObject.transform);
        Obj_button[3] = Item_obj[3].GetComponent<Button>();
        Item_obj[3].name = "Heal_Item";
        button_intaractable(Obj_button[3]);
    }
    //void Item_Get_Check(Button button)
    //{
    //    Item_Manager.Item.TryGetValue(button.tag, out bool tag_bool);
    //    if (tag_bool == true)
    //    {
    //        button.interactable = false;
    //    }
    //}
    //public void shop_select()
    //{
    //    int switch_num;
    //    Item_Library = GetComponent<Item_Library>();
    //    switch (ChangeScene.scene_cnt)
    //    {
    //        case 3: shop_max = 3; break;
    //        case 6: shop_max = 4; break;
    //        case 9: shop_min = 0; break;
    //    }
    //    switch_num = Random.Range(shop_min, shop_max);
    //    switch (switch_num)
    //    {
    //        case 0: number1 = Random.Range(prefab.Length - 2, prefab.Length); break;
    //        case 1: number1 = Random.Range(1, prefab.Length - 6); break;
    //        case 2: number1 = Random.Range(1, prefab.Length - 4); break;
    //        case 3: number1 = Random.Range(1, prefab.Length - 2); break;
    //    }
    //    CreateObject1();
    //    do
    //    {
    //        switch_num = Random.Range(shop_min, shop_max);
    //        switch (switch_num)
    //        {
    //            case 0: number2 = Random.Range(prefab.Length - 2, prefab.Length); break;
    //            case 1: number2 = Random.Range(1, prefab.Length - 6); break;
    //            case 2: number2 = Random.Range(1, prefab.Length - 4); break;
    //            case 3: number2 = Random.Range(1, prefab.Length - 2); break;
    //        }
    //    } while (number2 == number1);
    //    CreateObject2();

    //    do
    //    {
    //        switch_num = Random.Range(shop_min, shop_max);
    //        switch (switch_num)
    //        {
    //            case 0: number3 = Random.Range(prefab.Length - 2, prefab.Length); break;
    //            case 1: number3 = Random.Range(1, prefab.Length - 6); break;
    //            case 2: number3 = Random.Range(1, prefab.Length - 4); break;
    //            case 3: number3 = Random.Range(1, prefab.Length - 2); break;
    //        }
    //    } while (number3 == number2 || number3 == number1);
    //    CreateObject3();
    //    CreateObjectHeal();
    //}
    public void Getflag_reset()
    {
        Item_Library.GetFlag1 = false;
        Item_Library.GetFlag2 = false;
        Item_Library.GetFlag3 = false;
        Item_Library.Heal_Get_Flag = false;
    }
    public void shop_reroll()
    {

        if (PlayerController.MONEY >= 30)
        {
            PlayerController.MONEY -= 30;

            Destroy(obj1);
            Item_Library.GetFlag1 = false;
            Destroy(obj2);
            Item_Library.GetFlag2 = false;
            Destroy(obj3);
            Item_Library.GetFlag3 = false;
            tmp_1 = -1;
            tmp_2 = -1;
            tmp_3 = -1;
            //shop_select();

            for(int i =0;i<=2;i++)
            {
                Destroy(Item_obj[i]);
                Item_Library.GetFlag[i] = false;
                Shop_tmp[i] = -1;
                item_select(i);
                Create_ShopItem(i);
            }
          
        }
        else
        {
            text.text = ("リロールは30G必要です");
        }
    }
    public void button_intaractable(Button button)
    {
        button.interactable = false;
    }

    int Create_ShopItem(int i)
    {
        if (Shop_tmp[i] == -1)
        {
            switch (i)
            {
                case 0:
                    Item_obj[i] = Instantiate(prefab[Item_number[i]], new Vector3(-3.7f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
                    Item_obj[i].name = "Item_Image_1"; Shop_tmp[i] = Item_number[i]; break;
                case 1:
                    Item_obj[i] = Instantiate(prefab[Item_number[i]], new Vector3(-0.15f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
                    Item_obj[i].name = "Item_Image_2"; Shop_tmp[i] = Item_number[i]; break;
                case 2:
                    Item_obj[i] = Instantiate(prefab[Item_number[i]], new Vector3(3.45f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
                    Item_obj[i].name = "Item_Image_3"; Shop_tmp[i] = Item_number[i]; break;
                  
            }
            Obj_button[i] = Item_obj[i].GetComponent<Button>();
            Item_Get_Check(i);
        }
        else
        {
            switch (i)
            {
                case 0:
                    Item_obj[i] = Instantiate(prefab[Shop_tmp[i]], new Vector3(-3.7f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
                    Item_obj[i].name = "Item_Image_1"; break;
                case 1:
                    Item_obj[i] = Instantiate(prefab[Shop_tmp[i]], new Vector3(-0.15f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
                    Item_obj[i].name = "Item_Image_2"; break;
                case 2:
                    Item_obj[i] = Instantiate(prefab[Shop_tmp[i]], new Vector3(3.45f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
                    Item_obj[i].name = "Item_Image_3"; break;

            }
            Obj_button[i] = Item_obj[i].GetComponent<Button>();
            Item_Get_Check(i);
        }
       
        return Item_number[i];
    }

    void item_select(int i)
    {
       
        switch (ChangeScene.scene_cnt)
        {
            case 4: Shop_limit = 4; break;
            case 7: Shop_limit = 2; break;
            case 9: Shop_limit =  0; break;
            default:                 break;
        }
        switch(i)
        {
            case 0: Item_number[i] = Random.Range(1, prefab.Length - Shop_limit); break;
            case 1: do {Item_number[i] = Random.Range(1, prefab.Length - Shop_limit); } while (Item_number[0] == Item_number[1]); break;
            case 2: do {Item_number[i] = Random.Range(1, prefab.Length - Shop_limit); } while (Item_number[0] == Item_number[2] || Item_number[1] == Item_number[2]); break;
            case 3: Item_number[i] = 0;break;
        }
    }

    void Item_Get_Check(int i)
    {
        Item_Manager.Item.TryGetValue(Obj_button[i].tag, out bool tag_bool);
        if (tag_bool == true)
        {
            Obj_button[i].interactable = false;
        }
    }
}
