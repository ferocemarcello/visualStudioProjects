using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise31_10_2016.Models.Students
{
    public class Student
    {
        public int EnrollmentNo { get; set; }
        public string StudentName { get; set; }
        public List<Course> EnrolledCourses { get; set; }

        public static Student GetStudentById(int id,Repository r)
        {
            LinkedList<Student>.Enumerator en = r.GetStudents().GetEnumerator();
            en.MoveNext();
            while (en.Current != null)
            {
                if (en.Current.EnrollmentNo == id)
                {
                    return en.Current;
                }
                en.MoveNext();
            }
            return null;
        }
    }
}