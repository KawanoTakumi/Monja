using UnityEngine;
using UnityEngine.UI;

public class Item_Library : MonoBehaviour
{
    // Start is called before the first frame update
    public int money;//お金
    //設定金額
    int ItemValue1 = 20;
    int ItemValue2 = 25;
    int ItemValue3 = 30;
    int ItemValue_Heal = 25;//回復用
    //取得フラグ
    public static bool GetFlag1 = false;
    public static bool GetFlag2 = false;
    public static bool GetFlag3 = false;
    public static bool Heal_Get_Flag = false;
    public bool Flag_1 = false;
    public bool Flag_2 = false;
    public bool Flag_3 = false;
    public Button heal_button;//回復アイテム用ボタン
    public Text textbox;//テキスト
    Shop_manager shop_manager;//ショップマネージャー

    //テスト
    public static bool[] GetFlag = new bool[4] { false, false, false, false };//012=アイテム3=ヒール
   int[] ITEM_VALUE = new int[4] { 20, 25, 30, 25 };
    void Start()
    {
        GameObject obj = GameObject.Find("shopmanager");
        shop_manager = obj.GetComponent<Shop_manager>();//ショップマネージャーを取得
    }
    void Update()
    {
        money = PlayerController.MONEY;
        //回復アイテムを取得したとき、インタラクトできなくする
        if (GetFlag[3] == true)
        {
            heal_button.interactable = false;
        }
        else
        {
            heal_button.interactable = true;
        }
    }
    //----------------------------
    //購入判定
    //---------------------------
    public void Buy1()
    {
        //お金が設定金額より多くゲットフラグがtrueの時
        if (money >= ItemValue1 && GetFlag1 == false)
        {
            if(Item_Manager.Item.TryGetValue(shop_manager.button1.tag,out bool button1))
            {
                if(button1 == false)
                {
                    money -= ItemValue1;
                }
            }
            PlayerController.MONEY = money;//Player側の数も減らす
            GetFlag1 = true;
        }
        else if (GetFlag1 == true)
        {
            textbox.text = "そのアイテムはすでに持っています。";
        }
        else if (money - ItemValue1 < 0)
        {
            textbox.text = "お金が足りません。";
        }
    }

    public void Buy2()
    {
        //お金が設定金額より多くゲットフラグがtrueの時
        if (money >= ItemValue2 && GetFlag2 == false)
        {
            if (Item_Manager.Item.TryGetValue(shop_manager.button2.tag, out bool button2))
            {
                if (button2 == false)
                {
                    money -= ItemValue2;
                }
            }

            PlayerController.MONEY = money;//Player側の数も減らす
            GetFlag2 = true;
        }
        else if (GetFlag2 == true)
        {
            textbox.text = "そのアイテムはすでに持っています。";
        }
        else if (money - ItemValue1 < 0)
        {
            textbox.text = "お金が足りません。";
        }
    }
    public void Buy3()
    {
        //お金が設定金額より多くゲットフラグがtrueの時
        if (money >= ItemValue3 && GetFlag3 == false)
        {
            if (Item_Manager.Item.TryGetValue(shop_manager.button3.tag, out bool button3))
            {
                if (button3 == false)
                {
                    money -= ItemValue3;
                }
            }

            PlayerController.MONEY = money;//Player側の数も減らす
            GetFlag3 = true;
        }
        else if (GetFlag3 == true)
        {
            textbox.text = "そのアイテムはすでに持っています。";
        }
        else if (money - ItemValue1 < 0)
        {
            textbox.text = "お金が足りません。";
        }
    }
    //回復購入関数
    public void Heal_Buy()
    {
        if(money >= ItemValue_Heal)
        {
            money -= ItemValue_Heal;
            PlayerController.HP_POTION++;
            PlayerController.MONEY = money;
            shop_manager.healbutton.interactable = false;
            Heal_Get_Flag = true;
        }
        else
        {
            textbox.text = "お金が足りません";
        }
    }

    public void Buy(int i)
    {
        if(money >= ITEM_VALUE[i])
        {
           
            if (i == 3)PlayerController.HP_POTION++;
            if (Item_Manager.Item.TryGetValue(shop_manager.Obj_button[i].tag, out bool button))
            {
                if (button == false)
                {
                    money -= ITEM_VALUE[i];
                }
            }
            PlayerController.MONEY = money;
            shop_manager.Obj_button[i].interactable = false;
            GetFlag[i] = true;
        }
        else if(GetFlag[i] == true)
        {
            textbox.text = "そのアイテムはすでに持っています。";
        }
        else if(money - ITEM_VALUE[0] < 0)
        {
            textbox.text = "お金が足りません";
        }
    }
}