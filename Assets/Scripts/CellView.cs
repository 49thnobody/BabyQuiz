using UnityEngine;

namespace GameLoop
{
    public class CellView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _optionSprite;

        private string _option;

        public string Option => _option;

        public void Set(Vector2 size, Vector2 positon)
        {
            transform.localPosition = positon;
            transform.localScale = size;
        }

        public void Set(string option, Sprite sprite)
        {
            _option = option;
            _optionSprite.sprite = sprite;

            if (option == "7" || option == "8")
            {
                _optionSprite.transform.Rotate(new Vector3(0, 0, -90));
            }
        }
    }
}