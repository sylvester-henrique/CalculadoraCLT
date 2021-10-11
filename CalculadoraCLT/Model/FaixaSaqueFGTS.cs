namespace CalculadoraCLT.Model
{
    /// <summary>
    /// Representa uma faixa salarial para cálculo do FGTS.
    /// </summary>
    public class FaixaSaqueFGTS : FaixaMonetaria
    {
        /// <summary>
        /// A parcela adicional do saque do FGTS.
        /// </summary>
        public double ParcelaAdicional { get; set; }
    }
}