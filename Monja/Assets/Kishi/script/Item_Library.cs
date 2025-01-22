using UnityEngine;
using UnityEngine.UI;

public class Item_Library : MonoBehaviour
{
    // Start is called before the first frame update
    public int money;//����
                     //�ݒ���z
    int[] ITEM_VALUE = new int[4] { 20, 25, 30, 25 };
    //�擾�t���O
    public static bool[] GetFlag = new bool[4] { false, false, false, false };//012=�A�C�e��3=�q�[��
    public Button heal_button;//�񕜃A�C�e���p�{�^��
    public Text textbox;//�e�L�X�g
    Shop_manager shop_manager;//�V���b�v�}�l�[�W���[
                              //
    void Start()
    {
        GameObject obj = GameObject.Find("shopmanager");
        shop_manager = obj.GetComponent<Shop_manager>();//�V���b�v�}�l�[�W���[���擾
    }
    void Update()
    {
        money = PlayerController.MONEY;
        //�񕜃A�C�e�����擾�����Ƃ��A�C���^���N�g�ł��Ȃ�����
        if (GetFlag[3] == true)
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
    public void Buy(int i)
    {
        if(money >= ITEM_VALUE[i] && GetFlag[i]==false)
        {
           
            if (i == 3)PlayerController.HP_POTION++;
            if (Item_Manager.Item.TryGetValue(shop_manager.Obj_button[i].tag, out bool button))
            {
                if (button == false)
                {
                    money -= ITEM_VALUE[i];
                }
            }
            PlayerController.MONEY = money;
            shop_manager.Obj_button[i].interactable = false;
            GetFlag[i] = true;
        }
        else if(GetFlag[i] == true)
        {
            textbox.text = "���̃A�C�e���͂��łɎ����Ă��܂��B";
        }
        else if(money - ITEM_VALUE[0] < 0)
        {
            textbox.text = "����������܂���";
        }
    }
}