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
        public void INSS_Calcular_Deve_Gerar_ArgumentException_Salario_Bruto_Menor_Igual_Zero(double salarioBruto)
        {
            Assert.Throws<ArgumentException>(() => _inss.Calcular(salarioBruto));
        }
    }
}