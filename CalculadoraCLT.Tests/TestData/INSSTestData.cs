using Xunit;

namespace CalculadoraCLT.Tests.TestData
{
    public static class INSSTestData
    {
        public static TheoryData<double, double> INSS_Deve_Calcular()
        {
            return new TheoryData<double, double>()
            {
                { 1000, 75 },
                { 1200, 91.50 },
                { 3000, 277.40 },
                { 4000, 411.29 },
                { 6500, 751.99 },
            };
        }
    }
}