using System.Collections.Generic;
using System.Collections;

namespace CalculadoraCLT.Model
{
    /// <summary>
    /// Representa uma previsão do Saque Aniversário do FGTS.
    /// </summary>
    public class PrevisaoFGTS
    {
        /// <summary>
        /// Um <see cref="IEnumerable"></see> de valores que representam saques.
        /// </summary>
        public IEnumerable<double> Saques { get; set; }

        /// <summary>
        /// O saldo final da conta do FGTS depois dos saques realizados.
        /// </summary>
        public double SaldoFinal { get; set; }
    }
}