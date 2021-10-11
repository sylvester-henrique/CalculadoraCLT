using CalculadoraCLT.Model;

namespace CalculadoraCLT
{
    /// <summary>
    /// Realiza cálculos relacionados ao FGTS (Fundo de Garantia de Tempo de Serviço).
    /// </summary>
    public interface IFGTS
    {
        /// <summary>
        /// Calcula o valor do FGTS de um mês a partir do salário bruto.
        /// </summary>
        /// <param name="salario">Salário bruto de um mês.</param>
        /// <returns>O valor do FGTS de um mês.</returns>
        double Calcular(double salario);

        /// <summary>
        /// Calcula o valor que poderá ser sacado seguindo a regra do Saque Aniversário do FGTS.
        /// </summary>
        /// <param name="saldoFgts">Saldo da conta do FGTS.</param>
        /// <returns>O valor que poderá ser sacado.</returns>
        double SaqueAniversario(double saldoFgts);

        /// <summary>
        /// Calcula os próximos saques feitos por meio do Saque Aniversário além do saldo final depois dos saques.
        /// </summary>
        /// <param name="saldoFgts">Saldo atual do FGTS.</param>
        /// <param name="salarioMedio">Salário médio no perído do cálculo.</param>
        /// <param name="mesInicio">Mês de início do cálculo.</param>
        /// <param name="mesAniversario">Mês do Saque Aniversário.</param>
        /// <param name="quantidadeAnos">Quantidade de anos que o cálculo será feito.</param>
        /// <returns>Uma <see cref="PrevisaoFGTS"></see> com os valores dos saques calculados e valor do saldo do FGTS depois dos saques.</returns>
        PrevisaoFGTS PrevisaoSaques(double saldoFgts, double salarioMedio, int mesInicio, int mesAniversario, int quantidadeAnos);
    }
}