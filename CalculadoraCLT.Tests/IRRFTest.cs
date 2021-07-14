using System;
using Xunit;

namespace CalculadoraCLT.Tests
{
    public class IRRFTest
    {
        private readonly IRRF _irrf = new IRRF();

        [Theory]
        [InlineData(900, 0)]
        [InlineData(2500, 28.40)]
        [InlineData(3500, 119.01)]
        [InlineData(4300, 229.38)]
        [InlineData(5500, 472.28)]
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
            Assert.Throws<ArgumentException>(() => _irrf.Calcular(salarioBruto));
        }
    }
}