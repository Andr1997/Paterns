using System;

namespace Behavioral_Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerMediator mediator = new ManagerMediator();
            Colleague customer = new CustomerColleague(mediator);
            Colleague programmer = new ProgrammerColleague(mediator);
            Colleague tester = new TesterColleague(mediator);
            //mediator.Customer = customer;
            //mediator.Programmer = programmer;
            //mediator.Tester = tester;

            customer.Send("Exista comanda - trebuie aplicatie");
            programmer.Send("Aplicatia e gata, trebuie testata");
            tester.Send("Aplicatia este testata - este gata de livrare");

            Console.Read();
        }
    }

    abstract class Mediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }
    abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }
        public abstract void Notify(string message);
    }
    // clasa clientului
    class CustomerColleague : Colleague
    {
        public CustomerColleague(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Mesaj clientului: " + message);
        }
    }
    // clasa programatorului
    class ProgrammerColleague : Colleague
    {
        public ProgrammerColleague(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Mesaj programatorului: " + message);
        }
    }
    // clasa testerului
    class TesterColleague : Colleague
    {
        public TesterColleague(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Mesaj testerului: " + message);
        }
    }

    class ManagerMediator : Mediator
    {
        public Colleague Customer { get; set; }
        public Colleague Programmer { get; set; }
        public Colleague Tester { get; set; }
        public override void Send(string msg, Colleague colleague)
        {
            //daca emitatorul este client, atunci este o comanda noua sitrimitem mesaj programatorului
            if (Customer == colleague)
                Programmer.Notify(msg);
            // daca emitatorul este programator atunci aplicatia este gata si trebuie testata
            else if (Programmer == colleague)
                Tester.Notify(msg);
            // daca emitatorul este tester atunci aplicatia este gata de livrate
            else if (Tester == colleague)
                Customer.Notify(msg);
        }
    }
}
