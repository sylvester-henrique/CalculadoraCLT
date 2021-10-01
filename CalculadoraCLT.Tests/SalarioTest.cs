using CalculadoraCLT.Tests.TestData;
using System;
using Xunit;

namespace CalculadoraCLT.Tests
{
    public class SalarioTest
    {
        private readonly Salario _salario = new Salario();

        [Theory]
        [MemberData(nameof(SalarioTestData.Salario_Deve_Calcular_Salario_Liquido), MemberType = typeof(SalarioTestData))]
        public void Salario_Deve_Calcular_Salario_Liquido(double salarioBruto, double salarioLiquidoEsperado)
        {
            var salarioLiquidoCalculado = _salario.SalarioLiquido(salarioBruto);
            Assert.Equal(salarioLiquidoEsperado, salarioLiquidoCalculado, precision: 2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-6345.21)]
        public void Salario_Liquido_Deve_Lancar_ArgumentOutOfRangeException(double salarioBruto)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _salario.SalarioLiquido(salarioBruto));
        }

        [Theory]
        [MemberData(nameof(SalarioTestData.Salario_Deve_Calcular_Taxa_Descontos), MemberType = typeof(SalarioTestData))]

        public void Salario_Deve_Calcular_Taxa_Descontos(double salarioBruto, double taxaDescontosEsperada)
        {
            var taxaDescontosCalculada = _salario.TaxaDescontos(salarioBruto);
            Assert.Equal(taxaDescontosEsperada, taxaDescontosCalculada, precision: 2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-6)]
        public void Taxa_Descontos_Deve_Lancar_ArgumentOutOfRangeException(double salarioBruto)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _salario.TaxaDescontos(salarioBruto));
        }

        [Theory]
        [MemberData(nameof(SalarioTestData.Salario_Deve_Calcular_Total_Descontos), MemberType = typeof(SalarioTestData))]
        public void Salario_Deve_Calcular_Total_Descontos(double salarioBruto, double totalDescontosEsperado)
        {
            var totalDescontosCalculado = _salario.TotalDescontos(salarioBruto);
            Assert.Equal(totalDescontosEsperado, totalDescontosCalculado, precision: 2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-789)]
        public void Total_Descontos_Deve_Lancar_ArgumentOutOfRangeException(double salarioBruto)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _salario.TotalDescontos(salarioBruto));
        }
    }
}