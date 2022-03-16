using EndlessRunner.GameLogic;
using EndlessRunner.Interfaces;
using UnityEngine;

namespace EndlessRunner.Controller
{
    public class InputSystem : MonoBehaviour, ISystem, IMover
    {
        [SerializeField] private float _speed;
        [SerializeField] private MinMaxValue _offset;

        private IRunner _runner;

        public IMoveable Moveable { get; set; }

        public void Initialize()
        {
            _runner = new PlayerMovement(Moveable.Transform, _speed, Screen.width * 0.5f, _offset);
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