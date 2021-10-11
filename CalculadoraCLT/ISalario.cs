namespace CalculadoraCLT
{
    /// <summary>
    /// Faz cálculos de salário da CLT (Consolidação de Leis de Trabalho) brasileira.
    /// </summary>
    public interface ISalario
    {
        /// <summary>
        /// Calcula o valor do salário líquido de um mês a partir do salário bruto.
        /// </summary>
        /// <param name="salarioBruto">Salário bruto de um mês.</param>
        /// <returns>O valor do salário líquido de um mês.</returns>
        double SalarioLiquido(double salarioBruto);

        /// <summary>
        /// Calcula o valor da taxa de deduções realizadas a partir do salário bruto.
        /// </summary>
        /// <param name="salarioBruto">O salário bruto de um mês.</param>
        /// <returns>A porcentagem de descontos realizados no salário bruto até chegar ao salário líquido.</returns>
        double TaxaDescontos(double salarioBruto);

        /// <summary>
        /// Calcula o valor total de deduções realizadas a partir do salário bruto.
        /// </summary>
        /// <param name="salarioBruto">O salário bruto de um mês.</param>
        /// <returns>O valor total de descontos realizados no salário bruto até chegar ao salário líquido.</returns>
        double TotalDescontos(double salarioBruto);
    }
}