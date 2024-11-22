using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSE : MonoBehaviour
{
    private new AudioSource audio;
    public AudioClip Sound;
    private string songName;

    Camera mainCamera;
    GameObject targetObject;
    RaycastHit hit;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        mainCamera = Camera.main;

        SetCursor(true);
    }
    void Update()
    {
        // �}�E�X�̍��{�^�����������ꂽ��A�ΏۃI�u�W�F�N�g�𒲂ׂ鏈��
        if (Input.GetMouseButtonDown(0))
        {
            LookUpTargetObject();
            return;
        }
        CastRay();
    }
    void OnDisable()
    {
        SetCursor(true);
    }
    ////�}�E�X��UI�̏�ɏ�����特����
    //void OnMouseEnter()
    //{
    //    Debug.Log("abcd");
    //        GetComponent<AudioSource>().Play();  // ���ʉ���炷
    //}
    //void OnMouseExit()
    //{
    //    Debug.Log("�}�E�X���I�u�W�F�N�g���痣��܂����B");
        
    //}
    // �}�E�X�J�[�\���̈ʒu����u���C�v���΂��āA�����̃R���C�_�[�ɓ����邩�ǂ������`�F�b�N
    void CastRay()
    {
        //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 origin = Input.mousePosition;
        Vector3 direction = new Vector3(0, 0, 1);
        //Debug.Log(direction);
        //Debug.Log(origin);
        //if (Physics.Raycast(ray.origin, direction, out hit, Mathf.Infinity))
        if (Physics.Raycast(origin, direction, out hit, Mathf.Infinity))
            {
                Debug.Log("narasuyo");

            targetObject = hit.collider.gameObject;
            SetCursor(false);
            Debug.Log("abcd");
            songName = "Mouse SE";
            Sound = (AudioClip)Resources.Load("Sound/" + songName);
            audio.PlayOneShot(Sound);
        }
        else
        {
            targetObject = null;
            SetCursor(true);
        }
    }
    void LookUpTargetObject()
    {
        //if (targetObject == null)
        //{
        //    return;
        //}
        //else if (targetObject == CompareTag("UI"))
        //{

        //}

        SetCursor(true);
        targetObject.CompareTag("UI");
        // ���̃R���|�[�l���g�𖳌��ɂ���i�������Ȃ��ƒ��ׂĂ���Œ��ɕʂ̃I�u�W�F�N�g�𒲂ׂ邱�Ƃ��ł��Ă��܂��j
        enabled = false;
    }
    void SetCursor(bool isDefault)
    {
        ;
    }
}
