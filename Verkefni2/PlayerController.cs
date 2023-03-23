
// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using TMPro;



public class PlayerController : MonoBehaviour {
	// Búa til breytur fyrir hegðun leiks
	public float speed;
	public TextMeshProUGUI healthText;
	public TextMeshProUGUI scoreText;
	public float jumpForce = 10;
    private float movementX;
    private float movementY;
	private Rigidbody rb;
	private InputAction jumpAction;
	private int hearts;
	private int score;


	// í byrjun leiks
	void Start ()
	{
		// Setur rigidbody component að private rb breytunni
		rb = GetComponent<Rigidbody>();

		// Gefa spilanda 3 upphafslif 
		hearts = 3;
		score = 0;

		// kallar settext fallið
		SetText ();
	}

	void FixedUpdate ()
	{
		Vector3 movement = new Vector3 (movementX, 0.0f, movementY); // Býr til nýtt Vector3 hlut sem táknar hreyfingu hlutar í hnitakerfi leiksins
		rb.AddForce (movement * speed); // Bætir hraða við hlutinn með því að nota "AddForce" fallið á rigidbody hlutinn og margfalda hraða með hreyfingunni sem við bjuggum til í fyrri línu kóðans
		if (hearts <= 0)
        {
			//Hleður game-over senuna
            SceneManager.LoadScene(3);
        
        }
	}

	void OnTriggerEnter(Collider other) 
	{
		// Ef hluturinn sem leikmaður snertir hefur taggið 'PickUp'
		if (other.gameObject.CompareTag ("PickUp"))
		{
			// Peningur hverfur
			other.gameObject.SetActive (false);

			// Bæta einum við 'hearts' breytuna
			hearts = hearts + 1;
			score = score + 1;

			// Kallar setText fallið
			SetText ();
		}
		
	}

	void OnCollisionEnter(Collision collision)
    {
		// Ef hluturinn sem leikmaður snertir hefur taggið 'Obstacle'
		if (collision.collider.tag == "Obstacle")
		{
			// Taka einn frá 'hearts'
			hearts = hearts - 1;

			// Kallar setText fallið
			SetText ();
		}
	}

	// Stjórnar hreyfingu
	void OnMove(InputValue value)
	{
		Vector2 v = value.Get<Vector2>(); // Sækir hreyfinguna sem notandinn slær inn og geymir hana sem Vector2 hlut í breytunni v
		movementX = v.x; // stillir hreyfingu á x-ás 
		movementY = v.y; // stillir hreyfingu á y-ás 
	}

    void SetText()
	{
		// Skrifar upp lífin
		healthText.text = "Health: " + hearts.ToString();
		// Skrifar upp scoreið
		scoreText.text = "Score: " + score.ToString();

	}
	

	private void OnEnable()
    {
        jumpAction = new InputAction("Jump", InputActionType.Button, "<Keyboard>/space"); // býr til nýtt action tengt space takkanum
        jumpAction.Enable(); //jumpaction virkjað
        jumpAction.performed += ctx => Jump(); // kallar á jump fallið
    }

    private void OnDisable()
    {
		// Lætur spilanda stökkva
        jumpAction.performed -= ctx => Jump(); // kallar á jump fallið
        jumpAction.Disable(); //afvirkjar jumpaction
    }

	private void Jump()
	{
		// Lætur spilanda stökkva
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
	}
    
   
    
}