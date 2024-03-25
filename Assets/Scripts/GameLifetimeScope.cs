using Config;
using GameLoop;
using UnityEngine;
using VContainer;
using VContainer.Unity;

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

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameFieldConfig);

            builder.RegisterComponent(_tipText);

            builder.RegisterComponent(_levelBuilder);

            builder.RegisterComponent(_level);

            builder.RegisterComponent(_cellViewPrefab);
        }
    }
}