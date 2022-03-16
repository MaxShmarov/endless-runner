using EndlessRunner.Blocks;
using EndlessRunner.Interfaces;
using EndlessRunner.Levels;
using EndlessRunner.Obstacles;
using EndlessRunner.UI;
using System.Collections;
using UnityEngine;

namespace EndlessRunner.GameLogic
{
    public class GameLoop : MonoBehaviour
    {
        [SerializeField] private BlockSystem _blockSystem;
        [SerializeField] private ObstacleSystem _obstacleSystem;
        [SerializeField] private Player _player;
        [SerializeField] private MainWindow _ui;
        [SerializeField] private LevelConfig _levels;

        private SystemRunner _systemRunner;
        private Level _currentLevel;

        private bool _running;

        private IEnumerator Start()
        {
            _systemRunner = new SystemRunner();
            _systemRunner.Initialize(new ISystem[] { _blockSystem, _obstacleSystem });

            yield return null;

            _player.HealthChanged += OnHealthChanged;
            _player.ScoreChanged += OnScoreChanged;
            _player.Initialize();

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