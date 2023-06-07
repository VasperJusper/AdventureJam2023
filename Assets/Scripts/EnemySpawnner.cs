using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    public Vector2 cords;

    public float enemyAmount;
    public float x, y;

    public GameObject enemyPrefab;

    void Start()
    {
        enemyAmount = 20f;
    }

    void Update()
    {
        while (enemyAmount > 1)
        {
            x = Random.Range(-20f, 20f);
            y = Random.Range(-20f, 20f);

            cords = new Vector2(x, y);
            var enemy = Instantiate(enemyPrefab, cords, Quaternion.identity);
            enemyAmount -= 1f;
        }
    }
}
