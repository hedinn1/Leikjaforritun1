using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f; // Hraði leikmanns
    
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    public GameObject projectilePrefab;
    public float projectileSpeed = 10f; // Hraði skotsins

    private PointCounter pointCounter; // Benda á PointCounter hlutinn
    
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0); // Sjálfgefin átt til að horfa á
    
    private void LaunchProjectile()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.speed = projectileSpeed;
        projectile.transform.right = transform.right; // Stillum átt skotsins
    }
    
    // Start er kallað þegar leikurinn byrjar
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        pointCounter = GameObject.FindWithTag("PointCounter").GetComponent<PointCounter>(); // Finnur PointCounter hlutinn með því að nota tag

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gem")) // Ef stungið er í gem
        {
            Destroy(collision.gameObject); // Eyða gem GameObject-inu
            pointCounter.CollectGem(); // Auka stigatalninguna

        }
    }

    public void DeductPoint()
    {
        pointCounter.DeductPoint();
    }

    // Update er kallað einu sinni á hverjum ramma
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y); // Stillum áttina sem við erum að horfa á
            lookDirection.Normalize(); // Normalizerum áttina
        }
        
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        
        if (Input.GetKeyDown(KeyCode.C)) // Ef ýtt er á C takkann
        {
            LaunchProjectile(); // Skot er send út
        }
    }
    
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime; // Hreyfum fyrirvallarinnstunguna á x-ás
        position.y = position.y + 10.0f * vertical * Time.deltaTime; // Hreyfum fyrirvallarinnstunguna á y-ás

        rigidbody2d.MovePosition(position); // Uppfærum staðsetningu fyrirvallarinnstungunnar
    }

}