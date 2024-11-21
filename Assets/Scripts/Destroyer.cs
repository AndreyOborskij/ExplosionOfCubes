using System;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Clicker _clicker;

    public event Action<CubeInitializer> Destroyed;

    private void OnEnable()
    {
        _clicker.Clicked += DestroyCube;
    }

    private void OnDisable()
    {
        _clicker.Clicked -= DestroyCube;
    }

    private void DestroyCube(CubeInitializer cube)
    {
        CalculateProbability probability = cube.GetComponent<CalculateProbability>();

        if (probability != null && probability.Determine() == true)
        {
            Destroyed?.Invoke(cube);
        }

        Destroy(cube.gameObject);
    }    
}
