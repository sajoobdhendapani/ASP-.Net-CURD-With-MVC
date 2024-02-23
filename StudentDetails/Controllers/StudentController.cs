using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentDetails.DataAccessLayer;
using Microsoft.Extensions.Configuration;

namespace StudentDetails.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentDetailsRepoistory _add;
        private readonly string _connectionstring;
        public StudentController(IStudentDetailsRepoistory add, IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DbConnection");
            _add = add;


        }
        // GET: Student
        public ActionResult Index()
        {
            try
            {
                var result = _add.GetallRecords();
                return View("View", result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var result = _add.GetByid(id);
                return View("Details", result);
            }
            catch
            {
                return View("Error");
            }
           
            //return View();
        }

        // GET: Student/Create
        public ActionResult Create(long? id)
        {
            try
            {
                if(id.HasValue)
                {
                    var student = _add.GetByid(id.Value);
                    return View("Create", student);

                }
                else
                {
                    var result = new StudentDetail();
                  
                    return View("Create", result);
                }

            }
            catch(Exception ex)
            {
                return View("Error");
            }

        }

        // POST: Student/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(StudentDetail val)
        {
            try
            {
                if (val.StudentId == 0)
                {
                    _add.Insert(val);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _add.Update(val.StudentId, val);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View("Error");
            }
       }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {

            var result = _add.GetByid(id);
            return View("Edit", result);
        }

        // POST: Student/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentDetail data)
        {
            try
            {
                _add.Update(id, data);
                var result = _add.GetallRecords();
                return View("text", result);
                
               
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _add.GetByid(id);
                return View("Delete", result);
            }
            catch
            {
                return View("Error");
            }
            
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult delete(int id)
        {
            try
            {
                _add.Delete(id);
                var result = _add.GetallRecords();
                return View("View", result);

            }
            catch
            {
                return View("Error");
            }
        
    }
        [HttpGet]
        [Route("~/api/depart")]
        public ActionResult Subject()
        {
            try
            {
                var get = Getvalue();
                return Ok(get.ToList());
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }

        }

        private List<Subject> Getvalue()
        {

            List<Subject> depart = new List<Subject>();
            Subject input = new Subject();
            input.ID = 1;
            input.Name = "ECE";
            depart.Add(input);

            Subject inner = new Subject();
            inner.ID = 2;
            inner.Name = "CSE";
            depart.Add(inner);

            Subject inter = new Subject();
            inter.ID = 3;
            inter.Name = "MECH";
            depart.Add(inter);
            return depart;

        }
    }
}
