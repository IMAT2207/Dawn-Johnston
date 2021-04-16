using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System.Collections.Generic;

namespace Testing_Customer_Collection
{

    [TestClass]
    public class tstCustomerCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            //Create an instance of the class we want to create
            clsCustomerCollection collection = new clsCustomerCollection();
            //Test to see if it exists
            Assert.IsNotNull(collection);
        }

        [TestMethod]
        public void CustomerListOK()
        {
            //Create an instance of the class we want to create
            clsCustomerCollection collection = new clsCustomerCollection();
            //Create some test data to assign to the property
            List<clsCustomer> TestList = new List<clsCustomer>();
            //Creating an item for use in the list
            clsCustomer TestItem = new clsCustomer();
            //Set properties
            TestItem.TraderId = 3;
            TestItem.TraderPassword = "123456";
            TestItem.BusinessName = "Generic Business";
            TestItem.ContactEmail = "business@email.com";
            TestItem.DeliveryAddress = "45 Business Street";
            TestItem.AccountCreationDate = DateTime.Now;
            TestItem.IsSignedIn = true;
            TestItem.NumberOfOrders = 12;

            //Add test items to the list
            TestList.Add(TestItem);
            //Assign data to property
            collection.CustomerList = TestList;
            //Test to see if the values are the same
            Assert.AreEqual(collection.CustomerList, TestList);
        }

        [TestMethod]
        public void ThisCustomerPropertyOK()
        {
            //Create an instance of the class we want to create
            clsCustomerCollection collection = new clsCustomerCollection();
            //Create some test data to assign to the property
            clsCustomer TestCustomer = new clsCustomer();
            //Set the properties of the test object
            TestCustomer.TraderId = 3;
            TestCustomer.TraderPassword = "123456";
            TestCustomer.BusinessName = "Generic Business";
            TestCustomer.ContactEmail = "business@email.com";
            TestCustomer.DeliveryAddress = "45 Business Street";
            TestCustomer.AccountCreationDate = DateTime.Now;
            TestCustomer.IsSignedIn = true;
            TestCustomer.NumberOfOrders = 12;
            //Assign data to the property
            collection.ThisCustomer = TestCustomer;
            //Test to see if the values are the same
            Assert.AreEqual(collection.ThisCustomer, TestCustomer);
        }

        [TestMethod]
        public void ListAndCountOK()
        {
            //Create an instance of the class we want to create
            clsCustomerCollection collection = new clsCustomerCollection();
            //Create some test data to assign to the property
            List<clsCustomer> TestList = new List<clsCustomer>();
            //Creating an item for use in the list
            clsCustomer TestItem = new clsCustomer();
            //Set properties
            TestItem.TraderId = 3;
            TestItem.TraderPassword = "456789";
            TestItem.BusinessName = "Generic Business";
            TestItem.ContactEmail = "business@email.com";
            TestItem.DeliveryAddress = "45 Business Street";
            TestItem.AccountCreationDate = DateTime.Now;
            TestItem.IsSignedIn = true;
            TestItem.NumberOfOrders = 12;

            //Add test items to the list
            TestList.Add(TestItem);
            //Assign data to property
            collection.CustomerList = TestList;
            //Test to see of the two values are the same
            Assert.AreEqual(collection.Count, TestList.Count);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            //Create an instance of the class we want to create
            clsCustomerCollection collection = new clsCustomerCollection();
            //Creating an item for use in the list
            clsCustomer TestItem = new clsCustomer();
            //Variable to store the primary key
            Int32 PrimaryKey = 0;

            //Set properties
            TestItem.TraderId = 3;
            TestItem.TraderPassword = "456789";
            TestItem.BusinessName = "Generic Business";
            TestItem.ContactEmail = "business@email.com";
            TestItem.DeliveryAddress = "45 Business Street";
            TestItem.AccountCreationDate = DateTime.Now;
            TestItem.IsSignedIn = true;
            TestItem.NumberOfOrders = 12;

            //Set this item to the test data
            collection.ThisCustomer = TestItem;
            //Add to the record
            PrimaryKey = collection.Add();
            //Set the primary key to the test data
            TestItem.TraderId = PrimaryKey;
            //Find the record
            collection.ThisCustomer.Find(PrimaryKey);
            //Test that the two values are the same
            Assert.AreEqual(collection.ThisCustomer, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            //Create an instance of the class we want to create
            clsCustomerCollection collection = new clsCustomerCollection();
            //Creating an item for use in the list
            clsCustomer TestItem = new clsCustomer();
            //Variable to store the primary key
            Int32 PrimaryKey = 0;

            //Set properties
            TestItem.TraderId = 3;
            TestItem.TraderPassword = "123456";
            TestItem.BusinessName = "Generic Business";
            TestItem.ContactEmail = "business@email.com";
            TestItem.DeliveryAddress = "45 Business Street";
            TestItem.AccountCreationDate = DateTime.Now;
            TestItem.IsSignedIn = true;
            TestItem.NumberOfOrders = 12;

            //Set this item to the test data
            collection.ThisCustomer = TestItem;
            //Add to the record
            PrimaryKey = collection.Add();
            //Set the primary key to the test data
            TestItem.TraderId = PrimaryKey;

            //Modify The Test Data
            TestItem.TraderId = 3;
            TestItem.TraderPassword = "678910";
            TestItem.BusinessName = "Business Two";
            TestItem.ContactEmail = "businesstwo@email.com";
            TestItem.DeliveryAddress = "43 Wall Street";
            TestItem.AccountCreationDate = DateTime.Now.AddYears(-1);
            TestItem.IsSignedIn = false;
            TestItem.NumberOfOrders = 2;

            //Set the record based on rhw new test data
            collection.ThisCustomer = TestItem;
            //Update the record
            collection.Update();
            //Find the record
            collection.ThisCustomer.Find(PrimaryKey);
            //Test to see ThisCustomer matches the test data
            Assert.AreEqual(collection.ThisCustomer, TestItem);

        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            //Create an instance of the class we want to create
            clsCustomerCollection collection = new clsCustomerCollection();
            //Creating an item for use in the list
            clsCustomer TestItem = new clsCustomer();
            //Variable to store the primary key
            Int32 PrimaryKey = 0;

            //Set properties
            TestItem.TraderId = 3;
            TestItem.TraderPassword = "DeLeTe";
            TestItem.BusinessName = "Generic Business";
            TestItem.ContactEmail = "business@email.com";
            TestItem.DeliveryAddress = "45 Business Street";
            TestItem.AccountCreationDate = DateTime.Now;
            TestItem.IsSignedIn = true;
            TestItem.NumberOfOrders = 12;

            //Set this item to the test data
            collection.ThisCustomer = TestItem;
            //Add to the record
            PrimaryKey = collection.Add();
            //Set the primary key to the test data
            TestItem.TraderId = PrimaryKey;
            //Find the record
            collection.ThisCustomer.Find(PrimaryKey);
            //Delete the record
            collection.Delete();
            //Now find the record
            Boolean Found = collection.ThisCustomer.Find(PrimaryKey);
            //Test to see if the record was found
            Assert.IsFalse(Found);
        }

        [TestMethod]
        public void ReportByBusinessNameOK()
        {
            //Create an instance of the class we want to create
            clsCustomerCollection collection = new clsCustomerCollection();
            //Create an instance of the class we want to create
            clsCustomerCollection filteredCollection = new clsCustomerCollection();
            //Apply a blank string
            filteredCollection.ReportByBusinessName("");
            //Test that values are the same
            Assert.AreEqual(collection.Count, filteredCollection.Count);
        }

        [TestMethod]
        public void ReportByBusinessNameNoneFound()
        {
            //Create an instance of the class we want to create
            clsCustomerCollection filteredCollection = new clsCustomerCollection();
            //Apply a BusinessName that doesnt exist
            filteredCollection.ReportByBusinessName("Freds Burgers");
            //Test to see that there are no records
            Assert.AreEqual(0, filteredCollection.Count);
        }

        [TestMethod]
        public void ReportByBusinessNameTestDataFound()
        {
            //Create an instance of the class we want to create
            clsCustomerCollection filteredCollection = new clsCustomerCollection();
            //Variable to store outcome
            Boolean Ok = true;
            //Apply a Business Name that doesnt exist
            filteredCollection.ReportByBusinessName("Generic Business");
            //Check that the correct number of records are found
            if (filteredCollection.CustomerList.Count == 2)
            {
                //Check the first record ID is 18
                if (filteredCollection.CustomerList[0].TraderId != 18)
                {
                    Ok = false;
                }
                //Check the first record ID is 19
                if (filteredCollection.CustomerList[1].TraderId != 19)
                {
                    Ok = false;
                }
            }
            else
            {
                Ok = false;
            }
            //Test to see that there are no records
            Assert.IsTrue(Ok);
        }

    }
}
