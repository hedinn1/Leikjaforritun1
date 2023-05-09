using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PointCounter : MonoBehaviour
{
    private int pointCount; // Breyta sem geymir stigatalninguna

    public TextMeshProUGUI pointCounterText; // Textasvæðið sem sýnir stigatalninguna

    private void Start()
    {
        UpdatePointCounter(); // Uppfærum stigatalninguna
    }

    public void CollectGem()
    {
        pointCount++; // Hækkum stigatalninguna um einn
        UpdatePointCounter(); // Uppfærum stigatalninguna
    }

    public void DeductPoint()
    {
        pointCount--; // Lækkum stigatalninguna um einn
        UpdatePointCounter(); // Uppfærum stigatalninguna

        if (pointCount < 0)
        {
            // Skiptum um scenið yfir í "game over" senuna
            SceneManager.LoadScene(2);
        }
    }

    private void UpdatePointCounter()
    {
        pointCounterText.text = "Points: " + pointCount;
    }
}