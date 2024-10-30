using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money_Display : MonoBehaviour
{

    public Text textbox;
    public Text Money_Text;//金額表示用テキスト
    Item_Library item_library;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("gamemanager");
        item_library = obj.GetComponent<Item_Library>();    
    }

    // Update is called once per frame
    void Update()
    {
        Money_Text.text = string.Format("{0}", PlayerController.Money);

    }
}
