using CalculadoraCLT.Model;
using CalculadoraCLT.Tests.TestData;
using System;
using System.Linq;
using Xunit;

namespace CalculadoraCLT.Tests
{
    public class FGTSTest
    {
        private readonly FGTS _fgts;

        public FGTSTest()
        {
            _fgts = new FGTS();
        }

        [Theory]
        [MemberData(nameof(FGTSTestData.FGTS_Deve_Calcular), MemberType = typeof(FGTSTestData))]
        public void FGTS_Deve_Calcular(double salario, double fgtsEsperado)
        {
            var fgtsCalculado = _fgts.Calcular(salario);
            Assert.Equal(fgtsEsperado, fgtsCalculado, precision: 2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        public void FGTS_Calcular_Deve_Lancar_ArgumentOutOfRangeException(double salario)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _fgts.Calcular(salario));
        }

        [Theory]
        [InlineData(-2000)]
        public void FGTS_Calcular_Saque_Deve_Lancar_ArgumentOutOfRangeException(double saldoFgts)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _fgts.Calcular(saldoFgts));
        }

        [Theory]
        [MemberData(nameof(FGTSTestData.FGTS_Deve_Calcular_Saque_Aniversario), MemberType = typeof(FGTSTestData))]
        public void FGTS_Deve_Calcular_Saque_Aniversario(double saldoFgts, double saqueEsperado)
        {
            var saqueCalculado = _fgts.SaqueAniversario(saldoFgts);
            Assert.Equal(saqueEsperado, saqueCalculado, precision: 2);
        }

        [Theory]
        [InlineData(-100)]
        public void FGTS_Saque_Aniversario_Deve_Lancar_ArgumentOutOfRangeException(double saldoFgts)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _fgts.SaqueAniversario(saldoFgts));
        }

        [Theory]
        [MemberData(nameof(FGTSTestData.FGTS_Deve_Calcular_Previsao_Saques), MemberType = typeof(FGTSTestData))]
        public void FGTS_Deve_Calcular_Previsao_Saques(double saldoFgts, double salarioMedio, int mesInicio, int mesAniversario, int quantidadeAnos, PrevisaoFGTS previsaoFgtsEsperada)
        {
            var previsaoFgtsCalculada = _fgts.PrevisaoSaques(saldoFgts, salarioMedio, mesInicio, mesAniversario, quantidadeAnos);
            Assert.Equal(previsaoFgtsEsperada.SaldoFinal, previsaoFgtsCalculada.SaldoFinal);
            Assert.Equal(quantidadeAnos, previsaoFgtsCalculada.Saques.Count());
            Assert.Equal(previsaoFgtsEsperada.Saques, previsaoFgtsCalculada.Saques);
        }

        [Theory]
        [MemberData(nameof(FGTSTestData.FGTS_Previsao_Saques_Deve_Lancar_ArgumentOutOfRangeException), MemberType = typeof(FGTSTestData))]
        public void FGTS_Previsao_Saques_Deve_Lancar_ArgumentOutOfRangeException(double saldoFgts, double salarioMedio, int mesInicio, int mesAniversario, int quantidadeAnos)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>_fgts.PrevisaoSaques(saldoFgts, salarioMedio, mesInicio, mesAniversario, quantidadeAnos));
        }

        [Theory]
        [MemberData(nameof(FGTSTestData.FGTS_Deve_Lancar_ArgumentException), MemberType = typeof(FGTSTestData))]
        public void FGTS_Deve_Lancar_ArgumentException(FaixaSaqueFGTS[] faixaSaqueFGTs)
        {
            Assert.Throws<ArgumentException>(() => new FGTS(faixaSaqueFGTs));
        }

        [Theory]
        [MemberData(nameof(FGTSTestData.FGTS_Deve_Lancar_ArgumentOutOfRangeException), MemberType = typeof(FGTSTestData))]
        public void FGTS_Deve_Lancar_ArgumentOutOfRangeException(FaixaSaqueFGTS[] faixaSaqueFGTs)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new FGTS(faixaSaqueFGTs));
        }

        [Theory]
        [MemberData(nameof(FGTSTestData.FGTS_Nao_Deve_Lancar_Excecao), MemberType = typeof(FGTSTestData))]
        public void FGTS_Nao_Deve_Lancar_Excecao(FaixaSaqueFGTS[] faixasSaqueFGTS)
        {
            var exception = Record.Exception(() => new FGTS(faixasSaqueFGTS));
            Assert.Null(exception);
        }
    }
}