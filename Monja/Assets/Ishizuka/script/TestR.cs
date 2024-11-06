using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestR : MonoBehaviour
{
    public Button button;
    public bool true_tag = false;
    // Start is called before the first frame update
    void Start()
    {
        button.interactable = false;
    }
    // Update is called once per frame
    void Update()
    {
        button.interactable = false;

        if (Item_Manager.Item[button.tag] == true)
            button.interactable = true;
    }
}