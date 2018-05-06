using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    public abstract class AbstractPrinter // Абстракция для принтера
    {
        public string Name { get; set; }
        public string Model { get; set; }        
    }
}
