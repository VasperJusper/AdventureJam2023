using TMPro;
using UnityEngine;

public class CheckLevel : MonoBehaviour
{
    Transform LvTxt;
    Transform Text;

    private void Awake()
    {
        LvTxt = transform.Find("LvTxt");
        Text = transform.Find("Text (TMP)");

        string type = Text.GetComponent<TextMeshProUGUI>().text;
        int level = PlayerPrefs.GetInt(type);

        LvTxt.GetComponent<TextMeshProUGUI>().text = "Level: " + level;
    }
}
