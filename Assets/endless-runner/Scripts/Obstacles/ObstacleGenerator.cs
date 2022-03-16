using EndlessRunner.Common;
using UnityEngine;

namespace EndlessRunner.Obstacles
{
    public class ObstacleGenerator : Generator<Obstacle>
    {
        private MinMaxValue _offsetByX;
        private MinMaxValue _offsetByZ;

        public ObstacleGenerator(Pool<Obstacle> pool, int minimalCount, MinMaxValue offsetByX, MinMaxValue offsetByZ) : base(pool, minimalCount)
        {
            _offsetByX = offsetByX;
            _offsetByZ = offsetByZ;
        }

        protected override void SetItemPosition(Obstacle item, int index)
        {
            if (_activeItems.Count > 1)
            {
                var previous = _activeItems[index - 1];

                var newPosition = new Vector3(
                    _offsetByX.GetRandom(),
                    previous.transform.position.y,
                    previous.transform.position.z + _offsetByZ.GetRandom());

                item.transform.position = newPosition;
            }
        }
    }
}