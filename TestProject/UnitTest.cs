using DotnetUnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestInitialize]
        public void SetUp()
        {
            ShoppingCart cart = new ShoppingCart();
        }

        [TestMethod]
        public void AddProductToShoopingCart()
        {
            Product product = new Product(1, "Potato", 1.23, 1.34);
            ShoppingCart cart = new ShoppingCart();
            cart.AddProductToCart(product);
            Assert.IsTrue(cart.Products.Count.Equals(1));
        }

        [TestMethod]
        public void AddProductToShoopingCartCheckIdOfProduct()
        {
            Product product = new Product(1, "Potato", 1.23, 1.34);
            ShoppingCart cart = new ShoppingCart();
            cart.AddProductToCart(product);
            Assert.IsTrue(cart.Products.First().Id.Equals(product.Id));
        }

        [TestMethod]
        public void AddProductToShoopingCartCheckNameOfProduct()
        {
            Product product = new Product(1, "Potato", 1.23, 1.34);
            ShoppingCart cart = new ShoppingCart();
            cart.AddProductToCart(product);
            Assert.IsTrue(cart.Products.First().Name.Equals(product.Name));
        }

        [TestMethod]
        public void RemoveProductFromShoopingCart()
        {
            Product product = new Product(1, "Potato", 1.23, 1.34);
            ShoppingCart cart = new ShoppingCart();
            cart.AddProductToCart(product);
            cart.RemoveProductFromCart(product);
            Assert.IsTrue(cart.Products.Count.Equals(0));
        }

        [TestMethod]
        public void GetTotalPriceOfShoopingCart()
        {
            Product product = new Product(1, "Potato", 1.23, 1.34);
            ShoppingCart cart = new ShoppingCart();
            cart.AddProductToCart(product);
            var a = cart.GetCartTotalPrice();
            Assert.IsTrue(cart.GetCartTotalPrice().Equals(product.Price* product.Quantity));
        }
    }
}