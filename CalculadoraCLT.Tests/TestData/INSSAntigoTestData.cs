using Xunit;

namespace CalculadoraCLT.Tests.TestData
{
    public static class INSSAntigoTestData
    {
        public static TheoryData<double, double> INSSAntigo_Deve_Calcular()
        {
            return new TheoryData<double, double>
            {
                { 850, 68 },
                { 1830.3, 164.73 },
                { 4100, 451 },
                { 8250, 671.12 },
            };
        }
    }
}