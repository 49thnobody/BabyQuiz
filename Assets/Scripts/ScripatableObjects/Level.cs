using Config;
using Data;
using System;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private LevelConfig[] _configs;

    [SerializeField]
    private OptionBundleData[] _bundles;

    private int _currentConfig;

    [SerializeField]
    private LevelBuilder _levelBuilder;

    private CellView[,] _cells;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        _currentConfig = 0;

        var maxSize = new Vector2Int(_configs.Max(c => c.Columns), _configs.Max(c => c.Rows));
        _cells = _levelBuilder.BuildCells(maxSize);

        var currentSize = new Vector2Int(_configs[0].Columns, _configs[0].Rows);
        _levelBuilder.CorrectOffset(currentSize);

        ShowHideCells();
    }

    private void ShowHideCells()
    {
        for (int y = 0; y < _cells.GetLength(0); y++)
        {
            for (int x = 0; x < _cells.GetLength(1); x++)
            {
                _cells[y, x].gameObject.SetActive(y < _configs[0].Rows && x < _configs[0].Columns);
            }
        }
    }
}