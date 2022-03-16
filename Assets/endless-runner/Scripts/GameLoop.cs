using EndlessRunner.Blocks;
using EndlessRunner.Interfaces;
using EndlessRunner.Obstacles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunner
{
    public class GameLoop : MonoBehaviour
    {
        [SerializeField] private BlockSystem _blockSystem;
        [SerializeField] private ObstacleSystem _obstacleSystem;

        private List<ISystem> _systems;

        private bool _running;

        private IEnumerator Start()
        {
            _systems = new List<ISystem>();

            _systems.Add(_blockSystem);
            _systems.Add(_obstacleSystem);

            for (int i = 0; i < _systems.Count; i++)
            {
                _systems[i].Initialize();
            }

            yield return null;

            _running = true;
        }

        private void Update()
        {
            if (!_running) { return; }

            for (int i = 0; i < _systems.Count; i++)
            {
                _systems[i].Run();
            }
        }
    }
}