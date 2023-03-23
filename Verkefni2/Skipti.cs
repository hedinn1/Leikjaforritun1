using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skipti : MonoBehaviour
{
    // Bætir inn collider trigger
    private void OnTriggerEnter(Collider other)
    {
        // Leikmaður hverfur
        other.gameObject.SetActive(false);
        //Kallar á bíða fallið
        StartCoroutine(Bida());
    }
    IEnumerator Bida()
    {
        // Biður í 3 sekundur
        yield return new WaitForSeconds(3);
        //Kallar endurræsa fallið
        Endurræsa();
    }
    public void Endurræsa()
    {
        // Keyrir næstu senu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);//næsta sena
    }
}
