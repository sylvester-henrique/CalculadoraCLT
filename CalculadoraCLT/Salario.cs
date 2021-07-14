using System;

namespace CalculadoraCLT
{
    public class Salario : ISalario
    {
        private readonly IINSS _inss;
        private readonly IIRRF _irrf;

        public Salario()
        {
            _inss = new INSS();
            _irrf = new IRRF(_inss);
        }

        public Salario(IINSS inss, IIRRF irrf)
        {
            _inss = inss;
            _irrf = irrf;
        }

        public double SalarioLiquido(double salarioBruto)
        {
            if (salarioBruto <= 0)
                throw new ArgumentException($"{nameof(salarioBruto)} não pode ser menor ou igual a zero!");

            return salarioBruto - _inss.Calcular(salarioBruto) - _irrf.Calcular(salarioBruto);
        }

        public double TaxaDescontos(double salarioBruto)
        {
            if (salarioBruto <= 0)
                throw new ArgumentException($"{nameof(salarioBruto)} não pode ser menor ou igual a zero!");

            var salarioLiquido = SalarioLiquido(salarioBruto);
            return (1 - (salarioLiquido / salarioBruto)) * 100;
        }

        public double TotalDescontos(double salarioBruto)
        {
            if (salarioBruto <= 0)
                throw new ArgumentException($"{nameof(salarioBruto)} não pode ser menor ou igual a zero!");

            var salarioLiquido = SalarioLiquido(salarioBruto);
            return salarioBruto - salarioLiquido;
        }
    }
}