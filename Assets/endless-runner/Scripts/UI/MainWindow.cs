using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EndlessRunner.UI
{
    public class MainWindow : MonoBehaviour
    {
        public event Action StartClick;

        [SerializeField] private TextMeshProUGUI _currentHealth;
        [SerializeField] private TextMeshProUGUI _currentScore;
        [SerializeField] private Button _startButton;

        private const string HEALTH_FORMAT = "Health:{0}";
        private const string SCORE_FORMAT = "Score:{0}";

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClicked);
        }

        private void OnStartButtonClicked()
        {
            _startButton.gameObject.SetActive(false);

            StartClick?.Invoke();
        }

        public void UpdateHealth(int health)
        {
            _currentHealth.text = string.Format(HEALTH_FORMAT, health);
        }

        public void UpdateScore(int score)
        {
            _currentScore.text = string.Format(SCORE_FORMAT, score);
        }
    }
}