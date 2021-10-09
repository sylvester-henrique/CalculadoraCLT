using CalculadoraCLT.Model;
using System.Collections.Generic;
using Xunit;

namespace CalculadoraCLT.Tests.TestData
{
    public static class FGTSTestData
    {
        public static TheoryData<double, double> FGTS_Deve_Calcular()
        {
            return new TheoryData<double, double>
            {
                { 1000, 80 },
                { 3492.34, 279.39 },
                { 5840, 467.2 },
                { 8500, 680 },
                { 13567,  1085.36 },
            };
        }

        public static TheoryData<double, double> FGTS_Deve_Calcular_Saque_Aniversario()
        {
            return new TheoryData<double, double>
            {
                { 432, 216 },
                { 872.4, 398.96 },
                { 3610.6, 1233.18 },
                { 5000, 1650 },
                { 9999, 2649.8 },
                { 13567, 3185.05 },
                { 18382.54, 3738.25 },
                { 20000.01, 3900 },
                { 23560, 4078 }
            };
        }

        public static TheoryData<double, double, int, int, int, PrevisaoFGTS> FGTS_Deve_Calcular_Previsao_Saques()
        {
            return new TheoryData<double, double, int, int, int, PrevisaoFGTS>
            {
                { 0, 1200, 10, 6, 1,
                    new PrevisaoFGTS
                    {
                        Saques = new List<double> { 434 },
                        SaldoFinal = 814
                    }
                },
                { 0, 5000, 8, 8, 1,
                    new PrevisaoFGTS
                    {
                        Saques = new List<double> { 200 },
                        SaldoFinal = 5000
                    }
                },
                { 5000, 8500, 5, 4, 3,
                    new PrevisaoFGTS
                    {
                        Saques = new List<double> { 3226, 3845.4, 4122.43 },
                        SaldoFinal = 20326.17
                    }
                },
            };
        }

        public static TheoryData<double, double, int, int, int> FGTS_Previsao_Saques_Deve_Lancar_ArgumentOutOfRangeException()
        {
            return new TheoryData<double, double, int, int, int>
            {
                { -100, 1000, 3, 6, 2 },
                { 0, -50, 3, 6, 2 },
                { 0, 0, 3, 6, 2 },
                { 500, 6800, 0, 6, 2 },
                { 500, 6800, 13, 6, 2 },
                { 4200, 9800, 1, -2, 2 },
                { 4200, 9800, 1, 30, 2 },
                { 3000, 2000, 1, 12, -4 },
                { 3000, 2000, 1, 12,  0},
            };
        }

        public static TheoryData<FaixaSaqueFGTS[]> FGTS_Deve_Lancar_ArgumentException()
        {
            return new TheoryData<FaixaSaqueFGTS[]>
            {
                null,
                new FaixaSaqueFGTS[] { },
                new FaixaSaqueFGTS[]
                {
                    new FaixaSaqueFGTS { LimiteSuperior = 2000, Aliquota = 0.5, ParcelaAdicional = 0 },
                    new FaixaSaqueFGTS { LimiteSuperior = 1000, Aliquota = 0.4, ParcelaAdicional = 50 },
                    new FaixaSaqueFGTS { LimiteSuperior = double.MaxValue, Aliquota = 0.05, ParcelaAdicional = 2900 },
                },
                new FaixaSaqueFGTS[]
                {
                    new FaixaSaqueFGTS { LimiteSuperior = 500, Aliquota = 0.5, ParcelaAdicional = 0 },
                    new FaixaSaqueFGTS { LimiteSuperior = 1000, Aliquota = 0.7, ParcelaAdicional = 50 },
                    new FaixaSaqueFGTS { LimiteSuperior = double.MaxValue, Aliquota = 0.05, ParcelaAdicional = 2900 },
                },
                new FaixaSaqueFGTS[]
                {
                    new FaixaSaqueFGTS { LimiteSuperior = 10000, Aliquota = 0.2, ParcelaAdicional = 650 },
                    new FaixaSaqueFGTS { LimiteSuperior = 15000, Aliquota = 0.15, ParcelaAdicional = 3350 },
                    new FaixaSaqueFGTS { LimiteSuperior = double.MaxValue, Aliquota = 0.05, ParcelaAdicional = 2900 },
                },
                new FaixaSaqueFGTS[]
                {
                    new FaixaSaqueFGTS { LimiteSuperior = 20000, Aliquota = 0.1, ParcelaAdicional = 1900 },
                    new FaixaSaqueFGTS { LimiteSuperior = double.MaxValue, Aliquota = 0.05, ParcelaAdicional = 2900 },
                    new FaixaSaqueFGTS { LimiteSuperior = 50000, Aliquota = 0.03, ParcelaAdicional = 3000 },
                },
            };
        }

