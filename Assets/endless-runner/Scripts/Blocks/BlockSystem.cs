using EndlessRunner.GameLogic;
using EndlessRunner.Interfaces;
using UnityEngine;

namespace EndlessRunner.Blocks
{
    public class BlockSystem : MonoBehaviour, ISystem
    {
        [SerializeField] private BlockFactory _factory;
        [SerializeField] private int _minimumWaySize;
        [SerializeField] private int _poolCapacity;
        [SerializeField] private float _speed;

        private IRunner _runner;

        public void Initialize()
        {
            _factory.Initialize(transform);

            var pool = new BlockPool(_factory);
            pool.Initialize(_poolCapacity);

            var generator = new BlocksGenerator(pool, _minimumWaySize);
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