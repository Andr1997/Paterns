using System;

namespace Structural_Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // calatorul
            Driver driver = new Driver();
            // auto
            Auto auto = new Auto();
            // mergem in calatorie
            driver.Travel(auto);
            // am intalnit pustiu, trebuie sa folosim camila
            Camel camel = new Camel();
            // folosim adapter
            ITransport camelTransport = new CamelToTransportAdapter(camel);
            // condinuam calatoria pe nisipuri
            driver.Travel(camelTransport);

            Console.Read();
        }
    }
    interface ITransport
    {
        void Drive();
    }
    // auto
    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Auto merge pe drum");
        }
    }
    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }
    // interfata Animalului
    interface IAnimal
    {
        void Move();
    }
    // clasa camila
    class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Camila merge prin pustiu");
        }
    }
    // Adapter de la camila catre ITransport
    class CamelToTransportAdapter : ITransport
    {
        Camel camel;
        public CamelToTransportAdapter(Camel c)
        {
            camel = c;
        }

        public void Drive()
        {
            camel.Move();
        }
    }
}
