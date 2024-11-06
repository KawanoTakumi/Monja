
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image icon;
    public GameObject removeButton;
    Dictionary item;
    //ƒAƒCƒeƒ€‚ð’Ç‰Á‚·‚é
    public void AddItem(Dictionary newItem)
    {
        item = newItem;
        
        removeButton.SetActive(true);
    }
}