using UnityEngine;
using UnityEngine.UI;

public class ending_script : MonoBehaviour
{
    public GameObject Cave_scene;//���A�̃V�[��
    public Text Ending_Text;//�G���f�B���O�p�e�L�X�g

    //���A�̃V�[�����폜
    public void Cave_del()
    {
        Cave_scene.SetActive(false);
    }

    public void Text_Change(int Number)
    {
        switch (Number)
        {
            case 1: Ending_Text.text = "�����A���A�̎�ł���h���S����\n�|�����Ƃ��ł�����l����";break;
            case 2: Ending_Text.text = "�p�������C�g�z�΂�\n��ʂɑ��݂��Ă����ԂɒH�蒅�����Ƃ��ł���";break;
            case 3: Ending_Text.text = "��l���̓p�������C�g�z�΂�\n��ʂɎ����A����"; break;
            case 4: Ending_Text.text = "�������ɓ���邱�Ƃ��ł���\n�������Ď�l���͖���B�����邱�Ƃ��ł���"; break;
            case 5: Ending_Text.text = "��������c�ɂ��������ׂē��܂�Ă��܂������E�E�E";break;
        }
    }
}
