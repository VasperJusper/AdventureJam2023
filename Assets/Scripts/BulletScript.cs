using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float _timeDestroyBullet = 0.3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !gameObject.CompareTag("EnemyBullets"))
        {
            Destroy(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject, _timeDestroyBullet);
        }
    }
}
