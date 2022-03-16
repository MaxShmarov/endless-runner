using EndlessRunner.Common;

namespace EndlessRunner.Obstacles
{
    public class ObstaclePool : Pool<Obstacle>
    {
        public ObstaclePool(Factory<Obstacle> factory) : base(factory)
        {
        }
    }
}