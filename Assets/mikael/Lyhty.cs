using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;




public class Lyhty : MonoBehaviour
{
    [Header("Light Settings")]
    public Light lanterlight;

    [Range(1, 3)]
    public int brigntnessLevel = 2;

    [Header("1: heikko")]
    public float dimIntensity = 1.0f;
    public float dimRange = 5.0f;
    public float dimburnMultiplier = 0.5f;

    [Header("2: keskitaso")]
    public float midIntensity = 2.0f;
    public float midRange = 10.0f;
    public float midburnMultiplier = 1.0f;

    [Header("3: kirkas")]
    public float brightIntensity = 3.0f;
    public float brightRange = 15.0f;
    public float brightburnMultiplier = 2.0f;

    public float fuelcapacity = 100f;
    public float fuelburnout = 1f;
    public float CurrentFuel;

    private void Start()
    {
        CurrentFuel = fuelcapacity;
        if (lanterlight == null)
        {
            lanterlight = GetComponent<Light>();
        }
        UpdateLight();
    }
    void update()
    {
        Lanterfuel();
        LanterBrigthness();
    }
    void Lanterfuel()
    {
        if (CurrentFuel <= 0f)
        {
            return;
        }

        float multiplayer = midburnMultiplier;
        if (brigntnessLevel == 1) multiplayer = dimburnMultiplier;
        else if (brigntnessLevel == 3) multiplayer = brightburnMultiplier;

        CurrentFuel -= fuelburnout * Time.deltaTime * multiplayer;

        if (CurrentFuel <= 0f)
        {
            CurrentFuel = 0f;
            lanterlight.enabled = false;
            lanterlight.intensity = 0f;
        }
    }

    void LanterBrigthness()
    {
        if (CurrentFuel <= 0f) return;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            brigntnessLevel = Mathf.Clamp(brigntnessLevel - 1, 1, 3);
            UpdateLight();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            brigntnessLevel = Mathf.Clamp(brigntnessLevel + 1, 1, 3);
            UpdateLight();
        }
    }
    void UpdateLight()
    {
        if (lanterlight == null || CurrentFuel <= 0f) return;
        lanterlight.enabled = true;
            switch (brigntnessLevel)
        {
            case 1: // Heikko kirkkaus
                lanterlight.intensity = dimIntensity;
                lanterlight.range = dimRange;
                break;
            case 2: // Keskitaso kirkkaus
                lanterlight.intensity = midIntensity;
                lanterlight.range = midRange;
                break;
            case 3: // Kirkas kirkkaus
                lanterlight.intensity = brightIntensity;
                lanterlight.range = brightRange;
                break;
        }
    }
}