using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace TestingStaff
{
    [TestClass]
    public class tstStaff
    {

        // TEST DATA
        string StaffPassword = "password";
        string RecordCreated = DateTime.Now.Date.ToString();
        string FirstName = "Test";
        string FamilyName = "Account";

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
        public void RecordAddedOK()
        {
            // Creates an instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // Creates test data, and assigns that data to the property.
            DateTime TestData = DateTime.Now.Date;
            StaffMember.RecordCreated = TestData;

            // Tests for equality between the two values.
            Assert.AreEqual(StaffMember.RecordCreated, TestData);
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

        /* Find method tests */ 

        [TestMethod]
        public void FindMethodOK()
        {
            // Creates an instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // Boolean variable to store the results of the validation.
            Boolean Found = false;

            // Creating some test data to use with the method.
            int StaffID = 12;

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
            int StaffID = 12;

            // Invoking the method.
            Found = StaffMember.Find(StaffID);

            // Checks the StaffID.
            if (StaffMember.StaffID != 12)

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
            int StaffID = 12;

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
            Int32 StaffID = 12;

            // Invoking the method.
            Found = StaffMember.Find(StaffID);

            // Checks the property.
            if (StaffMember.IsManager != true)
            {
                OK = false;
            }

            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestRecordCreatedFound()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            //Boolean variable to store the result of the search.
            Boolean Found = false;

            // Boolean variable to record if the data is OK.
            Boolean OK = true;

            // Creationg test data to use with the method.
            Int32 StaffID = 12;

            // Invoking the method.
            Found = StaffMember.Find(StaffID);

            // Checks the property.
            if (StaffMember.RecordCreated != Convert.ToDateTime("01/07/2020"))
            {
                OK = false;
            }

            Assert.IsTrue(OK);
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
            Int32 StaffID = 12;

            // Invoking the method.
            Found = StaffMember.Find(StaffID);

            // Checks the property.
            if (StaffMember.FirstName != "Test")
            {
                OK = false;
            }

            Assert.IsTrue(OK);
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
            Int32 StaffID = 12;

            // Invoking the method.
            Found = StaffMember.Find(StaffID);

            //Assert.AreEqual(expected, actual);

            // Checks the property.
            if (StaffMember.FamilyName != "Account")
            {
                OK = false;
            }
            

            Assert.IsTrue(OK);


        }

        [TestMethod]
        public void ValidMethodOK()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            String Error = "";

            // Ivokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the rsult is correct.
            Assert.AreEqual(Error, "");
        }

        /* StaffPassword boundry tests */

        [TestMethod]
        public void StaffPasswordMinLessOne()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test data to pass to the method.
            string StaffPassword = "";

            // Ivokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for in-equality, to see if the result is correct.
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void StaffPasswordMin()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test data to pass to the method.
            string StaffPassword = "a";

            // Ivokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the result is correct.
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void StaffPasswordMinPlusOne()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test data to pass to the method.
            string StaffPassword = "aa";

            // Ivokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the result is correct.
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void StaffPasswordMid()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test data to pass to the method.
            string StaffPassword = "aaaaaaaaaaaaaaa"; // 15 characters.

            // Ivokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the result is correct.
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void StaffPasswordMax()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test data to pass to the method.
            string StaffPassword = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"; // 30 characters.

            // Ivokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the result is correct.
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void StaffPasswordMaxLessOne()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test data to pass to the method.
            string StaffPassword = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaa"; // 29 characters.

            // Ivokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the result is correct.
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void StaffPasswordMaxPlusOne()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test data to pass to the method.
            string StaffPassword = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"; // 31 characters.

            // Ivokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for in-equality, to see if the result is correct.
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void StaffPasswordExtremeMax()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test data to pass to the method.
            string StaffPassword = "";
            StaffPassword = StaffPassword.PadRight(100, 'a'); // 100 characters.

            // Ivokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for in-equality, to see if the result is correct.
            Assert.AreNotEqual(Error, "");
        }

        /* RecordCreated boundry tests */

        [TestMethod]
        public void RecordCreatedExtremeMin()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Variable to store the test date data (todays date).
            DateTime TestDate = DateTime.Now.Date;

            // Change date to todays date - 10 years (extreme min).
            TestDate = TestDate.AddYears(-10);

            // Converting the date variable to a string variable.
            string RecordCreated = TestDate.ToString();

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for in-equality, to see if the result is correct.
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void RecordCreatedMinLessOne()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Variable to store the test date data (todays date).
            DateTime TestDate = DateTime.Now.Date;

            // Change date to todays date - 1 day (min - 1).
            TestDate = TestDate.AddDays(-1);

            // Converting the date variable to a string variable.
            string RecordCreated = TestDate.ToString();

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for in-equality, to see if the result is correct.
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void RecordCreatedMin()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Variable to store the test date data (todays date).
            DateTime TestDate = DateTime.Now.Date;

            // Converting the date variable to a string variable.
            string RecordCreated = TestDate.ToString();

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the result is correct.
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void RecordCreatedMinPlusOne()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Variable to store the test date data (todays date).
            DateTime TestDate = DateTime.Now.Date;

            // Change date to todays date + 1 day (min + 1).
            TestDate = TestDate.AddDays(1);

            // Converting the date variable to a string variable.
            string RecordCreated = TestDate.ToString();

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for in-equality, to see if the result is correct.
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void RecordCreatedExtremeMax()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Variable to store the test date data (todays date).
            DateTime TestDate = DateTime.Now.Date;

            // Change date to todays date + 10 years (extreme max).
            TestDate = TestDate.AddYears(10);

            // Converting the date variable to a string variable.
            string RecordCreated = TestDate.ToString();

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for in-equality, to see if the result is correct.
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void RecordCreatedInvalidData()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Setting the RecordCreated to a non Date value.
            string RecordCreated = "test string";

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for in-equality, to see if the result is correct.
            Assert.AreNotEqual(Error, "");
        }

        /* FirstName boundry tests */

        [TestMethod]
        public void FirstNameMinLessOne()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test value.
            string FirstName = "";

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for in-equality, to see if the result is correct.
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void FirstNameMin()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test value.
            string FirstName = "a";

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the result is correct.
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FirstNameMinPlusOne()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test value.
            string FirstName = "aa";

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the result is correct.
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FirstNameMaxLessOne()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test value.
            string FirstName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"; // 49 characters.

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the result is correct.
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FirstNameMax()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test value.
            string FirstName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"; // 50 characters.

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the result is correct.
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FirstNameMaxPlusOne()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test value.
            string FirstName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"; // 51 characters.

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for in-equality, to see if the result is correct.
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void FirstNameMid()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test value.
            string FirstName = "aaaaaaaaaaaaaaaaaaaaaaaaa"; // 25 characters.

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the result is correct.
            Assert.AreEqual(Error, "");
        }

        /* FamilyName boundry tests */

        [TestMethod]
        public void FamilyNameMinLessOne()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test value.
            string FamilyName = "";

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for in-equality, to see if the result is correct.
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void FamilyNameMin()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test value.
            string FamilyName = "a";

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the result is correct.
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FamilytNameMinPlusOne()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test value.
            string FamilyName = "aa";

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the result is correct.
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FamilyNameMaxLessOne()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test value.
            string FamilyName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"; // 49 characters.

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the result is correct.
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FamilyNameMax()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test value.
            string FamilyName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"; // 50 characters.

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the result is correct.
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FamilyNameMaxPlusOne()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test value.
            string FamilyName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"; // 51 characters.

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for in-equality, to see if the result is correct.
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void FamilyNameMid()
        {
            // Creates a new instance of the staff class.
            clsStaff StaffMember = new clsStaff();

            // String variable to store an error message.
            string Error = "";

            // Test value.
            string FamilyName = "aaaaaaaaaaaaaaaaaaaaaaaaa"; // 25 characters.

            // Invokes the method.
            Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);

            // Tests for equality, to see if the result is correct.
            Assert.AreEqual(Error, "");
        }
    } 
}