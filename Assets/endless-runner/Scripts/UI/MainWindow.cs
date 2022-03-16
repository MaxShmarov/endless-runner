using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EndlessRunner.UI
{
    public class MainWindow : MonoBehaviour
    {
        public event Action StartClick;
        public event Action RestartClick;

        [SerializeField] private TextMeshProUGUI _currentHealth;
        [SerializeField] private TextMeshProUGUI _currentScore;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _restartButton;

        private const string HEALTH_FORMAT = "Health:{0}";
        private const string SCORE_FORMAT = "Score:{0}";

        private void Awake()
        {
            SetActiveStartButton(true);
            SetActiveRestartButton(false);
        }

        public void ShowRestartButton()
        {
            SetActiveRestartButton(true);
        }

        public void UpdateHealth(int health)
        {
            _currentHealth.text = string.Format(HEALTH_FORMAT, health);
        }

        public void UpdateScore(int score)
        {
            _currentScore.text = string.Format(SCORE_FORMAT, score);
        }

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClicked);
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }

        private void OnStartButtonClicked()
        {
            SetActiveStartButton(false);

            StartClick?.Invoke();
        }

        private void OnRestartButtonClicked()
        {
            SetActiveRestartButton(false);

            RestartClick?.Invoke();
        }

        private void SetActiveRestartButton(bool value)
        {
            _restartButton.gameObject.SetActive(value);
        }

        private void SetActiveStartButton(bool value)
        {
            _startButton.gameObject.SetActive(value);
        }
    }
}