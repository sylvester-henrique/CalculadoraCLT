using System;

namespace CalculadoraCLT
{
    /// <inheritdoc/>
    public class Salario : ISalario
    {
        private readonly IINSS _inss;
        private readonly IIRRF _irrf;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="Salario"></see>.
        /// </summary>
        public Salario()
        {
            _inss = new INSS();
            _irrf = new IRRF(_inss);
        }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="Salario"></see>.
        /// </summary>
        /// <param name="inss">Um <see cref="IINSS"></see> que será usado no cálculo de salário.</param>
        /// <param name="irrf">Um <see cref="IIRRF"></see> que será usado no cálculo de salário.</param>
        public Salario(IINSS inss, IIRRF irrf)
        {
            _inss = inss;
            _irrf = irrf;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Lançada quando <paramref name="salarioBruto"></paramref> representa um valor menor ou igual a zero.
        /// </exception>
        public double SalarioLiquido(double salarioBruto)
        {
            if (salarioBruto <= 0)
                throw new ArgumentOutOfRangeException(nameof(salarioBruto), salarioBruto, "O valor especificado não pode ser menor ou igual a zero.");

            return salarioBruto - _inss.Calcular(salarioBruto) - _irrf.Calcular(salarioBruto);
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Lançada quando <paramref name="salarioBruto"></paramref> representa um valor menor ou igual a zero.
        /// </exception>
        public double TaxaDescontos(double salarioBruto)
        {
            if (salarioBruto <= 0)
                throw new ArgumentOutOfRangeException(nameof(salarioBruto), salarioBruto, "O valor especificado não pode ser menor ou igual a zero.");

            var salarioLiquido = SalarioLiquido(salarioBruto);
            return (1 - (salarioLiquido / salarioBruto)) * 100;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Lançada quando <paramref name="salarioBruto"></paramref> representa um valor menor ou igual a zero.
        /// </exception>
        public double TotalDescontos(double salarioBruto)
        {
            if (salarioBruto <= 0)
                throw new ArgumentOutOfRangeException(nameof(salarioBruto), salarioBruto, "O valor especificado não pode ser menor ou igual a zero.");

            var salarioLiquido = SalarioLiquido(salarioBruto);
            return salarioBruto - salarioLiquido;
        }
    }
}