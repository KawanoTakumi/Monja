using UnityEngine;

public class Status_Controller : MonoBehaviour
{
    public GameObject[] Effects;//ステータスエフェクト
    public static GameObject eff_obj;
    GameObject _parent;//親オブジェクト
    public PlayerController player;
    
    public void Status_Effect(bool player_flag, int number)
    {
        switch(player_flag)
        {
            case true:_parent = GameObject.Find("Player");break;
            case false:_parent = GameObject.Find("Monster");break;
        }
        switch(number)
        {
            case 0:Create_Effect_Status(0, 0.0f, 0.0f);break;//凍結
            case 1:Create_Effect_Status(1, 0.0f, 0.0f);break;//石化
            case 2:Create_Effect_Status(2, 0.0f, 0.0f);break;//毒
            case 3:Create_Effect_Status(3, 0.0f, 0.0f);break;//延焼
        }
    }
    public void Create_Effect_Status(int number, float Fx, float Fy)
    {
        eff_obj = Instantiate(Effects[number], new Vector3(Fx, Fy, 0), Quaternion.identity, _parent.transform);
        eff_obj.name = "Effect_image_" + number;
    }
    public void Delete_Effect()
    {
        Destroy(eff_obj);
    }
}