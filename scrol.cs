using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrol : MonoBehaviour
{
    public GameObject eraser;
    public GameObject cam;
    public float star, delta, delta2, die1 = 0;
    Rigidbody2D rigid;
    Rigidbody2D rigid2;
    Transform Eratra;
    Transform camtra;

    AudioSource audios;
    public AudioClip[] clips;
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponent<AudioSource>();
        Eratra = eraser.transform;
        camtra = cam.transform;
        rigid = eraser.GetComponent<Rigidbody2D>();
        rigid2 = cam.GetComponent<Rigidbody2D>();
    }

    public void Scr_Eraser(float x)
    {

        die1 = eraser.GetComponent<Control>().die;
        if (camtra.position.y >= 23)
        {
            if (Eratra.position.x <= 45f && camtra.position.x <= 57.5f)
            {
                cam.transform.position = new Vector3(Eratra.position.x + 12, Eratra.position.y, -15);
            }
            else
            {
                rigid2.velocity = new Vector3(0, -1 * x / 2, 0.0f);
                cam.transform.position = new Vector3(camtra.position.x, camtra.position.y, -15);
            }
        }

        else if (camtra.position.y <= 23)
        {
            cam.transform.position = new Vector3(57.5f, 23, -15);
        }


        if (Eratra.position.y <= 15f && camtra.position.x <= 290)
        {
            delta += Time.deltaTime;
            audios.clip = clips[0];
            audios.Play();
        }
        if (delta < 2f && delta > 1f)
        {
            cam.transform.position = new Vector3(57, 0, -15);
            Eratra.transform.position = new Vector3(53, 0, 0);
        }

        else if (delta >= 2f)
        {
            camtra.position = new Vector3(55 + delta * 4f, 0, -15);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float delta = eraser.GetComponent<Control>().delta;
        if (delta >= 1)
        {
            delta2 += Time.deltaTime;
            if (delta2 <= 2 && delta2 > 0 && die1 == 1)
            {
                Scr_Eraser(0);
                eraser.GetComponent<Control>().Move_Eraser(0);
            }
        }
        else
        {
            Scr_Eraser(4);
            eraser.GetComponent<Control>().Move_Eraser(5);
        }
    }
}
