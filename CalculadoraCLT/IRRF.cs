using CalculadoraCLT.Model;
using System;
using System.Linq;

namespace CalculadoraCLT
{
    /// <inheritdoc/>
    public class IRRF : IIRRF
    {
        private readonly IINSS _inss;

        private readonly FaixaSalarialIRRF[] _faixaSalariais = new FaixaSalarialIRRF[]
        {
            new FaixaSalarialIRRF { LimiteSuperior = 1903.98, Aliquota =  0.0, Deducao = 0.0 },
            new FaixaSalarialIRRF { LimiteSuperior = 2826.65, Aliquota =  0.075, Deducao = 142.80 },
            new FaixaSalarialIRRF { LimiteSuperior = 3751.05, Aliquota = 0.15, Deducao = 354.80 },
            new FaixaSalarialIRRF { LimiteSuperior = 4664.68, Aliquota = 0.225, Deducao = 636.13 },
            new FaixaSalarialIRRF { LimiteSuperior = double.MaxValue, Aliquota = 0.275, Deducao = 869.36 },
        };

        /// <summary>
        /// Inicializa uma nova instância de <see cref="IRRF"></see>.
        /// </summary>
        public IRRF()
        {
            _inss = new INSS();
        }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="IRRF"></see>.
        /// </summary>
        /// <param name="inss">Um <see cref="IINSS"></see> que será usado no cálculo de FGTS.</param>
        public IRRF(IINSS inss)
        {
            _inss = inss;
        }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="IRRF"></see>.
        /// </summary>
        /// <param name="inss">Um <see cref="IINSS"></see> que será usado no cálculo de IRRF.</param>
        /// <param name="faixaSalariais">Valores que serão utilizados no cálculo de IRRF.</param>
        public IRRF(IINSS inss, FaixaSalarialIRRF[] faixaSalariais) : this(faixaSalariais)
        {
            _inss = inss;
        }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="IRRF"></see>.
        /// </summary>
        /// <exception cref="ArgumentException">
        ///     Lançada quando <paramref name="faixaSalariais"></paramref> representa um valor nulo ou vazio.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Lançada quando os valores de <paramref name="faixaSalariais"></paramref> não estão em ordem crescente.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Lançada quando algum valor de <see cref="FaixaMonetaria.LimiteSuperior"></see> é menor ou igual a zero.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Lançada quando algum valor de <see cref="FaixaMonetaria.Aliquota"></see> não está entre 0 e 1.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Lançada quando algum valor de <see cref="FaixaSalarialIRRF.Deducao"></see> é menor que zero.
        /// </exception>
        /// <param name="faixaSalariais">Valores que serão utilizados no cálculo de IRRF.</param>
        public IRRF(FaixaSalarialIRRF[] faixaSalariais)
        {
            if (!faixaSalariais?.Any() ?? true)
                throw new ArgumentException("O valor especificado não pode ser nulo nem um array vazio.", nameof(faixaSalariais));

            if (faixaSalariais.Any(f => f.LimiteSuperior <= 0))
                throw new ArgumentOutOfRangeException(nameof(faixaSalariais), $"O valor de {nameof(FaixaSalarialIRRF.LimiteSuperior)} não pode ser menor ou igual a zero.");

            if (faixaSalariais.Any(f => f.Aliquota < 0 || f.Aliquota > 1))
                throw new ArgumentOutOfRangeException(nameof(faixaSalariais), $"O valor de {nameof(FaixaSalarialIRRF.Aliquota)} deve ser maior que zero e menor ou igual a 1");

            if (faixaSalariais.Any(f => f.Deducao < 0))
                throw new ArgumentOutOfRangeException(nameof(faixaSalariais), $"O valor de {nameof(FaixaSalarialIRRF.Deducao)} não pode ser menor que zero.");

            if (!FaixaSalarialOrdemCrescente(faixaSalariais))
                throw new ArgumentException("Os valores das faixas salariais devem estar na ordem crescente.", nameof(faixaSalariais));

            _faixaSalariais = faixaSalariais;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Lançada quando <paramref name="salarioBruto"></paramref> representa um valor menor ou igual a zero.
        /// </exception>
        public double Calcular(double salarioBruto)
        {
            if (salarioBruto <= 0)
                throw new ArgumentOutOfRangeException(nameof(salarioBruto), salarioBruto, "O valor especificado não pode ser menor ou igual a zero.");

            var baseCalculo = salarioBruto - _inss.Calcular(salarioBruto);

            for (var i = 0; i < _faixaSalariais.Length - 1; i++)
            {
                if (baseCalculo < _faixaSalariais[i].LimiteSuperior)
                    return baseCalculo * _faixaSalariais[i].Aliquota - _faixaSalariais[i].Deducao;
            }
            var ultimaFaixaSalarial = _faixaSalariais.Last();
            return baseCalculo * ultimaFaixaSalarial.Aliquota - ultimaFaixaSalarial.Deducao;
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