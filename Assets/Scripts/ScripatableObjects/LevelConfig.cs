using System;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "New LevelConfig", menuName = "Config/Level Config")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField]
        private int _rows;

        public int Rows => _rows;

        [SerializeField]
        private int _columns;

        public int Columns => _columns;

        public int Size => _rows * _columns;
    }
}