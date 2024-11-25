using Unity.VisualScripting;
using UnityEngine;

public class FuelScript : MonoBehaviour
{
    public float startingFuel { get; private set; }
    public float currentFuel { get; private set; }


    private void Awake()
    {
        startingFuel = 1000;
        currentFuel = startingFuel;
    }

    public void UseFuel(float _amount)
    {
        currentFuel = Mathf.Clamp(currentFuel - _amount, 0, startingFuel);
    }

    public void AddFuel(float _amount)
    { 
        currentFuel += _amount;
    }

}
