namespace CalculadoraCLT.Model
{
    /// <summary>
    /// Representa uma faixa salarial para cálculo de INSS.
    /// </summary>
    public class FaixaSalarialINSS
    {
        /// <summary>
        /// O limite superior da faixa salarial.
        /// </summary>
        public double LimiteSuperior { get; set; }

        /// <summary>
        /// A alíquota da faixa salarial.
        /// </summary>
        public double Aliquota { get; set; }
    }
}