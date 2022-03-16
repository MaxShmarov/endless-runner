using EndlessRunner.Interfaces;
using UnityEngine;

namespace EndlessRunner.GameLogic
{
    public class PlayerMovement : IRunner
    {
        private Transform _transform;
        private float _speed;
        private float _screenCenter;
        private Vector3 _direction;
        private MinMaxValue _offset;

        public float Modificator { get; private set; }

        public PlayerMovement(Transform transform, float speed, float screenCenter, MinMaxValue offset)
        {
            _transform = transform;
            _speed = speed;
            _screenCenter = screenCenter;
            _offset = offset;
        }

        public void ApplyModificator(float modificator)
        {
            Modificator = modificator;
        }

        public void Run()
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x > _screenCenter)
                {
                    if (_transform.position.x > _offset.max)
                        return;

                    _direction = Vector3.right;
                }
                else
                {
                    if (_transform.position.x < _offset.min)
                        return;

                    _direction = Vector3.left;
                }

                _transform.Translate(_speed * Modificator * _direction);
            }
        }
    }
}