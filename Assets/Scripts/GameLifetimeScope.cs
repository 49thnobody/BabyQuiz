using Config;
using GameLoop;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Visuals;

namespace DependencyInjection
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private GameFieldConfig _gameFieldConfig;

        [SerializeField]
        private CellView _cellViewPrefab;

        [SerializeField]
        private LevelBuilder _levelBuilder;

        [SerializeField]
        private Level _level;

        [SerializeField]
        private TipText _tipText;

        [SerializeField]
        private RestartButton _restartButton;

        [SerializeField]
        private FadeAnimator _fade;

        [SerializeField]
        private InputSystem _inputSystem;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameFieldConfig);

            builder.RegisterComponent(_tipText);

            builder.RegisterComponent(_levelBuilder);

            builder.RegisterComponent(_level);

            builder.RegisterComponent(_cellViewPrefab);

            builder.RegisterComponent(_restartButton);

            builder.RegisterComponent(_fade);

            builder.RegisterComponent(_inputSystem);
        }
    }
}