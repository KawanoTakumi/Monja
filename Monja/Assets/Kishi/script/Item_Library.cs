using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Library : MonoBehaviour
{
    // Start is called before the first frame update
    public int money;
    int ItemValue1 = 25;
    int ItemValue2 = 30;
    int ItemValue3 = 35;
    //�擾�t���O
    public static bool GetFlag1 = false;
    public static bool GetFlag2 = false;
    public static bool GetFlag3 = false;
    public bool Flag_1 = false;
    public bool Flag_2 = false;
    public bool Flag_3 = false;


    public Text textbox;


    Shop_manager shop_manager;
    void Start()
    {
        GameObject obj = GameObject.Find("shopmanager");
        shop_manager = obj.GetComponent<Shop_manager>();//�V���b�v�}�l�[�W���[���擾

    }

    // Update is called once per frame
    void Update()
    {
        money = PlayerController.Money;
    }

    //----------------------------
    //�w������
    //---------------------------

    public void Buy1()
    {
        if (money >= ItemValue1 && GetFlag1 == false)
        {
            if(Item_Manager.Item.TryGetValue(shop_manager.button1.tag,out bool button1))
            {
                if(button1 == false)
                {
                    money -= ItemValue1;
                }
            }
            PlayerController.Money = money;//Player���̐������炷
            GetFlag1 = true;
        }
        else if (GetFlag1 == true)
        {
            textbox.text = "���̃A�C�e���͂��łɎ����Ă��܂��B";
        }
        else if (money - ItemValue1 < 0)
        {
            textbox.text = "����������܂���B";
        }
    }

    public void Buy2()
    {
        if (money >= ItemValue2 && GetFlag2 == false)
        {
            if (Item_Manager.Item.TryGetValue(shop_manager.button2.tag, out bool button2))
            {
                if (button2 == false)
                {
                    money -= ItemValue2;
                }
            }

            PlayerController.Money = money;//Player���̐������炷
            GetFlag2 = true;
        }
        else if (GetFlag2 == true)
        {
            textbox.text = "���łɎ����Ă��܂��B";
        }
        else if (money - ItemValue1 < 0)
        {
            textbox.text = "����������܂���B";
        }
    }
    public void Buy3()
    {
        if (money >= ItemValue3 && GetFlag3 == false)
        {
            if (Item_Manager.Item.TryGetValue(shop_manager.button3.tag, out bool button3))
            {
                if (button3 == false)
                {
                    money -= ItemValue3;
                }
            }

            PlayerController.Money = money;//Player���̐������炷
            GetFlag3 = true;
        }
        else if (GetFlag3 == true)
        {
            textbox.text = "���łɎ����Ă��܂��B";
        }
        else if (money - ItemValue1 < 0)
        {
            textbox.text = "����������܂���B";
        }
    }
}