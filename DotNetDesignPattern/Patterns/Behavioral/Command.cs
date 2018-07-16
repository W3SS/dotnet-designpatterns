using System;
using System.Collections.Generic;

namespace DotNetDesignPattern.Patterns.Behavioral
{
    public abstract class Command
    {
        protected IReceiver _receiver;

        public Command(IReceiver receiver)
        {
            _receiver = receiver;
        }
        public abstract void Excute();
        public abstract void Undo();
    }

    public interface IReceiver
    {
        void Action(char @operator, int operand);
    }

    public class Calculator : IReceiver
    {
        private int _currentValue = 0;

        public void Action(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+': _currentValue += operand; break;
                case '-': _currentValue -= operand; break;
                case '*': _currentValue *= operand; break;
                case '/': _currentValue /= operand; break;
            }
            Console.WriteLine("Current value = {0,3} (following {1} {2})", _currentValue, @operator, operand);
        }
    }

    public class CalculatorCommand : Command
    {
        public char Operator { get; set; }
        public int Operand { get; set; }

        public CalculatorCommand(IReceiver receiver) : base(receiver)
        {

        }
        public override void Excute()
        {
            _receiver.Action(Operator, Operand);
        }

        public override void Undo()
        {
            _receiver.Action(GetUndoOperator(), Operand);
        }

        private char GetUndoOperator()
        {
            switch (Operator)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default:
                    throw new ArgumentException("@operator");
            }
        }
    }

    public class Invoker
    {
        private List<Command> _commands = new List<Command>();
        private int _current = 0;

        public void Compute(Command command)
        {
            _current++;
            _commands.Add(command);
            command.Excute();
        }

        public void Redo(int level)
        {
            for (int i = 0; i < level; i++)
            {
                if (_current < _commands.Count - 1)
                {
                    _commands[_current++].Excute();
                }
                else
                {
                    break;
                }
            }
        }

        public void Undo(int level)
        {
            for (int i = 0; i < level; i++)
            {
                if (_current > 0)
                {
                    _commands[--_current].Undo();
                }
                else
                {
                    break;
                }
            }
        }
    }

    public class CommandFactory
    {
        public static Command GetCommand(IReceiver receiver, char @operator, int operand)
        {
            return new CalculatorCommand(receiver)
            {
                Operator = @operator,
                Operand = operand
            };
        }
    }
}
