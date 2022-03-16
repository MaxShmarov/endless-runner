using EndlessRunner.Blocks;
using EndlessRunner.Controller;
using EndlessRunner.Interfaces;
using EndlessRunner.Levels;
using EndlessRunner.Obstacles;
using EndlessRunner.UI;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndlessRunner.GameLogic
{
    public class GameLoop : MonoBehaviour
    {
        [SerializeField] private BlockSystem _blockSystem;
        [SerializeField] private ObstacleSystem _obstacleSystem;
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private Player _player;
        [SerializeField] private MainWindow _ui;
        [SerializeField] private LevelConfig _levels;

        private SystemRunner _systemRunner;
        private Level _currentLevel;

        private bool _running;

        private IEnumerator Start()
        {
            _inputSystem.Moveable = _player;

            _systemRunner = new SystemRunner();
            _systemRunner.Initialize(new ISystem[] { _inputSystem, _blockSystem, _obstacleSystem });

            yield return null;

            _player.HealthChanged += OnHealthChanged;
            _player.ScoreChanged += OnScoreChanged;
            _player.Initialize();

            _ui.StartClick += OnStartClicked;
        }

        private void OnStartClicked()
        {
            _ui.StartClick -= OnStartClicked;

            _running = true;
        }

        private void Update()
        {
            if (!_running) { return; }

            _systemRunner.Run();
        }

        private void OnScoreChanged(int score)
        {
            _ui.UpdateScore(score);

            if (_currentLevel != null)
            {
                if (score >= _currentLevel.maxScore)
                    UpdateLevel(_levels.GetNextLevel(_currentLevel.id));
            }
            else
            {
                UpdateLevel(_levels.GetStartingLevel());
            }
        }

        private void UpdateLevel(Level level)
        {
            _currentLevel = level;
            _systemRunner.Modify(_currentLevel.speedModificator);
        }

        private void OnHealthChanged(int health)
        {
            _ui.UpdateHealth(health);

            if (health <= 0)
            {
                _running = false;

                _ui.ShowRestartButton();
                _ui.RestartClick += OnRestartButtonClick;
            }
        }

        private void OnRestartButtonClick()
        {
            _ui.RestartClick -= OnRestartButtonClick;

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnDestroy()
        {
            _player.HealthChanged -= OnHealthChanged;
            _player.ScoreChanged -= OnScoreChanged;
        }
    }
}