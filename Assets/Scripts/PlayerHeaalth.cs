using UnityEngine;
using UnityEngine.UI;

public class PlayerHeaalth : MonoBehaviour
{
    public float PlayersHeaalth = 100f;

    public Slider healthBarImage;

    void Start()
    {
        PlayersHeaalth = 100f;
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullets"))
        {
            PlayersHeaalth -= 10f;
        }
    }

    public void UpdateHealthBar()
    {
        healthBarImage.value = Mathf.Clamp(PlayersHeaalth / 100f, 0, 1f);
    }
}
