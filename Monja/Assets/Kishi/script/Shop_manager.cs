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
    public static IDictionary<string, bool> Item = new Dictionary<string, bool>();

    public Button button1;
    public Button button2;
    public Button button3;
    [SerializeField] GameObject _parentGameObject;

    void Start()
    {
        GameObject obj = GameObject.Find("gamemanager");
        item_library = obj.GetComponent<Item_Library>();
        //辞書にキーを設定
        if(Item.ContainsKey("healdrink") == false)
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
        //tagからvalueを取得
        Item.TryGetValue(button1.tag, out bool flag_1);
        Item.TryGetValue(button2.tag, out bool flag_2);
        Item.TryGetValue(button3.tag, out bool flag_3);

        // ボタン反応の停止
        if (flag_1 == true && button1.interactable == true)
        {
            button1.interactable = false;
            TestR.Tag1 = button1.tag;
            Debug.Log(TestR.Tag1);
            Debug.Log(button1.interactable);
        }
        if (flag_2 == true && button2.interactable == true)
        {
            button2.interactable = false;
            TestR.Tag2 = button2.tag;
            Debug.Log(TestR.Tag2);
            Debug.Log(button2.interactable);
        }
        if (flag_3 == true && button3.interactable == true)
        {
            button3.interactable = false;
            TestR.Tag3 = button3.tag;
            Debug.Log(TestR.Tag3);
            Debug.Log(button3.interactable);
        }

    }
    void CreateObject1()
    {
        // ゲームオブジェクトを生成します。
        GameObject obj1 = Instantiate(prefab[number1], new Vector3(-3.8f, 2f, 0), Quaternion.identity, _parentGameObject.transform);
        button1 = obj1.GetComponent<Button>();
        obj1.name = "Item_Image_1";
        Debug.Log(button1.tag);
        Debug.Log(button1.interactable);
    }
    void CreateObject2()
    {
        GameObject obj2 = Instantiate(prefab[number2], new Vector3(0.11f, 2f, 0), Quaternion.identity, _parentGameObject.transform);
        button2 = obj2.GetComponent<Button>();
        obj2.name = "Item_Image_2";
        Debug.Log(button2.tag);
        Debug.Log(button2.interactable);
    }
    void CreateObject3()
    {
        GameObject obj3 = Instantiate(prefab[number3], new Vector3(4.35f, 2f, 0), Quaternion.identity, _parentGameObject.transform);
        button3 = obj3.GetComponent<Button>();
        obj3.name = "Item_Image_3";
        Debug.Log(button3.tag);
        Debug.Log(button3.interactable);
    }
}