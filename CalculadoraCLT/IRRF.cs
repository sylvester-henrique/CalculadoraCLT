using CalculadoraCLT.Model;
using System;
using System.Linq;

namespace CalculadoraCLT
{
    public class IRRF : IIRRF
    {
        private readonly IINSS _inss;

        private readonly FaixaSalarialIRRF[] _faixaSalariais = new FaixaSalarialIRRF[]
        {
            new FaixaSalarialIRRF { LimiteSuperior = 1903.98, Aliquota =  0.0, Deducao = 0.0 },
            new FaixaSalarialIRRF { LimiteSuperior = 2826.65, Aliquota =  7.5, Deducao = 142.80 },
            new FaixaSalarialIRRF { LimiteSuperior = 3751.05, Aliquota = 15.0, Deducao = 354.80 },
            new FaixaSalarialIRRF { LimiteSuperior = 4664.68, Aliquota = 22.5, Deducao = 636.13 },
            new FaixaSalarialIRRF { LimiteSuperior = double.MaxValue, Aliquota = 27.5, Deducao = 869.36 },
        };

        public IRRF()
        {
            _inss = new INSS();
        }

        public IRRF(IINSS inss)
        {
            _inss = inss;
        }

        public IRRF(IINSS inss, FaixaSalarialIRRF[] faixaSalariais) : this(faixaSalariais)
        {
            _inss = inss;
        }

        public IRRF(FaixaSalarialIRRF[] faixaSalariais)
        {
            if (!faixaSalariais?.Any() ?? true)
                throw new ArgumentException("O valor especificado não pode ser nulo nem um array vazio.", nameof(faixaSalariais));

            if (faixaSalariais.Any(f => f.LimiteSuperior <= 0))
                throw new ArgumentOutOfRangeException(nameof(faixaSalariais), $"O valor de {nameof(FaixaSalarialIRRF.LimiteSuperior)} não pode ser menor ou igual a zero.");

            if (faixaSalariais.Any(f => f.Aliquota < 0 || f.Aliquota > 100))
                throw new ArgumentOutOfRangeException(nameof(faixaSalariais), $"O valor de {nameof(FaixaSalarialIRRF.Aliquota)} deve ser maior que zero e menor que 100");

            if (faixaSalariais.Any(f => f.Deducao < 0))
                throw new ArgumentOutOfRangeException(nameof(faixaSalariais), $"O valor de {nameof(FaixaSalarialIRRF.Deducao)} não pode ser menor que zero.");

            var ultimaFaixaSalarial = faixaSalariais.Last();
            if (ultimaFaixaSalarial.LimiteSuperior != double.MaxValue)
                throw new ArgumentException($"O valor de {nameof(FaixaSalarialIRRF.LimiteSuperior)} da última faixa salarial deve ser igual a {nameof(double.MaxValue)}.", nameof(faixaSalariais));

            var primeiraFaixaSalarial = faixaSalariais.First();
            if (primeiraFaixaSalarial.Aliquota == 0 && primeiraFaixaSalarial.Deducao != 0)
                throw new ArgumentException($"Quando o valor de ${nameof(FaixaSalarialIRRF.Aliquota)} for igual a zero, o valor de {nameof(FaixaSalarialIRRF.Deducao)} também deve ser igual a zero.", nameof(faixaSalariais));

            if (!FaixaSalarialOrdemCrescente(faixaSalariais))
                throw new ArgumentException("Os valores das faixas salariais devem estar na ordem crescente.", nameof(faixaSalariais));
        }

        public double Calcular(double salarioBruto)
        {
            if (salarioBruto <= 0)
                throw new ArgumentOutOfRangeException(nameof(salarioBruto), salarioBruto, "O valor especificado não pode ser menor ou igual a zero.");

            var baseCalculo = salarioBruto - _inss.Calcular(salarioBruto);

            for (var i = 0; i < _faixaSalariais.Length - 1; i++)
            {
                if (baseCalculo < _faixaSalariais[i].LimiteSuperior)
                    return baseCalculo * (_faixaSalariais[i].Aliquota / 100) - _faixaSalariais[i].Deducao;
            }
            var ultimaFaixaSalarial = _faixaSalariais.Last();
            return baseCalculo * (ultimaFaixaSalarial.Aliquota / 100) - ultimaFaixaSalarial.Deducao;
        }

        private static bool FaixaSalarialOrdemCrescente(FaixaSalarialIRRF[] faixaSalariais)
        {
            double limiteSuperiorFaixaAnterior, aliquotaFaixaAnterior, deducaoFaixaAnterior;
            limiteSuperiorFaixaAnterior = aliquotaFaixaAnterior = deducaoFaixaAnterior = double.MinValue;

            foreach (var faixa in faixaSalariais)
            {
                if (limiteSuperiorFaixaAnterior >= faixa.LimiteSuperior)
                    return false;

                if (aliquotaFaixaAnterior >= faixa.Aliquota)
                    return false;

                if (deducaoFaixaAnterior >= faixa.Deducao)
                    return false;

                limiteSuperiorFaixaAnterior = faixa.LimiteSuperior;
                aliquotaFaixaAnterior = faixa.Aliquota;
                deducaoFaixaAnterior = faixa.Deducao;
            }
            return true;
        }
    }
}