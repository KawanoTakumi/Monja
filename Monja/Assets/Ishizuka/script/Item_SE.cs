using UnityEngine;


public class Item_SE : MonoBehaviour
{
    private AudioSource AudioSource;

    private void Start()
    {
        //�I�[�f�B�I�\�[�X�擾
        AudioSource = GetComponent<AudioSource>();
    }

    public void Hit_se()
    {
        // ���ʉ���炷
        GetComponent<AudioSource>().Play();  
    }
}