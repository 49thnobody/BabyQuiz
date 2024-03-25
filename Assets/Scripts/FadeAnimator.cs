using DG.Tweening;
using GameLoop;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Visuals
{
    public class FadeAnimator : MonoBehaviour
    {
        [SerializeField]
        private Image _image;

        [SerializeField]
        private float _maxAlpha;

        [SerializeField]
        private float _duration;

        [Inject]
        private InputSystem _inputSystem;

        public void Fade()
        {
            _inputSystem.ToggleInput(false);

            DOTween.Sequence()
                .Append(_image.DOFade(_maxAlpha, _duration))
                .Append(_image.DOFade(0f, _duration))
                .onComplete = () => _inputSystem.ToggleInput(true);
        }
    }
}