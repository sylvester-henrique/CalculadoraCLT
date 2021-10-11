using CalculadoraCLT.Model;
using System;
using Xunit;

namespace CalculadoraCLT.Tests.TestData
{
    public static class INSSTestData
    {
        public static TheoryData<double, double> INSS_Deve_Calcular()
        {
            return new TheoryData<double, double>()
            {
                { 1000, 75 },
                { 1200, 91.50 },
                { 3000, 277.40 },
                { 4000, 411.29 },
                { 6500, 751.99 },
            };
        }

        public static TheoryData<FaixaSalarialINSS[]> INSS_Deve_Lancar_ArgumentException()
        {
            return new TheoryData<FaixaSalarialINSS[]>
            {
                null,
                Array.Empty<FaixaSalarialINSS>(),
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 1000, Aliquota = 0.1 },
                    new FaixaSalarialINSS { LimiteSuperior = 500, Aliquota = 0.15 },
                    new FaixaSalarialINSS { LimiteSuperior = 400, Aliquota = 0.2 },
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 1750, Aliquota = 0.5 },
                    new FaixaSalarialINSS { LimiteSuperior = 2000, Aliquota = 0.15 },
                    new FaixaSalarialINSS { LimiteSuperior = 3300, Aliquota = 0.75 },
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 1950, Aliquota = 0.5 },
                    new FaixaSalarialINSS { LimiteSuperior = 1950, Aliquota = 0.75 },
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 1950, Aliquota = 0.75 },
                    new FaixaSalarialINSS { LimiteSuperior = 3500, Aliquota = 0.75 },
                },
            };
        }

        public static TheoryData<FaixaSalarialINSS[]> INSS_Deve_Lancar_ArgumentOutOfRangeException()
        {
            return new TheoryData<FaixaSalarialINSS[]>
            {
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 0, Aliquota = 0.1 }
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = -5, Aliquota = 0.1 }
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 3500, Aliquota = -0.55 }
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 3500, Aliquota = 0 }
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 3500, Aliquota = 1.2 }
                },
            };
        }

        public static TheoryData<FaixaSalarialINSS[]> INSS_Nao_Deve_Lancar_Excecao()
        {
            return new TheoryData<FaixaSalarialINSS[]>
            {
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 1000, Aliquota = 0.1 }
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 1250.43, Aliquota = 0.1 },
                    new FaixaSalarialINSS { LimiteSuperior = 2350.94, Aliquota = 0.15 },
                    new FaixaSalarialINSS { LimiteSuperior = 3800.12, Aliquota = 0.2 },
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 1750, Aliquota = 0.556 },
                    new FaixaSalarialINSS { LimiteSuperior = 2000, Aliquota = 0.6899 },
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 1100.00, Aliquota =  0.075 },
                    new FaixaSalarialINSS { LimiteSuperior = 2203.48, Aliquota =  0.09 },
                    new FaixaSalarialINSS { LimiteSuperior = 3305.23, Aliquota = 0.12 },
                    new FaixaSalarialINSS { LimiteSuperior = 6433.57, Aliquota = 0.14 },
                }
            };
        }
    }
}