using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreTriggerScript : MonoBehaviour
{
    public GameObject StoreUI;
    private bool collided = false;

    private void Update()
    {
        if (collided & Input.GetKeyDown(KeyCode.I))
        {
            StoreUI.SetActive(true);
        }


        else if (!collided)
        {
            StoreUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            collided = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            collided = false;
        }
    }
}
