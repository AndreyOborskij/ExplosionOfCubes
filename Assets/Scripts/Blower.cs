using UnityEngine;

public class Blower : MonoBehaviour
{
    [SerializeField] private Creator _creator;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private void OnEnable()
    {
        _creator.Created += BlowUp;
    }

    private void OnDisable()
    {
        _creator.Created -= BlowUp;
    }

    private void BlowUp(Rigidbody cube)
    {
        Vector3 explosionPosition = cube.transform.position;

        cube.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
    }
}
