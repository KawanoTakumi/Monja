using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Library : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Item
    {
       Healdrink,
       Bowlingball,
       CDPlayer,
       CD,
       Radio,
       Hourglass //çªéûåv
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
        
    }
    public bool GetItemFlag(Item item)
    {
        return ItemFlags[(int)item];
    }

    //----------------------------
    //çwì¸îªíËÅiééçÏÅj
    //---------------------------

    //public 
}
