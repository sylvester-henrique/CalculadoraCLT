using CalculadoraCLT.Model;
using System;

namespace CalculadoraCLT
{
    public class IRRF : IIRRF
    {
        private FaixaSalarialIRRF _faixaSalarial1 = new FaixaSalarialIRRF { LimiteSuperior = 1903.98, Aliquota =  0.0, Deducao = 0.0 };
        private FaixaSalarialIRRF _faixaSalarial2 = new FaixaSalarialIRRF { LimiteSuperior = 2826.65, Aliquota =  7.5, Deducao = 142.80 };
        private FaixaSalarialIRRF _faixaSalarial3 = new FaixaSalarialIRRF { LimiteSuperior = 3751.05, Aliquota = 15.0, Deducao = 354.80 };
        private FaixaSalarialIRRF _faixaSalarial4 = new FaixaSalarialIRRF { LimiteSuperior = 4664.68, Aliquota = 22.5, Deducao = 636.13 };
        private FaixaSalarialIRRF _faixaSalarial5 = new FaixaSalarialIRRF { LimiteSuperior = double.MaxValue, Aliquota = 27.5, Deducao = 869.36 };
        private readonly IINSS _inss;

        public IRRF()
        {
            _inss = new INSS();
        }

        public IRRF(IINSS inss)
        {
            _inss = inss;
        }

        public double Calcular(double salarioBruto)
        {
            if (salarioBruto <= 0)
                throw new ArgumentOutOfRangeException(nameof(salarioBruto), salarioBruto, "O valor especificado não pode ser menor ou igual a zero.");

            var baseCalculo = salarioBruto - _inss.Calcular(salarioBruto);
            if (baseCalculo <= _faixaSalarial1.LimiteSuperior)
                return 0;

            if (baseCalculo <= _faixaSalarial2.LimiteSuperior)
                return baseCalculo * (_faixaSalarial2.Aliquota / 100) - _faixaSalarial2.Deducao;

            if (baseCalculo <= _faixaSalarial3.LimiteSuperior)
                return baseCalculo * (_faixaSalarial3.Aliquota / 100) - _faixaSalarial3.Deducao;

            if (baseCalculo <= _faixaSalarial4.LimiteSuperior)
                return baseCalculo * (_faixaSalarial4.Aliquota / 100) - _faixaSalarial4.Deducao;

            return baseCalculo * (_faixaSalarial5.Aliquota / 100) - _faixaSalarial5.Deducao;
        }
    }
}