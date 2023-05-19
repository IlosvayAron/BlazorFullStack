using System.ComponentModel.DataAnnotations;

namespace BlazorLibraryServer.Test
{
    [TestClass]
    public class MemberUnitTest
    {
        [TestMethod]
        public void TestRequired_WhenNameIsProvided_ReturnsTrue()
        {
            //act
            var requiredValidation = new RequiredAttribute();
            string input = "John Doe";

            //arrange
            var isValid = requiredValidation.IsValid(input);

            //assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void TestRegularExpression_WhenTheNameIsValid_ReturnsTrue()
        {
            //act
            var regularExpressionValidation = new RegularExpressionAttribute("^([a-zA-Z]{2,}\\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)");
            string input = "John Doe";

            //arrange
            var isValid = regularExpressionValidation.IsValid(input);

            //assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void TestMaxLength_WhenItsCharactersAreWithinTheExpectedValue_ReturnsTrue()
        {
            //act
            var maxLenghtValidation = new MaxLengthAttribute(50);
            string input = "John Doe";

            //arrange
            var isValid = maxLenghtValidation.IsValid(input);

            //assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void TestRegularExpression_WhenTheReadingNumberIsValid_ReturnsTrue()
        {
            //act
            var regularExpressionValidation = new RegularExpressionAttribute("^[0-9]*$");
            string input = "125";

            //arrange
            var isValid = regularExpressionValidation.IsValid(input);

            //assert
            Assert.IsTrue(isValid);
        }
    }
}
