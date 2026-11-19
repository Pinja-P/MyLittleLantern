using UnityEngine;
using UnityEngine.UI;

public class LanternUI : MonoBehaviour
{
    [SerializeField] private Image FuelBar;
    [SerializeField] private Lyhty lyhty;
 
    private void Update()
    {
        UpdateFuelBar();
    }

    private void UpdateFuelBar()
    {
        if (lyhty == null || FuelBar == null)
            return;

        float fuelPercentage = lyhty.currentFuel
            / lyhty.fuelCapacity;
        FuelBar.fillAmount = Mathf.Clamp01(fuelPercentage);

    }
}
