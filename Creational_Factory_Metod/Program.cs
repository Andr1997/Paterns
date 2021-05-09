using System;

namespace Structural_Factory_Metod
{
    class Program
    {
        static void Main(string[] args)
        {
            Developer dev = new PanelDeveloper("Constructor din cotilet");
            House house2 = dev.Create();

            dev = new WoodDeveloper("Constructor privat");
            House house = dev.Create();

            Console.ReadLine();
        }
    }

    // clasa abstracta a companiei de constructie
    abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string n)
        {
            Name = n;
        }
        abstract public House Create();
    }

    // construeste case din cotilet
    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string n) : base(n)
        { }

        public override House Create()
        {
            return new PanelHouse();
        }
    }

    // construeste case din lemn
    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string n) : base(n)
        { }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

    abstract class House
    { }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("Casa din cotilet este construita");
        }
    }
    class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("Casa din lemn este construita");
        }
    }
}
