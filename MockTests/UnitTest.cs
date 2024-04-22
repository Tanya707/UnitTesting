using DotnetUnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace MockTests
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void GetOrderPrice_Returns_Correct_Price_After_Discount()
        {
            UserAccount user = new UserAccount("John", "Smith", "1990/10/10");

            var discountUtilityMock = new Mock<IDiscountUtility>();
            discountUtilityMock.Setup(x => x.CalculateDiscount(user)).Returns(3);

            var orderService = new OrderService(discountUtilityMock.Object);

            var orderPrice = orderService.GetOrderPrice(user);

            Assert.AreEqual(user.ShoppingCart.GetCartTotalPrice() - 3, orderPrice);

            discountUtilityMock.Verify(x => x.CalculateDiscount(user), Times.Once);

            discountUtilityMock.VerifyNoOtherCalls();
        }
    }
}