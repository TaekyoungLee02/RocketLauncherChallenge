using UnityEngine;
using UnityEngine.UI;

public class EnergyDashboardC : MonoBehaviour
{
    [SerializeField] private EnergySystemC energySystem;
    [SerializeField] private Image fillBar;
    private void Start()
    {
        energySystem.OnEnergyChanged += UpdateFuelBar;
    }

    private void UpdateFuelBar(float fuel)
    {
        fillBar.fillAmount = fuel / energySystem.MaxFuel;
    }
}