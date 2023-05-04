using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    // Þetta fall er kallað þegar hlutur rekst á annan hlut í leiknum sem hefur Collider2D komponent.
    void OnTriggerStay2D(Collider2D other)
    {
        // Hér er skilgreint controller sem er RubyController hluturinn á Collider2D hlutnum sem rekst á þennan DamageZone hlut.
        RubyController controller = other.GetComponent<RubyController >();
        // Ef RubyController hlutur er á Collider2D hlutnum sem rekst á þennan DamageZone hlut þá er heilsa RubyController hlutarins minnkað um 1.
        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
    }
}
