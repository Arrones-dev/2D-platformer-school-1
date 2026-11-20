using UnityEngine;

public class PickUpScript: MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    public int score;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            score += 1;
            Destroy(gameObject);
        }
    }
}