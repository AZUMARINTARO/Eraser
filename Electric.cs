using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric : MonoBehaviour
{
    SpriteRenderer SpriteRenderer;
    float count = 0;
    public GameObject bar;
   public GameObject bar2;
    public void First_Electro()
    {
        bar.transform.Translate(0, -0.7f, 0);
        bar2.transform.Translate(0, 0.7f, 0);
    }
   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "negative" || other.gameObject.tag == "positive")
        {
            count++;
                other.GetComponent<SpriteRenderer>().color = Color.yellow;
            
        }
    }

    void Update()
    {
        if (count == 2)
        {
            First_Electro();
        }
    }
}
