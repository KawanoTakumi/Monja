using UnityEngine;
using UnityEngine.UI;

public class Item_Library : MonoBehaviour
{
    // Start is called before the first frame update
    public int money;//お金
                     //設定金額
    int[] ITEM_VALUE = new int[4] { 20, 25, 30, 25 };
    //取得フラグ
    public static bool[] GetFlag = new bool[4] { false, false, false, false };//012=アイテム3=ヒール
    public Button heal_button;//回復アイテム用ボタン
    public Text textbox;//テキスト
    Shop_manager shop_manager;//ショップマネージャー
                              //
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
    public void Buy(int i)
    {
        if(money >= ITEM_VALUE[i] && GetFlag[i]==false)
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