using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Library : MonoBehaviour
{
    // Start is called before the first frame update

    int Dummymoney = 100;
    public Text textbox;
    bool GetFlag = false;
   
    public enum Item
    {
       Healdrink,
       Bowlingball,
       CDPlayer,
       CD,
       Radio,
       Hourglass //�����v
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

        if (Button_Check.instance.isTouched)
        {


            if (Dummymoney >= 25 && GetFlag == false)
            {
                ItemFlags[(int)Item.Bowlingball] = true;
                Dummymoney -= 25;
                Debug.Log(Dummymoney);
                GetFlag = true;
            }
            else
                textbox.text = "����������܂���B";
        }
    }
    public bool GetItemFlag(Item item)
    {
        return ItemFlags[(int)item];
    }

    //----------------------------
    //�w������i����j
    //---------------------------

  
    
}
