using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestR : MonoBehaviour
{
    public Button button;
    public static string Tag1;
    public static string Tag2;
    public static string Tag3;
    public  bool true_tag = false;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Tag1);
        Debug.Log(Tag2);
        Debug.Log(Tag3);
    }

    // Update is called once per frame
    void Update()
    {
        if (button.CompareTag(Tag1)|| button.CompareTag(Tag2)|| button.CompareTag(Tag3) == true)
        {
            true_tag = true;
        }
        if (true_tag == false)
        {
            button.interactable = false;
        }
        else if(true_tag == true)
        {
            button.interactable = true;
        }
    }
}