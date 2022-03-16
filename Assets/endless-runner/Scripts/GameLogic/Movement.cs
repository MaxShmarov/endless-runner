using EndlessRunner.Interfaces;
using UnityEngine;

namespace EndlessRunner.GameLogic
{
    public class Movement : IRunner
    {
        private Transform _transform;
        private float _speed;

        public float Modificator { get; private set; }

        public Movement(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void ApplyModificator(float modificator)
        {
            Modificator = modificator;
        }

        public void Run()
        {
            if (_transform == null) { return; }

            _transform.Translate(_speed * Modificator * Vector3.back);
        }
    }
}