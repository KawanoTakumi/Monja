using UnityEngine;
using UnityEngine.UI;

public class Button_Cnt : MonoBehaviour
{
    public GameObject Title_button;  //�^�C�g���{�^���I�u�W�F�N�g
    public Text Title_text;          //�^�C�g���{�^���e�L�X�g
    
    //�A�b�v�f�[�g���\�b�h
    //�����E�E�E�ŏ��̃V�[���̎��A�^�C�g���ɖ߂���폜
    void Update()
    {
        //�V�[���J�E���g��0�̎��A�^�C�g���ɖ߂�{�^�����폜
        if(ChangeScene.SCENE_CNT == 0)
        {
            Destroy(Title_button);
            Destroy(Title_text);
        }
    }
}