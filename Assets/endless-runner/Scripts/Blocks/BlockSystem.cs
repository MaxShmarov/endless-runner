using System.Collections;
using UnityEngine;

namespace EndlessRunner.Blocks
{
    public class BlockSystem : MonoBehaviour
    {
        [SerializeField] private BlockFactory _blockFactory;
        [SerializeField] private int _minimumWaySize;
        [SerializeField] private int _poolCapacity;
        [SerializeField] private float _speed;

        private BlockMovement mover;

        private IEnumerator Start()
        {
            _blockFactory.Initialize(transform);

            var pool = new BlockPool(_blockFactory);
            pool.Initialize(_poolCapacity);

            var generator = new BlocksGenerator(pool, _minimumWaySize);
            generator.Generate();

            yield return null;

            mover = new BlockMovement(transform, _speed);
        }

        private void Update()
        {
            mover?.Update();
        }
    }
}