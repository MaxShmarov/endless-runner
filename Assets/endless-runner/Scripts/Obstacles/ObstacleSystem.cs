using EndlessRunner.GameLogic;
using EndlessRunner.Interfaces;
using UnityEngine;

namespace EndlessRunner.Obstacles
{
    public class ObstacleSystem : MonoBehaviour, ISystem
    {
        [SerializeField] private ObstacleFactory _factory;
        [SerializeField] private int _minimumSize;
        [SerializeField] private int _poolCapacity;
        [SerializeField] private float _speed;
        [SerializeField] private MinMaxValue _offsetByX;
        [SerializeField] private MinMaxValue _offsetByZ;

        private IRunner _runner;

        public void Initialize()
        {
            _factory.Initialize(transform);

            var pool = new ObstaclePool(_factory);
            pool.Initialize(_poolCapacity);

            var generator = new ObstacleGenerator(pool, _minimumSize, _offsetByX, _offsetByZ);
            generator.Generate();

            _runner = new Movement(transform, _speed);
        }

        public void Modify(float modificator)
        {
            _runner?.ApplyModificator(modificator);
        }

        public void Run()
        {
            _runner?.Run();
        }
    }
}