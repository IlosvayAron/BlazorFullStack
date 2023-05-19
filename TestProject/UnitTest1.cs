using Bunit;
using BlazorLibrarianPage.Pages;

namespace BlazorLibrarianPage.Tests
{
    public class AddCustomerTests
    {
        //[Fact]
        //public void CanEnterName()
        //{
        //    // Arrange
        //    var customerServiceMock = new Mock<ICustomerService>();
        //    Member member = new Member
        //    {
        //        Name = "Test",
        //        Address = "Test street 18.",
        //        ReadingNumber = 10,
        //        DateOfBirth = DateTime.Now,
        //    };
        //    customerServiceMock.Setup(x => x.AddMemberAsync(member))
        //        .Returns(Task.FromResult(member));

        //    var customer = new Member();
        //    // Act


        //    // Assert
        //}

        [Fact]
        public void CanEnterName()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<AddCustomerPage>();
            var paraElm = cut.Find("Name");

            // Act
            cut.Find("button").Click();
            var paraElmText = paraElm.TextContent;

            // Assert
        }

        [Fact]
        public void CounterShouldIncrementWhenSelected()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Counter>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button").Click();
            var paraElmText = paraElm.TextContent;

            // Assert
            paraElmText.MarkupMatches("Current count: 1");
        }
    }
}
