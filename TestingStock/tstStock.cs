using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingStock
{

    [TestClass]
    public class tstStock
    {
        public clsStock createOrder()
        {
            clsStock stock = new clsStock();
            stock.Find(1);
            return stock;
        }

        [TestMethod]
        public void InstanceOK()
        {
            clsStock stock = new clsStock();
            clsStock product = new clsStock();
            Assert.IsNotNull(stock);
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void AttributeProductDescriptionOK()
        {
            clsStock product = new clsStock();
            Assert.IsNull(product.ProductDescription);        
        }

        [TestMethod]
        public void AttributeIsAvailableOK()
        {
            clsStock product = new clsStock();
            Assert.IsNotNull(product.IsAvailable);
            Assert.IsTrue(product.QuantityAvailable > 0);
        }

        [TestMethod]
        public void AttributeQuantityAvailableOK()
        {
            clsStock product = new clsStock();
            Assert.IsNotNull(product.QuantityAvailable);
            Assert.IsTrue(product.QuantityAvailable >= 0 && product.QuantityAvailable <=50);
        }

        [TestMethod]
        public void AttributeRestockDateOK()
        {
            clsStock product = new clsStock();
            Assert.IsNotNull(product.RestockDate);
        }
    }
}
