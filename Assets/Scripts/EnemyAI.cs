using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;
    [SerializeField]
    private GameObject bulletPrefab;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(Movement());
    }

    private IEnumerator Movement()
    {
        while (true)
        {
            float vx = Random.Range(-0.1f, 0.1f);
            float vy = Random.Range(-0.1f, 0.1f);
            for (int i = 0; i < 50; i++)
            {
                rb.velocity = new Vector2(vx, vy);
                transform.position = new Vector2(transform.position.x + vx, transform.position.y + vy);
                yield return null;
            }
            yield return new WaitForSeconds(2);
            float distance = Vector2.Distance(transform.position, target.position);
            if (distance < 10)
            {
                Vector3 direction = target.position - transform.position;
                float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) * Mathf.PI / 180;
                var bulletPrefab1 = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bulletPrefab1.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle) * 10, Mathf.Sin(angle) * 10);
            }
            yield return new WaitForSeconds(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //Destroy(gameObject);
        }
    }
}
