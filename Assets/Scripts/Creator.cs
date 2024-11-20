using System;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] private Destroyer _destroyer;

    private int _minCountCubes = 2;
    private int _maxCountCubes = 6;
    private int _decreaseSize = 2;
    private int _decreasePercent = 2;

    public event Action<Rigidbody> Created;

    private void OnEnable()
    {
        _destroyer.Destroyed += CreateCube;
    }

    private void OnDisable()
    {
        _destroyer.Destroyed -= CreateCube;
    }

    private void CreateCube(Rigidbody cube)
    {
        int countCubes = UnityEngine.Random.Range(_minCountCubes, _maxCountCubes + 1);

        for (int i = 0; i < countCubes; i++)
        {
            Rigidbody copy = Instantiate(cube);

            CreateDifferences(copy);
            Created?.Invoke(copy);
        }
    }

    private void CreateDifferences(Rigidbody newCube)
    {
        CubeInitializer cubeInitializer = newCube.GetComponent<CubeInitializer>();

        Color newColor = UnityEngine.Random.ColorHSV();
        Vector3 newSize = newCube.transform.localScale / _decreaseSize;
        float splitChance = cubeInitializer.SplitChance / _decreasePercent;

        cubeInitializer.Init(newColor, newSize, splitChance);
    }
}
