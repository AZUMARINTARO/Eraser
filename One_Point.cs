using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_Point : MonoBehaviour
{
    string str1, str2, str3;//注意事項ナンバー
    GameObject text;//注意事項のこと
    public GameObject cam;//カメラ
    public GameObject but;//ボタンのこと
    public float Stop = 0;
    Vector3 bottom;
    Rigidbody2D rigid;
    Rigidbody2D rigid2;
    // Start is called before the first frame update
    void Start()
    {
        bottom= new Vector3(0, -5000f, 0);
        rigid = this.GetComponent<Rigidbody2D>();
        rigid2 = cam.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Stop == 0)
        {
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid2.constraints = RigidbodyConstraints2D.None;
        }
        else
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            rigid2.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

    public void Deleate_Button()
    {
        Stop = 0;
        text.transform.position = new Vector3(0f, -5000f, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "One_Point")
        {
            str1 = other.gameObject.name;
            str2 = str1.Substring(9, 1);
            str3 = "Button" + str2;
            this.text = GameObject.Find(str3);
            text.transform.position = new Vector3(768f, 345.5f, 0);
            Stop = 1;
        }
    }
    }

