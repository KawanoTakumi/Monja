using UnityEngine;

public class Setting_Manager : MonoBehaviour
{
    public AudioSource[] Audio_source;//Audio用ソース
    //public AudioSource SE_source;//SE用ソース
    void Update()
    {
        //音楽のボリュームをすべて一定にする
        Audio_source[0].volume = Slider_Manager.Music_Volume;
        Audio_source[1].volume = Audio_source[0].volume;
        Audio_source[2].volume = Audio_source[0].volume;
        Audio_source[3].volume = Audio_source[0].volume;
        Audio_source[4].volume = Audio_source[0].volume;
        Audio_source[5].volume = Audio_source[0].volume;
    }
}