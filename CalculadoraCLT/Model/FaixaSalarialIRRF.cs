namespace CalculadoraCLT.Model
{
    /// <summary>
    /// Representa uma faixa salarial para cálculo de IRRF.
    /// </summary>
    public class FaixaSalarialIRRF : FaixaMonetaria
    {
        /// <summary>
        /// A dedução de IRRF.
        /// </summary>
        public double Deducao { get; set; }
    }
}