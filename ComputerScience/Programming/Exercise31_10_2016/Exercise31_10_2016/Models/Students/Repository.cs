using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise31_10_2016.Models.Students
{
    public class Repository
    {
        private  LinkedList<Student> Students = new LinkedList<Student>();
        private  LinkedList<Faculty> Faculties = new LinkedList<Faculty>();
        private  LinkedList<Course> Courses = new LinkedList<Course>();
        public  LinkedList<Student> GetStudents()
        {
            return Students;
        }
        public  LinkedList<Course> GetCourses()
        {
            return Courses;
        }
        public  LinkedList<Faculty> GetFaculties()
        {
            return Faculties;
        }
        public  void CreateStudent(Student s)
        {
            Students.AddFirst(s);
        }
        public  void CreateFaculty(Faculty f)
        {
            Faculties.AddFirst(f);
        }
        public  void CreateCourse(Course c)
        {
            Courses.AddFirst(c);
        }
        public  void UpdateStudent(int id,Student s2)
        {
            Student s= Student.GetStudentById(id,this);
            Students.Find(s).Value = s2;
        }
        public  void UpdateFaculty(int id, Faculty f2)
        {
            Faculty f = Faculty.GetFacultyById(id,this);
            Faculties.Find(f).Value = f2;
        }
        public  void UpdateCourse(int id, Course c2)
        {
            Course c = Course.GetCourseById(id,this);
            Courses.Find(c).Value = c2;
        }
        public  void DeleteStudent(int id)
        {
            Student s = Student.GetStudentById(id,this);
            Students.Remove(s);
        }
        public  void DeleteFaculty(int id)
        {
            Faculty f = Faculty.GetFacultyById(id,this);
            Faculties.Remove(f);
        }
        public  void DeleteCourse(int id)
        {
            Course c = Course.GetCourseById(id,this);
            Courses.Remove(c);
        }
    }
}