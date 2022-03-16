using EndlessRunner.Interfaces;
using System;
using UnityEngine;

namespace EndlessRunner.GameLogic
{
    public class Player : MonoBehaviour, IPlayer
    {
        public event Action<int> HealthChanged;
        public event Action<int> ScoreChanged;

        [SerializeField] private int _defaultHealth;

        private int _currentHealth;
        public int Health {
            get => _currentHealth;
            private set
            {
                _currentHealth = value;
                HealthChanged?.Invoke(_currentHealth);
            }
        }

        private int _currentScore;
        public int Score
        {
            get => _currentScore;
            private set
            {
                _currentScore = value;
                ScoreChanged?.Invoke(_currentScore);
            }
        }

        public void Initialize()
        {
            Score = 0;
            Health = _defaultHealth;
        }

        public void TakeDamege()
        {
            Health--;
        }

        public void IncreaseScore()
        {
            Score++;
        }
    }
}