using System;
using Xunit;

namespace CalculadoraCLT.Tests
{
    public class INSSTest
    {
        private readonly INSS _inss = new INSS();

        [Theory]
        [InlineData(1000, 75)]
        [InlineData(1200, 91.50)]
        [InlineData(3000, 277.40)]
        [InlineData(4000, 411.29)]
        [InlineData(6500, 751.99)]
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