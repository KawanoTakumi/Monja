using UnityEngine;
using UnityEngine.UI;
public class PickUpItem : MonoBehaviour
{
    //Item�f�[�^������
    public Item item;
    
    void Start()
    {
        //�ݒ肵���A�C�R����\��������
        GetComponent<Image>().sprite = item.icon;
    }

//�C���x���g���ɃA�C�e����ǉ�
    public void PickUp()
    {
        Inventry.instance.Add(item);
        Destroy(gameObject);
    }
}
