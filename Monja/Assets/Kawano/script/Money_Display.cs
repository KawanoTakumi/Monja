using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money_Display : MonoBehaviour
{

    public Text textbox;
    public Text Money_Text;//���z�\���p�e�L�X�g
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Money_Text.text = string.Format("{0}", PlayerController.Money);

    }
}
