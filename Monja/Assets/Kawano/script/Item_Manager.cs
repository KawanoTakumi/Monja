using System.Collections.Generic;
using UnityEngine;
public class Item_Manager : MonoBehaviour
{
    //念のためstaticにしてどこでも値が保持されるようにする
    public static IDictionary<string, bool> Item = new Dictionary<string, bool>();
    private void Awake()
    {
        DontDestroyOnLoad(this);//このスクリプトは破棄されない
        Application.targetFrameRate = 60;//フレームレートを60fpsに固定
        //辞書にキーを設定
        if (Item.ContainsKey("healdrink") == false)
        {
            //アイテムをItem辞書に登録
            Item.Add("none",                false);//空のキーを設定（アイテムがないときの状態）
            Item.Add("healdrink",           false);//0
            Item.Add("bowlingball",         false);//1
            Item.Add("CDplayer",            false);//2
            Item.Add("cd",                  false);//3
            Item.Add("radio",               false);//4
            Item.Add("hourglass",           false);//5
            Item.Add("kesigomu",            false);//6
            Item.Add("TV",                  false);//7
            Item.Add("CreditCard",          false);//8
            Item.Add("Mouse",               false);//9

            Item.Add("HandMirror",          false);//10
            Item.Add("bowlingpin",          false);//11
            Item.Add("baseball_ball",       false);//12
            Item.Add("dice",                false);//13
            Item.Add("Water bucket",        false);//14
            Item.Add("Popcorn",             false);//15
            Item.Add("Apple",               false);//16
            Item.Add("Scissors",            false);//17
            Item.Add("ice",                 false);//18
            Item.Add("Pudding",             false);//19 

            Item.Add("Drill",               false);//20
            Item.Add("Headphone",           false);//21  
            Item.Add("Coffee",              false);//22
            Item.Add("Safetycone",          false);//23
            Item.Add("USB",                 false);//24
            Item.Add("UtypeMagnet",         false);//25
            Item.Add("Smartphone",          false);//26
            Item.Add("ItypeMagnet",         false);//27
            Item.Add("Magnifying Speculum", false);//28 
            Item.Add("Mike",                false);//29

            Item.Add("Megaphone",           false);//30
            Item.Add("HandMill",            false);//31
            Item.Add("Poteto",              false);//32
            Item.Add("Scop",                false);//33
            Item.Add("hammer",              true);//34 //調整
            Item.Add("Speaker",             false);//35
            Item.Add("Sylinge",             false);//36
            Item.Add("Baseball_glove",      false);//37
            Item.Add("Boxing_glove",        false);//38   
            Item.Add("Juice",               false);//39

            Item.Add("Gas_burner",          false);//40    
            Item.Add("Hamberger",           false);//41
            Item.Add("Pencil",              false);//42
            Item.Add("Mayonnaise",          false);//43
            Item.Add("Watch",               false);//44
            Item.Add("Scythe",              false);//45
            Item.Add("Robe",                true);//46
            Item.Add("Eye",                 true);//47
            Item.Add("MagicBook",           false);//48
            Item.Add("Scale",               false);//49

            Item.Add("Tooth",               false);//50
        }
    }
}