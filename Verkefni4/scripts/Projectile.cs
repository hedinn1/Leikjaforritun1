using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    
    // Awake() fallið keyrir þegar leikurinn byrjar og stillir Rigidbody2D breytuna.

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    
    // Public fall sem er hægt að kalla úr öðrum klasum til að senda skot í ákveðna átt með ákveðnum hraða.

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    
    // Update() fallið keyrir í hverjum ramma og eyðir gameObjectinu ef stærðin hans er meiri en 1000.0f.
    void Update()
    {
        if(transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }
    
    // OnCollisionEnter2D() fallið keyrir þegar skot klessir á annan collider í leiknum.
    void OnCollisionEnter2D(Collision2D other)
    {
    
        // Sækjum EnemyController hlutinn af Collider-inum sem var hittaður og athugum hvort hann er ekki null.
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }
    
        Destroy(gameObject);
    }
}
