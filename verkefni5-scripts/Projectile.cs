using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f; // Hraði skotsins

    private Rigidbody2D rigidbody2D; // Rigidbody2D komponentið á skotinu

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); // Sækjum Rigidbody2D komponentið
    }

    private void FixedUpdate()
    {
        Vector2 currentPosition = rigidbody2D.position; // Núverandi staðsetning skotsins
        currentPosition += speed * Time.fixedDeltaTime * (Vector2)transform.right; // Hreyfum skotid áfram í rétta átt með hraða
        rigidbody2D.MovePosition(currentPosition); // Uppfærum staðsetningu skotsins
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // Ef skotid snertir óvin
        {
            Destroy(collision.gameObject); // Eyðum óvinnum
            Destroy(gameObject); // Eyðum skotinu
        }
    }
}