using System;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public event Action<Rigidbody> Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(_ray, out hit))
            {
                Rigidbody body = hit.collider.GetComponent<Rigidbody>();

                Clicked?.Invoke(body);
            }
        }
    }
}
