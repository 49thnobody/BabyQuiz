using System;
using UnityEngine;

public class CellView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _optionSprite;

    public void Set(Vector2 size, Vector2 positon)
    {
        transform.localPosition = positon;
        transform.localScale = size;
    }

    public void Set(Sprite sprite)
    {
        _optionSprite.sprite = sprite;
    }
}
