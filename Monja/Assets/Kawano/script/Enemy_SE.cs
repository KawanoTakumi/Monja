using UnityEngine;

public class Enemy_SE : MonoBehaviour
{
    public AudioSource SE_source;//オーディオソース
    //オーディオクリップ（配列）
    [SerializeField] AudioClip[] SE_audio_clip;
    ////モンスター用SE関数(SEの番号)
    public void SE_Monster(int SE_number)
    {
        switch (SE_number)
        {
            case 1:SE_source.PlayOneShot(SE_audio_clip[0]);break;//敵攻撃
            case 2:SE_source.PlayOneShot(SE_audio_clip[1]);break;//敵防御
            case 3:SE_source.PlayOneShot(SE_audio_clip[2]);break;//敵死亡
        }
    }
    //SEストップ関数
    public void SE_Del()
    {
        SE_source.Stop();//SEをストップさせる
    }
}