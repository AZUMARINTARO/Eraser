using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Measure : MonoBehaviour
{
    public GameObject eraser;
    Rigidbody2D rigid;
   public float delta = 0;
    float Up = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rigid = eraser.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "eraser")
        {
            delta += Time.deltaTime;
            if (delta < Up)
            {
                if (other.transform.localScale.x==1&& other.transform.localScale.y == 2)
                {
                    Debug.Log("Good");
                }
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            rigid.constraints = RigidbodyConstraints2D.None;
        }
    }
}
