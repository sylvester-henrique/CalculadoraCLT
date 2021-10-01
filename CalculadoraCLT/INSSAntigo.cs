using CalculadoraCLT.Model;
using System;

namespace CalculadoraCLT
{
    public class INSSAntigo : IINSS
    {
        private readonly FaixaSalarialINSS FaixaSalarial1 = new FaixaSalarialINSS { LimiteSuperior = 1830.29, Aliquota = 8.0 };
        private readonly FaixaSalarialINSS FaixaSalarial2 = new FaixaSalarialINSS { LimiteSuperior = 3050.52, Aliquota = 9.0 };
        private readonly FaixaSalarialINSS FaixaSalarial3 = new FaixaSalarialINSS { LimiteSuperior = 6101.06, Aliquota = 11.00 };
        private readonly double ValorMaximo = 671.12;

        public double Calcular(double salarioBruto)
        {
            if (salarioBruto <= 0)
                throw new ArgumentOutOfRangeException(nameof(salarioBruto), salarioBruto, "O valor especificado não pode ser menor ou igual a zero.");

            if (salarioBruto <= FaixaSalarial1.LimiteSuperior)
                return salarioBruto * (FaixaSalarial1.Aliquota / 100);

            if (salarioBruto <= FaixaSalarial2.LimiteSuperior)
                return salarioBruto * (FaixaSalarial2.Aliquota / 100);

            if (salarioBruto <= FaixaSalarial3.LimiteSuperior)
                return salarioBruto * (FaixaSalarial3.Aliquota / 100);

            return ValorMaximo;
        }
    }
}