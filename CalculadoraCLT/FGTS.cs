using CalculadoraCLT.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculadoraCLT
{
    public class FGTS : IFGTS
    {
        private const double TaxaFgts = 0.08;

        private readonly FaixaSaqueFGTS[] _faixasSaque = new FaixaSaqueFGTS[]
        {
            new FaixaSaqueFGTS { LimiteSuperior = 500, Aliquota = 0.5, ParcelaAdicional = 0 },
            new FaixaSaqueFGTS { LimiteSuperior = 1000, Aliquota = 0.4, ParcelaAdicional = 50 },
            new FaixaSaqueFGTS { LimiteSuperior = 5000, Aliquota = 0.3, ParcelaAdicional = 150 },
            new FaixaSaqueFGTS { LimiteSuperior = 10000, Aliquota = 0.2, ParcelaAdicional = 650 },
            new FaixaSaqueFGTS { LimiteSuperior = 15000, Aliquota = 0.15, ParcelaAdicional = 1150 },
            new FaixaSaqueFGTS { LimiteSuperior = 20000, Aliquota = 0.1, ParcelaAdicional = 1900 },
            new FaixaSaqueFGTS { LimiteSuperior = double.MaxValue, Aliquota = 0.05, ParcelaAdicional = 2900 },
        };

        public FGTS() { }

        public FGTS(FaixaSaqueFGTS[] faixasSaque)
        {
            if (!faixasSaque?.Any() ?? true)
                throw new ArgumentException("O valor especificado não pode ser nulo nem um array vazio.", nameof(faixasSaque));

            if (faixasSaque.Any(f => f.LimiteSuperior <= 0))
                throw new ArgumentOutOfRangeException(nameof(faixasSaque), $"O valor de {nameof(FaixaSaqueFGTS.LimiteSuperior)} não pode ser menor ou igual a zero");

            if (faixasSaque.Any(f => f.Aliquota <= 0))
                throw new ArgumentOutOfRangeException(nameof(faixasSaque), $"O valor de {nameof(FaixaSaqueFGTS.Aliquota)} não pode ser menor ou igual a zero");

            if (faixasSaque.Any(f => f.ParcelaAdicional < 0))
                throw new ArgumentOutOfRangeException(nameof(faixasSaque), $"O valor de {nameof(FaixaSaqueFGTS.ParcelaAdicional)} não pode ser menor que zero");

            if (!LimiteSuperiorParcelaAdicionalOrdemCrescente(faixasSaque))
            {
                throw new ArgumentException($"Os valores de {nameof(FaixaSaqueFGTS.LimiteSuperior)} e {nameof(FaixaSaqueFGTS.ParcelaAdicional)} devem estar em ordem crescente.", nameof(faixasSaque));
            }

            if (!AliquotaOrdemDecrescente(faixasSaque))
            {
                throw new ArgumentException($"Os valores de {nameof(FaixaSaqueFGTS.Aliquota)} devem estar na ordem decrescente", nameof(faixasSaque));
            }

            _faixasSaque = faixasSaque;
        }

        public double Calcular(double salario)
        {
            if (salario <= 0)
                throw new ArgumentOutOfRangeException(nameof(salario), salario, "O parâmetro especificado não pode ser menor ou igual a zero.");

            return salario * TaxaFgts;
        }

        public double SaqueAniversario(double saldoFgts)
        {
            if (saldoFgts < 0)
                throw new ArgumentOutOfRangeException(nameof(saldoFgts), saldoFgts, "O parâmetro especificado não pode ser menor que zero.");

            for (var i= 0; i < _faixasSaque.Length - 1; i++)
            {
                if (saldoFgts <= _faixasSaque[i].LimiteSuperior)
                {
                    return saldoFgts * _faixasSaque[i].Aliquota + _faixasSaque[i].ParcelaAdicional;
                }
            }
            var ultimaFaixa = _faixasSaque.Last();
            return saldoFgts * ultimaFaixa.Aliquota + ultimaFaixa.ParcelaAdicional;
        }

        public PrevisaoFGTS PrevisaoSaques(double saldoFgts, double salarioMedio, int mesInicio, int mesAniversario, int quantidadeAnos)
        {
            if (saldoFgts < 0)
                throw new ArgumentOutOfRangeException(nameof(saldoFgts), saldoFgts, "O parâmetro especificado não pode ser menor que zero.");

            if (salarioMedio <= 0)
                throw new ArgumentOutOfRangeException(nameof(salarioMedio), salarioMedio, "O parâmetro especificado não pode ser menor ou igual a zero.");

            if (quantidadeAnos <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantidadeAnos), quantidadeAnos, "O parâmetro especificado não pode ser menor ou igual a zero.");

            if (!(mesInicio >= 1 && mesInicio <= 12))
                throw new ArgumentOutOfRangeException(nameof(mesInicio), mesInicio, "O parâmetro especificado deve estar entre 1 e 12.");

            if (!(mesAniversario >= 1 && mesAniversario <= 12))
                throw new ArgumentOutOfRangeException(nameof(mesAniversario), mesAniversario, "O parâmetro especificado deve estar entre 1 e 12.");

            var data = new DateTime(DateTime.Today.Year, mesInicio, DateTime.Today.Day);
            var saldo = saldoFgts;
            var saques = new List<double>();
            var quantidadeMeses = quantidadeAnos * 12;

            for (var i=0; i<quantidadeMeses; i++)
            {
                saldo += Calcular(salarioMedio);
                if (data.Month == 12)
                {
                    saldo += Calcular(salarioMedio);
                }
                if (data.Month == mesAniversario)
                {
                    var saque = SaqueAniversario(saldo);
                    saldo -= saque;
                    saques.Add(saque);
                }
                data = data.AddMonths(1);
            }

            return new PrevisaoFGTS
            {
                SaldoFinal = saldo,
                Saques = saques
            };
        }

        private static bool LimiteSuperiorParcelaAdicionalOrdemCrescente(FaixaSaqueFGTS[] faixasSaque)
        {
            for (var i = 0; i < faixasSaque.Length - 1; i++)
            {
                if (faixasSaque[i].LimiteSuperior >= faixasSaque[i + 1].LimiteSuperior)
                    return false;

                if (faixasSaque[i].ParcelaAdicional >= faixasSaque[i + 1].ParcelaAdicional)
                    return false;
            }
            return true;
        }

        private static bool AliquotaOrdemDecrescente(FaixaSaqueFGTS[] faixasSaque)
        {
            for (var i = 0; i < faixasSaque.Length - 1; i++)
            {
                if (faixasSaque[i].Aliquota <= faixasSaque[i + 1].Aliquota)
                    return false;
            }
            return true;
        }
    }
}
