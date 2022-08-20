using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    public float x, y, angle,tim,share = 0;
    public static float times = 0;
    Rigidbody2D rigid;
    AudioSource audios;
    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        audios = GetComponent<AudioSource>();
    }
    void Update()
    {
        Change_Angles();
        Move_Eraser();
    }
    public void Change_Angles()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))//角度を変えてリセット
        {
            angle++;
        }
        if (Input.GetKey(KeyCode.X))//Xを押すと伸びる
        {
            times += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Z))//Zを押すと縮む
        {
            times -= Time.deltaTime;
        }
        {//角度取得
            if (angle % 2 == 1)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (times<0)
        {
            times = 0;
        }
        if (times > 0.9f)
        {
            times = 0.9f;
            tim = 1;
        }
        x =1 - times;
        y = 2 + (2 * times);
        transform.localScale = new Vector3(x, y, 1);
    }

    public void Move_Eraser()
    {
        float eraser_velocity_x = 0;
        float eraser_velocity_y = 0;
        float kon = 5f;

        //以下入力キー
        if (Input.GetKey(KeyCode.RightArrow))
        {
            eraser_velocity_x = kon;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            eraser_velocity_x =  -1*kon;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            eraser_velocity_y =kon;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            eraser_velocity_y =  -1*kon;
        }
                rigid.velocity = new Vector3(eraser_velocity_x, eraser_velocity_y, 0);
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "arrow")
        {
            Debug.Log("Fuck!!!!!!!!!");
        }
    }
    }
