using EndlessRunner.Blocks;
using EndlessRunner.Interfaces;
using EndlessRunner.Obstacles;
using EndlessRunner.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunner.GameLogic
{
    public class GameLoop : MonoBehaviour
    {
        [SerializeField] private BlockSystem _blockSystem;
        [SerializeField] private ObstacleSystem _obstacleSystem;
        [SerializeField] private Player _player;
        [SerializeField] private MainWindow _ui;

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

            _player.HealthChanged += OnHealthChanged;
            _player.ScoreChanged += OnScoreChanged;
            _player.Initialize();

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

        private void OnScoreChanged(int score)
        {
            _ui.UpdateScore(score);
        }

        private void OnHealthChanged(int health)
        {
            _ui.UpdateHealth(health);

            if (health <= 0)
            {
                _running = false;

                FinishLoop();
            }
        }

        private void FinishLoop()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void OnDestroy()
        {
            _player.HealthChanged -= OnHealthChanged;
            _player.ScoreChanged -= OnScoreChanged;
        }
    }
}