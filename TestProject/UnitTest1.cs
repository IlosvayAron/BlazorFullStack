using Bunit;
using BlazorLibrarianPage.Pages;
using BlazorFullStack.Contract;
using BlazorLibrarianPage.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorLibrarianPage.Tests
{
    public class AddCustomerTests
    {
        [Fact]
        public void Name_Input_Correct()
        {
            // Arrange
            using var ctx = new TestContext();
            var customerServiceMock = new Mock<ICustomerService>();
            ctx.Services.AddSingleton(customerServiceMock.Object);

            var cut = ctx.RenderComponent<AddCustomerPage>();
            var nameInput = cut.Find("#name");
            nameInput.Change("Test Jozska");

            // Act
            cut.Find("button").Click();

            // Assert
            var validationMessage = cut.FindAll(".validation-message");
            Assert.Empty(validationMessage);
        }

        [Fact]
        public void Name_Input_Empty()
        {
            // Arrange
            using var ctx = new TestContext();
            var customerServiceMock = new Mock<ICustomerService>();
            ctx.Services.AddSingleton(customerServiceMock.Object);

            var cut = ctx.RenderComponent<AddCustomerPage>();
            var nameInput = cut.Find("#name");
            nameInput.Change("    ");

            var validationMessage = cut.Find(".validation-message");

            // Act
            cut.Find("button").Click();

            // Assert
            Assert.Equal("Please enter a name.", validationMessage.TextContent);
        }


        [Fact]
        public void Name_Input_Incorrect()
        {
            // Arrange
            using var ctx = new TestContext();
            var customerServiceMock = new Mock<ICustomerService>();
            ctx.Services.AddSingleton(customerServiceMock.Object);

            var cut = ctx.RenderComponent<AddCustomerPage>();
            var nameInput = cut.Find("#name");
            nameInput.Change("asd");

            var validationMessage = cut.Find(".validation-message");

            // Act
            cut.Find("button").Click();

            // Assert
            Assert.Equal("Valid characters include (A-Z) (a-z) (' space -)", validationMessage.TextContent);
        }

        [Fact]
        public void Name_Input_TooLong()
        {
            // Arrange
            using var ctx = new TestContext();
            var customerServiceMock = new Mock<ICustomerService>();
            ctx.Services.AddSingleton(customerServiceMock.Object);

            var cut = ctx.RenderComponent<AddCustomerPage>();
            var nameInput = cut.Find("#name");
            nameInput.Change("abcdefghijabcdefghijabcdefghij abcdefghijabcdefghij");

            var validationMessage = cut.Find(".validation-message");

            // Act
            cut.Find("button").Click();

            // Assert
            Assert.Equal("The name can only be 50 characters long.", validationMessage.TextContent);
        }

        [Fact]
        public void ReadingNumber_Input_Not_Number()
        {
            // Arrange
            using var ctx = new TestContext();
            var customerServiceMock = new Mock<ICustomerService>();
            ctx.Services.AddSingleton(customerServiceMock.Object);

            var cut = ctx.RenderComponent<AddCustomerPage>();
            var nameInput = cut.Find("#name");
            nameInput.Change("Test Jozska");
            var readingNumberInput = cut.Find("#readingNumber");
            readingNumberInput.Change("asd");

            var validationMessage = cut.Find(".validation-message");

            // Act
            cut.Find("button").Click();

            // Assert
            Assert.Equal("The ReadingNumber field must be a number.", validationMessage.TextContent);
        }
    }
}
