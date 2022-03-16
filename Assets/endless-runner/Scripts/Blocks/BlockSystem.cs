using EndlessRunner.Interfaces;
using System.Collections;
using UnityEngine;

namespace EndlessRunner.Blocks
{
    public class BlockSystem : MonoBehaviour, ISystem
    {
        [SerializeField] private BlockFactory _blockFactory;
        [SerializeField] private int _minimumWaySize;
        [SerializeField] private int _poolCapacity;
        [SerializeField] private float _speed;

        private BlockMovement _mover;

        public bool IsRunning { get; private set; }


        private IEnumerator Start()
        {
            Initialize();

            yield return null;

            Run();
        }

        public void Initialize()
        {
            _blockFactory.Initialize(transform);

            var pool = new BlockPool(_blockFactory);
            pool.Initialize(_poolCapacity);

            var generator = new BlocksGenerator(pool, _minimumWaySize);
            generator.Generate();

            _mover = new BlockMovement(transform, _speed);
        }

        public void Run()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }

        private void Update()
        {
            if (!IsRunning) { return; }

            _mover?.Update();
        }
    }
}