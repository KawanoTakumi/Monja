using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class intro_script : MonoBehaviour
{
    public Text Text_box;                           //テキストボックス
    public AudioSource SE_source;                   //SEのソース
    [SerializeField] AudioClip[] SE_clip;           //SEのクリップ配列

    //テキスト変更関数(変更するテキスト番号)
    public void Change_Text(int Text_num)
    {
        //引数の値に応じてテキストの内容を変更する
        switch (Text_num)
        {
            default:Text_box.text = "";break;
            case 1: Text_box.text = "ある日、突如として街の中に大穴が現れた";break;
            case 2: Text_box.text = "大穴の奥地で発見された未知の物質\n『パラレライト鉱石』";break;
            case 3: Text_box.text = "この物質はとても貴重で高額で取引されている。\n主人公は大金持ちになるため\n大穴の中へ向かうのであった。"; break;
            case 4: Text_box.text = "・・・足を滑らせて穴の中に落ちながら。";break;
            case 5: SceneManager.LoadScene("work_01");break;
        }
    }
    //イントロ用SE再生関数(SEの番号)
    public void SE_Play_Intro(int Set_num)
    {
        //set_num毎にSEを再生する
        switch (Set_num)
        {
            case 1: SE_source.PlayOneShot(SE_clip[0]);break;//足音
            case 2: SE_source.PlayOneShot(SE_clip[1]);break;//びっくり
            case 3: SE_source.PlayOneShot(SE_clip[2]);break;//落下音
        }
    }

    //イントロ用SEストップ関数
    public void SE_Stop_Intro()
    {
        SE_source.Stop();
    }
}