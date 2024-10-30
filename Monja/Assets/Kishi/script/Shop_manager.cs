using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Shop_manager: MonoBehaviour
{
    // オブジェクトを生成する元となるPrefabへの参照を保持します。
    public GameObject[] prefab;
    public int number1;
    public int number2;
    public int number3;
    public bool item_flag;
    Item_Library item_library;
    public IDictionary<string, bool> Item = new Dictionary<string, bool>();

    public Button button1;
    public Button button2;
    public Button button3;
    [SerializeField] GameObject _parentGameObject;

    void Start()
    {
        GameObject obj = GameObject.Find("gamemanager");
        item_library = obj.GetComponent<Item_Library>();

        //辞書にキーを設定
        if (Item.ContainsKey("healdrink") == false)
        {
            Item.Add("healdrink", false);
            Item.Add("bowlingball", false);
            Item.Add("CDplayer", false);
            Item.Add("cd", false);
            Item.Add("radio", false);
            Item.Add("hourglass", false);
        }


        number1 = Random.Range(0, prefab.Length);
        Debug.Log(number1);
        CreateObject1();
        do{
            number2 = Random.Range(0, prefab.Length);
        } while (number2 == number1);
        CreateObject2();
        do{
            number3 = Random.Range(0, prefab.Length);
        } while (number3 == number2 || number3 == number1);
        CreateObject3();
    }

    private void Update()
    {
        //アイテムライブラリのGetFlagがtrueの時DictionalyのItem.valueをtrueにする
        if (item_library.GetFlag1 == true)
        {
            Item[button1.tag] = true;
        }
        if (item_library.GetFlag2 == true)
        {
            Item[button2.tag] = true;
        }
        if (item_library.GetFlag3 == true)
        {
            Item[button3.tag] = true;
        }
        //if(button1 != null)
        //{
        //    Item.TryGetValue(button1.tag, out bool flag_1);
        //}

        //ボタン反応の停止
        if(button1 != null)
        {
            if (Item[button1.tag] == true && button1.interactable == true)
            {
                button1.interactable = false;
                TestR.Tag1 = button1.tag;
                Debug.Log(TestR.Tag1);
                Debug.Log(button1.interactable);
            }
            if (Item[button2.tag] == true && button2.interactable == true)
            {
                button2.interactable = false;
                TestR.Tag2 = button2.tag;
                Debug.Log(TestR.Tag2);
                Debug.Log(button2.interactable);
            }
            if (Item[button3.tag] == true && button3.interactable == true)
            {
                button3.interactable = false;
                TestR.Tag3 = button3.tag;
                Debug.Log(TestR.Tag3);
                Debug.Log(button3.interactable);
            }

        }

    }
    void CreateObject1()
    {
        // ゲームオブジェクトを生成します。
        GameObject obj1 = Instantiate(prefab[number1], new Vector3(-3.6f, 1.55f, 0), Quaternion.identity, _parentGameObject.transform);
        button1 = obj1.GetComponent<Button>();
        obj1.name = "Item_Image_1";
        Item_Get_Check(button1);
        Debug.Log(button1.tag);
        Debug.Log(button1.interactable);
    }
    void CreateObject2()
    {
        GameObject obj2 = Instantiate(prefab[number2], new Vector3(-0.15f,1.55f, 0), Quaternion.identity, _parentGameObject.transform);
        button2 = obj2.GetComponent<Button>();
        obj2.name = "Item_Image_2";
        Item_Get_Check(button2);
        Debug.Log(button2.tag);
        Debug.Log(button2.interactable);
    }
    void CreateObject3()
    {
        GameObject obj3 = Instantiate(prefab[number3], new Vector3(3.6f, 1.55f, 0), Quaternion.identity, _parentGameObject.transform);
        button3 = obj3.GetComponent<Button>();
        obj3.name = "Item_Image_3";
        Item_Get_Check(button3);
        Debug.Log(button3.tag);
        Debug.Log(button3.interactable);
    }

    void Item_Get_Check(Button button)
    {
        Debug.Log(button.tag);
        if (Item[button.tag] == true)
            button.interactable = false;
    }
}