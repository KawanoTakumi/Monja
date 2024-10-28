
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image icon;
    public GameObject removeButton;
    Item item;
    //ƒAƒCƒeƒ€‚ð’Ç‰Á‚·‚é
    public void AddItem(Item newItem)
    {
        item = newItem;
        
        removeButton.SetActive(true);
    }
}