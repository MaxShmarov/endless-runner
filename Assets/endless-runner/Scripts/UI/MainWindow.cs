using TMPro;
using UnityEngine;

namespace EndlessRunner.UI
{
    public class MainWindow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentHealth;
        [SerializeField] private TextMeshProUGUI _currentScore;

        private const string HEALTH_FORMAT = "Health:{0}";
        private const string SCORE_FORMAT = "Score:{0}";

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