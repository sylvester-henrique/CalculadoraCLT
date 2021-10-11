namespace CalculadoraCLT.Model
{
    /// <summary>
    /// Representa uma faixa monetária.
    /// </summary>
    public abstract class FaixaMonetaria
    {
        /// <summary>
        /// O limite superior da faixa monetária.
        /// </summary>
        public double LimiteSuperior { get; set; }

        /// <summary>
        /// A alíquota da faixa monetária.
        /// </summary>
        public double Aliquota { get; set; }
    }
}