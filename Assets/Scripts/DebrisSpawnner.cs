using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawnner : MonoBehaviour
{
    public GameObject DebrisObject;

    public Vector2 cords;

    private float x, y;
    private float DebrisAmount = 10f;

    private void Awake()
    {
        DebrisAmount = 10f;
    }
    void Update()
    {
        while (DebrisAmount > 1f)
        {
            x = Random.Range(-30f, 30f);
            y = Random.Range(-30f, 30f);

            cords = new Vector2(x, y);
            var Debris = Instantiate(DebrisObject, cords, Quaternion.identity);
            DebrisAmount -= 1f;
        }
    }
}
