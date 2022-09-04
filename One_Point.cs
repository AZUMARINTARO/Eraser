using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_Point : MonoBehaviour
{
    string str1, str2, str3;//注意事項ナンバー
    GameObject text;//注意事項のこと
    public GameObject cam;//カメラ
    public GameObject but;//ボタンのこと
    public float Stop,die,Another,electronics,delta = 0;
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
        die = this.GetComponent<Control>().die;
        Another = this.GetComponent<Control>().stop;
        electronics = this.GetComponent<Electric>().electro;
        delta = this.GetComponent<Electric>().delta;

        if (Stop == 0 && Another == 0 && electronics != 1 && (delta >= 1 || delta == 0) && die == 0)
        {
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid2.constraints = RigidbodyConstraints2D.None;
        }
        else if (Another == 1 || Stop == 1 || electronics == 1 || (delta > 0 && delta < 1) || die >= 1)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePosition;
            rigid2.constraints = RigidbodyConstraints2D.FreezePosition;
        }

        if (Input.GetKey(KeyCode.Return))
        {
            Stop = 0;
            text.transform.position = new Vector3(0f, -5000f, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "One_Point")
        {
            str1 = other.gameObject.name;
            str2 = str1.Substring(9, 1);
            str3 = "Button" + str2;
            this.text = GameObject.Find(str3);
            text.transform.position = new Vector3(708f, 345.5f, 0);
            Stop = 1;
        }
    }
    }

