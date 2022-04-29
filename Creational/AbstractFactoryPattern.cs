using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    /// <summary>
    /// Abstract Factory design pattern provides an interface for creating families of related or dependent objects without specifying their concrete classes.
    /// Component in this pattern are:
    /// 1 AbstractFactory - declares an interface of operations that create abstarct products
    /// 2 ConcreteFactory - implement the operations to create concrete product objects
    /// 3 AbstractProduct - declare an interface for a type of product object
    /// 4 Product - defines a product to be create by the corresponding concrete factory, abd implements the AbstractProduct interface
    /// 5 Client - uses interfaces declared by AbstractFactory and AbstractProduct classes
    /// </summary>
    class AbstractFactoryPattern
    {
        public void CallAbstractFactory()
        {
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();

        }
    }

    /// <summary>
    /// AbstractFactory 
    /// </summary>
    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    class AfricaFactory : ContinentFactory
    {
        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }

        public override Herbivore CreateHerbivore()
        {
            return new WildBeest();
        }
    }

    class AmericaFactory : ContinentFactory
    {
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }

        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
    }

    /// <summary>
    /// AbstractProductA abstract class
    /// </summary>
    abstract class Herbivore
    {

    }

    /// <summary>
    /// AbstractProductB abstract class
    /// </summary>
    abstract class Carnivore
    {
        public virtual void Eat(Herbivore h)
        {
            Console.WriteLine($"{this.GetType().Name} eats {h.GetType().Name}");
        }
    }


    /// <summary>
    /// ProductA1
    /// </summary>
    class WildBeest : Herbivore
    {

    }

    /// <summary>
    /// ProductB1
    /// </summary>
    class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine($"{this.GetType().Name} eats {h.GetType().Name}");
        }
    }


    /// <summary>
    /// ProductA2
    /// </summary>
    class Bison : Herbivore
    {

    }

    /// <summary>
    /// ProductB2
    /// </summary>
    class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine($"{this.GetType().Name} eats {h.GetType().Name}");
        }
    }

    class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        public AnimalWorld(ContinentFactory factory)
        {
            _herbivore = factory.CreateHerbivore();
            _carnivore = factory.CreateCarnivore();
        }

        /// <summary>
        /// Carnivore animal eats each and every herbivore animal available to that animal
        /// </summary>
        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}
