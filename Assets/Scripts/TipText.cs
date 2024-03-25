using TMPro;
using UnityEngine;

namespace GameLoop
{
    public class TipText : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        public void ChangeText(string text)
        {
            _text.text = text;
        }
    }
}
