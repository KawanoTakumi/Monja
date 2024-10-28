using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Library : MonoBehaviour
{
    // Start is called before the first frame update

    int Dummymoney = 100000000;
    int ItemVlue1 = 25;
    public Text textbox;
    bool GetFlag1 = false;
    bool GetFlag2 = false;
    bool GetFlag3= false;
    int Item_Check;
    int Item_number1;
    int Item_number2;
    int Item_number3;
   public Button button1;
   public Button button2;
   public Button button3;

    Shop_manager shop_manager;
    

    
    GameObject obj;

    public  enum Item
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
        ItemFlags[(int)Item.Bowlingball] = false;

        GameObject obj = GameObject.Find("gamemanager");
        shop_manager = obj.GetComponent<Shop_manager>();

        //int Item_Check1 = shop_manager.random1;
        //int Item_Check2 = shop_manager.random2;
        //int Item_Check3 = shop_manager.random3;




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
            switch(Item_number1)
            {
                case 0:

                    ItemFlags[(int)Item.Healdrink] = true;  break;
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
            switch (Item_number2)
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
            switch (Item_number3)
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
}