using UnityEngine;


public class Item_SE : MonoBehaviour
{
    private AudioSource AudioSource;

    private void Start()
    {
        //オーディオソース取得
        AudioSource = GetComponent<AudioSource>();
    }

    public void Hit_se()
    {
        // 効果音を鳴らす
        GetComponent<AudioSource>().Play();  
    }
}