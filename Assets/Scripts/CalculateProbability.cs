using UnityEngine;

public class CalculateProbability : MonoBehaviour
{
    [SerializeField] private Rigidbody cube;

    private float _probabilityPercent;

    public bool Compute => Determine();

    private bool Determine()
    {
        CubeInitializer cubeInitializer = cube.GetComponent<CubeInitializer>();
        Renderer renderer = cube.GetComponent<Renderer>();

        _probabilityPercent = Random.value;

        if (_probabilityPercent <= cubeInitializer.SplitChance)
        {
            return true;
        }

        return false;
    }
}
