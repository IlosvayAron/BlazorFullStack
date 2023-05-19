//using System;
//using System.Threading.Tasks;
//using Bunit;
//using Xunit;
//using BlazorLibrarianPage.Pages;
//using BlazorFullStack.Contract;
//using BlazorLibrarianPage.Services;
//using Microsoft.AspNetCore.Components;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
//using Moq;
//using Castle.Core.Resource;

//namespace BlazorLibrarianPage.Tests
//{
//    [TestClass]
//    public class AddCustomerTests
//    {
//        [TestMethod]
//        public async Task AddCustomer_ValidName()
//        {
//            // Arrange
//            var member = new Member();
//            member.Name = "Test";

//            // Act
//            await CustomerService.AddMemberAsync(member);

//            // Assert
//            Assert.AreEqual("Test", member.Name);
//        }

//        [Fact]
//        public async Task AddCustomer_InValidName()
//        {
//            // Arrange
//            var member = new Member();


//            // Act
//            member.Name = "      ";

//            // Assert
//            Assert.Equal(member.Name, "      ");
//        }
//    }

//    // Mock implementation of ICustomerService
//    public class MockCustomerService : ICustomerService
//    {
//        public List<Member> AddedMembers { get; } = new List<Member>();

//        public Task AddMemberAsync(Member member)
//        {
//            AddedMembers.Add(member);
//            return Task.CompletedTask;
//        }

//        public Task<IEnumerable<Member>?> GetAllMembersAsync()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<Member?> GetMemberByIdAsync(int id)
//        {
//            throw new NotImplementedException();
//        }
//    }

//    // Mock implementation of NavigationManager
//    public class MockNavigationManager : NavigationManager
//    {
//        public string NavigatedTo { get; private set; }

//        protected override void NavigateToCore(string uri, bool forceLoad)
//        {
//            NavigatedTo = uri;
//        }
//    }
//}
