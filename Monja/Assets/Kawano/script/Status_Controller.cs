using UnityEngine;

public class Status_Controller : MonoBehaviour
{
    public GameObject[] Effects;//�X�e�[�^�X�G�t�F�N�g
    public static GameObject eff_obj;//�G�t�F�N�g�I�u�W�F�N�g
    GameObject _parent;//�e�I�u�W�F�N�g
    public PlayerController player;//�v���C���[
    
    //�X�e�[�^�X�I�u�W�F�N�g
    public void Status_Effect(bool player_flag, int number)
    {
        //�v���C���[���ǂ���
        switch(player_flag)
        {
            case true:_parent = GameObject.Find("Player");break;
            case false:_parent = GameObject.Find("Monster");break;
        }
        //��Ԉُ�
        switch(number)
        {
            case 0:Create_Effect_Status(0, 0.0f, 0.0f);break;//����
            case 1:Create_Effect_Status(1, 0.0f, 0.0f);break;//�Ή�
            case 2:Create_Effect_Status(2, 0.0f, 0.0f);break;//��
            case 3:Create_Effect_Status(3, 0.0f, 0.0f);break;//����
        }
    }
    //�G�t�F�N�g�쐬�֐��i��Ԉُ�ԍ��A�ʒuX�A�ʒuY�j
    public void Create_Effect_Status(int number, float Fx, float Fy)
    {
        eff_obj = Instantiate(Effects[number], new Vector3(Fx, Fy, 0), Quaternion.identity, _parent.transform);
        eff_obj.name = "Effect_image_" + number;
    }
    //�폜�֐�
    public void Delete_Effect()
    {
        Destroy(eff_obj);
    }
}