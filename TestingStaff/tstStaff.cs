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

        [TestMethod]
        public void FindMethodOK()
        {
            // Creates an instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // Boolean variable to store the results of the validation.
            Boolean Found = false;

            // Creating some test data to use with the method.
            int StaffID = 1;

            // Invoking the method.
            Found = StaffMember.Find(StaffID);

            // Test to see if the result is true.
            Assert.IsTrue(Found);
        }

        [TestMethod]
        public void TestStaffIDFound()
        {
            // Creates an instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // Boolean variable to store the results of the search.
            Boolean Found = false;

            // Boolean variable to record if the data is OK.
            Boolean OK = true;

            // Creating some test data to use with the method.
            int StaffID = 11;

            // Invoking the method.
            Found = StaffMember.Find(StaffID);

            // Checks the StaffID.
            if (StaffMember.StaffID != 11)

            {
                OK = false;
            }

            // Test to see if the result is correct.
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestStaffPasswordFound()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // Boolean variable to store the results of the search.
            Boolean Found = false;

            // Boolean variable to record if the data is OK.
            Boolean OK = true;

            // Creating some test data to use with the method.
            int StaffID = 11;

            // Invoking the method.
            Found = StaffMember.Find(StaffID);

            // Checks the property.
            if (StaffMember.StaffPassword != "password")
            {
                OK = false;
            }

            // Test to see if the result is true.
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestIsManagerFound()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            //Boolean variable to store the result of the search.
            Boolean Found = false;

            // Boolean variable to record if the data is OK.
            Boolean OK = true;

            // Creationg test data to use with the method.
            int StaffID = 11;

            // Invoking the method.
            Found = StaffMember.Find(StaffID);

            // Checks the property.
            if (StaffMember.IsManager != true)
            {
                OK = false;
            }
        }

        [TestMethod]
        public void TestDOBFound()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            //Boolean variable to store the result of the search.
            Boolean Found = false;

            // Boolean variable to record if the data is OK.
            Boolean OK = true;

            // Creationg test data to use with the method.
            int StaffID = 11;

            // Invoking the method.
            Found = StaffMember.Find(StaffID);

            // Checks the property.
            if (StaffMember.DOB != DateTime.Now)
            {
                OK = false;
            }
        }

        [TestMethod]
        public void TestFirstNameFound()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            //Boolean variable to store the result of the search.
            Boolean Found = false;

            // Boolean variable to record if the data is OK.
            Boolean OK = true;

            // Creationg test data to use with the method.
            int StaffID = 11;

            // Invoking the method.
            Found = StaffMember.Find(StaffID);

            // Checks the property.
            if (StaffMember.FirstName != "first name") ;
            {
                OK = false;
            }
        }

        [TestMethod]
        public void TestFamilyNameFound()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            //Boolean variable to store the result of the search.
            Boolean Found = false;

            // Boolean variable to record if the data is OK.
            Boolean OK = true;

            // Creationg test data to use with the method.
            int StaffID = 11;

            // Invoking the method.
            Found = StaffMember.Find(StaffID);

            // Checks the property.
            if (StaffMember.FamilyName != "family name")
            {
                OK = false;
            }
        }

        /*public clsStaff createStaffAccount()
    {
        clsStaff order = new clsStaff();
        order.Find(1);
        return order;
    }*/




    } 
}
