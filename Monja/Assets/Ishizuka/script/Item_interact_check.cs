using UnityEngine;
using UnityEngine.UI;

public class Item_interact_check : MonoBehaviour
{
    public Button button;//ボタン
    //インベントリのアイテムの表示を切り替える
    void Start()
    {
        button.interactable = false;
    }
    void Update()
    {
        button.interactable = false;

        if (Item_Manager.Item[button.tag] == true)
            button.interactable = true;
    }
}