using CalculadoraCLT.Model;

namespace CalculadoraCLT
{
    interface IFGTS
    {
        double Calcular(double salario);
        double SaqueAniversario(double saldoFgts);
        PrevisaoFGTS PrevisaoSaques(double saldoFgts, double salarioMedio, int mesInicio, int mesAniversario, int quantidadeAnos);
    }
}