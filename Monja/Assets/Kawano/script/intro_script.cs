using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class intro_script : MonoBehaviour
{
    public Text text_box;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Change_Text(int text_num)
    {
        switch (text_num)
        {
            default:text_box.text = "";break;
            case 1: text_box.text = "������A�˔@�Ƃ��ĊX�̒��ɑ匊�����ꂽ";break;
            case 2: text_box.text = "�匊�̉��n�Ŕ������ꂽ���m�̕���\n�f�p�������C�g�z�΁B'";break;
            case 3: text_box.text = "���̕����͂ƂĂ��M�d�ō��z�Ŏ������Ă���B\n��l���͑�������ɂȂ邽��\n�匊�̒��֌������̂ł������B"; break;
            case 4: text_box.text = "�E�E�E�������点�Č��̒��ɗ����Ȃ���B";break;
            case 5: SceneManager.LoadScene("work_01");break;
        }
    }
}