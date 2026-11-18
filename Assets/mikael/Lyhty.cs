using UnityEngine;
using UnityEngine.InputSystem;





public class Lyhty : MonoBehaviour
{
    [Header("Light Settings")]
    
    public SpriteRenderer lanternRenderer;

    [Range(1, 3)]
    public int brightnessLevel = 2;

    [Header("1: Heikko")]
    public Sprite dimSprite;
    public float dimBurnMultiplier = 0.5f;

    [Header("2: Keskitaso")]
    public Sprite midSprite;
    public float midBurnMultiplier = 1.0f;

    [Header("3: Kirkas")]
    public Sprite brightSprite;
    public float brightBurnMultiplier = 2.0f;

    [Header("Fuel Settings")]
    public float fuelCapacity = 100f;
    public float fuelBurnout = 1f;
    public float currentFuel;

    private void Awake()
    {
        if (lanternRenderer == null)
        {
            lanternRenderer = GetComponent<SpriteRenderer>();
        }
    }

    private void Start()
    {
        currentFuel = fuelCapacity;
        UpdateSprite();
    }

    private void Update()
    {
        HandleFuel();
        
    }

    private void HandleFuel()
    {
        if (currentFuel <= 0f) return;

        float multiplier = midBurnMultiplier;
        if (brightnessLevel == 1) multiplier = dimBurnMultiplier;
        else if (brightnessLevel == 3) multiplier = brightBurnMultiplier;

        currentFuel -= fuelBurnout * Time.deltaTime * multiplier;

        if (currentFuel <= 0f)
        {
            currentFuel = 0f;
            if (lanternRenderer != null)
            {
                lanternRenderer.enabled = false;
            }
        }
    }
    public void LightDown(InputAction.CallbackContext context)
    {

        if (currentFuel <= 0f) return;

        if (context.performed)
        {
            brightnessLevel = Mathf.Clamp(brightnessLevel - 1, 1, 3);
            UpdateSprite();
            Debug.Log("Brightness decreased to: " + brightnessLevel);
    }
        }
    
    public void LightUp(InputAction.CallbackContext context)
    {
        if (currentFuel <= 0f) return;

        if (context.performed)
        {
            brightnessLevel = Mathf.Clamp(brightnessLevel + 1, 1, 3);
            UpdateSprite();
            Debug.Log("Brightness increased to: " + brightnessLevel);
        }
    }
    private void UpdateSprite()
    {
        if (lanternRenderer == null) return;

        
        if (currentFuel <= 0f)
        {
            lanternRenderer.enabled = false;
            return;
        }


        switch (brightnessLevel)
        {
            case 1:
                if (dimSprite != null) lanternRenderer.sprite = dimSprite;
                break;
            case 2:
                if (midSprite != null) lanternRenderer.sprite = midSprite;
                break;
            case 3:
                if (brightSprite != null) lanternRenderer.sprite = brightSprite;
                break;
        }
    }
}