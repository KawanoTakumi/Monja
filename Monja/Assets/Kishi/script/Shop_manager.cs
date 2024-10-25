using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Shop_manager: MonoBehaviour
{
    //�\��������摜�I�u�W�F�N�g��Raw�摜�R���|�[�l���g
    public RawImage img1;
    public RawImage img2;
    public RawImage img3;

    //bool stop1 = false;
    //bool stop2 = false;
    //bool stop3 = false;
    //bool restart = false;

    //�\��������摜���X�g
    public List<Texture> texture_list = new List<Texture>();

    // Start is called before the first frame update
    void Start()
    {

        img1 = GameObject.Find("DisplayImage").GetComponent<RawImage>();
        img2 = GameObject.Find("DisplayImage2").GetComponent<RawImage>();
        img3 = GameObject.Find("DisplayImage3").GetComponent<RawImage>();
        //1�`10�̉摜��ǂݍ���
        read_img(6);
        ChangeImage1();
        ChangeImage2();
        ChangeImage3();

       
    }

    private void Update()
    {

       
    }

    //���\�[�X����\�����������摜���w�肵���������ǂݍ��ފ֐�
    public void read_img(int n)
    {
        Texture tmp;
        for (int i = 1; i < n + 1; i++)
        {
            tmp = Resources.Load("img/"+i) as Texture;
            texture_list.Add(tmp);
        }
    }

    //�{�^���ŌĂяo�����֐�
    public void ChangeImage1()
    {
        //�P�`�\������摜�̐��������_���ŎZ�o
        int random1 = Random.Range(0, texture_list.Count);

        Debug.Log("�����_���l1��" + random1);

        img1.texture = texture_list[random1];
        texture_list.Remove(img1.texture);
    }

    public void ChangeImage2()
    {
        //�P�`�\������摜�̐��������_���ŎZ�o
        int random2 = Random.Range(0, texture_list.Count);

        Debug.Log("�����_���l2��" + random2);

        img2.texture = texture_list[random2];
        texture_list.Remove(img2.texture);
    }

    public void ChangeImage3()
    {
        //�P�`�\������摜�̐��������_���ŎZ�o
        int random3 = Random.Range(0, texture_list.Count);

        Debug.Log("�����_���l3��" + random3);

        img3.texture = texture_list[random3];
        texture_list.Remove(img3.texture);
    }
}
