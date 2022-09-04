using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Text_Script : MonoBehaviour
{
    GameObject txt_size;
    GameObject die,but;
    public GameObject Eraser;
    public float Another=0;
    // Start is called before the first frame update
    void Start()
    {
        txt_size = GameObject.Find("Text_Eraser_Size");
        die = GameObject.Find("DIE_Text");
    }

    // Update is called once per frame
    void Update()
    {
        Another = Eraser.GetComponent<Control>().stop;
        float y = Eraser.transform.localScale.y;
        float x = Eraser.transform.localScale.x;
        { if (Eraser.transform.rotation.z == 0)
        {
            this.txt_size.GetComponent<Text>().text = "サイズ\nたて：" + y.ToString("F2") + "\nよこ：" + x.ToString("F2");
        }
        else
        {
            this.txt_size.GetComponent<Text>().text = "サイズ\nたて：" + x.ToString("F2") + "\nよこ：" + y.ToString("F2");
        } }

        if (Another == 1)
        {
            this.die.GetComponent<Text>().text = "GAME OVER";
        }
    }
}
