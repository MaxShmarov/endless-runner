using UnityEngine;

namespace EndlessRunner.Levels
{
    [CreateAssetMenu(fileName = "Level config", menuName = "New level config")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private Level[] _levels;

        public Level GetStartingLevel()
        {
            if (_levels.Length > 0)
                return _levels[0];

            return new Level(0, 1, 1);
        }

        public Level GetNextLevel(int levelId)
        {
            for(int i = 0; i < _levels.Length; i++)
            {
                if (_levels[i].id == levelId)
                {
                    if (i < _levels.Length - 1)
                    {
                        return _levels[i + 1];
                    }
                    else
                    {
                        return _levels[i];
                    }
                }
            }

            return new Level(0, 1, 1);
        }
    }
}