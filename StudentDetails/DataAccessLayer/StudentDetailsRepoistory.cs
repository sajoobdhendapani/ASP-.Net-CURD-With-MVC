using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDetails.DataAccessLayer
{
    public class StudentDetailsRepoistory : IStudentDetailsRepoistory
    {
        private readonly SampleDbContext _context;

        public StudentDetailsRepoistory(SampleDbContext context)
        {
            _context = context;
        }
        public void Insert(StudentDetail details)
        {
            try
            {
                _context.Database.ExecuteSqlRaw($"exec InsertStudentDetails '{details.Name}','{details.DOB}','{details.AGE}','{details.Gender}','{details.MobileNumber}' ,'{details.Email}','{details.Subject}'");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Update(long id, StudentDetail value)
        {
            try
            {
                var result = _context.Database.ExecuteSqlRaw($"exec UpdateStudentDetail {id}, '{value.Name}','{value.DOB}',{value.AGE},'{value.Gender}',{value.MobileNumber},'{value.Email}','{value.Subject}' ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Delete(int stdid)
        {
            try
            {
                _context.Database.ExecuteSqlRaw($"delete StudentDetail where StudentId={stdid}");
                
            }
            catch 
            {
                throw;  
            }
        }
        public IEnumerable<StudentDetail> GetallRecords()
        {
            try
            {
                var result = _context.StudentDetail.FromSqlRaw($"select * from StudentDetail ").ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public StudentDetail GetByid(long id)
        {
            try
            {
                var result = _context.StudentDetail.FromSqlRaw($" exec GetnyidStudentdetails {id} ");
                return result.ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
