using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float y2 = 7.5f;
    Rigidbody2D rigid;
   public float y;
    public GameObject eraser;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent < Rigidbody2D>();
        y = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (eraser.transform.position.x >= 270)
        {
            rigid.velocity = new Vector3(-1*y*y, -1*y, 0);
        }
        if (this.transform.position.x <= 275f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            if (this.transform.position.y <= 0 || this.transform.position.y >= y2)
            {
                y *= -1;
            }
        }
         }
}
