using Config;
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

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameFieldConfig);

            builder.RegisterComponent(_levelBuilder);

            builder.RegisterComponent(_cellViewPrefab);
        }
    }
}