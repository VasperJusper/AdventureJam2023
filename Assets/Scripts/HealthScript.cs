using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private float heathAmount = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayersBullet"))
        {
            heathAmount -= 3f;
        }

        if (heathAmount < 1f)
        {
            Destroy(gameObject);
        }
    }
}
