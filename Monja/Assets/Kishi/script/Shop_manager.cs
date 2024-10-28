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

    int[] item_ban;
    int i = 0;

    [SerializeField] GameObject _parentGameObject;

    void Start()
    {
        //GameObject obj = GameObject.Find<"gamemanager">;
        //item_library = obj.GetComponent<Item_Library>();

        SelectItem1();
        SelectItem1();
        SelectItem3();


        CreateObject1();
        CreateObject2();
        CreateObject3();
    }

    private void Update()
    {


    }


    void CreateObject1()
    {
        // ゲームオブジェクトを生成します。

        GameObject obj1 = Instantiate(prefab[number1], new Vector3(-4.29f, 1, 0), Quaternion.identity, _parentGameObject.transform);
        Debug.Log(number1);
        
    }
    void CreateObject2()
    {
        GameObject obj2 = Instantiate(prefab[number2], new Vector3(0.11f, 1, 0), Quaternion.identity, _parentGameObject.transform);
        Debug.Log(number2);
        
    }
    void CreateObject3()
    {
        GameObject obj3 = Instantiate(prefab[number3], new Vector3(5.45f, 1, 0), Quaternion.identity, _parentGameObject.transform);
        Debug.Log(number3);
        
    }

   void SelectItem1()
    {
        number1 = Random.Range(0, prefab.Length);
       //switch(number1)
       // {
       //     case 0:if() break;
       // }
           
    }

    void SelectItem2()
    {
        do
        {
            number2 = Random.Range(0, prefab.Length);
           
                
            
        } while (number2 == number1);
    }

    void SelectItem3()
    {
        do
        {
            number3 = Random.Range(0, prefab.Length);
            
               
             
        } while (number3 == number2 || number3 == number1);
    }
}
