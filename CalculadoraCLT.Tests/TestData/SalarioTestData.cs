using Xunit;

namespace CalculadoraCLT.Tests.TestData
{
    public static class SalarioTestData
    {
        public static TheoryData<double, double> Salario_Deve_Calcular_Salario_Liquido()
        {
            return new TheoryData<double, double>
            {
                { 800, 740 },
                { 1150, 1063 },
                { 2350, 2132.11 },
                { 3645.23, 3145.87 },
                { 4333.12, 3639.4 },
                { 7756.99, 5947.98 },
            };
        }

        public static TheoryData<double, double> Salario_Deve_Calcular_Taxa_Descontos()
        {
            return new TheoryData<double, double>
            {
                { 700, 7.5 },
                { 1345.89, 7.77 },
                { 2999.99, 11.29 },
                { 5468, 19.78 },
                { 9999, 24.26 },
            };
        }

        public static TheoryData<double, double> Salario_Deve_Calcular_Total_Descontos()
        {
            return new TheoryData<double, double>
            {
                { 980, 73.5 },
                { 1430, 112.2 },
                { 2777.98, 297.5 },
                { 3150, 368.79 },
            };
        }
    }
}
