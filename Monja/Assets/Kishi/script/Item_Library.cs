using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Library : MonoBehaviour
{
    // Start is called before the first frame update
    int money = PlayerController.Money;//PlayerControllerのMoneyを取得
    int ItemValue1 = 25;
    //int ItemValue2 = 30;
    public Text textbox;
    public Text Money_Text;//金額表示用テキスト
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



    public IDictionary<string, bool> Item = new Dictionary<string, bool>();

    Shop_manager shop_manager;
    
    GameObject obj;





    private void Awake()
    {
        DontDestroyOnLoad(this);
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
    }

    void Start()
    {
        Flag_1 = false;
        Flag_2 = false;
        Flag_3 = false;


        GameObject obj = GameObject.Find("gamemanager");
        shop_manager = obj.GetComponent<Shop_manager>();

       
    }

    // Update is called once per frame
    void Update()
    {
       //Money_Text.text = string.Format("{0}",money);

    }

    //----------------------------
    //購入判定（試作）
    //---------------------------

    public void Buy1()
    {
        if (money>= ItemValue1 && GetFlag1 == false)
        {
            Item_number1 = shop_manager.number1;
          


            money -= ItemValue1;
            PlayerController.Money = money;//Player側の数も減らす
            Debug.Log(money);
            GetFlag1 = true;
            //Flag_1 = Item[shop_manager.button1.tag];

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
            Item_number2 = shop_manager.number2;
          


            money -= ItemValue1;
            PlayerController.Money = money;//Player側の数も減らす
            Debug.Log(money);
            GetFlag2 = true;
            //Flag_2 = Item[shop_manager.button2.tag];

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
            Item_number3 = shop_manager.number3;

            

            money -= ItemValue1;
            PlayerController.Money = money;//Player側の数も減らす
            Debug.Log(money);
            GetFlag3 = true;
            //Flag_3 = Item[shop_manager.button3.tag];

        }
        else if (money - ItemValue1 < 0)
        {
            Debug.Log(money);
            textbox.text = "お金が足りません。";
        }
    }

   

  
}