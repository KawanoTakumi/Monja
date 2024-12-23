using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_interact_check : MonoBehaviour
{
    public Button button;//ƒ{ƒ^ƒ“
    void Start()
    {
        button.interactable = false;
    }
    void Update()
    {
        button.interactable = false;

        if (Item_Manager.Item[button.tag] == true)
            button.interactable = true;
    }
}