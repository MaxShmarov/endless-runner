namespace EndlessRunner.Interfaces
{
    public interface ISystem
    {
        bool IsRunning { get; }
        void Initialize();
        void Run();
        void Stop();
    }
}