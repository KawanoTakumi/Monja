using UnityEngine;
using UnityEngine.UI;

public class Item_interact_check : MonoBehaviour
{
    public Button button;//�{�^��
    //�C���x���g���̃A�C�e���̕\����؂�ւ���
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