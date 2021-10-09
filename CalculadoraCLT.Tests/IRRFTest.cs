using CalculadoraCLT.Model;
using CalculadoraCLT.Tests.TestData;
using System;
using Xunit;

namespace CalculadoraCLT.Tests
{
    public class IRRFTest
    {
        private readonly IRRF _irrf = new IRRF();

        [Theory]
        [MemberData(nameof(IRRFTestData.IRRF_Deve_Calcular), MemberType = typeof(IRRFTestData))]
        public void IRRF_Deve_Calcular(double salarioBruto, double irrfEsperado)
        {
            var irrfCalculado = _irrf.Calcular(salarioBruto);
            Assert.Equal(irrfEsperado, irrfCalculado, precision: 2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5000)]
        public void IRRF_Calcular_Deve_Lancar_ArgumentException_Salario_Bruto_Menor_Igual_Zero(double salarioBruto)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _irrf.Calcular(salarioBruto));
        }

        [Theory]
        [MemberData(nameof(IRRFTestData.IRRF_Deve_Lancar_ArgumentException), MemberType = typeof(IRRFTestData))]
        public void IRRF_Deve_Lancar_ArgumentException(FaixaSalarialIRRF[] faixasSalariais)
        {
            Assert.Throws<ArgumentException>(() => new IRRF(faixasSalariais));
        }

        [Theory]
        [MemberData(nameof(IRRFTestData.IRRF_Deve_Lancar_ArgumentOutOfRangeException), MemberType = typeof(IRRFTestData))]
        public void IRRF_Deve_Lancar_ArgumentOutOfRangeException(FaixaSalarialIRRF[] faixasSalariais)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new IRRF(faixasSalariais));
        }

        [Theory]
        [MemberData(nameof(IRRFTestData.IRRF_Nao_Deve_Lancar_Excecao), MemberType = typeof(IRRFTestData))]
        public void IRRF_Nao_Deve_Lancar_Excecao(FaixaSalarialIRRF[] faixasSalariais)
        {
            var exception = Record.Exception(() => new IRRF(faixasSalariais));
            Assert.Null(exception);
        }
    }
}