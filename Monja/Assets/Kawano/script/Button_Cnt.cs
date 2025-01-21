using UnityEngine;
using UnityEngine.UI;

public class Button_Cnt : MonoBehaviour
{
    public GameObject Title_button;  //タイトルボタンオブジェクト
    public Text Title_text;          //タイトルボタンテキスト
    
    //アップデートメソッド
    //説明・・・最初のシーンの時、タイトルに戻るを削除
    void Update()
    {
        //シーンカウントが0の時、タイトルに戻るボタンを削除
        if(ChangeScene.SCENE_CNT == 0)
        {
            Destroy(Title_button);
            Destroy(Title_text);
        }
    }
}