using System;
using Xunit;

namespace CalculadoraCLT.Tests
{
    public class SalarioTest
    {
        private readonly Salario _salario = new Salario();

        [Theory]
        [InlineData(800, 740)]
        [InlineData(1150, 1063)]
        [InlineData(2350, 2132.11)]
        [InlineData(3645.23, 3145.87)]
        [InlineData(4333.12, 3639.4)]
        [InlineData(7756.99, 5947.98)]
        public void Salario_Deve_Calcular_Salario_Liquido(double salarioBruto, double salarioLiquidoEsperado)
        {
            var salarioLiquidoCalculado = _salario.SalarioLiquido(salarioBruto);
            Assert.Equal(salarioLiquidoEsperado, salarioLiquidoCalculado, precision: 2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-6345.21)]
        public void Salario_Salario_Liquido_Deve_Lancar_ArgumentException_Salario_Bruto_Menor_Igual_Zero(double salarioBruto)
        {
            Assert.Throws<ArgumentException>(() => _salario.SalarioLiquido(salarioBruto));
        }

        [Theory]
        [InlineData(700, 7.5)]
        [InlineData(1345.89, 7.77)]
        [InlineData(2999.99, 11.29)]
        [InlineData(5468, 19.78)]
        [InlineData(9999, 24.26)]
        public void Salario_Deve_Calcular_Taxa_Descontos(double salarioBruto, double taxaDescontosEsperada)
        {
            var taxaDescontosCalculada = _salario.TaxaDescontos(salarioBruto);
            Assert.Equal(taxaDescontosEsperada, taxaDescontosCalculada, precision: 2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-6)]
        public void Salario_Taxa_Descontos_Deve_Lancar_ArgumentException_Salario_Bruto_Menor_Igual_Zero(double salarioBruto)
        {
            Assert.Throws<ArgumentException>(() => _salario.TaxaDescontos(salarioBruto));
        }

        [Theory]
        [InlineData(980, 73.5)]
        [InlineData(1430, 112.2)]
        [InlineData(2777.98, 297.5)]
        [InlineData(3150, 368.79)]
        public void Salario_Deve_Calcular_Total_Descontos(double salarioBruto, double totalDescontosEsperado)
        {
            var totalDescontosCalculado = _salario.TotalDescontos(salarioBruto);
            Assert.Equal(totalDescontosEsperado, totalDescontosCalculado, precision: 2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-789)]
        public void Salario_Total_Descontos_Deve_Lancar_ArgumentException_Salario_Bruto_Menor_Igual_Zero(double salarioBruto)
        {
            Assert.Throws<ArgumentException>(() => _salario.TotalDescontos(salarioBruto));
        }
    }
}