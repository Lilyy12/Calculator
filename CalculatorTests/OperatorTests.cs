using Calculator;

namespace CalculatorTests
{
    public class OperatorTests
    {
        [Theory]
        [InlineData(1, 2, "+", 3)]
        [InlineData(3, -4, "+", -1)]
        [InlineData(3, -4, "-", 7)]
        [InlineData(3, -4, "*", -12)]
        [InlineData(3, -3, "/", -1)]
        [InlineData(10, 0, "+", 10)]
        [InlineData(0, 0, "+", 0)]
        public void TestOperation_ReturnAsExpected(int inputOne, int inputTwo, string symbol, int Output)
        {
            // arrange
            var operationTest = $"{inputOne}{symbol}{inputTwo}";
            // act
            double result = new Operator().EvaluateExpression(operationTest);
            // assert
            Assert.Equal(result, Output);
        }

        [Fact]
        public void InvalidInput_ReturnExceptionMessage()
        {
            // arrange
            var operationTest = "2+n";

            // act && assert
            Assert.Throws<FormatException>(() => new Operator().EvaluateExpression(operationTest));
        }
    
    }
}