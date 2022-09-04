using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric : MonoBehaviour
{
    public float count, electro, delta = 0;
  public  bool test = true;
    AudioSource audios;
    public AudioClip[] clips;
    Rigidbody2D rigid;
    float xx=0;
    public GameObject bar1, bar2, bar3, bar4, bar5;
    GameObject others;

    void Start()
    {
        audios = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        First_Electro();
        float x = 0.15f;
        if (count == 4)
        {
            Denki();
            bar4.transform.Translate(x, x * -1, 0);
            bar5.transform.Translate(x, x, 0);
        }
    }

    public void Denki()
    {
        //xx = others.transform.position.x;
        float x = this.transform.position.x;
        others.GetComponent<SpriteRenderer>().color = Color.yellow;
        delta += Time.deltaTime;

        if (delta <= 1&&delta>0&&xx-x<=4) { electro = 1;
            audios.clip = clips[0];
            audios.Play();
        }
        else
        {
            electro = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        others = other.gameObject;
        if (other.gameObject.tag == "negative" || other.gameObject.tag == "positive")
        {
            count++;
            }
        }

    void OnTriggerStay2D(Collider2D other)
    {
        others = other.gameObject;
        Rigidbody2D rigid = bar1.GetComponent<Rigidbody2D>();
        if (other.gameObject.tag == "First_ele")
        {
            Denki();
                rigid.velocity = new Vector3(20f, 0f, 0);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "First_ele")
        {
            delta = 0;
            count = 0;
            other.GetComponent<SpriteRenderer>().color = new Color32(190, 193, 195, 255);
        }

        else if(other.gameObject.tag == "negative" || other.gameObject.tag == "positive")
        {
            delta = 0;
        }
    }

    public void First_Electro()
    {
        float x = 0.15f;
        if (count == 2)
        {
            bar2.transform.Translate(x, x * -1, 0);
            bar3.transform.Translate(x, x, 0);
            Denki();
        }
    }}
