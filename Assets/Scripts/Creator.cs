using System;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] private Destroyer _destroyer;

    private int _minCountCubes = 2;
    private int _maxCountCubes = 6;
    private int _decreaseSize = 2;
    private int _decreasePercent = 2;

    public event Action<CubeInitializer> Created;

    private void OnEnable()
    {
        _destroyer.Destroyed += CreateCube;
    }

    private void OnDisable()
    {
        _destroyer.Destroyed -= CreateCube;
    }

    private void CreateCube(CubeInitializer cube)
    {
        int countCubes = UnityEngine.Random.Range(_minCountCubes, _maxCountCubes + 1);

        for (int i = 0; i < countCubes; i++)
        {
            CubeInitializer copy = Instantiate(cube);

            CreateDifferences(copy);
            Created?.Invoke(copy);
        }
    }

    private void CreateDifferences(CubeInitializer newCube)
    {
        Color newColor = UnityEngine.Random.ColorHSV();
        Vector3 newSize = newCube.transform.localScale / _decreaseSize;
        float splitChance = newCube.SplitChance / _decreasePercent;

        newCube.Init(newColor, newSize, splitChance);
    }
}
