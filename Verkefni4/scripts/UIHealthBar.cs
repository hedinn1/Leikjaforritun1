using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance { get; private set; }
    
    public Image mask;
    float originalSize;
    
    void Awake()
    {
        // Núllstillum stofnaða breytu til að halda utan um eina tilvist af þessum klasa.
        instance = this;
    }

    void Start()
    {
        // Geymum upphaflega stærð myndarinnar.
        originalSize = mask.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {				    
        // Setjum nýja stærð á masakinn sem sýnir lif út frá innsláttargildi.
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
