using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Library : MonoBehaviour
{
    // Start is called before the first frame update
    public int money;
    int ItemValue1 = 25;
    //int ItemValue2 = 30;
    public bool GetFlag1 = false;
    public bool GetFlag2 = false;
    public bool GetFlag3= false;
    //int Item_Check;
    //int Item_number1;
    //int Item_number2;
    //int Item_number3;
    public bool Flag_1 = false;
    public bool Flag_2 = false;
    public bool Flag_3 = false;


    public Text textbox;


    Shop_manager shop_manager;
    
    GameObject obj;

    void Start()
    {
        //tag����value���擾


        GameObject obj = GameObject.Find("shopmanager");
        shop_manager = obj.GetComponent<Shop_manager>();
        //Debug.Log(shop_manager.button1);

    }

    // Update is called once per frame
    void Update()
    {
        money = PlayerController.Money;
    }

    //----------------------------
    //�w������i����j
    //---------------------------

    public void Buy1()
    {
        if (money>= ItemValue1 && GetFlag1 == false)
        {
            money -= ItemValue1;
            PlayerController.Money = money;//Player���̐������炷
            Debug.Log(money);
            GetFlag1 = true;
        }
        else  if (money - ItemValue1 < 0)
        {
            Debug.Log(money);
            textbox.text = "����������܂���B";
        }
    }
    public void Buy2()
    {
        if (money >= ItemValue1 && GetFlag2 == false)
        {
            money -= ItemValue1;
            PlayerController.Money = money;//Player���̐������炷
            Debug.Log(money);
            GetFlag2 = true;
        }
        else if (money - ItemValue1 < 0)
        {
            Debug.Log(money);
            textbox.text = "����������܂���B";
        }
    }
    public void Buy3()
    {
        if (money >= ItemValue1 && GetFlag3 == false)
        {
            money -= ItemValue1;
            PlayerController.Money = money;//Player���̐������炷
            Debug.Log(money);
            GetFlag3 = true;
        }
        else if (money - ItemValue1 < 0)
        {
            Debug.Log(money);
            textbox.text = "����������܂���B";
        }
    }
}