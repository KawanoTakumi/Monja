using UnityEngine;

public class Enemy_SE : MonoBehaviour
{
    public AudioSource SE_source;//�I�[�f�B�I�\�[�X
    //�I�[�f�B�I�N���b�v�i�z��j
    [SerializeField] AudioClip[] SE_audio_clip;
    ////�����X�^�[�pSE�֐�(SE�̔ԍ�)
    public void SE_Monster(int SE_number)
    {
        switch (SE_number)
        {
            case 1:SE_source.PlayOneShot(SE_audio_clip[0]);break;//�G�U��
            case 2:SE_source.PlayOneShot(SE_audio_clip[1]);break;//�G�h��
            case 3:SE_source.PlayOneShot(SE_audio_clip[2]);break;//�G���S
        }
    }
    //SE�X�g�b�v�֐�
    public void SE_Del()
    {
        SE_source.Stop();//SE���X�g�b�v������
    }
}