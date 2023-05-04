using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
void OnTriggerEnter2D(Collider2D other)
{
     // Finnur RubyController skriftuna á game objectinu sem klessir á triggerinn.

     RubyController controller = other.GetComponent<RubyController>();
     
     // Ef heilsustig RubyControllers er minna en hámarksheilsustig:
     if (controller != null)
     {
          if(controller.currentHealth < controller.maxHealth)
          {
	  	// Hækkar heilsustig RubyControllers um 1.
	       controller.ChangeHealth(1);
	       // Eyðir game objectinu sem triggerinn er bundinn við.
	       Destroy(gameObject);
          }
     }
}
}
