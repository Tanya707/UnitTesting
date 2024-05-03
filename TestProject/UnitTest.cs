using DotnetUnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        private ShoppingCart _cart = new ShoppingCart();
        private Product _product = new Product(1, "Potato", 1.23, 1.34);

        [TestInitialize]
        public void SetUp()
        {
            _cart.AddProductToCart(_product);
        }

        [TestMethod]
        public void AddProductToShoopingCart()
        {
            Assert.IsTrue(_cart.Products.Count.Equals(1));
        }

        [TestMethod]
        public void AddProductToShoopingCartCheckIdOfProduct()
        {
            Assert.IsTrue(_cart.Products.First().Id.Equals(_product.Id));
        }

        [TestMethod]
        public void AddProductToShoopingCartCheckNameOfProduct()
        {
            Assert.IsTrue(_cart.Products.First().Name.Equals(_product.Name));
        }

        [TestMethod]
        public void RemoveProductFromShoopingCart()
        {
            _cart.RemoveProductFromCart(_product);
            Assert.IsTrue(_cart.Products.Count.Equals(0));
        }

        [TestMethod]
        public void GetTotalPriceOfShoopingCart()
        {
            Assert.IsTrue(_cart.GetCartTotalPrice().Equals(_product.Price * _product.Quantity));
        }

        [TestMethod]
        public void AddTheSameProductToShoopingCart()
        {
            _cart.AddProductToCart(_product);
            Assert.IsTrue(_cart.Products.Count.Equals(1));
        }

        [TestMethod]
        public void AddNewProductToShoopingCart()
        {
            Product newProduct = new Product(2, "Banana", 1.43, 2.34);
            _cart.AddProductToCart(newProduct);
            Assert.IsTrue(_cart.Products.Count.Equals(2));
        }
    }
}