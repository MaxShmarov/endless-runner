using System;

namespace EndlessRunner.Interfaces
{
    public interface IPlayer
    {
        event Action<int> HealthChanged;
        event Action<int> ScoreChanged;

        int Health { get; }
        int Score { get; }

        void Initialize();
        void TakeDamege();
        void IncreaseScore();
    }
}