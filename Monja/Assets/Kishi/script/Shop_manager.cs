using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Shop_manager : MonoBehaviour
{
    // オブジェクトを生成する元となるPrefabへの参照を保持します。
    public GameObject[] prefab;
    //ショップ陳列アイテム選出
    int[] Item_number = new int[4];
    //ショップ陳列アイテム
    GameObject[] Item_obj = new GameObject[4];
    
    public Item_Library Item_Library;//アイテムライブラリ
    public Button[] Obj_button = new Button[4];         //購入ボタン
    //ボスアイテム除外用
    public static int Shop_limit = 6;
    //ショップ選出アイテム保存用
    public static int[] Shop_tmp = new int[3] { -1, -1, -1 };
    //説明テキスト
    public Text text;
    [SerializeField] GameObject _parentGameObject;

    void Start()
    {

        for(int i=0;i<=3;i++)
        {
           
            switch (i)
            {
                case 0: item_select(i); Create_ShopItem(i); break;
                case 1: item_select(i); Create_ShopItem(i); break;
                case 2: item_select(i); Create_ShopItem(i); break;
                case 3: item_select(i); CreateObjectHeal(); break;
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

        for (int i = 0; i <= 2; i++)
        {
            if (Item_Library.GetFlag[i] == true)
                Item_Manager.Item[Obj_button[i].tag] = true;
        }

    }
    public void CreateObjectHeal()
    {
        Item_obj[3] = Instantiate(prefab[Item_number[3]], new Vector3(7.75f, -1.2f, 0), Quaternion.identity, _parentGameObject.transform);
        Obj_button[3] = Item_obj[3].GetComponent<Button>();
        Item_obj[3].name = "Heal_Item";
        button_intaractable(Obj_button[3]);
    }

    //ゲットフラグリセット
    public void Getflag_reset()
    {
        //アイテムの取得フラグリセット

        for (int i = 0; i < 4; i++)
            Item_Library.GetFlag[i] = false;
    }
    public void shop_reroll()
    {

        if (PlayerController.MONEY >= 30)
        {
            PlayerController.MONEY -= 30;


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
       
        switch (ChangeScene.SCENE_CNT)
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
