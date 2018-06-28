namespace MvcDesignPattern.Core
{
    public class ComputerAssembler
    {
        private IComputerBuilder _builder;

        public ComputerAssembler(IComputerBuilder builder)
        {
            _builder = builder;
        }


        public Computer AssembleComputer()
        {
            return
                _builder.AddCPU()
                    .AddCabinet()
                    .AddMonitor()
                    .AddKeyboard()
                    .AddMouse()
                    .GetComputer();
        }
    }
}
