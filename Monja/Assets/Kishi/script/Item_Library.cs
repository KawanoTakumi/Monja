using UnityEngine;
using UnityEngine.UI;

public class Item_Library : MonoBehaviour
{
    // Start is called before the first frame update
    public int money;//����
    //�ݒ���z
    int ItemValue1 = 20;
    int ItemValue2 = 25;
    int ItemValue3 = 30;
    int ItemValue_Heal = 25;//�񕜗p
    //�擾�t���O
    public static bool GetFlag1 = false;
    public static bool GetFlag2 = false;
    public static bool GetFlag3 = false;
    public static bool Heal_Get_Flag = false;
    public bool Flag_1 = false;
    public bool Flag_2 = false;
    public bool Flag_3 = false;
    public Button heal_button;//�񕜃A�C�e���p�{�^��
    public Text textbox;//�e�L�X�g
    Shop_manager shop_manager;//�V���b�v�}�l�[�W���[
    void Start()
    {
        GameObject obj = GameObject.Find("shopmanager");
        shop_manager = obj.GetComponent<Shop_manager>();//�V���b�v�}�l�[�W���[���擾
    }
    void Update()
    {
        money = PlayerController.MONEY;
        //�񕜃A�C�e�����擾�����Ƃ��A�C���^���N�g�ł��Ȃ�����
        if (Heal_Get_Flag == true)
        {
            heal_button.interactable = false;
        }
        else
        {
            heal_button.interactable = true;
        }
    }
    //----------------------------
    //�w������
    //---------------------------
    public void Buy1()
    {
        //�������ݒ���z��葽���Q�b�g�t���O��true�̎�
        if (money >= ItemValue1 && GetFlag1 == false)
        {
            if(Item_Manager.Item.TryGetValue(shop_manager.button1.tag,out bool button1))
            {
                if(button1 == false)
                {
                    money -= ItemValue1;
                }
            }
            PlayerController.MONEY = money;//Player���̐������炷
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
        //�������ݒ���z��葽���Q�b�g�t���O��true�̎�
        if (money >= ItemValue2 && GetFlag2 == false)
        {
            if (Item_Manager.Item.TryGetValue(shop_manager.button2.tag, out bool button2))
            {
                if (button2 == false)
                {
                    money -= ItemValue2;
                }
            }

            PlayerController.MONEY = money;//Player���̐������炷
            GetFlag2 = true;
        }
        else if (GetFlag2 == true)
        {
            textbox.text = "���̃A�C�e���͂��łɎ����Ă��܂��B";
        }
        else if (money - ItemValue1 < 0)
        {
            textbox.text = "����������܂���B";
        }
    }
    public void Buy3()
    {
        //�������ݒ���z��葽���Q�b�g�t���O��true�̎�
        if (money >= ItemValue3 && GetFlag3 == false)
        {
            if (Item_Manager.Item.TryGetValue(shop_manager.button3.tag, out bool button3))
            {
                if (button3 == false)
                {
                    money -= ItemValue3;
                }
            }

            PlayerController.MONEY = money;//Player���̐������炷
            GetFlag3 = true;
        }
        else if (GetFlag3 == true)
        {
            textbox.text = "���̃A�C�e���͂��łɎ����Ă��܂��B";
        }
        else if (money - ItemValue1 < 0)
        {
            textbox.text = "����������܂���B";
        }
    }
    //�񕜍w���֐�
    public void Heal_Buy()
    {
        if(money >= ItemValue_Heal)
        {
            money -= ItemValue_Heal;
            PlayerController.HP_POTION++;
            PlayerController.MONEY = money;
            shop_manager.healbutton.interactable = false;
            Heal_Get_Flag = true;
        }
        else
        {
            textbox.text = "����������܂���";
        }
    }
}