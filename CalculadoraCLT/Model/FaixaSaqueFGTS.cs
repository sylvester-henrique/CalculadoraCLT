namespace CalculadoraCLT.Model
{
    /// <summary>
    /// Representa uma faixa salarial para cálculo do FGTS.
    /// </summary>
    public class FaixaSaqueFGTS
    {
        /// <summary>
        /// O limite superior da faixa salarial.
        /// </summary>
        public double LimiteSuperior { get; set; }

        /// <summary>
        /// A alíquota da faixa salarial.
        /// </summary>
        public double Aliquota { get; set; }

        /// <summary>
        /// A parcela adiciona da faixa salarial.
        /// </summary>
        public double ParcelaAdicional { get; set; }
    }
}