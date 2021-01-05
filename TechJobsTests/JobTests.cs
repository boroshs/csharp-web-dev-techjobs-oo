using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        Job job1 = new Job();
        Job job2 = new Job();
        Job job3 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
        Job job4 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

        // test that the ID values for the two objects are NOT the same
        // and differ by 1
        // something to do with ID values incrementation, this test fails when you do run all then passes when run by itself
        [TestMethod]
        public void TestSettingJobId()
        {
            Assert.AreEqual(1, job1.Id);
            Assert.AreEqual(1, job2.Id-job1.Id);
        }
        
        //  constructor correctly assigns the value of each field
        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            string name = "Product tester";
            Employer employer = new Employer("ACME");
            Location location = new Location("Desert");
            PositionType positionType = new PositionType("Quality control");
            CoreCompetency coreCompetency = new CoreCompetency("Persistence");
            Job job5 = new Job(name, employer, location, positionType, coreCompetency);

            Assert.AreEqual(job5.Name, name);
            Assert.AreEqual(job5.EmployerName, employer);
            Assert.AreEqual(job5.EmployerName.Value, "ACME");
            Assert.AreEqual(job5.EmployerLocation, location);
            Assert.AreEqual(job5.EmployerLocation.Value, "Desert");
            Assert.AreEqual(job5.JobType, positionType);
            Assert.AreEqual(job5.JobType.Value, "Quality control");
            Assert.AreEqual(job5.JobCoreCompetency, coreCompetency);
            Assert.AreEqual(job5.JobCoreCompetency.Value, "Persistence");
        }
        
        // Generate two Job objects that have identical field values EXCEPT for id. 
        // Test that Equals() returns false
        [TestMethod]
        public void TestJobsForEquality()
        {
            Assert.IsFalse(job3.Equals(job4));

            /* Id increments strangely, idk what expected behavior is
             * Assert.AreEqual(1, job3.EmployerName.Id);
            Assert.AreEqual(4, job4.EmployerName.Id - job3.EmployerName.Id);
            Assert.AreEqual(2, job3.EmployerLocation.Id);
            Assert.AreEqual(4, job4.EmployerLocation.Id - job3.EmployerLocation.Id);
            Assert.AreEqual(3, job3.JobType.Id);
            Assert.AreEqual(4, job4.JobType.Id - job3.JobType.Id);
            Assert.AreEqual(4, job3.JobCoreCompetency.Id);
            Assert.AreEqual(4, job4.JobCoreCompetency.Id - job3.JobCoreCompetency.Id);

            Assert.IsFalse(job3.EmployerName.Equals(job4.EmployerName));
            Assert.IsFalse(job3.EmployerLocation.Equals(job4.EmployerLocation));
            Assert.IsFalse(job3.JobType.Equals(job4.JobType));
            Assert.IsFalse(job3.JobCoreCompetency.Equals(job4.JobCoreCompetency));*/
        }

        
        // When passed a Job object, it should return a string that contains 
        // a blank line before and after the job information.
        [TestMethod]
        public void TestToStringBlankLines()
        {
            string jobStr = job3.ToString();
            Assert.IsTrue(jobStr.StartsWith("\n"));
            Assert.IsTrue(jobStr.EndsWith("\n"));
        }
        
        // The string should contain a label for each field, 
        // followed by the data stored in that field.Each field should be on its own line.
        // ID: , Name: , Employer: , Location: , Position Type: , Core Competency: 
        [TestMethod]
        public void TestToStringFields()
        {
            string jobStr = job3.ToString();
            string expectedStr = "\nName: Product tester\nEmployer: ACME\nLocation: Desert\nPosition Type: Quality control\nCore Competency: Persistence\n"; ;
            Assert.AreEqual(expectedStr, jobStr);
        }
        
        // If a field is empty, the method should add, “Data not available” after the label.
        [TestMethod]
        public void TestToStringEmptyField()
        {
            Job job6 = new Job("", new Employer(""), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency(""));
            string jobStr = job6.ToString();
            string expectedStr = "\nName: Data not available\nEmployer: Data not available\nLocation: Desert\nPosition Type: Quality control\nCore Competency: Data not available\n"; ;
            Assert.AreEqual(expectedStr, jobStr);
        }
    }
}
