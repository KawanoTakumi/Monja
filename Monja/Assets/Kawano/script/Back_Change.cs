using UnityEngine;
using UnityEngine.UI;

public class Back_Change : MonoBehaviour
{
    public Image Back_image;//�w�i�摜
    public Sprite[] sprite;//�\���������摜�z��

    //�X�^�[�g���\�b�h
    //�����E�E�E�R���|�[�l���g���擾
    void Start()
    {
        Back_image = GetComponent<Image>();
    }

    //�A�b�v�f�[�g���\�b�h
    //�����E�E�E�V�[���J�E���g���ɕ\������摜��ύX����
    void Update()
    {
<<<<<<< HEAD
        //�V�[���J�E���g���ɉ摜��ύX
        switch(ChangeScene.SCENE_CNT)
=======
        //�V�[���J�E���g���ɉ摜��ύX�i�X�v���C�g�̔ԍ��ŊǗ��j
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