using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing4
{
    [TestClass]
    public class tstStaff
    {
        [TestMethod]
        public void InstanceOK()
        {
            // Creates an instance of the staff class.
            clsStaff StaffMember = new clsStaff();
            
            // Tests to see it exists.
            Assert.IsNotNull(StaffMember);
        }

        [TestMethod]
        public void IsManagerPropertyOK()
        {
            // Creates an instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // Creates test data, and assigns that data to the property.
            Boolean TestData = true;
            StaffMember.IsManager = TestData;

            // Tests for equality between the two values.
            Assert.AreEqual(StaffMember.IsManager, TestData);
        }

        [TestMethod]
        public void DOBPropertyOK()
        {
            // Creates an instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // Creates test data, and assigns that data to the property.
            DateTime TestData = DateTime.Now.Date;
            StaffMember.DOB = TestData;

            // Tests for equality between the two values.
            Assert.AreEqual(StaffMember.DOB, TestData);
        }

        [TestMethod]
        public void StaffIDPropertyOK()
        {
            // Creates an instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // Creates test data, and assigns that data to the property.
            int TestData = 1;
            StaffMember.StaffID = TestData;

            // Tests for equality between the two values.
            Assert.AreEqual(StaffMember.StaffID, TestData);
        }

        [TestMethod]
        public void StaffPasswordPropertyOK()
        {
            // Creates an instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // Creates test data, and assigns that data to the property.
            String TestData = "password";
            StaffMember.StaffPassword = TestData;

            // Tests for equality between the two values.
            Assert.AreEqual(StaffMember.StaffPassword, TestData);
        }

        [TestMethod]
        public void FirstNamePropertyOK()
        {
            // Creates an instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // Creates test data, and assigns data to the property.
            String TestData = "first name";
            StaffMember.FirstName = TestData;

            // Tests for equality between the two values.
            Assert.AreEqual(StaffMember.FirstName, TestData);
        }

        [TestMethod]
        public void FamilyNamePropertyOK()
        {
            // Creates an instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // Creates test data, and assigns data to the property.
            String TestData = "family name";
            StaffMember.FamilyName = TestData;

            // Tests for equality between the two values.
            Assert.AreEqual(StaffMember.FamilyName, TestData);
        }

        public clsStaff createStaffAccount()
        {
            clsStaff order = new clsStaff();
            order.Find(1);
            return order;
        }


    }
}
