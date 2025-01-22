using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class intro_script : MonoBehaviour
{
    public Text Text_box;                           //�e�L�X�g�{�b�N�X
    public AudioSource SE_source;                   //SE�̃\�[�X
    [SerializeField] AudioClip[] SE_clip;           //SE�̃N���b�v�z��

    //�e�L�X�g�ύX�֐�(�ύX����e�L�X�g�ԍ�)
    public void Change_Text(int Text_num)
    {
        //�����̒l�ɉ����ăe�L�X�g�̓��e��ύX����
        switch (Text_num)
        {
            default:Text_box.text = "";break;
            case 1: Text_box.text = "������A�˔@�Ƃ��ĊX�̒��ɑ匊�����ꂽ";break;
            case 2: Text_box.text = "�匊�̉��n�Ŕ������ꂽ���m�̕���\n�w�p�������C�g�z�΁x";break;
            case 3: Text_box.text = "���̕����͂ƂĂ��M�d�ō��z�Ŏ������Ă���B\n��l���͑�������ɂȂ邽��\n�匊�̒��֌������̂ł������B"; break;
            case 4: Text_box.text = "�E�E�E�������点�Č��̒��ɗ����Ȃ���B";break;
            case 5: SceneManager.LoadScene("work_01");break;
        }
    }
    //�C���g���pSE�Đ��֐�(SE�̔ԍ�)
    public void SE_Play_Intro(int Set_num)
    {
        //set_num����SE���Đ�����
        switch (Set_num)
        {
            case 1: SE_source.PlayOneShot(SE_clip[0]);break;//����
            case 2: SE_source.PlayOneShot(SE_clip[1]);break;//�т�����
            case 3: SE_source.PlayOneShot(SE_clip[2]);break;//������
        }
    }

    //�C���g���pSE�X�g�b�v�֐�
    public void SE_Stop_Intro()
    {
        SE_source.Stop();
    }
}