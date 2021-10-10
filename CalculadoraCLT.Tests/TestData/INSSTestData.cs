using CalculadoraCLT.Model;
using System;
using System.Linq;
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
                    new FaixaSalarialINSS { LimiteSuperior = 1000, Aliquota = 10 },
                    new FaixaSalarialINSS { LimiteSuperior = 500, Aliquota = 15 },
                    new FaixaSalarialINSS { LimiteSuperior = 400, Aliquota = 20 },
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 1750, Aliquota = 50 },
                    new FaixaSalarialINSS { LimiteSuperior = 2000, Aliquota = 15 },
                    new FaixaSalarialINSS { LimiteSuperior = 3300, Aliquota = 75 },
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 1950, Aliquota = 50 },
                    new FaixaSalarialINSS { LimiteSuperior = 1950, Aliquota = 75 },
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 1950, Aliquota = 75 },
                    new FaixaSalarialINSS { LimiteSuperior = 3500, Aliquota = 75 },
                },
            };
        }

        public static TheoryData<FaixaSalarialINSS[]> INSS_Deve_Lancar_ArgumentOutOfRangeException()
        {
            return new TheoryData<FaixaSalarialINSS[]>
            {
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 0, Aliquota = 10 }
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = -5, Aliquota = 10 }
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 3500, Aliquota = -55 }
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 3500, Aliquota = 0 }
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 3500, Aliquota = 120 }
                },
            };
        }

        public static TheoryData<FaixaSalarialINSS[]> INSS_Nao_Deve_Lancar_Excecao()
        {
            return new TheoryData<FaixaSalarialINSS[]>
            {
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 1000, Aliquota = 10 }
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 1250.43, Aliquota = 10 },
                    new FaixaSalarialINSS { LimiteSuperior = 2350.94, Aliquota = 15 },
                    new FaixaSalarialINSS { LimiteSuperior = 3800.12, Aliquota = 20 },
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 1750, Aliquota = 55.60 },
                    new FaixaSalarialINSS { LimiteSuperior = 2000, Aliquota = 68.99 },
                },
                new FaixaSalarialINSS[]
                {
                    new FaixaSalarialINSS { LimiteSuperior = 1100.00, Aliquota =  7.5 },
                    new FaixaSalarialINSS { LimiteSuperior = 2203.48, Aliquota =  9.0 },
                    new FaixaSalarialINSS { LimiteSuperior = 3305.23, Aliquota = 12.00 },
                    new FaixaSalarialINSS { LimiteSuperior = 6433.57, Aliquota = 14.00 },
                }
            };
        }
    }
}