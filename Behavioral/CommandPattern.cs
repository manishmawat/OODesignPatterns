using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    /// <summary>
    /// Client
    /// </summary>
    class CommandPattern
    {
        Invoker invoke = new Invoker();
        public void Client()
        {
            invoke.Compute('+', 10);
            invoke.Compute('+', 20);
            invoke.Compute('-', 5);

            invoke.Undo();

            invoke.ReDo();
        }
    }

    /// <summary>
    /// Command
    /// </summary>
    interface ICommand
    {
        void Execute();
        void UnExecute();
    }

    /// <summary>
    /// ConcreteCommand
    /// </summary>
    class ConcreteCommand : ICommand
    {
        Receiver calculator = new Receiver();
        char oper;
        int operand;
        public ConcreteCommand(Receiver rec, char op, int operand)
        {
            this.calculator = rec;
            this.oper = op;
            this.operand = operand;
        }
        public void Execute()
        {
            calculator.Operation(oper, operand);
        }

        public void UnExecute()
        {
            calculator.Operation(UndoOperator(oper), operand);
        }

        char UndoOperator(char op)
        {
            switch(op)
            {
                case '+':return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default:
                    throw new ArgumentException("op");
            }
        }
    }


    /// <summary>
    /// Invoker ask the command to carry out the request
    /// It stores the list of command and undo/redo as per request
    /// </summary>
    class Invoker
    {
        Receiver calculator = new Receiver();
        List<ICommand> commands = new List<ICommand>();
        int currentCommandIndex = 0;

        public void Compute(char @operator, int operand)
        {
            ConcreteCommand command = new ConcreteCommand(calculator,@operator,operand);
            command.Execute();
            commands.Add(command);
            currentCommandIndex++;
        }

        public void Undo()
        {
            ICommand command = commands[--currentCommandIndex];
            command.UnExecute();
        }

        public void ReDo()
        {
            if (currentCommandIndex >= commands.Count)
            {
                currentCommandIndex = commands.Count - 1;
                return;
            }
            ICommand command = commands[currentCommandIndex++];
            command.Execute();
        }

    }

    //Receiver - who does actual work like calculator
    class Receiver
    {
        int curr = 0;

        public Receiver()
        {

        }
        public void Operation(char @operator, int operand)
        {
            switch(@operator)
            {
                case '+':curr += operand; break;
                case '-': curr -= operand; break;
                case '*': curr *= operand; break;
                case '/': curr /= operand; break;
            }
        }
    }


}
