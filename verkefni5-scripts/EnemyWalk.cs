using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public float walkSpeed = 2f; // Gönguhraði óvinarins
    public float leftBoundary = -5f; // Vinstri mörk óvinarferilsins
    public float rightBoundary = 5f; // Hægri mörk óvinarferilsins

    private bool isMovingRight = true; // Breyta sem heldur utan um hvort óvinurinn sé að hreyfast til hægri

    private void Update()
    {
        if (isMovingRight)
        {
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);

            if (transform.position.x >= rightBoundary)
            {
                 // Náðum til hægri mörkanna, skiptum um átt
                isMovingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);

            if (transform.position.x <= leftBoundary)
            {
                // Náðum til vinstri mörkanna, skiptum um átt
                isMovingRight = true;
            }
        }
    }
}
