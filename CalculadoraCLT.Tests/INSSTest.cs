using CalculadoraCLT.Model;
using CalculadoraCLT.Tests.TestData;
using System;
using Xunit;

namespace CalculadoraCLT.Tests
{
    public class INSSTest
    {
        private readonly INSS _inss = new INSS();

        [Theory]
        [MemberData(nameof(INSSTestData.INSS_Deve_Calcular), MemberType = typeof(INSSTestData))]
        public void INSS_Deve_Calcular(double salarioBruto, double inssEsperado)
        {
            var inssCalculado = _inss.Calcular(salarioBruto);
            Assert.Equal(inssEsperado, inssCalculado, precision: 2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1000)]
        public void INSS_Calcular_Deve_Lancar_ArgumentOutOfRangeException(double salarioBruto)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _inss.Calcular(salarioBruto));
        }

        [Theory]
        [MemberData(nameof(INSSTestData.INSS_Deve_Lancar_ArgumentException), MemberType = typeof(INSSTestData))]
        public void INSS_Deve_Lancar_ArgumentException(FaixaSalarialINSS[] faixasSalariais)
        {
            Assert.Throws<ArgumentException>(() => new INSS(faixasSalariais));
        }

        [Theory]
        [MemberData(nameof(INSSTestData.INSS_Deve_Lancar_ArgumentOutOfRangeException), MemberType = typeof(INSSTestData))]
        public void INSS_Deve_Lancar_ArgumentOutOfRangeException(FaixaSalarialINSS[] faixasSalariais)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new INSS(faixasSalariais));
        }

        [Theory]
        [MemberData(nameof(INSSTestData.INSS_Nao_Deve_Lancar_Excecao), MemberType = typeof(INSSTestData))]
        public void INSS_Nao_Deve_Lancar_Excecao(FaixaSalarialINSS[] faixasSalariais)
        {
            var exception = Record.Exception(() => new INSS(faixasSalariais));
            Assert.Null(exception);
        }
    }
}