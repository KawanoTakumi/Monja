using UnityEngine;
using UnityEngine.UI;

public class Item_text : MonoBehaviour
{
    public Button button;   //�{�^��
    Text Item_name;         //�A�C�e���̖��O
    Text Item_guide_text;        //�A�C�e���̐�����

    //�X�^�[�g���\�b�h
    //�����E�E�E�R���|�[�l���g�擾
    void Start()
    {
        //�e��l���ŏ��Ɏ擾
        GameObject Name = GameObject.Find("Item_Name");
        Item_name = Name.GetComponent<Text>();
        GameObject Text = GameObject.Find("Item_Text");
        Item_guide_text = Text.GetComponent<Text>();
        button = GetComponent<Button>();
        button.interactable = true;
    }

    //�{�^���������ꂽ�Ƃ�
    public void Hit_button()
    {
        if (button == CompareTag("bowlingball"))
        {
            Item_name.text = "�{�E�����O�̋�";
            Item_guide_text.text = "�{�E�����O�Ɏg���Ă����ʁB�����d���B\n\n�����U���͂��Q�O�㏸�����A�����h��͂��Q�O����������";
        }
        else if (button == CompareTag("radio"))
        {
            Item_name.text = "���W�I";
            Item_guide_text.text = "�����𖳐��ʐM�ŖT���ł���@�B�B�ǂ����ő̑����n�܂�B\n\n���^�[���J�n���ɖh��͂��P�O���������AHP���T����������";
        }
        else if (button == CompareTag("healdrink"))
        {
            Item_name.text = "LIFE";
            Item_guide_text.text = "�ʃW���[�X�B�Â��Ă��������B\n\n[����A�C�e��] �̗͂��T�O�񕜂���B�i�J�C�t�N�������Ǝg�p�ł���j";
        }
        else if (button == CompareTag("hourglass"))
        {
            Item_name.text = "�����v";
            Item_guide_text.text = "�����g�������v�B���Ԃ͗L���B\n\n���^�[���J�n���ɕ����U���͂��P�O�㏸�����A�̗͂��T����������";
        }
        else if (button == CompareTag("cd"))
        {
            Item_name.text = "CD";
            Item_guide_text.text = "�f���≹�y���������ނ��Ƃ��ł���B��������ɂ����B\n\n�����h��͂������قǁA�����U���͂��㏸������";
        }
        else if (button == CompareTag("CDplayer"))
        {
            Item_name.text = "CD�v���[���[";
            Item_guide_text.text = "CD���Z�b�g���邱�Ƃŉ��y�𒮂���BCD�͂ǂ��H\n\n�����h��͂��Q�O�㏸�����A�����U���͂��Q�O����������";
        }
        else if (button == CompareTag("kesigomu"))
        {
            Item_name.text = "�����S��";
            Item_guide_text.text = "���������̂�������B���ʂȂ��̂��������B\n\n�����U���͂��Q�O���������A�����U���͂������قǖ��@�U���͂�������";
        }
        else if (button == CompareTag("TV"))
        {
            Item_name.text = "�e���r";
            Item_guide_text.text = "�f���������ł���@�B�B���Ȃ��̂��D���Ȕԑg�͉��H\n\n���@�U���͂T�ɂ����@�U���͂��R�㏸������";
        }
        else if (button == CompareTag("CreditCard"))
        {
            Item_name.text = "�N���W�b�g�J�[�h";
            Item_guide_text.text = "���������Ă�����J�[�h�B�F�ł��̐l�̉��l���킩��B\n\n�퓬�J�n��Q�OG�������ɒǉ�����\n";
        }
        else if (button == CompareTag("Mouse"))
        {
            Item_name.text = "�}�E�X";
            Item_guide_text.text = "�p�\�R�����g���Ƃ��ɕK�{�̋@�B�B�}�E�X�Ȃ��͍l�����Ȃ��B\n\n���@�U���͂��P�O����������";
        }
        else if (button == CompareTag("HandMirror"))
        {
            Item_name.text = "�n���h�~���[";
            Item_guide_text.text = "��y�ɗe�p���m�F�ł���R���p�N�g�ȋ��B���拾�A�������̂͒N�H\n\n�����h��͂Ɩ��@�h��͂��P�T����������";
        }
        else if (button == CompareTag("bowlingpin"))
        {
            Item_name.text = "�{�E�����O�s��";
            Item_guide_text.text = "�{�E�����O�œ��_�����߂邽�߂̂��́B�l�ɂ͂��ĂȂ��ŁB\n\n�퓬�J�n���A�����U���͂������قǊl�����z������";
        }
        else if (button == CompareTag("baseball_ball"))
        {
            Item_name.text = "�싅�{�[��";
            Item_guide_text.text = "�싅�p�̃{�[���B�X�g���[�C�N�A�o�b�^�[�A�E�g�I\n\n�����U���͂��P�T�����������h��͂��P�O����������";
        }
        else if (button == CompareTag("dice"))
        {
            Item_name.text = "�T�C�R��";
            Item_guide_text.text = "�����_���Ő��������߂邽�߂̓���B�Pd�U? �Qd�U?\n\n���^�[���J�n���Ƀ����_���Ȍ��ʂ𔭓�";
        }
        else if (button == CompareTag("Water bucket"))
        {
            Item_name.text = "������̃o�P�c";
            Item_guide_text.text = "�����������o�P�c�B�A�C�X�o�P�c�`�������W�I�I�I\n\n���@�h��͂��P�O����������";
        }
        else if (button == CompareTag("Popcorn"))
        {
            Item_name.text = "�|�b�v�R�[��";
            Item_guide_text.text = "�g�E�����R�V�������ł͂������������َq�B�f��ɂ͕K�{�̂����B\n\n�퓬�J�n���A�̗͂��Q�O�񕜂�����";
        }
        else if (button == CompareTag("Apple"))
        {
            Item_name.text = "�����S";
            Item_guide_text.text = "�Ԃ��ĊÂ��؂Ɏ���ʎ��B�Ђ�߂��̎�B\n\n�퓬�J�n���A�̗͂��R�O�񕜂��A���@�U���͂��P�T����������";
        }
        else if (button == CompareTag("Scissors"))
        {
            Item_name.text = "�n�T�~";
            Item_guide_text.text = "���┯�Ȃǂ�؂邽�߂̂�����B�ǂ�ȃJ�b�g�����D�݁H\n\n�����U���͂��Q�O���������邪�^�[�����ɕ����h��͂��Q����������";
        }
        else if (button == CompareTag("ice"))
        {
            Item_name.text = "�X";
            Item_guide_text.text = "���𓀂点��Ƃł��镨�́B�����X�ɂ��܂����H\n���@�U���͂��P�O���������A�X�̒e�ōU������B\n�i�A�C�e����ʂŃA�C�e���������Ɩ��@�U�����ω��j";
        }
        else if (button == CompareTag("Pudding"))
        {
            Item_name.text = "�v����";
            Item_guide_text.text = "���������Ȃǂƈꏏ�Ɍł߂��Â����َq�B�����̎��ԁB\n�퓬�J�n���̗͂��ő�l�̂Q�T�����񕜂���B\n�܂��A�����S�������Ă���Ɛ퓬���Ƃɍő�̗͂��R�O��������";
        }
        else if (button == CompareTag("Drill"))
        {
            Item_name.text = "�h����";
            Item_guide_text.text = "���Ɍ����J���铹��B���̊J�������ɂ͒��ӁI�I\n\n�퓬�J�n���A�G�̖h��͂̔��������g�̕����U���͂ɉ��Z����B";
        }
        else if (button == CompareTag("Headphone"))
        {
            Item_name.text = "�w�b�h�t�H��";
            Item_guide_text.text = "���ɂ��邱�Ƃŉ��y�𕷂����Ƃ��ł��铹��B�����̐��E�ɓ����Ă��܂��B\n���^�[���J�n���ɕ����U���͂ƕ����h��͂��R���������đ̗͂��P�O��";
        }
        else if (button == CompareTag("UtypeMagnet"))
        {
            Item_name.text = "U���^�}�O�l�b�g";
            Item_guide_text.text = "U���^�̃}�O�l�b�g�B���͂Ȏ��͂�ттĂ���B�G�̕���������t��\n\n���@�U���͂Q�O��������";
        }
        else if (button == CompareTag("Coffee"))
        {
            Item_name.text = "�R�[�q�[";
            Item_guide_text.text = "�������������������B�ƂĂ��ꂢ�BChill Time !!!\n\n�̗͂��Q�O���炵���@�U���͂��R�O����������";
        }
        else if (button == CompareTag("Safetycone"))
        {
            Item_name.text = "�O�p�R�[��";
            Item_guide_text.text = "�댯�ȏꏊ�ɐݒu���Ă�����́B���܂ɏR����s�^�ȓz�B\n\n�퓬�J�n���A�Q�T���̊m���ŕ����U���͂ƕ����h��͂��S�O����";
        }
        else if (button == CompareTag("USB"))
        {
            Item_name.text = "USB������";
            Item_guide_text.text = "�p�\�R���������ۑ��ł���@�B�B�Ȃ�������I���B\n\n���@�U���͂��Q�O�����������@�h��͂��P�O����������";
        }
        else if (button == CompareTag("Smartphone"))
        {
            Item_name.text = "�X�}�[�g�t�H��";
            Item_guide_text.text = "�l�i�������l�X�ȋ@�\�̂����d�b�@��B��񂲂̃}�[�N�B\n\n���@�U���͂������قǖ��@�h��͂𑝉�������";
        }
        else if (button == CompareTag("ItypeMagnet"))
        {
            Item_name.text = "I���^�}�O�l�b�g";
            Item_guide_text.text = "I���^�̃}�O�l�b�g�BU���^�Ƃ������ĕς��Ȃ��B\n\n���@�h��͂��Q�O����������";
        }
        else if (button == CompareTag("Magnifying Speculum"))
        {
            Item_name.text = "���ዾ";
            Item_guide_text.text = "�����g�債�Č��邱�Ƃ��ł��铹��B�����Y���P���B\n\n���^�[���J�n���ɕ����h��͂Ɩ��@�h��͂��R����������";
        }
        else if (button == CompareTag("Mike"))
        {
            Item_name.text = "�}�C�N";
            Item_guide_text.text = "�����E�����Ƃ��ł���@�B�BSay Yeah!!\n���@�U���͂��R�O�����������̃m�C�Y�ōU������\n�i�A�C�e����ʂŃA�C�e���������Ɩ��@�U�����ω��j";
        }
        else if (button == CompareTag("Megaphone"))
        {
            Item_name.text = "���K�z��";
            Item_guide_text.text = "����傫������@�B�B�����吺���o���Ȃ��Ă������B\n\n�����h��͂��Q�O����������";
        }
        else if (button == CompareTag("HandMill"))
        {
            Item_name.text = "�n���h�~��";
            Item_guide_text.text = "����҂����߂̓���B���΂������肪���Ă邺�B\n�R�[�q�[�������Ă��鎞�A���@�U���͂��U�O����������\n�����Ă��Ȃ����͖��@�U���͂��R�O����������";
        }
        else if(button == CompareTag("Poteto"))
        {
            Item_name.text = "�|�e�g";
            Item_guide_text.text = "�W���K�C������ŗg�����H�ו��B�H�ׂ�̂���߂��Ȃ��B\n�n���o�[�K�[�������Ă��鎞�����U���͂��U�O����������\n�����Ă��Ȃ����͕����U���͂��R�O����������";
        }
        else if (button == CompareTag("Scop"))
        {
            Item_name.text = "�V���x��";
            Item_guide_text.text = "�y���@������A�ς�����ł���B\n\n�퓬�J�n���S���̂P�̊m���ł������R�O���肷��";
        }
        else if (button == CompareTag("hammer"))
        {
            Item_name.text = "�n���}�[";
            Item_guide_text.text = "�l�X�ȗp�r�����閜�\�ȓ���B\n\n���^�[���J�n���ɂP�O���̂P�̊m���ő�����C�₳����";
        }
        else if (button == CompareTag("Speaker"))
        {
            Item_name.text = "�X�s�[�J�[";
            Item_guide_text.text = "���𑝕������鑕�u�B�J���e�b�g�H\n\n�G�̕����h��͂��Q�T����������";
        }
        else if (button == CompareTag("Sylinge"))
        {
            Item_name.text = "���ˊ�";
            Item_guide_text.text = "��ÖړI�Ŏg����A��[�����������B\n\n���^�[���J�n���ɂU���̂P�̊m���ő̗͂��R�O�񕜂����A����ȊO�̎��͂T�񕜂�����";
        }
        else if (button == CompareTag("Baseball_glove"))
        {
            Item_name.text = "�싅�O���[�u";
            Item_guide_text.text = "�싅�Ŏg����O���[�u�B��ɂ悭�t�B�b�g����B\n�����U���͂��Q�T����������B\n�싅�{�[���������Ă���A���@�U���͂��R�T����������";
        }
        else if (button == CompareTag("Boxing_glove"))
        {
            Item_name.text = "�{�N�V���O�O���[�u";
            Item_guide_text.text = "�{�N�V���O�Ŏg�p�����O���[�u,�ꔭKO�I�I\n\n�U���Q�L���������Ƃ������U���͂��R����������";
        }
        else if (button == CompareTag("Juice"))
        {
            Item_name.text = "�W���[�X";
            Item_guide_text.text = "�ʏ`�Ȃǂ��������������B�������͂킩��Ȃ��B\n\n�퓬�J�n���̗͂��Q�O�񕜂�����";
        }
        else if (button == CompareTag("Gas_burner"))
        {
            Item_name.text = "�K�X�o�[�i�[";
            Item_guide_text.text = "�K�X�ŔM�𐶂ݏo������B�_�f�����u���R�₹�I�I�I\n\n�����^�[���J�n���A�����U���͂��Q�T����������";
        }
        else if (button == CompareTag("Hamberger"))
        {
            Item_name.text = "�n���o�[�K�[";
            Item_guide_text.text = "�W�����N�t�[�h�̉��l�B�J�����[�������B����O�H�����B\n�|�e�g�������Ă��鎞�����U���͂��S�O����������\n�����Ă��Ȃ��Ƃ��͕����U���͂��Q�O����������";
        }
        else if (button == CompareTag("Pencil"))
        {
            Item_name.text = "���M";
            Item_guide_text.text = "�����������A�F��d���Ɏ�ނ�����BH or HB or B?\n\n�����U���͂��T�O���������邪���^�[���J�n���ɕ����U���͂��T����������";
        }
        else if (button == CompareTag("Mayonnaise"))
        {
            Item_name.text = "�}���l�[�Y";
            Item_guide_text.text = "���Ɩ��ō�钲�����B�ꕔ�̐l�͂�����������Ƃ����肷��Ƃ��B\n\n���@�U���͂��T�O���������邪���^�[���J�n���ɖ��@�U���͂��T����������";
        }
        else if (button == CompareTag("Watch"))
        {
            Item_name.text = "�r���v";
            Item_guide_text.text = "���Ԃ��C�y�Ɋm�F�ł���A�Љ�l�ɂ͕K�{�̃A�C�e���B\n\n��l���̗̑͂���������قǕ����U���͂𑝉�������";
        }
        else if (button == CompareTag("Scythe"))
        {
            Item_name.text = "���_�̊�";
            Item_guide_text.text = "�؂ꖡ���������B���܂Ŋ����Ă��܂��B\n\n�����U���͂��S�O���������A�N���e�B�J�������Ȃ蔭�����₷���Ȃ�";
        }
        else if (button == CompareTag("Robe"))
        {
            Item_name.text = "���_�̃��[�u";
            Item_guide_text.text = "���_�����Ă������[�u�B�Ђ���Ɨ₽���B\n\n�����h��͂��S�O���������A�N���e�B�J�����������₷���Ȃ�";
        }
        else if (button == CompareTag("Eye"))
        {
            Item_name.text = "���f���[�T�̖�";
            Item_guide_text.text = "���f���[�T�̖ځB��舵���ɂ͒��ӂ��K�v�B\n\n���@�h��͂��S�O���������A�N���e�B�J�����o�₷���Ȃ�";
        }
        else if (button == CompareTag("MagicBook"))
        {
            Item_name.text = "���f���[�T�̖�����";
            Item_guide_text.text = "���f���[�T���g���Ă����������B������Ă��镶���͉�ǂł��Ȃ��B\n���@�U���͂��S�O���������A�N���e�B�J�����o�₷���Ȃ�\n�i�A�C�e����ʂŃA�C�e���������Ɩ��@�U�����ω��j";
        }
        else if (button == CompareTag("Scale"))
        {
            Item_name.text = "�h���S���̗�";
            Item_guide_text.text = "�h���S���̑̕\�𕢂��Ă���؁B�ق�̂�ƒg�����B\n\n���^�[���J�n���ɑS�X�e�[�^�X���P�O����������";
        }
        else if (button == CompareTag("Tooth"))
        {
            Item_name.text = "�h���S���̉�";
            Item_guide_text.text = "�h���S���̉s����B��̂Ђ�ʂ̃T�C�Y�B\n\n�̗͂𔼕��Ɍ��炷����ɕ����U���͂��P�O�O����������";
        }
    }

    //���@�U�����ォ��ύX���邽�߂̊֐��i�A�C�e����ʂŃ{�^�����������炻�̖��@�U���ɂȂ�j
    public void magic_number(int num_M)
    {
        PlayerController.MAGIC_TYPE = num_M;
    }
}