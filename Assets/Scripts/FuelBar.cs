using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    [SerializeField] private FuelScript engineFuel;
    [SerializeField] private Image totalFuelBar;
    [SerializeField] private Image currentFuelBar;

    private void Start()
    { 
        engineFuel = GameObject.FindGameObjectWithTag("Bird").GetComponent<FuelScript>();
        totalFuelBar.fillAmount = engineFuel.currentFuel;
    }

    private void Update() 
    {
        currentFuelBar.fillAmount = engineFuel.currentFuel/engineFuel.startingFuel;
        
    }
}
