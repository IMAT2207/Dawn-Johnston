using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System.Collections.Generic;

namespace TestingStaff
{
    [TestClass]
    public class tstStaffCollection
    {

        [TestMethod]
        public void InstanceOK()
        {
            // Creates an instance of clsStaffCollection
            clsStaffCollection StaffMembers = new clsStaffCollection();

            // Test to see if the instance exists.
            Assert.IsNotNull(StaffMembers);
        }

        [TestMethod]
        public void StaffListOK()
        {
            // Creates an instance of clsStaffCollection.
            clsStaffCollection StaffMembers = new clsStaffCollection();

            // Creates a list of objects used for the test data, assigns to the property.
            List<clsStaff> TestList = new List<clsStaff>();

            // Create an item of test data.
            clsStaff TestItem = new clsStaff();

            // Sets the test items properties.
            TestItem.StaffID = 12;
            TestItem.StaffPassword = "password";
            TestItem.IsManager = true;
            TestItem.RecordCreated = DateTime.Now.Date;
            TestItem.FirstName = "Test";
            TestItem.FamilyName = "Account";

            // Adds the item to the test list.
            TestList.Add(TestItem);

            // Assigns the data to the property.
            StaffMembers.StaffList = TestList;

            // Tests for equality of the two values.
            Assert.AreEqual(StaffMembers.StaffList, TestList);


        }

        [TestMethod]
        public void ThisStaffPropertyOK()
        {
            // Creates an instance of clsStaffCollection.
            clsStaffCollection StaffMembers = new clsStaffCollection();

            // Creteating test data to assign to the property.
            clsStaff TestStaff = new clsStaff();

            // Sets the test items properties.
            TestStaff.StaffID = 12;
            TestStaff.StaffPassword = "password";
            TestStaff.IsManager = true;
            TestStaff.RecordCreated = DateTime.Now.Date;
            TestStaff.FirstName = "Test";
            TestStaff.FamilyName = "Account";

            // Assigns the data to the property.
            StaffMembers.ThisStaff = TestStaff;

            // Tests for equality of the two values.
            Assert.AreEqual(StaffMembers.ThisStaff, TestStaff);
        }

        [TestMethod]
        public void ListAndCountOK()
        {
            // Creates an instance of clsStaffCollection.
            clsStaffCollection StaffMembers = new clsStaffCollection();

            // Creates a list of objects used for the test data, assigns to the property.
            List<clsStaff> TestList = new List<clsStaff>();

            // Creates the item of test data.
            clsStaff TestItem = new clsStaff();

            // Sets the test items properties.
            TestItem.StaffID = 12;
            TestItem.StaffPassword = "password";
            TestItem.IsManager = true;
            TestItem.RecordCreated = DateTime.Now.Date;
            TestItem.FirstName = "Test";
            TestItem.FamilyName = "Account";

            // Adds the items to the list.
            TestList.Add(TestItem);

            // Assigns the data to the property.
            StaffMembers.StaffList = TestList;

            // Tests for equality of the two values.
            Assert.AreEqual(StaffMembers.Count, TestList.Count);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            // Creates an instance of clsStaffCollection.
            clsStaffCollection StaffMembers = new clsStaffCollection();

            // Create an item for test data.
            clsStaff TestItem = new clsStaff();

            // Variable to store the primary key value.
            int PrimaryKey = 0;

            // Sets the properties of the test item.
            TestItem.StaffID = 17;
            TestItem.StaffPassword = "password";
            TestItem.IsManager = true;
            TestItem.RecordCreated = DateTime.Now.Date;
            TestItem.FirstName = "New test";
            TestItem.FamilyName = "Account";

            // Set ThisStaff to the test data.
            StaffMembers.ThisStaff = TestItem;

            // Add the record.
            PrimaryKey = StaffMembers.Add();

            // Set the primary key of the test data.
            TestItem.StaffID = PrimaryKey;

            // Find the record.
            StaffMembers.ThisStaff.Find(PrimaryKey);

            // Tests for equality of the two values.
            Assert.AreEqual(StaffMembers.ThisStaff, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            // Creates an instance of clsStaffCollection.
            clsStaffCollection StaffMembers = new clsStaffCollection();

            // Create an item for test data.
            clsStaff TestItem = new clsStaff();

            // Variable to store the primary key value.
            int PrimaryKey = 0;

            // Sets the properties of the test item.
            TestItem.StaffID = 21;
            TestItem.StaffPassword = "password";
            TestItem.IsManager = true;
            TestItem.RecordCreated = DateTime.Now.Date;
            TestItem.FirstName = "Test";
            TestItem.FamilyName = "Account";

            // Set ThisStaff to the test data.
            StaffMembers.ThisStaff = TestItem;

            // Add the record.
            PrimaryKey = StaffMembers.Add();

            // Set the primary key of the test data.
            TestItem.StaffID = PrimaryKey;

            // Modify the test data.
            TestItem.StaffID = 271;
            TestItem.StaffPassword = "passwordTest";
            TestItem.IsManager = false;
            TestItem.RecordCreated = DateTime.Now.Date;
            TestItem.FirstName = "firstName test";
            TestItem.FamilyName = "familyName test";

            // Set the record based on the new test data.
            StaffMembers.ThisStaff = TestItem;

            // Update the record.
            StaffMembers.Update();

            // Find the record.
            StaffMembers.ThisStaff.Find(PrimaryKey);

            // Tests for equality of the two values.
            Assert.AreEqual(StaffMembers.ThisStaff, TestItem);
        }
    }
} 
