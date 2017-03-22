using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Faculty;  //

namespace FacultyTests1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1,1);
        }

        public void TestAddStudent1()
        {
            Student student = new Student();
            student.ID = 10000;
            student.Name = "Jan Boxeur";
            student.BirthDate = DateTime.Now;
            student.Address = "Republicii";
            
            IDBManager db = new MySQLDBManager();
            db.AddStudent(student);
        }
    }
}
