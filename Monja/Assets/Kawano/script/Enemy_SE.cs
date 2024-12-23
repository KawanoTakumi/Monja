using UnityEngine;

public class Enemy_SE : MonoBehaviour
{
    public AudioSource SE_Source;//オーディオソース
    //各オーディオクリップ
    [SerializeField] AudioClip se_1;
    [SerializeField] AudioClip se_2;
    [SerializeField] AudioClip se_3;
    //モンスター用SE関数
    public void SE_Monster(int num)
    {
        switch (num)
        {
            case 1:SE_Source.PlayOneShot(se_1);break;
            case 2:SE_Source.PlayOneShot(se_2);break;
            case 3:SE_Source.PlayOneShot(se_3);break;
        }
    }
    //SEストップ関数
    public void SE_Del()
    {
        SE_Source.Stop();
    }
}