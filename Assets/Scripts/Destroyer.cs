using System;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Clicker _clicker;

    public event Action<Rigidbody> Destroyed;

    private void OnEnable()
    {
        _clicker.Clicked += DestroyCube;
    }

    private void OnDisable()
    {
        _clicker.Clicked -= DestroyCube;
    }

    private void DestroyCube(Rigidbody cube)
    {
        CalculateProbability probability = cube.GetComponent<CalculateProbability>();

        if (probability.Compute == true)
        {
            Destroyed?.Invoke(cube);
            Destroy(cube.gameObject);
        }
        else
        {
            Destroy(cube.gameObject);
        }
    }    
}
