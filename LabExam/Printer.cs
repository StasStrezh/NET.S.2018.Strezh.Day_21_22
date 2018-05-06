using System;
using System.Collections.Generic;
using System.IO;

namespace LabExam
{
    public class Printer : AbstractPrinter //Принтер на основе абстракции
    {
        public Printer()
        {

        }

        public Printer(string name, string model)
        {
            this.Name = name;
            this.Model = model;
        }

        public event EventHandler<PrinterEventArgs> StateChanging = delegate { };

        public override bool Equals(object obj)
        {
            var printer = obj as Printer;
            return printer != null &&
                   Name == printer.Name &&
                   Model == printer.Model;
        }
        public override int GetHashCode()
        {
            var hashCode = -1566092560;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Model);
            return hashCode;
        }

        public void Print(Stream stream)
        {
            StartedPrint();
            for (int i = 0; i < stream.Length; i++)
            {
                // simulate printing
                Console.WriteLine(stream.ReadByte());
            }
            EndedPrint();
        }
        protected virtual void StartedPrint() => StateChanging?.Invoke(this, new PrinterEventArgs(this, "Started"));
        protected virtual void EndedPrint() => StateChanging?.Invoke(this, new PrinterEventArgs(this, "Ended"));
       
        public override string ToString()
        {
            return $"{Name} - {Model}";
        }        
    }
}