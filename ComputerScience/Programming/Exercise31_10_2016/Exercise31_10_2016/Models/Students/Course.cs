using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise31_10_2016.Models.Students
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public static Course GetCourseById(int id,Repository r)
        {
            LinkedList<Course>.Enumerator en = r.GetCourses().GetEnumerator();
            en.MoveNext();
            while (en.Current != null)
            {
                if (en.Current.CourseId == id)
                {
                    return en.Current;
                }
                en.MoveNext();
            }
            return null;
        }
    }
}