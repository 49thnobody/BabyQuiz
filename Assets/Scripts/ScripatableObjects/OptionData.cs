using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class OptionData
    {
        [SerializeField]
        private string _identifier;

        public string Identifier => _identifier;

        [SerializeField]
        private Sprite _sprite;

        public Sprite Sprite => _sprite;
    }
}