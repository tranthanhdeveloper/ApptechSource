using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranThanhSolution5.Models.Business;

namespace TranThanhSolution5.Models.Data
{
    public class StudentService
    {
        private readonly DataService dataService;
        public StudentService()
        {
            this.dataService = new DataService("Student");
        }
        public List<Student> GetStudents()
        {
            string dataString = this.dataService.ReadData();
            List<Student> students = null;
            if( dataString != "" && dataString != null )
            {
                students = JsonConvert.DeserializeObject<List<Student>>(dataString);

            }
            else
            {
                students = new List<Student>();
            }
            return students;
        }

        public void AddStudent(Student student)
        {
            List<Student> students = this.GetStudents();
            students.Add(student);
            this.dataService.WriteData(JsonConvert.SerializeObject(students));
        }

        public void UpdateStudent(Student student)
        {
            List<Student> students = this.GetStudents();
            students.RemoveAll(stu => stu.Uuid.Equals(student.Uuid));
            students.Add(student);
            this.dataService.WriteData(JsonConvert.SerializeObject(students));
        }

    }
}