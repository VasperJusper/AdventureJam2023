using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;

public class DebryCollecter : MonoBehaviour
{
    Transform Canvas;

    int Debris = 0;
    TextMeshProUGUI DebrisTxt;

    GameObject CollectingTxt;

    private void Start()
    {
        Debris = PlayerPrefs.GetInt("Debris");

        Canvas = GameObject.Find("Canvas").transform;

        DebrisTxt = Canvas.Find("Menu").Find("GeneralMenuBackground").Find("DebrisImg").Find("Text").GetComponent<TextMeshProUGUI>();
        WriteDebryCount();

        CollectingTxt = Resources.Load<GameObject>("CollectingTxt");
    }

    void WriteDebryCount()
    {
        DebrisTxt.text = Debris + " Debris";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Debris")
        {
            int _count = Random.Range(1, 5);
            Debris += _count;
            WriteDebryCount();
            Destroy(collision.gameObject);
            GameObject newtxtobj = Instantiate(CollectingTxt, new Vector3(1100, 0, 0), Quaternion.identity, Canvas);
            newtxtobj.GetComponent<TextMeshProUGUI>().text = "+" + _count + " Debris";
        }
    }
}
