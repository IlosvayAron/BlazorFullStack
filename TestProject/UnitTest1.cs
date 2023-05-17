using Xunit;
using BlazorLibrarianPage.Pages;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void NameField_InvalidName_DisplaysErrorMessage()
        {
            // Arrange
            var component = new AddCustomer();

            // Act
            component.Name = "123"; // Set an invalid name
            component.AddCustomer(); // Trigger the form submission

            // Assert
            // Check if the error message is displayed
            Assert.NotNull(component.ValidationMessages.GetValidationMessages("Name"));
        }
    }
}