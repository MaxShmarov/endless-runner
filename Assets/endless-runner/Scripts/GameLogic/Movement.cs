using UnityEngine;

namespace EndlessRunner.GameLogic
{
    public class Movement
    {
        private Transform _transform;
        private float _speed;

        public float Modificator { get; private set; }

        public Movement(Transform transform, float speed)
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