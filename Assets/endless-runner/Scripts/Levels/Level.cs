using System;

namespace EndlessRunner.Levels
{
    [Serializable]
    public class Level
    {
        public int id;
        public float speedModificator;
        public int maxScore;

        public Level() { }

        public Level(int id, int speedModificator, int maxScore)
        {
            this.id = id;
            this.speedModificator = speedModificator;
            this.maxScore = maxScore;
        }
    }
}