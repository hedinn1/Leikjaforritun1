using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;
    
    public int maxHealth = 5;
    
    public GameObject projectilePrefab;
    
    public int health { get { return currentHealth; }}
    public int currentHealth;
    
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); //ná í hreyfinguna
        animator = GetComponent<Animator>(); //ná í animation
        
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        Vector2 move = new Vector2(horizontal, vertical); //vektor sem segir til um hvernig á að hreyfa
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y); //átt er stillt eftir hreyfingu
            lookDirection.Normalize();
        }
        
        animator.SetFloat("Look X", lookDirection.x); //stillt animation x-ás áttar
        animator.SetFloat("Look Y", lookDirection.y); //stillt animation y-ás áttar
        animator.SetFloat("Speed", move.magnitude); //stillt animation hraða
        
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false; //ef teljari nær niðri þá hættir invincibility
    }
        }
        
        if(Input.GetKeyDown(KeyCode.C)) //notandi ýtir á takka C til að skjóta
        {
            Launch();
        }
        
        if (Input.GetKeyDown(KeyCode.X)) //notandi ýtir á takka X til að hefja samtal
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                }
            }
        }
    }
    
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        // Hreyfing eftir x og y ásnum með hraða, lárétta og lóðrétt átt, tímasetningu og hraðastillingum
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        // Ef stigafjöldi er minni en núll
        if (amount < 0)
        {
            // Ef leikmaður er invincible
            if (isInvincible)
                return;
            // Leikmaður verður invincible
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        // Núverandi heilsa er takmörkuð á bilinu 0 og hámarks heilsu
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
    
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
    }
}
