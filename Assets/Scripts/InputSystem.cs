using UnityEngine;

namespace GameLoop
{
    public class InputSystem : MonoBehaviour
    {
        private bool _isInputEnabled = true;

        private void Update()
        {
            if (!_isInputEnabled)
            {
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                Collider2D targetObject = Physics2D.OverlapPoint(GetMousePosition());

                if (!targetObject)
                {
                    return;
                }

                var cell = targetObject.GetComponentInParent<CellView>();
                if (!cell)
                {
                    return;
                }

                cell.ManageClick();
            }
        }

        private Vector3 GetMousePosition()
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        }

        public void ToggleInput(bool isEnabled)
        {
            _isInputEnabled = isEnabled;
        }
    }
}