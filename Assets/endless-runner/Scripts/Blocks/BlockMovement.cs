using UnityEngine;

namespace EndlessRunner.Blocks
{
    public class BlockMovement
    {
        private Transform _transform;
        private float _speed;

        public float Modificator { get; private set; }

        public BlockMovement(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;

            Modificator = 1;
        }

        public void ApplyModificator(float modificator)
        {
            Modificator = modificator;
        }

        public void Update()
        {
            if (_transform == null) { return; }

            _transform.Translate(_speed * Modificator * Vector3.back);
        }
    }
}