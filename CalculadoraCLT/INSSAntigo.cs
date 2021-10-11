using CalculadoraCLT.Model;
using System;

namespace CalculadoraCLT
{
    /// <inheritdoc/>
    public class INSSAntigo : IINSS
    {
        private readonly FaixaSalarialINSS FaixaSalarial1 = new FaixaSalarialINSS { LimiteSuperior = 1830.29, Aliquota = 0.08 };
        private readonly FaixaSalarialINSS FaixaSalarial2 = new FaixaSalarialINSS { LimiteSuperior = 3050.52, Aliquota = 0.09 };
        private readonly FaixaSalarialINSS FaixaSalarial3 = new FaixaSalarialINSS { LimiteSuperior = 6101.06, Aliquota = 0.11 };
        private readonly double ValorMaximo = 671.12;

        /// <inheritdoc/>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Lançada quando <paramref name="salarioBruto"></paramref> representa um valor menor ou igual a zero.
        /// </exception>
        public double Calcular(double salarioBruto)
        {
            if (salarioBruto <= 0)
                throw new ArgumentOutOfRangeException(nameof(salarioBruto), salarioBruto, "O valor especificado não pode ser menor ou igual a zero.");

            if (salarioBruto <= FaixaSalarial1.LimiteSuperior)
                return salarioBruto * FaixaSalarial1.Aliquota;

            if (salarioBruto <= FaixaSalarial2.LimiteSuperior)
                return salarioBruto * FaixaSalarial2.Aliquota;

            if (salarioBruto <= FaixaSalarial3.LimiteSuperior)
                return salarioBruto * FaixaSalarial3.Aliquota;

            return ValorMaximo;
        }
    }
}