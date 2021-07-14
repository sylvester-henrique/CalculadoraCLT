using System;
using Xunit;

namespace CalculadoraCLT.Tests
{
    public class INSSAntigoTest
    {
        private readonly INSSAntigo _inssAntigo = new INSSAntigo();

        [Theory]
        [InlineData(850, 68)]
        [InlineData(1830.3, 164.73)]
        [InlineData(4100, 451)]
        [InlineData(8250, 671.12)]
        public void INSSAntigo_Deve_Calcular(double salarioBruto, double inssEsperado)
        {
            var inssCalculado = _inssAntigo.Calcular(salarioBruto);
            Assert.Equal(inssEsperado, inssCalculado, precision: 2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void INSSAntigo_Calcular_Deve_Lancar_ArgumentException_Salario_Bruto_Menor_Igual_Zero(double salarioBruto)
        {
            Assert.Throws<ArgumentException>(() => _inssAntigo.Calcular(salarioBruto));
        }
    }
}