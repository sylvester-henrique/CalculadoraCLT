namespace CalculadoraCLT
{
    /// <summary>
    /// Realiza cálculos relacionados ao IRRF (Imposto sobre a renda retido na fonte).
    /// </summary>
    public interface IIRRF
    {
        /// <summary>
        /// Calcula o valor do IRRF de um mês a partir do salário bruto.
        /// </summary>
        /// <param name="SalarioBruto">Salário bruto de um mês.</param>
        /// <returns>O valor do IRRF de um mês.</returns>
        double Calcular(double SalarioBruto);
    }
}