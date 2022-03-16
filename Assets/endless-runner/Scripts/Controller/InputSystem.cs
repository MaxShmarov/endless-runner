using EndlessRunner.Interfaces;
using UnityEngine;

namespace EndlessRunner.Controller
{
    public class InputSystem : MonoBehaviour, ISystem, IMover
    {
        [SerializeField] private float _sensitivity;
        [SerializeField] private MinMaxValue _offset;

        private float _modificator;
        private float _centerPoint;
        private Vector3 _direction;

        public IMoveable Moveable { get; set; }

        public void Initialize()
        {
            _centerPoint = Screen.width * 0.5f;
            _modificator = 1;
        }

        public void Modify(float modificator)
        {
            _modificator = modificator;
        }

        public void Run()
        {
            if (Moveable == null) { return; }

            if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x > _centerPoint)
                {
                    if (Moveable.Transform.position.x > _offset.max)
                        return;

                    _direction = Vector3.right;
                }
                else
                {
                    if (Moveable.Transform.position.x < _offset.min)
                        return;

                    _direction = Vector3.left;
                }

                Moveable.Transform.Translate(_sensitivity * _modificator * _direction);
            }
        }
    }
}