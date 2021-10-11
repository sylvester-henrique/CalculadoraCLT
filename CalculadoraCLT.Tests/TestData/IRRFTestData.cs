using CalculadoraCLT.Model;
using System;
using Xunit;

namespace CalculadoraCLT.Tests.TestData
{
    public static class IRRFTestData
    {
        public static TheoryData<double, double> IRRF_Deve_Calcular()
        {
            return new TheoryData<double, double>
            {
                { 900, 0 },
                { 2500, 28.40 },
                { 3500, 119.01 },
                { 4300, 229.38 },
                { 5500, 472.28 },
            };
        }

        public static TheoryData<FaixaSalarialIRRF[]> IRRF_Deve_Lancar_ArgumentException()
        {
            return new TheoryData<FaixaSalarialIRRF[]>
            {
                null,
                Array.Empty<FaixaSalarialIRRF>(),
                new FaixaSalarialIRRF[]
                {
                    new FaixaSalarialIRRF { LimiteSuperior = 7000, Aliquota = 0.1, Deducao = 200 },
                    new FaixaSalarialIRRF { LimiteSuperior = 5000, Aliquota = 0.7, Deducao = 300 },
                    new FaixaSalarialIRRF { LimiteSuperior = double.MaxValue, Aliquota = 0.9, Deducao = 400 },
                },
                new FaixaSalarialIRRF[]
                {
                    new FaixaSalarialIRRF { LimiteSuperior = 2000, Aliquota = 0.1, Deducao = 200 },
                    new FaixaSalarialIRRF { LimiteSuperior = 5000, Aliquota = 0.05, Deducao = 300 },
                    new FaixaSalarialIRRF { LimiteSuperior = double.MaxValue, Aliquota = 0.9, Deducao = 400 },
                },
                new FaixaSalarialIRRF[]
                {
                    new FaixaSalarialIRRF { LimiteSuperior = 1000, Aliquota = 0.24, Deducao = 400 },
                    new FaixaSalarialIRRF { LimiteSuperior = 4000, Aliquota = 0.7, Deducao = 300 },
                    new FaixaSalarialIRRF { LimiteSuperior = double.MaxValue, Aliquota = 0.9, Deducao = 100 },
                },
            };
        }

        public static TheoryData<FaixaSalarialIRRF[]> IRRF_Deve_Lancar_ArgumentOutOfRangeException()
        {
            return new TheoryData<FaixaSalarialIRRF[]>
            {
                new FaixaSalarialIRRF[]
                {
                    new FaixaSalarialIRRF { LimiteSuperior = 0, Aliquota = 0.12, Deducao = 500 },
                    new FaixaSalarialIRRF { LimiteSuperior = double.MaxValue, Aliquota = 0.15, Deducao = 600 }
                },
                new FaixaSalarialIRRF[]
                {
                    new FaixaSalarialIRRF { LimiteSuperior = -400, Aliquota = 0.12, Deducao = 500 },
                    new FaixaSalarialIRRF { LimiteSuperior = double.MaxValue, Aliquota = 0.16, Deducao = 700 }
                },
                new FaixaSalarialIRRF[]
                {
                    new FaixaSalarialIRRF { LimiteSuperior = 5000, Aliquota = -0.5, Deducao = 100 },
                    new FaixaSalarialIRRF { LimiteSuperior = double.MaxValue, Aliquota = 0, Deducao = 900 },
                },
                new FaixaSalarialIRRF[]
                {
                    new FaixaSalarialIRRF { LimiteSuperior = 5000, Aliquota = 0.5, Deducao = 200 },
                    new FaixaSalarialIRRF { LimiteSuperior = double.MaxValue, Aliquota = 1.5, Deducao = 800 },
                },
                new FaixaSalarialIRRF[]
                {
                    new FaixaSalarialIRRF { LimiteSuperior = 5000, Aliquota = 0.5, Deducao = -50 },
                    new FaixaSalarialIRRF { LimiteSuperior = double.MaxValue, Aliquota = 0.9, Deducao = 0 },
                },
            };
        }

        public static TheoryData<FaixaSalarialIRRF[]> IRRF_Nao_Deve_Lancar_Excecao()
        {
            return new TheoryData<FaixaSalarialIRRF[]>
            {
                new FaixaSalarialIRRF[]
                {
                    new FaixaSalarialIRRF { LimiteSuperior = 1903.98, Aliquota =  0.0, Deducao = 0.0 },
                    new FaixaSalarialIRRF { LimiteSuperior = 2826.65, Aliquota =  0.075, Deducao = 142.80 },
                    new FaixaSalarialIRRF { LimiteSuperior = 3751.05, Aliquota = 0.15, Deducao = 354.80 },
                    new FaixaSalarialIRRF { LimiteSuperior = 4664.68, Aliquota = 0.225, Deducao = 636.13 },
                    new FaixaSalarialIRRF { LimiteSuperior = double.MaxValue, Aliquota = 0.275, Deducao = 869.36 },
                },
                new FaixaSalarialIRRF[]
                {
                    new FaixaSalarialIRRF { LimiteSuperior = 1250, Aliquota = 0.1243, Deducao = 500 },
                    new FaixaSalarialIRRF { LimiteSuperior = 4650, Aliquota = 0.3850, Deducao = 700 },
                    new FaixaSalarialIRRF { LimiteSuperior = double.MaxValue, Aliquota = 0.4299, Deducao = 900 }
                },
                new FaixaSalarialIRRF[]
                {
                    new FaixaSalarialIRRF { LimiteSuperior = double.MaxValue, Aliquota = 0.6749, Deducao = 1200 }
                }
            };
        }
    }
}