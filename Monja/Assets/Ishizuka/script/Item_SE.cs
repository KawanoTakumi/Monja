using UnityEngine;


public class Item_SE : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        //�I�[�f�B�I�\�[�X�擾
        audioSource = GetComponent<AudioSource>();
    }

    public void hit_se()
    {
        // ���ʉ���炷
        GetComponent<AudioSource>().Play();  
    }
}