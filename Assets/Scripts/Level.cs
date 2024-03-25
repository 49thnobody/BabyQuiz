using Config;
using Data;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using Visuals;

namespace GameLoop
{
    public class Level : MonoBehaviour
    {
        [SerializeField]
        private LevelConfig[] _configs;

        [SerializeField]
        private OptionBundleData[] _bundles;

        private int _currentConfig;

        [Inject]
        private readonly LevelBuilder _levelBuilder;

        private CellView[,] _cells;

        private string _correctAnswer;
        public string CorrectAnswer => _correctAnswer;

        [Inject]
        private readonly TipText _tipText;

        [Inject]
        private readonly RestartButton _restartButton;

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

            ShowHideCells();

            FillOptions();
        }

        private void DestroyCells()
        {
            for (int y = 0; y < _cells.GetLength(0); y++)
            {
                for (int x = 0; x < _cells.GetLength(1); x++)
                {
                    _cells[y, x].Destroy();
                }
            }
        }

        private void FillOptions()
        {
            // i know we are picking up from only 2 bundles, and actualy they are both suitable for given level sizes,
            // but what if we add a new difficulty level someday? the digit sets can become too small for this

            bool isFit;
            int bundleIndex;

            do
            {
                bundleIndex = Random.Range(0, _bundles.Length);

                isFit = _bundles[bundleIndex].Size >= _configs[_currentConfig].Size;
            } while (!isFit);

            var bundle = _bundles[bundleIndex];
            var options = new List<int>();

            for (int i = 0; i < _configs[_currentConfig].Size; i++)
            {
                int optionIndex;
                do
                {
                    // pick an index until we get non-repetative one
                    optionIndex = Random.Range(0, bundle.Size);

                } while (options.Contains(optionIndex));
                options.Add(optionIndex);
            }

            int index = 0;
            for (int y = 0; y < _configs[_currentConfig].Rows; y++)
            {
                for (int x = 0; x < _configs[_currentConfig].Columns; x++)
                {
                    var option = bundle.OptionData[options[index]];
                    _cells[y, x].Set(option.Identifier, option.Sprite, this);

                    index++;
                }
            }

            _correctAnswer = bundle.OptionData[options[Random.Range(0, options.Count)]].Identifier;

            _tipText.ChangeText(_correctAnswer);
        }

        private void ShowHideCells()
        {
            for (int y = 0; y < _cells.GetLength(0); y++)
            {
                for (int x = 0; x < _cells.GetLength(1); x++)
                {
                    _cells[y, x].gameObject.SetActive(y < _configs[_currentConfig].Rows && x < _configs[_currentConfig].Columns);
                }
            }

            _levelBuilder.CorrectOffset(new Vector2Int(_configs[_currentConfig].Columns, _configs[_currentConfig].Rows));
        }

        public void NextLevel()
        {
            if (_currentConfig + 1 == _configs.Length)
            {
                _restartButton.Show(() => Restart());
            }
            else
            {
                _currentConfig++;
                StartCoroutine(Utils.Wait(.7f, () =>
                {
                    ShowHideCells();
                    FillOptions();
                }));
            }
        }

        public void Restart()
        {
            DestroyCells();
            StartCoroutine(Utils.Wait(1f, () => StartGame()));
        }
    }
}
