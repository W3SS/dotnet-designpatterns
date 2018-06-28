namespace ContactManager.Core
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
            _builder.AddCPU();
            _builder.AddCabinet();
            _builder.AddMonitor();
            _builder.AddKeyboard();
            _builder.AddMouse();

            return _builder.GetComputer();
        }
    }
}
