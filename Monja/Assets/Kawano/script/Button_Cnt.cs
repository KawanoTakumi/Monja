using UnityEngine;
using UnityEngine.UI;

public class Button_Cnt : MonoBehaviour
{
    public GameObject Title_button;//タイトルボタンオブジェクト
    public Text title_text;//タイトルに戻るテキスト
    // Update is called once per frame
    void Update()
    {
        //シーンカウントが0の時、タイトルに戻るボタンを削除
        if(ChangeScene.SCENE_CNT == 0)
        {
            Destroy(Title_button);
            Destroy(title_text);
        }
    }
}