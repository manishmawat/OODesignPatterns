using DesignPatterns.Behavioral;
using DesignPatterns.Creational;
using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //----------------------Creational--------------------------------

            PrototypePattern pp = new PrototypePattern();
            pp.CallProtoTypePattern();

            BuilderPattern bp = new BuilderPattern();
            bp.CallBuilder();


            //----------------------Behavioral--------------------------------------

            TemplateMethodPattern templateMethod = new TemplateMethodPattern();
            templateMethod.CallTemplateMethod();

            StrategyPattern strategy = new StrategyPattern();
            strategy.CallStrategy();


            StatePattern statePattern = new StatePattern();
            statePattern.CallState();


            ObserverPattern observer = new ObserverPattern();
            observer.CallObserver();


            MomentoPattern momento = new MomentoPattern();
            momento.CallMomento();

            IteratorPattern itr = new IteratorPattern();
            itr.CallIterator();


            InterpreterPattern inter = new InterpreterPattern();
            inter.CallInterpreter();


            ChainOfResponsibilityPattern chain = new ChainOfResponsibilityPattern();
            chain.InitiateApproval();

            MediatorPattern med = new MediatorPattern();
            med.LetsChat();


            CommandPattern commandPattern = new CommandPattern();
            commandPattern.Client();
        }
    }
}
