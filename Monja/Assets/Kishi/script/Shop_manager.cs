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
    Item_Library item_library;

    //マップ定義
    IDictionary<string, bool> map = new Dictionary<string, bool>();


    Button button1;
    Button button2;
    Button button3;
    [SerializeField] GameObject _parentGameObject;

    void Start()
    {
        GameObject obj = GameObject.Find("gamemanager");
        item_library = obj.GetComponent<Item_Library>();


        number1 = Random.Range(0, prefab.Length);
        
        do
        {
            number2 = Random.Range(0, prefab.Length);
        } while (number2 == number1);

        do
        {
            number3 = Random.Range(0, prefab.Length);
        } while (number3 == number2 || number3 == number1);








        CreateObject1();
      //  CreateObject2();
       // CreateObject3();
    }

    private void Update()
    {


    }


    void CreateObject1()
    {
        // ゲームオブジェクトを生成します。

        GameObject obj1 = Instantiate(prefab[number1], new Vector3(-4.29f, 1, 0), Quaternion.identity, _parentGameObject.transform);
        button1 = obj1.GetComponent<Button>();
        obj1.name = "1";

        
        // ボタン反応の停止
        button1.interactable = false;


  //      Item_Get_Check(number1, button1);
        Debug.Log(button1.interactable);
    }
    void CreateObject2()
    {
        GameObject obj2 = Instantiate(prefab[number2], new Vector3(0.11f, 1, 0), Quaternion.identity, _parentGameObject.transform);
        Item_check(obj2);
       button2 = obj2.GetComponent<Button>();
        Item_Get_Check(number2, button2);
        Debug.Log(number2);
       
    }
    void CreateObject3()
    {
        GameObject obj3 = Instantiate(prefab[number3], new Vector3(5.45f, 1, 0), Quaternion.identity, _parentGameObject.transform);
        Item_check(obj3);
        button3 = obj3.GetComponent<Button>();
        Item_Get_Check(number3, button3);
        Debug.Log(number3);
       
    }

    void Item_check(GameObject obj)
    {
        obj = GameObject.FindWithTag("healdrink");
        obj = GameObject.FindWithTag("bowlingball");
        obj = GameObject.FindWithTag("CDplayer");
        obj = GameObject.FindWithTag("cd");
        obj = GameObject.FindWithTag("radio");
        obj = GameObject.FindWithTag("hourglass");
    }

    void Item_Get_Check(int n,Button button)
    {
        bool item = false;
        Debug.Log(n);
        switch (n)
        {
            case 0:
                item = item_library.GetItemFlag(Item_Library.Item.Healdrink);
                if (item == true)
                    Debug.Log(n);button.interactable = false; break;
            case 1:
                item = item_library.GetItemFlag(Item_Library.Item.Bowlingball);
                if (item == true)
                    Debug.Log(n); button.interactable = false; break;
            case 2:
                item = item_library.GetItemFlag(Item_Library.Item.CDPlayer);
                if (item == true)
                    Debug.Log(n); button.interactable = false; break;
            case 3:
                item = item_library.GetItemFlag(Item_Library.Item.CD);
                if (item == true)
                    Debug.Log(n); button.interactable = false; break;
            case 4:
                item = item_library.GetItemFlag(Item_Library.Item.Radio);
                if (item == true)
                    Debug.Log(n); button.interactable = false; break;
            case 5:
                item = item_library.GetItemFlag(Item_Library.Item.Hourglass);
                if (item == true)
                    Debug.Log(n); button.interactable = false; break;
        }
    }
}