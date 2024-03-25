using UnityEngine;

namespace GameLoop
{
    public class InputSystem : MonoBehaviour
    {
        private void Update()
        {
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
                // and mb wait some time
            }
        }

        private Vector3 GetMousePosition()
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        }
    }
}