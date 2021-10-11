namespace CalculadoraCLT
{
    /// <summary>
    /// Realiza cálculos relacionados ao INSS (Instituto Nacional do Seguro Social).
    /// </summary>
    public interface IINSS
    {
        /// <summary>
        /// Calcula o valor do INSS de um mês a partir do salário bruto.
        /// </summary>
        /// <param name="salarioBruto">Salário bruto de um mês.</param>
        /// <returns>O valor do INSS de um mês.</returns>
        double Calcular(double salarioBruto);
    }
}