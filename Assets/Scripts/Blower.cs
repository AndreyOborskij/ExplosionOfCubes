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

    private void BlowUp(CubeInitializer cube)
    {
        Vector3 explosionPosition = cube.transform.position;

        Rigidbody rigidbody = cube.GetComponent<Rigidbody>();

        if (rigidbody != null)
        {
            rigidbody.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
        }
    }
}
