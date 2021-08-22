using Xunit;

namespace CalculadoraCLT.Tests.TestData
{
    public static class IRRFTestData
    {
        public static TheoryData<double, double> IRRF_Deve_Calcular()
        {
            return new TheoryData<double, double>
            {
                { 900, 0 },
                { 2500, 28.40 },
                { 3500, 119.01 },
                { 4300, 229.38 },
                { 5500, 472.28 },
            };
        }
    }
}