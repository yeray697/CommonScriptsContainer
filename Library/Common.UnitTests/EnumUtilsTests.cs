using Common;

namespace CommonTests
{
    public class EnumUtilsTests
    {
        private enum Test
        {
            Default, A, B, C, D
        }

        [Fact]
        public void ParseOrDefault_HappyPath()
        {
            string input = "A";

            var output = EnumUtils.ParseOrDefault<Test>(input);

            Assert.Equal(Test.A, output);
        }

        [Theory]
        [InlineData("notValidValue", true)]
        [InlineData(null, true)]
        [InlineData("notValidValue", false)]
        public void ParseOrDefault_InvalidInput_DefaultOutput_HappyPath(string input, bool setDefault)
        {
            Test output;
            Test expectedOutput;

            if (setDefault)
            {
                expectedOutput = Test.C;
                output = EnumUtils.ParseOrDefault(input, Test.C);
            }
            else
            {
                expectedOutput = default;
                output = EnumUtils.ParseOrDefault<Test>(input);
            }

            Assert.Equal(expectedOutput, output);
        }
    }
}