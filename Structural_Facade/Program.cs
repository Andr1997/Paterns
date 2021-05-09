using System;

namespace Structural_Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            TextEditor textEditor = new TextEditor();
            Compiller compiller = new Compiller();
            CLR clr = new CLR();

            VisualStudioFacade ide = new VisualStudioFacade(textEditor, compiller, clr);

            Programmer programmer = new Programmer();
            programmer.CreateApplication(ide);

            Console.Read();
        }
    }
    // editor de cod 
    class TextEditor
    {
        public void CreateCode()
        {
            Console.WriteLine("Scrierea codului");
        }
        public void Save()
        {
            Console.WriteLine("Slavarea codului");
        }
    }
    class Compiller
    {
        public void Compile()
        {
            Console.WriteLine("Compilarea librariei");
        }
    }
    class CLR
    {
        public void Execute()
        {
            Console.WriteLine("Executarea aplicatiei");
        }
        public void Finish()
        {
            Console.WriteLine("Finisarea executiei aplicatiei");
        }
    }

    class VisualStudioFacade
    {
        TextEditor textEditor;
        Compiller compiller;
        CLR clr;
        public VisualStudioFacade(TextEditor te, Compiller compil, CLR clr)
        {
            this.textEditor = te;
            this.compiller = compil;
            this.clr = clr;
        }
        public void Start()
        {
            textEditor.CreateCode();
            textEditor.Save();
            compiller.Compile();
            clr.Execute();
        }
        public void Stop()
        {
            clr.Finish();
        }
    }

    class Programmer
    {
        public void CreateApplication(VisualStudioFacade facade)
        {
            facade.Start();
            facade.Stop();
        }
    }
}
