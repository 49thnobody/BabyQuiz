using GameLoop;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VContainer;
using Visuals;

namespace UI
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        [Inject]
        private readonly FadeAnimator _fade;

        [Inject]
        private readonly InputSystem _inputSystem;

        private UnityAction _callback;

        private void Awake()
        {
            _button.onClick.AddListener(FadeThenRestart);
        }

        private void FadeThenRestart()
        {
            _fade.Fade();
            _callback?.Invoke();

            StartCoroutine(Utils.Wait(2f, () =>
            {
                gameObject.SetActive(false);
            }
            ));
        }

        public void Show(UnityAction callback)
        {
            _inputSystem.ToggleInput(false);
            _callback = callback;
            gameObject.SetActive(true);
        }
    }
}
