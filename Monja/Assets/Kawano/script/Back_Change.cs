using UnityEngine;
using UnityEngine.UI;

public class Back_Change : MonoBehaviour
{
    public Image Back_image;//背景画像
    public Sprite[] sprite;//表示したい画像配列

    //スタートメソッド
    //説明・・・コンポーネントを取得
    void Start()
    {
        Back_image = GetComponent<Image>();
    }

    //アップデートメソッド
    //説明・・・シーンカウント毎に表示する画像を変更する
    void Update()
    {
<<<<<<< HEAD
        //シーンカウント毎に画像を変更
        switch(ChangeScene.SCENE_CNT)
=======
        //シーンカウント毎に画像を変更（スプライトの番号で管理）
        switch(ChangeScene.scene_cnt)
>>>>>>> 9440d7947f8c41c54bcf30d83cddef966fad4cab
        {
            case 1:
            case 2:Back_image.sprite = sprite[0];break;
            case 3:Back_image.sprite = sprite[1];break;
            case 4:
            case 5:Back_image.sprite = sprite[2];break;
            case 6:Back_image.sprite = sprite[3];break;
            case 7:
            case 8:Back_image.sprite = sprite[4];break;
            case 9:Back_image.sprite = sprite[5];break;
        }
    }
}