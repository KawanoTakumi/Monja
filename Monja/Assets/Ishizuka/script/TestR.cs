using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestR : MonoBehaviour
{
    public Button button;
    public static string Tag1 = "none";
    public static string Tag2 = "none";
    public static string Tag3 = "none";
    public bool true_tag = false;
    GameObject obj;
    Item_Manager item_manager;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Tag1);
        //Debug.Log(Tag2);
        //Debug.Log(Tag3);
        button.interactable = false;

        GameObject obj = GameObject.Find("gamemanager");
        item_manager = obj.GetComponent<Item_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (button.CompareTag(Tag1)|| button.CompareTag(Tag2)|| button.CompareTag(Tag3))
        //{
        //    true_tag = true;
        //}
        //if(true_tag == true)
        //{
        //    button.interactable = true;
        //}
        //else if(true_tag == false)
        //{
        //    button.interactable = false;
        //}

        
        button.interactable = false;

        if (item_manager.Item[button.tag] == true)
            button.interactable = true;

    }
}