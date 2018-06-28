namespace ContactManager.Core
{
    public interface IComputerBuilder
    {
        void AddCPU();
        void AddCabinet();
        void AddMouse();
        void AddKeyboard();
        void AddMonitor();
        Computer GetComputer();
    }
}
