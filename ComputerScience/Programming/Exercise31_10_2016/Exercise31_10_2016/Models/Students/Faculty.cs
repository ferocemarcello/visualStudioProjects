using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise31_10_2016.Models.Students
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public List<Course> AllotedCourses { get; set; }

        public static Faculty GetFacultyById(int id,Repository r)
        {
            LinkedList<Faculty>.Enumerator en = r.GetFaculties().GetEnumerator();
            en.MoveNext();
            while (en.Current != null)
            {
                if (en.Current.FacultyId == id)
                {
                    return en.Current;
                }
                en.MoveNext();
            }
            return null;
        }
    }
}