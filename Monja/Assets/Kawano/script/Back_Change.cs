using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back_Change : MonoBehaviour
{
    public Image img;
    public Sprite[] sprite;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(ChangeScene.scene_cnt)
        {
            case 1:
            case 2:img.sprite = sprite[0];break;
            case 3:img.sprite = sprite[1];break;
            case 4:
            case 5:img.sprite = sprite[2];break;
            case 6:img.sprite = sprite[3];break;
            case 7:
            case 8:img.sprite = sprite[4];break;
            case 9:img.sprite = sprite[5];break;
        }
    }
}
