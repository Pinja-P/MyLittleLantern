using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RealLight : MonoBehaviour
{
    public Lyhty lyhty;
    public Light2D realLight;
    public float dimIntensity = 3f;
    public float midIntensity = 6f;
    public float brightIntensity = 10f;


    void Start()
    {
        realLight = GetComponent<Light2D>();
        
        if (lyhty == null)
        {
            lyhty = Lyhty.instance;
        }

        
        
            
        
    }

    void Update()
    {
        if (lyhty == null || realLight == null) return;

       
        if (lyhty.currentFuel <= 0f)
        {
            realLight.enabled = false;
            return;
        }

        realLight.enabled = true;

        if (lyhty.lanternRenderer != null && lyhty.lanternRenderer.sprite != null)
        {
            realLight.lightCookieSprite = lyhty.lanternRenderer.sprite;
        }

        // Adjust the real light's brightness to match the level
        switch (lyhty.brightnessLevel)
        {
            case 1:
                realLight.intensity = dimIntensity;
                break;
            case 2:
                realLight.intensity = midIntensity;
                break;
            case 3:
                realLight.intensity = brightIntensity;
                break;
        }
    }
}

