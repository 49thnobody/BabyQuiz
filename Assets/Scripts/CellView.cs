using UnityEngine;

namespace GameLoop
{
    public class CellView : MonoBehaviour
    {
        private Level _level;

        [SerializeField]
        private SpriteRenderer _optionSprite;

        private string _option;

        public string Option => _option;

        public void Set(Vector2 size, Vector2 positon)
        {
            transform.localPosition = positon;
            transform.localScale = size;
            // somewhere here can be apearing bounce animation
        }

        public void Set(string option, Sprite sprite, Level level)
        {
            //i hate that but i hit circular dependency, so.. 
            _level = level;

            _option = option;
            _optionSprite.sprite = sprite;

            // fix rotated numbers, yes, i hardcode it, i dont see a realy good way to work araoun that
            if (option == "7" || option == "8")
            {
                _optionSprite.transform.rotation = new Quaternion(0, 0, 0, 0);
                _optionSprite.transform.Rotate(new Vector3(0, 0, -90));
            }
            else
            {
                _optionSprite.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }

        public void ManageClick()
        {
            if (_level.CorrectAnswer == _option)
            {
                // animation option bounce

                _level.NextLevel();
            }
            else
            {
                // animation option easeonbounce
            }
        }
    }
}