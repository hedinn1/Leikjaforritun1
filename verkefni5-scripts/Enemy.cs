using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PointCounter pointCounter; // Breyta sem geymir vísun í PointCounter hlutinn

    private void Start()
    {
        pointCounter = GameObject.FindWithTag("PointCounter").GetComponent<PointCounter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pointCounter.DeductPoint(); // Dragum einn stig frá stigatalningunni
            Destroy(gameObject); // Eyðum sjálfum okkar (Enemy hlutnum)
        }
    }
}

