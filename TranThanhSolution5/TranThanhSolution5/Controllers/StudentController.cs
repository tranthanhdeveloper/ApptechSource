using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranThanhSolution5.Models.Data;
using TranThanhSolution5.Models.View;
using AutoMapper;

namespace TranThanhSolution5.Controllers
{
    public class StudentController : Controller
    {
        private const string NO_STUDENT_FOUND_MSG = "There is't any student found";
        private const string LOAD_STUDENT_LIST_ERROR = "There is't any student found";

        // GET: Student
        public ActionResult Index()
        {
            try
            {
                StudentService studentService = new StudentService();
                List<Student> students = studentService.GetStudents();
                List<StudentListItemView> studentListItemViews = Mapper.Map<List<StudentListItemView>>(students);
                if (studentListItemViews.Count <=0)
                {
                    ViewData["message"] = NO_STUDENT_FOUND_MSG;
                }
                return View(studentListItemViews);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                List<StudentListItemView> studentListItemViews = new List<StudentListItemView>();
                ViewData["message"] = LOAD_STUDENT_LIST_ERROR;
                return View(studentListItemViews);

            }
            
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            // other way to create
            //CreateStudentView viewModel = new CreateStudentView();
            return View( new CreateStudentView());
        }

        [HttpPost]
        public ActionResult Create(CreateStudentView formData)
        {
            try
            {
                StudentService studentService = new StudentService();
                List<Student> studentList = new List<Student>();

                Student student = Mapper.Map<Student>(formData);
                student.Uuid = Guid.NewGuid();
                student.LastLogin = null;
                student.CreateAt = DateTime.Now;
                student.UpdateAt = DateTime.Now;

                studentService.AddStudent(student);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                Console.WriteLine("Has error:" + e);
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(Guid id)
        {
            try
            {
                StudentService studentService = new StudentService();
                List<Student> students = studentService.GetStudents();                
                Student currentStudent = students.Find(student => student.Uuid.Equals(id));
                EditStudentView editStudentView = Mapper.Map<EditStudentView>(currentStudent);
                return View(editStudentView);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, EditStudentView editFormData)
        {
            try
            {
                StudentService studentService = new StudentService();
                List < Student > students = studentService.GetStudents();
                Student currentStudent = students.Find(student => student.Uuid.Equals(id));
                currentStudent = Mapper.Map<Student>(editFormData);
                currentStudent.LastLogin = null;
                currentStudent.UpdateAt = DateTime.Now;
                currentStudent.Uuid = id;
                studentService.UpdateStudent(currentStudent);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine("Has error:" + e);
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        
    }
}
