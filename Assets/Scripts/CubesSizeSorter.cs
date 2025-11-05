using System.Collections.Generic;
using UnityEngine;

public class CubesSizeSorter : MonoBehaviour
{
    [SerializeField] private float _cubesDistance;
    [SerializeField] private Vector3 _lineStartPosition;
    [SerializeField] private List<Transform> _cubes = new List<Transform>();

    private void Awake()
    {
        BubbleSort();
        ArrangeCubesInLine();
    }

    private void BubbleSort()
    {
        for (int i = 0; i < _cubes.Count - 1; i++)
        {
            for (int j = 0; j < _cubes.Count - i - 1; j++)
            {
                if (_cubes[j].transform.localScale.magnitude < _cubes[j + 1].transform.localScale.magnitude)
                {
                    var temp = _cubes[j];
                    _cubes[j] = _cubes[j + 1];
                    _cubes[j + 1] = temp;
                }
            }
        }
    }

    private void ArrangeCubesInLine()
    {
        foreach (Transform cube in _cubes)
        {
            cube.position = _lineStartPosition;
            _lineStartPosition.x += _cubesDistance;
        }
    }
}
