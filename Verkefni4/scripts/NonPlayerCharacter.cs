using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    float timerDisplay;
    
    void Start()
    {
        dialogBox.SetActive(false); // Felur dialog í byrjun.
        timerDisplay = -1.0f;
    }
    
    void Update()
    {
        // Ef dialog er að sýnast:
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            
            // Ef tími er liðinn, felur dialog.
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }
    
    public void DisplayDialog()
    {
        // Birtir dialog í displayTime sekúndur.
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
