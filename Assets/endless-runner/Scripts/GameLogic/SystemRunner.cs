using EndlessRunner.Interfaces;

namespace EndlessRunner.GameLogic
{
    public class SystemRunner
    {
        private ISystem[] _systems;

        public void Initialize(ISystem[] systems)
        {
            _systems = systems;

            for (int i = 0; i < _systems.Length; i++)
            {
                _systems[i].Initialize();
            }
        }

        public void Modify(float modificator)
        {
            for (int i = 0; i < _systems.Length; i++)
            {
                _systems[i].Modify(modificator);
            }
        }

        public void Run()
        {
            for (int i = 0; i < _systems.Length; i++)
            {
                _systems[i].Run();
            }
        }
    }
}