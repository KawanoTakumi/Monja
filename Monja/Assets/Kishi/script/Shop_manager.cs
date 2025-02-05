using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Shop_manager : MonoBehaviour
{
    // �I�u�W�F�N�g�𐶐����錳�ƂȂ�Prefab�ւ̎Q�Ƃ�ێ����܂��B
    public GameObject[] prefab;
    //�V���b�v��A�C�e���I�o
    int[] Item_number = new int[4];
    //�V���b�v��A�C�e��
    GameObject[] Item_obj = new GameObject[4];
    
    public Item_Library Item_Library;//�A�C�e�����C�u����
    public Button[] Obj_button = new Button[4];         //�w���{�^��
    //�{�X�A�C�e�����O�p
    public static int Shop_limit = 6;
    public static bool TheGrimreaper_flag  = false;
    public static bool Medhusa_flag        = false;
    public static bool Dragon_flag         = false;
    //�V���b�v�I�o�A�C�e���ۑ��p
    public static int[] Shop_tmp = new int[3] { -1, -1, -1 };
    //�����e�L�X�g
    public Text text;
    [SerializeField] GameObject _parentGameObject;
   
    void Start()
    {

        for(int i=0;i<=3;i++)
        {
           
            switch (i)
            {
                case 0: item_select(i); Create_ShopItem(i); break;
                case 1: item_select(i); Create_ShopItem(i); break;
                case 2: item_select(i); Create_ShopItem(i); break;
                case 3: item_select(i); CreateObjectHeal(); break;
            }
        }
        for(int i=0;i<=2;i++)
        {
            Debug.Log(Shop_tmp[i]);
        }
        // shop_select();
       
    }

    public void Update()
    {
        for (int i = 0; i <= 3; i++)
        {
            Item_Manager.Item.TryGetValue(Obj_button[i].tag, out bool flag);
            if (flag == true && Obj_button[i].interactable == true)
                Obj_button[i].interactable = false;
        }

        for (int i = 0; i <= 2; i++)
        {
            if (Item_Library.GetFlag[i] == true)
                Item_Manager.Item[Obj_button[i].tag] = true;
        }

    }
    /// <summary>
    /// �񕜃A�C�e���̃I�u�W�F�N�g�𐶐����܂�
    /// </summary>
    public void CreateObjectHeal()
    {
        Item_obj[3] = Instantiate(prefab[Item_number[3]], new Vector3(7.75f, -1.2f, 0), Quaternion.identity, _parentGameObject.transform);
        Obj_button[3] = Item_obj[3].GetComponent<Button>();
        Item_obj[3].name = "Heal_Item";
        button_intaractable(Obj_button[3]);
    }

    /// <summary>
    ///�A�C�e���̓���󋵔���p�̃t���O�����Z�b�g���܂�
    /// </summary>
    public void Getflag_reset()
    {
        //�A�C�e���̎擾�t���O���Z�b�g

        for (int i = 0; i < 4; i++)
            Item_Library.GetFlag[i] = false;
    }

    /// <summary>
    /// �V���b�v���Ē��I���܂�
    /// </summary>
    public void shop_reroll()
    {

        if (PlayerController.MONEY >= 30)//�������m�F
        {
            PlayerController.MONEY -= 30;


            for(int i =0;i<=2;i++)
            {
                Destroy(Item_obj[i]);
                Item_Library.GetFlag[i] = false;
                Shop_tmp[i] = -1;
                item_select(i);
                Create_ShopItem(i);
            }
          
        }
        else
        {
            text.text = ("�����[����30G�K�v�ł�");
        }
    }
    /// <summary>
    /// �{�^���������ꂽ�ꍇ�A�{�^�����ēx�����Ȃ����܂�
    /// </summary>
    /// <param name="button"></param>
    public void button_intaractable(Button button)
    {
        button.interactable = false;
    }
    /// <summary>
    /// �A�C�e���̃C�u�W�F�N�g�𐶐����܂�
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    int Create_ShopItem(int i)
    {
        if (Shop_tmp[i] == -1)
        {
            switch (i)
            {
                case 0:
                    Item_obj[i] = Instantiate(prefab[Item_number[i]], new Vector3(-3.7f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
                    Item_obj[i].name = "Item_Image_1"; Shop_tmp[i] = Item_number[i]; break;
                case 1:
                    Item_obj[i] = Instantiate(prefab[Item_number[i]], new Vector3(-0.15f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
                    Item_obj[i].name = "Item_Image_2"; Shop_tmp[i] = Item_number[i]; break;
                case 2:
                    Item_obj[i] = Instantiate(prefab[Item_number[i]], new Vector3(3.45f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
                    Item_obj[i].name = "Item_Image_3"; Shop_tmp[i] = Item_number[i]; break;
                  
            }
            Obj_button[i] = Item_obj[i].GetComponent<Button>();
            Item_Get_Check(i);
        }
        else
        {
            switch (i)
            {
                case 0:
                    Item_obj[i] = Instantiate(prefab[Shop_tmp[i]], new Vector3(-3.7f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
                    Item_obj[i].name = "Item_Image_1"; break;
                case 1:
                    Item_obj[i] = Instantiate(prefab[Shop_tmp[i]], new Vector3(-0.15f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
                    Item_obj[i].name = "Item_Image_2"; break;
                case 2:
                    Item_obj[i] = Instantiate(prefab[Shop_tmp[i]], new Vector3(3.45f, 1.52f, 0), Quaternion.identity, _parentGameObject.transform);
                    Item_obj[i].name = "Item_Image_3"; break;

            }
            Obj_button[i] = Item_obj[i].GetComponent<Button>();
            Item_Get_Check(i);
        }
       
        return Item_number[i];
    }
    /// <summary>
    /// Create_ShopItem�Ő�������A�C�e����prefab���烉���_���őI�o���܂�
    /// </summary>
    /// <param name="i"></param>
    void item_select(int i)
    {
       
        switch (ChangeScene.SCENE_CNT)
        {
            case 4: TheGrimreaper_flag  = true; break;
            case 7:Medhusa_flag         = true; break;
            case 9:Dragon_flag          = true; break;
            default:                 break;
        }
        if (TheGrimreaper_flag == true)
        {
            Shop_limit = 4;
            if (Medhusa_flag == true)
            {
                Shop_limit = 2;
                if (Dragon_flag == true)
                {
                    Shop_limit = 0;
                }
            }
        }

        switch(i)
        {
            case 0: Item_number[i] = Random.Range(1, prefab.Length - Shop_limit); break;
            case 1: do {Item_number[i] = Random.Range(1, prefab.Length - Shop_limit); } while (Item_number[0] == Item_number[1]); break;
            case 2: do {Item_number[i] = Random.Range(1, prefab.Length - Shop_limit); } while (Item_number[0] == Item_number[2] || Item_number[1] == Item_number[2]); break;
            case 3: Item_number[i] = 0;break;
        }
    }
    /// <summary>
    ///�@����ς݂̃A�C�e���I�u�W�F�N�g�������Ȃ����܂�
    /// </summary>
    /// <param name="i">�X�^�[�g�֐���for���̕ϐ�i�̒l</param>
    void Item_Get_Check(int i)
    {
        Item_Manager.Item.TryGetValue(Obj_button[i].tag, out bool tag_bool);
        if (tag_bool == true)
        {
            Obj_button[i].interactable = false;
        }
    }
}
