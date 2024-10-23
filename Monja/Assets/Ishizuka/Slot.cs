using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image icon;
    public GameObject removeButton;
    Item item;
    //�A�C�e����ǉ�����
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = newItem.icon;
        removeButton.SetActive(true);
    }
    //�A�C�e������菜��
    public void ClearItem()
    {
        item = null;
        icon.sprite = null;
        removeButton.SetActive(false);
    }
    //�A�C�e���̏����{�^��
    public void OnRemoveButton()
    {
        Inventry.instance.Remove(item);
    }
    //�A�C�e���̎g�p�{�^��
    public void UseItem()
    {
        if (item == null)
        {
            return;
        }
        item.Use();
    }
}