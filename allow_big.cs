using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allow_big : MonoBehaviour
{
    public GameObject Eraser;
    Rigidbody2D rigid;
    Transform eratra, thistra;
    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        eratra = Eraser.transform;
        thistra = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (eratra.position.x-thistra.position.x >-14f)
        {
            rigid.velocity = new Vector3(-10f, 0f, 0f);
        }
    }
}
