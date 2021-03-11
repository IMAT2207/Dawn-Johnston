using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace TestingStock
{
    [TestClass]
    public class tstStockCollection
    {
        [TestMethod]
        public void TestMethod1()
        {

        }

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class
            clsStockCollection AllStocks = new clsStockCollection();
            //test it exists
            Assert.IsNotNull(AllStocks);
        }

        [TestMethod]
        public void StockListOK()
        {
            //create an instance
            clsStockCollection AllStocks = new clsStockCollection();
            //create data needs to be a list of oject
            List<clsStock> TestList = new List<clsStock>();
            //create the item f test data
            clsStock TestItem = new clsStock();
            //set its properties
            TestItem.ProductId = 1;
            TestItem.ProductName = "Beef";
            TestItem.ProductDescription = "Something Good";
            TestItem.IsAvailable = true;
            TestItem.QuantityAvailable = 1;
            TestItem.RestockDate = DateTime.Now.Date;
            //add the item to the test list
            TestList.Add(TestItem);
            //assign the data to the property
            AllStocks.StockList = TestList;
            //test to see that the two values are the same
            Assert.AreEqual(AllStocks.StockList, TestList);
        }

        [TestMethod]
        public void CountProductOK()
        {
            //create an instance of the class
            clsStockCollection AllStocks = new clsStockCollection();
            //create some test data to assign to the property
            Int32 SomeCount = 2;
            //assign the data to the property
            AllStocks.Count = SomeCount;
            Assert.AreEqual(AllStocks.Count, SomeCount);
        }

        [TestMethod]
        public void ThisStockOK()
        {
            //create an instance of the class
            clsStockCollection AllStocks = new clsStockCollection();
            //create some test data to assign
            clsStock TestStock = new clsStock();
            //set the properties of the test object
            TestStock.ProductId = 1;
            TestStock.ProductName = "Beef";
            TestStock.ProductDescription = "Something Good";
            TestStock.IsAvailable = true;
            TestStock.QuantityAvailable = 1;
            TestStock.RestockDate = DateTime.Now.Date;
            //assign data
            AllStocks.ThisStock = TestStock;
            Assert.AreEqual(AllStocks.ThisStock, TestStock);
        }
    }
}
