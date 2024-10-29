using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Library : MonoBehaviour
{
    // Start is called before the first frame update

    int Dummymoney = 100;
    int ItemVlue1 = 25;
    //int ItemValue2 = 30;
    public Text textbox;
    bool GetFlag1 = false;
    bool GetFlag2 = false;
    bool GetFlag3= false;
    int Item_Check;
    int Item_number1;
    int Item_number2;
    int Item_number3;
    Shop_manager shop_manager;
    
    GameObject obj;

    public enum Item
    {
        Healdrink,
        Bowlingball,
        CDPlayer,
        CD,
        Radio,
        Hourglass //砂時計
    }
    [SerializeField]
    public bool[] ItemFlags;
   
    



    void Start()
    {
        ItemFlags = new bool[6];


        GameObject obj = GameObject.Find("gamemanager");
        shop_manager = obj.GetComponent<Shop_manager>();

       

     

    }

    // Update is called once per frame
    void Update()
    {
       

    }

    //----------------------------
    //購入判定（試作）
    //---------------------------

    public void Buy1()
    {
        if (Dummymoney >= ItemVlue1 && GetFlag1 == false)
        {
            Item_number1 = shop_manager.number1;
            Item_Get(Item_number1);


            Dummymoney -= ItemVlue1;
            Debug.Log(Dummymoney);
            GetFlag1 = true;
        }
        else  if (Dummymoney - ItemVlue1 < 0)
        {
            Debug.Log(Dummymoney);
            textbox.text = "お金が足りません。";
        }

       
    }
    public void Buy2()
    {
        if (Dummymoney >= ItemVlue1 && GetFlag2 == false)
        {
            Item_number2 = shop_manager.number2;
            Item_Get(Item_number2);


            Dummymoney -= ItemVlue1;
            Debug.Log(Dummymoney);
            GetFlag2 = true;
        }
        else if (Dummymoney - ItemVlue1 < 0)
        {
            Debug.Log(Dummymoney);
            textbox.text = "お金が足りません。";
        }

       
    }
    public void Buy3()
    {
        if (Dummymoney >= ItemVlue1 && GetFlag3 == false)
        {
            Item_number3 = shop_manager.number3;

            Item_Get(Item_number3);

            Dummymoney -= ItemVlue1;
            Debug.Log(Dummymoney);
            GetFlag3 = true;
        }
        else if (Dummymoney - ItemVlue1 < 0)
        {
            Debug.Log(Dummymoney);
            textbox.text = "お金が足りません。";
        }

       
    }

    public bool GetItemFlag(Item item)
    {
        return ItemFlags[(int)item];
    }

    void Item_Get(int i)
    {
        switch (i)
        {
            case 0:
                ItemFlags[(int)Item.Healdrink] = true; break;
            case 1:
                ItemFlags[(int)Item.Bowlingball] = true; break;
            case 2:
                ItemFlags[(int)Item.CDPlayer] = true; break;
            case 3:
                ItemFlags[(int)Item.CD] = true; break;
            case 4:
                ItemFlags[(int)Item.Radio] = true; break;
            case 5:
                ItemFlags[(int)Item.Hourglass] = true; break;

        }
    }
}

