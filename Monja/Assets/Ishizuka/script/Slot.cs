
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
        
        removeButton.SetActive(true);
    }
}