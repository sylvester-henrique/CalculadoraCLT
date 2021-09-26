using System.Collections.Generic;

namespace CalculadoraCLT.Model
{
    public class PrevisaoFGTS
    {
        public IEnumerable<double> Saques { get; set; }
        public double SaldoFinal { get; set; }
    }
}
