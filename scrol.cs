using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrol : MonoBehaviour
{
    public GameObject eraser;
    public GameObject cam;
    public float star = 0;
    Rigidbody2D rigid;
    Rigidbody2D rigid2;
    Transform Eratra;
    Transform camtra;
    // Start is called before the first frame update
    void Start()
    {
        Eratra = eraser.transform;
        camtra = cam.transform;
        rigid = eraser.GetComponent<Rigidbody2D>();
        rigid2 = cam.GetComponent<Rigidbody2D>();
    }
    public void Star()
    {
        if (camtra.position.x-Eratra.position.x >30f)
        {
            star = 1;
        }
        else
        {
            star = 0;
        }
    }
    
    public void Scr_Eraser()
    {
        if (star == 0) { 
            Vector3 velo = new Vector3(3f, 0.0f, 0.0f);
           // rigid.velocity = velo;
            rigid2.velocity = velo;
        }
        else
        {
            eraser.SetActive(false);
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        Star();
        Scr_Eraser();
    }
}
