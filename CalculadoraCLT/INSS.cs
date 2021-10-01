using CalculadoraCLT.Model;
using System;

namespace CalculadoraCLT
{
    public class INSS : IINSS
    {
        private readonly FaixaSalarialINSS FaixaSalarial1 = new FaixaSalarialINSS { LimiteSuperior = 1100.00, Aliquota =  7.5 };
        private readonly FaixaSalarialINSS FaixaSalarial2 = new FaixaSalarialINSS { LimiteSuperior = 2203.48, Aliquota =  9.0 };
        private readonly FaixaSalarialINSS FaixaSalarial3 = new FaixaSalarialINSS { LimiteSuperior = 3305.23, Aliquota = 12.00 };
        private readonly FaixaSalarialINSS FaixaSalarial4 = new FaixaSalarialINSS { LimiteSuperior = 6433.57, Aliquota = 14.00 };
        private readonly double ValorMaximo = 751.99;

        public double Calcular(double salarioBruto)
        {
            if (salarioBruto <= 0)
                throw new ArgumentOutOfRangeException(nameof(salarioBruto), salarioBruto, "O valor especificado não pode ser menor ou igual a zero.");

            if (salarioBruto > FaixaSalarial4.LimiteSuperior)
                return ValorMaximo;

            if (salarioBruto <= FaixaSalarial1.LimiteSuperior)
                return salarioBruto * (FaixaSalarial1.Aliquota / 100);

            var inss = FaixaSalarial1.LimiteSuperior * (FaixaSalarial1.Aliquota / 100);
            if (salarioBruto <= FaixaSalarial2.LimiteSuperior)
            {
                inss += (salarioBruto - FaixaSalarial1.LimiteSuperior) * (FaixaSalarial2.Aliquota / 100);
                return inss;
            }

            inss += (FaixaSalarial2.LimiteSuperior - FaixaSalarial1.LimiteSuperior) * (FaixaSalarial2.Aliquota / 100);
            if (salarioBruto <= FaixaSalarial3.LimiteSuperior)
            {
                inss += (salarioBruto - FaixaSalarial2.LimiteSuperior) * (FaixaSalarial3.Aliquota / 100);
                return inss;
            }

            inss += (FaixaSalarial3.LimiteSuperior - FaixaSalarial2.LimiteSuperior) * (FaixaSalarial3.Aliquota / 100);
            inss += (salarioBruto - FaixaSalarial3.LimiteSuperior) * (FaixaSalarial4.Aliquota / 100);

            return inss;
        }
    }
}