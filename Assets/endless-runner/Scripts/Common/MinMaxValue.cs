using System;

namespace EndlessRunner.Common
{
    [Serializable]
    public struct MinMaxValue
    {
        public float min;
        public float max;

        public float GetRandom()
        {
            return UnityEngine.Random.Range(min, max);
        }
    }
}