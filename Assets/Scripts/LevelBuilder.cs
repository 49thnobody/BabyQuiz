using Config;
using UnityEngine;
using VContainer;

namespace GameLoop
{
    public class LevelBuilder : MonoBehaviour
    {
        [Inject]
        private GameFieldConfig _gameFieldConfig;

        [Inject]
        private CellView _cellView;

        private Vector2Int _fieldSize;

        public CellView[,] BuildCells(Vector2Int size)
        {
            _fieldSize = size;

            var result = new CellView[_fieldSize.y, _fieldSize.x];

            float width = _fieldSize.x * _gameFieldConfig.CellSize.x + (_fieldSize.x - 1) * _gameFieldConfig.CellSpacing;
            float height = _fieldSize.y * _gameFieldConfig.CellSize.y + (_fieldSize.y - 1) * _gameFieldConfig.CellSpacing;

            // find left bottom corner
            Vector2 startingPoint = new Vector2(-1 * width / 2, -1 * height / 2);
            transform.position = startingPoint;

            for (int y = 0; y < _fieldSize.y; y++)
            {
                for (int x = 0; x < _fieldSize.x; x++)
                {
                    var position = new Vector2(_gameFieldConfig.CellSize.x * x, height - _gameFieldConfig.CellSize.y * (y + 1));

                    // adding offset for cells
                    if (x > 0)
                    {
                        position += new Vector2(_gameFieldConfig.CellSpacing * x, 0);
                    }
                    if (y > 0)
                    {
                        position -= new Vector2(0, _gameFieldConfig.CellSpacing * y);
                    }

                    var cell = Instantiate(_cellView, transform);

                    cell.Set(_gameFieldConfig.CellSize, position);

                    result[y, x] = cell;
                }
            }

            return result;
        }

        public void CorrectOffset(Vector2Int size)
        {
            if (size.x < _fieldSize.x)
            {
                float width = size.x * _gameFieldConfig.CellSize.x + (size.x - 1) * _gameFieldConfig.CellSpacing;
                transform.position = new Vector2(-1 * width / 2, transform.position.y);
            }
        }
    }
}