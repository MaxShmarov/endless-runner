namespace EndlessRunner.Interfaces
{
    public interface ISystem
    {
        void Initialize();
        void Run();
        void Modify(float modificator);
    }
}