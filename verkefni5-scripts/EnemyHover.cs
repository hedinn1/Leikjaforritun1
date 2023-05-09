using UnityEngine;

public class EnemyHover : MonoBehaviour
{
    public float hoverSpeed = 2f; // Hraði sveiflunnar
    public float hoverHeight = 0.5f; // Hæð sveiflunnar

    private float startY; // Upphafsstöð y-hnitanna

    private void Start()
    {
        startY = transform.position.y; // Geymum upphafsstöð y-hnitanna
    }

    private void Update()
    {
       // Reiknum út lóðhæðarhliðrunina miðað við tíma og hraða
        float verticalOffset = Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;

        // Uppfærum staðsetningu óvinarins með lóðhæðarhliðruninni
        transform.position = new Vector3(transform.position.x, startY + verticalOffset, transform.position.z);
    }
}
