using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDeleter : MonoBehaviour
{
    float stopwatch = 0;

    TextMeshProUGUI m_TextMeshProUGUI;

    private void Start()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        stopwatch += Time.deltaTime;

        transform.position += new Vector3(0, 15, 1) * Time.deltaTime;
        m_TextMeshProUGUI.color = new Color(1, 1, 0, (2 - stopwatch) / 2);

        if(stopwatch > 2)
        {
            Destroy(gameObject);
        }
    }
}
