using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Library : MonoBehaviour
{
    // Start is called before the first frame update
    public int money = PlayerController.Money;//PlayerControllerのMoneyを取得
    int ItemValue1 = 25;
    //int ItemValue2 = 30;
    public bool GetFlag1 = false;
    public bool GetFlag2 = false;
    public bool GetFlag3= false;
    int Item_Check;
    int Item_number1;
    int Item_number2;
    int Item_number3;
    public bool Flag_1 = false;
    public bool Flag_2 = false;
    public bool Flag_3 = false;


    public Text textbox;


    Shop_manager shop_manager;
    
    GameObject obj;

    void Start()
    {
        //tagからvalueを取得


        GameObject obj = GameObject.Find("gamemanager");
        shop_manager = obj.GetComponent<Shop_manager>();
        //Debug.Log(shop_manager.button1);

    }

    // Update is called once per frame
    void Update()
    {
        money = PlayerController.Money;
    }

    //----------------------------
    //購入判定（試作）
    //---------------------------

    public void Buy1()
    {
        if (money>= ItemValue1 && GetFlag1 == false)
        {
            //Item_number1 = shop_manager.number1;
          


            money -= ItemValue1;
            PlayerController.Money = money;//Player側の数も減らす
            Debug.Log(money);
            GetFlag1 = true;

        }
        else  if (money - ItemValue1 < 0)
        {
            Debug.Log(money);
            textbox.text = "お金が足りません。";
        }
    }
    public void Buy2()
    {
        if (money >= ItemValue1 && GetFlag2 == false)
        {
            //Item_number2 = shop_manager.number2;
          


            money -= ItemValue1;
            PlayerController.Money = money;//Player側の数も減らす
            Debug.Log(money);
            GetFlag2 = true;

        }
        else if (money - ItemValue1 < 0)
        {
            Debug.Log(money);
            textbox.text = "お金が足りません。";
        }
    }
    public void Buy3()
    {
        if (money >= ItemValue1 && GetFlag3 == false)
        {
            //Item_number3 = shop_manager.number3;

            

            money -= ItemValue1;
            PlayerController.Money = money;//Player側の数も減らす
            Debug.Log(money);
            GetFlag3 = true;

        }
        else if (money - ItemValue1 < 0)
        {
            Debug.Log(money);
            textbox.text = "お金が足りません。";
        }
    }

   

  
}