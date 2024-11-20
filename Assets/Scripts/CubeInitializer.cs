using UnityEngine;

public class CubeInitializer : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1;    

    public void Init(Color color, Vector3 size,float splitChance)
    {
        GetComponent<Renderer>().material.color = color;
        transform.localScale = size;
        _splitChance = splitChance;
    }

    public float SplitChance => _splitChance;
}