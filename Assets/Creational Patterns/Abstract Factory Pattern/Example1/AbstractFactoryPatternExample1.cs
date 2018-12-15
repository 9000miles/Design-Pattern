//-------------------------------------------------------------------------------------
//	AbstractFactoryPatternExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

//This structural code demonstrates the Abstract Factory pattern creating parallel hierarchies of objects.
//Object creation has been abstracted and there is no need for hard-coded class names in the client code.

namespace AbstractFactoryPatternExample1
{
    public class AbstractFactoryPatternExample1 : MonoBehaviour
    {
        private void Start()
        {
            // Create and run the African animal world
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            // Create and run the American animal world
            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();
        }
    }

    /// <summary>
    /// The 'AbstractFactory' abstract class
    /// </summary>
    internal abstract class ContinentFactory
    {
        public abstract Botany CreateBotany();

        public abstract Herbivore CreateHerbivore();

        public abstract Carnivore CreateCarnivore();
    }

    /// <summary>
    /// The 'ConcreteFactory1' class
    /// </summary>
    internal class AfricaFactory : ContinentFactory
    {
        public override Botany CreateBotany()
        {
            return new Vegetables();
        }

        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    /// <summary>
    /// The 'ConcreteFactory2' class
    /// </summary>
    internal class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }

        public override Botany CreateBotany()
        {
            return new Vegetables();
        }
    }

    internal abstract class Botany
    {
    }

    internal class Vegetables : Botany
    {
    }

    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// </summary>
    internal abstract class Herbivore
    {
        public abstract void Eat(Botany b);
    }

    /// <summary>
    /// The 'AbstractProductB' abstract class
    /// </summary>
    internal abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    internal class Wildebeest : Herbivore
    {
        public override void Eat(Botany b)
        {
            Debug.Log(this.GetType().Name + " eats " + b.GetType().Name);
        }
    }

    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    internal class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Wildebeest
            Debug.Log(this.GetType().Name + " eats " + h.GetType().Name);
        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    internal class Bison : Herbivore
    {
        public override void Eat(Botany b)
        {
            Debug.Log(this.GetType().Name + " eats " + b.GetType().Name);
        }
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    internal class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison
            Debug.Log(this.GetType().Name + " eats " + h.GetType().Name);
        }
    }

    /// <summary>
    /// The 'Client' class
    /// </summary>
    internal class AnimalWorld
    {
        private Botany _botany;
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        // Constructor
        public AnimalWorld(ContinentFactory factory)
        {
            _botany = factory.CreateBotany();
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            _herbivore.Eat(_botany);
            _carnivore.Eat(_herbivore);
        }
    }
}