using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "New GameFieldConfig", menuName = "Config/Game Field Config")]
    public class GameFieldConfig : ScriptableObject
    {
        [SerializeField]
        private Vector2 _cellSize;

        [SerializeField]
        private float _cellSpacing;
    }
}