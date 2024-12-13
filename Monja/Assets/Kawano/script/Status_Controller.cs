using UnityEngine;

public class Status_Controller : MonoBehaviour
{
    public GameObject[] Effects;//�X�e�[�^�X�G�t�F�N�g
    public static GameObject eff_obj;
    GameObject _parent;//�e�I�u�W�F�N�g
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
            case 0:Create_Effect_Status(0, 0.0f, 0.0f);break;//����
            case 1:Create_Effect_Status(1, 0.0f, 0.0f);break;//�Ή�
            case 2:Create_Effect_Status(2, 0.0f, 0.0f);break;//��
            case 3:Create_Effect_Status(3, 0.0f, 0.0f);break;//����
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