using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Faculty;  //
using MySql.Data.MySqlClient;

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
            student.Name = "Jan Boxior";
            student.BirthDate = DateTime.Now;
            student.Address = "Republicii";
            
            IDBManager db = new MySQLDBManager();
            db.AddStudent(student);

            string connStr = "server=localhost;user=root;database=tema2;port=3306;password=root;";

            MySqlConnection conn = new MySqlConnection(connStr);
            using (conn)
            {
                conn.Open();
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();

                    string sql = "SELECT name FROM Student WHERE id='10000'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
             
                    while (rdr.Read())
                    {
                        //Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                        Assert.AreEqual(rdr[0], "Jan Boxior");
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