        public static TheoryData<FaixaSaqueFGTS[]> FGTS_Deve_Lancar_ArgumentOutOfRangeException()
        {
            return new TheoryData<FaixaSaqueFGTS[]>
            {
                new FaixaSaqueFGTS[]
                {
                    new FaixaSaqueFGTS { LimiteSuperior = -5000, Aliquota = 0.1, ParcelaAdicional = 1900 },
                    new FaixaSaqueFGTS { LimiteSuperior = -2500, Aliquota = 0.05, ParcelaAdicional = 2900 },
                    new FaixaSaqueFGTS { LimiteSuperior = 0, Aliquota = 0.03, ParcelaAdicional = 3000 },
                },
                new FaixaSaqueFGTS[]
                {
                    new FaixaSaqueFGTS { LimiteSuperior = 500, Aliquota = 0, ParcelaAdicional = 0 },
                    new FaixaSaqueFGTS { LimiteSuperior = 1000, Aliquota = -0.2, ParcelaAdicional = 50 },
                    new FaixaSaqueFGTS { LimiteSuperior = 5000, Aliquota = -0.3, ParcelaAdicional = 150 },
                },
                new FaixaSaqueFGTS[]
                {
                    new FaixaSaqueFGTS { LimiteSuperior = 500, Aliquota = 0.5, ParcelaAdicional = -500 },
                    new FaixaSaqueFGTS { LimiteSuperior = 1000, Aliquota = 0.4, ParcelaAdicional = -200 },
                    new FaixaSaqueFGTS { LimiteSuperior = 5000, Aliquota = 0.3, ParcelaAdicional = -100 },
                },
            };
        }

        public static TheoryData<FaixaSaqueFGTS[]> FGTS_Nao_Deve_Lancar_Excecao()
        {
            return new TheoryData<FaixaSaqueFGTS[]>
            {
                new FaixaSaqueFGTS[]
                {
                    new FaixaSaqueFGTS { LimiteSuperior = 500, Aliquota = 0.5, ParcelaAdicional = 0 },
                    new FaixaSaqueFGTS { LimiteSuperior = 1000, Aliquota = 0.4, ParcelaAdicional = 50 },
                    new FaixaSaqueFGTS { LimiteSuperior = 5000, Aliquota = 0.3, ParcelaAdicional = 150 },
                    new FaixaSaqueFGTS { LimiteSuperior = 10000, Aliquota = 0.2, ParcelaAdicional = 650 },
                    new FaixaSaqueFGTS { LimiteSuperior = 15000, Aliquota = 0.15, ParcelaAdicional = 1150 },
                    new FaixaSaqueFGTS { LimiteSuperior = 20000, Aliquota = 0.1, ParcelaAdicional = 1900 },
                    new FaixaSaqueFGTS { LimiteSuperior = double.MaxValue, Aliquota = 0.05, ParcelaAdicional = 2900 },                
                },
                new FaixaSaqueFGTS[]
                {
                    new FaixaSaqueFGTS { LimiteSuperior = 600, Aliquota = 0.75, ParcelaAdicional = 0 },
                    new FaixaSaqueFGTS { LimiteSuperior = 1050, Aliquota = 0.55, ParcelaAdicional = 500 },
                    new FaixaSaqueFGTS { LimiteSuperior = 4500, Aliquota = 0.3, ParcelaAdicional = 750 },
                },
                new FaixaSaqueFGTS[]
                {
                    new FaixaSaqueFGTS { LimiteSuperior = 2450, Aliquota = 0.45, ParcelaAdicional = 350 },
                },
            };
        }
    }
}