using UnityEngine;
using UnityEngine.UI;

public class Button_Cnt : MonoBehaviour
{
    public GameObject Title_button;//�^�C�g���{�^���I�u�W�F�N�g
    public Text title_text;//�^�C�g���ɖ߂�e�L�X�g
    // Update is called once per frame
    void Update()
    {
        //�V�[���J�E���g��0�̎��A�^�C�g���ɖ߂�{�^�����폜
        if(ChangeScene.SCENE_CNT == 0)
        {
            Destroy(Title_button);
            Destroy(title_text);
        }
    }
}