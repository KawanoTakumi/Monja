using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ending_script : MonoBehaviour
{
    public GameObject scene;//�V�[��
    public Text text_box;//�e�L�X�g�{�b�N�X
    //���A�̃V�[�����폜
    public void cave_del()
    {
        scene.SetActive(false);
    }

    public void Text_Change(int Number)
    {
        switch (Number)
        {
            case 1:text_box.text = "�����A���A�̎�ł���h���S����\n�|�����Ƃ��ł�����l����";break;
            case 2:text_box.text = "�p�������C�g�z�΂�\n��ʂɑ��݂��Ă����ԂɒH�蒅�����Ƃ��ł���";break;
            case 3:text_box.text = "��l���̓p�������C�g�z�΂��ʂ�\n�����A����"; break;
            case 4:text_box.text = "�������ɓ���邱�Ƃ��ł���\n�������Ď�l���͖���B�����邱�Ƃ��ł���"; break;
            case 5:text_box.text = "��������c�ɂ��������ׂē��܂�Ă��܂������E�E�E";break;
        }
    }
}
