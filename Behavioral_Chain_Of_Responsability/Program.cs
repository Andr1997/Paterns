using System;

namespace Behavioral_Chain_Of_Responsability
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver(false, true, true);

            PaymentHandler bankPaymentHandler = new BankPaymentHandler();
            PaymentHandler moneyPaymentHadler = new MoneyPaymentHandler();
            PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();
            bankPaymentHandler.Successor = paypalPaymentHandler;
            paypalPaymentHandler.Successor = moneyPaymentHadler;

            bankPaymentHandler.Handle(receiver);

            Console.Read();
        }
    }

    class Receiver
    {
        // transferuri bancare
        public bool BankTransfer { get; set; }
        // transferuri banesti - WesternUnion, Unistream
        public bool MoneyTransfer { get; set; }
        // transferuri PayPal
        public bool PayPalTransfer { get; set; }
        public Receiver(bool bt, bool mt, bool ppt)
        {
            BankTransfer = bt;
            MoneyTransfer = mt;
            PayPalTransfer = ppt;
        }
    }
    abstract class PaymentHandler
    {
        public PaymentHandler Successor { get; set; }
        public abstract void Handle(Receiver receiver);
    }

    class BankPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.BankTransfer == true)
                Console.WriteLine("Executa transfer bancar");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }

    class PayPalPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.PayPalTransfer == true)
                Console.WriteLine("Executa transfer PayPal");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
    // Transferuri cu ajutorul sistemelor banesti
    class MoneyPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.MoneyTransfer)
                Console.WriteLine("Executa transfer prin sisteme de transfer banesc");
            else
            {
                Successor?.Handle(receiver);
            }
        }
    }
}
