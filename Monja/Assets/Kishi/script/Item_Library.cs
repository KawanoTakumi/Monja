using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Library : MonoBehaviour
{
    // Start is called before the first frame update

    int Dummymoney = 25;
    int ItemVlue1 = 25;
    public Text textbox;
    bool GetFlag = false;

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
    private bool[] ItemFlags;


    void Start()
    {
        ItemFlags = new bool[6];
        ItemFlags[(int)Item.Bowlingball] = false;




       
    }

    // Update is called once per frame
    void Update()
    {
        if (Button_Check.instance.isTouched1)
        {
            Buy1();
        }
       

    }

    //----------------------------
    //購入判定（試作）
    //---------------------------

    void Buy1()
    {
        if (Dummymoney >= ItemVlue1 && GetFlag == false)
        {
            ItemFlags[(int)Item.Bowlingball] = true;
            Dummymoney -= ItemVlue1;
            Debug.Log(Dummymoney);
            GetFlag = true;
        }
        else  if (Dummymoney - ItemVlue1 < 0)
        {
            Debug.Log(Dummymoney);
            textbox.text = "お金が足りません。";
        }

        Button_Check.instance.isTouched1 = false;
    }

    public bool GetItemFlag(Item item)
    {
        return ItemFlags[(int)item];
    }
}