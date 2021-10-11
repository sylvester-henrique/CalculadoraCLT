namespace CalculadoraCLT.Model
{
    /// <summary>
    /// Representa uma faixa salarial para cálculo de IRRF.
    /// </summary>
    public class FaixaSalarialIRRF
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
        /// A dedução da faixa salarial.
        /// </summary>
        public double Deducao { get; set; }
    }
}