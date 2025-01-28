using UnityEngine;

public class Status_Controller : MonoBehaviour
{
    public GameObject[] Effects;//ステータスエフェクト
    public static GameObject eff_obj;//エフェクトオブジェクト
    GameObject _parent;//親オブジェクト
    
    //ステータスオブジェクト
    public void Status_Effect(bool player_flag, int number)
    {
        //プレイヤーかどうか
        switch(player_flag)
        {
            case true:_parent = GameObject.Find("Player"); break;
            case false:_parent = GameObject.Find("Monster");break;
        }
        //状態異常
        switch(number)
        {
            case 0:Create_Effect_Status(0);break;//凍結
            case 1:Create_Effect_Status(1);break;//石化
            case 2:Create_Effect_Status(2);break;//毒
            case 3:Create_Effect_Status(3);break;//延焼
            case 4:Create_Effect_Status(4);break;//気絶
        }
    }
    //エフェクト作成関数（状態異常番号、位置X、位置Y）
    public void Create_Effect_Status(int number)
    {
        eff_obj = Instantiate(Effects[number], new Vector3(_parent.transform.position.x, _parent.transform.position.y, 0), Quaternion.identity, _parent.transform);
    }
    //削除関数
    public void Delete_Effect()
    {
        Destroy(eff_obj);
    }
}