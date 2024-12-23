using UnityEngine;

public class Enemy_SE : MonoBehaviour
{
    public AudioSource SE_Source;//�I�[�f�B�I�\�[�X
    //�e�I�[�f�B�I�N���b�v
    [SerializeField] AudioClip se_1;
    [SerializeField] AudioClip se_2;
    [SerializeField] AudioClip se_3;
    //�����X�^�[�pSE�֐�
    public void SE_Monster(int num)
    {
        switch (num)
        {
            case 1:SE_Source.PlayOneShot(se_1);break;
            case 2:SE_Source.PlayOneShot(se_2);break;
            case 3:SE_Source.PlayOneShot(se_3);break;
        }
    }
    //SE�X�g�b�v�֐�
    public void SE_Del()
    {
        SE_Source.Stop();
    }
}