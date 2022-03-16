using EndlessRunner.Obstacles;

namespace EndlessRunner.Interfaces
{
    public interface IObstacle
    {
        ObstacleType Type { get; }
        void Collect();
    }
}