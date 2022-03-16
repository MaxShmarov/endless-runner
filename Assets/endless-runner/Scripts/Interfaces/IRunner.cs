namespace EndlessRunner.Interfaces
{
    public interface IRunner
    {
        float Modificator { get; }
        void ApplyModificator(float modificator);
        void Run();
    }
}