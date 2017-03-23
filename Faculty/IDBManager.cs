using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Faculty
{
    public interface IDBManager
    {
        IList<Student> RetrieveStudents();
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
    }
}
