using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class intro_script : MonoBehaviour
{
    public Text text_box;//�e�L�X�g�{�b�N�X
    public AudioSource audioSource_Work;//�����Ă��鎞��SE
    [SerializeField] AudioClip clip_work;//�����Ă��鎞
    [SerializeField] AudioClip clip_work_hapning;//�т�����
    [SerializeField] AudioClip clip_work_fall;//������
    public void Change_Text(int text_num)
    {
        switch (text_num)
        {
            default:text_box.text = "";break;
            case 1: text_box.text = "������A�˔@�Ƃ��ĊX�̒��ɑ匊�����ꂽ";break;
            case 2: text_box.text = "�匊�̉��n�Ŕ������ꂽ���m�̕���\n�w�p�������C�g�z�΁x";break;
            case 3: text_box.text = "���̕����͂ƂĂ��M�d�ō��z�Ŏ������Ă���B\n��l���͑�������ɂȂ邽��\n�匊�̒��֌������̂ł������B"; break;
            case 4: text_box.text = "�E�E�E�������点�Č��̒��ɗ����Ȃ���B";break;
            case 5: SceneManager.LoadScene("work_01");break;
        }
    }
    public void SE_Play_Intro(int set_num)
    {
        //set_num����SE���Đ�����
        switch (set_num)
        {
            case 1: audioSource_Work.PlayOneShot(clip_work);break;
            case 2: audioSource_Work.PlayOneShot(clip_work_hapning);break;
            case 3: audioSource_Work.PlayOneShot(clip_work_fall);break;

        }
    }
    public void SE_Stop_Intro()
    {
        audioSource_Work.Stop();
    }
}