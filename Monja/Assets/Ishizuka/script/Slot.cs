
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image icon;
    public GameObject removeButton;
    Dictionary item;
    //アイテムを追加する
    public void AddItem(Dictionary newItem)
    {
        item = newItem;
        
        removeButton.SetActive(true);
    }
}