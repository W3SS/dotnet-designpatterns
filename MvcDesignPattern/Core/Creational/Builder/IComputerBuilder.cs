namespace MvcDesignPattern.Core
{
    public interface IComputerBuilder
    {
        IComputerBuilder AddCPU();
        IComputerBuilder AddCabinet();
        IComputerBuilder AddMouse();
        IComputerBuilder AddKeyboard();
        IComputerBuilder AddMonitor();
        Computer GetComputer();
    }
}
