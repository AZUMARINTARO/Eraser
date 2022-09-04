    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Control : MonoBehaviour
    {

        public float x, y, angle, tim, share, add,delta,die,stop = 0;
        public static float times = 0;
        public GameObject cam,Scrol1;
        Rigidbody2D rigid;
        Rigidbody2D rigid_cam;
        AudioSource audios;
    Transform camtra;
        public AudioClip[] clips;
        // Start is called before the first frame update
        void Start()
        {
        rigid = GetComponent<Rigidbody2D>();
            rigid_cam=cam.GetComponent<Rigidbody2D>();
            audios = GetComponent<AudioSource>();
        camtra = cam.transform;
        }
        public void Change_Angles()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)|| Input.GetKeyDown(KeyCode.RightShift))//角度を変えてリセット
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

            if (times < 0)
            {
                times = 0;
            }
            if (times > 0.9f)
            {
                times = 0.9f;
                tim = 1;
            }
            x = 1 - times+(add*2);
            y = 2 + (2 * times)+(add*2);
            transform.localScale = new Vector3(x, y, 1);
        }

        public void Move_Eraser(float x)
        {
        float eraser_velocity_x = 0;
        float eraser_velocity_y = 0;

            //以下入力キー
    if (Input.GetKey(KeyCode.RightArrow))
    {
       eraser_velocity_x = x;
    }
    if (Input.GetKey(KeyCode.LeftArrow))
    {
       eraser_velocity_x = -1 * x;
    }
        if (Input.GetKey(KeyCode.UpArrow))
        {
       eraser_velocity_y = x;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
       eraser_velocity_y = -1 * x;
        }
        rigid.velocity = new Vector3(eraser_velocity_x, eraser_velocity_y, 0);
        }


    //死んだときの関数
    public void Die1()
    {
        stop = 1;
        audios.clip = clips[1];
        audios.Play();
    }


    void OnTriggerEnter2D(Collider2D other)
        {
        if (other.gameObject.tag == "arrow")
        {
            if (add <= 0)
            {
                Die1();
            }
            else
            {
                add--;
            }
        }

        if (other.gameObject.tag == "grow")
        {
            die++;
               audios.clip = clips[0];
               audios.Play();
               add++;
           other.transform.position = new Vector3(0, 9000, 0);
        }

        if (other.gameObject.tag == "not_grow")
        {
            die++;
           audios.clip = clips[0];
           audios.Play();
           add--;
           other.transform.position = new Vector3(0, 9000, 0);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
    if(other.gameObject.tag == "grow" || other.gameObject.tag == "not_grow")
    {
       delta = 0;
            die = 0;
    }
    }

    void Update()
    {
    Change_Angles();

        //死ぬ
        if  (camtra.position.y - this.transform.position.y <= -12.5f|| camtra.position.x - this.transform.position.x > 30f)
        {
            Die1();
        }
    }
    }
