using CalculadoraCLT.Model;
using System;
using System.Linq;

namespace CalculadoraCLT
{
    public class INSS : IINSS
    {
        private const int NumeroCasasDecimais = 2;

        private readonly FaixaSalarialINSS[] _faixasSalariais = new FaixaSalarialINSS[]
        {
            new FaixaSalarialINSS { LimiteSuperior = 1100.00, Aliquota =  7.5 },
            new FaixaSalarialINSS { LimiteSuperior = 2203.48, Aliquota =  9.0 },
            new FaixaSalarialINSS { LimiteSuperior = 3305.23, Aliquota = 12.00 },
            new FaixaSalarialINSS { LimiteSuperior = 6433.57, Aliquota = 14.00 }
        };

        public INSS() { }

        public INSS(FaixaSalarialINSS[] faixasSalariais)
        {
            if (!faixasSalariais?.Any() ?? true)
                throw new ArgumentException("O array especificado não pode ser nulo nem vazio.", nameof(faixasSalariais));

            if (faixasSalariais.Any(f => f.LimiteSuperior <= 0))
                throw new ArgumentOutOfRangeException(nameof(faixasSalariais), $"O valor de {nameof(FaixaSalarialINSS.LimiteSuperior)} não pode ser menor ou igual a zero.");

            if (faixasSalariais.Any(f => f.Aliquota <= 0 || f.Aliquota > 100))
                throw new ArgumentOutOfRangeException(nameof(faixasSalariais), $"O valor de {nameof(FaixaSalarialINSS.Aliquota)} deve ser maior que 0 e menor ou igual a 100");

            if (!LimitesSuperioresAliquotaOrdemCrescente(faixasSalariais))
                throw new ArgumentException($"Os valores de {nameof(FaixaSalarialINSS.LimiteSuperior)} e {nameof(FaixaSalarialINSS.Aliquota)} devem estar na ordem crescente.", nameof(_faixasSalariais));

            _faixasSalariais = faixasSalariais;
        }

        public double Calcular(double salarioBruto)
        {
            if (salarioBruto <= 0)
                throw new ArgumentOutOfRangeException(nameof(salarioBruto), salarioBruto, "O valor especificado não pode ser menor ou igual a zero.");

            var inss = 0.0;
            var limiteSuperiorFaixaAnterior = 0.0;

            for (var i=0; i<_faixasSalariais.Length; i++)
            {
                if (salarioBruto < _faixasSalariais[i].LimiteSuperior)
                {
                    inss += (salarioBruto - limiteSuperiorFaixaAnterior) * (_faixasSalariais[i].Aliquota / 100);
                    return inss;
                }
                inss += (_faixasSalariais[i].LimiteSuperior - limiteSuperiorFaixaAnterior) * (_faixasSalariais[i].Aliquota / 100);
                limiteSuperiorFaixaAnterior = _faixasSalariais[i].LimiteSuperior;
            }
            return Math.Round(inss, NumeroCasasDecimais);
        }

        private static bool LimitesSuperioresAliquotaOrdemCrescente(FaixaSalarialINSS[] faixasSalariais)
        {
            var limiteSuperiorFaixaAnterior = 0.0;
            var aliquotaFaixaAnterior = 0.0;

            for (var i = 0; i < faixasSalariais.Length; i++)
            {
                if (limiteSuperiorFaixaAnterior > faixasSalariais[i].LimiteSuperior)
                    return false;

                if (aliquotaFaixaAnterior > faixasSalariais[i].Aliquota)
                    return false;

                aliquotaFaixaAnterior = faixasSalariais[i].Aliquota;
                limiteSuperiorFaixaAnterior = faixasSalariais[i].LimiteSuperior;
            }
            return true;
        }
    }
}