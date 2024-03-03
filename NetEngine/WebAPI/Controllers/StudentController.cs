using Common;
using DistributedLock;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Repository.Database;
using SMS;
using System.Text;
using System.Xml;
using WebAPI.Filters;
using WebAPI.Libraries;
using WebAPI.Models.AppSetting;
using WebAPI.Models.Authorize;
using WebAPI.Models.Shared;
using WebAPI.Models.Student;
using WebAPI.Services;

namespace WebAPI.Controllers
{


    /// <summary>
    /// 系统访问授权模块
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly DatabaseContext db;

        private readonly IDHelper idHelper;


        public StudentController(DatabaseContext db, IDHelper idHelper)
        {
            this.db = db;
            this.idHelper = idHelper;
        }

        [HttpGet]
        public DtoPageList<DtoStudent> GetStudentList(int pageNum, int pageSize)
        {
            DtoPageList<DtoStudent> retList = new();

            int skip = (pageNum - 1) * pageSize;
            var query = db.TStudent.AsQueryable();

            retList.Total = query.Count();
            retList.List = query.OrderBy(t => t.Id).Select(t => new DtoStudent

            {
                Id = t.Id,
                Name = t.Name,
                Birthday = t.Birthday,
                CreateTime = t.CreateTime

            }).Skip(skip).Take(pageSize).ToList();

            // Display all ages on the page list
            var nowDate = DateTimeOffset.UtcNow.UtcDateTime; // UTC is the standard time = 0
            foreach (var student in retList.List)
            {
                var birthday = student.Birthday.ToDateTime(TimeOnly.Parse("00:00"));
                student.Age = (nowDate - birthday).Days / 365;
            }

            return retList;
        }

        [HttpGet]
        public DtoStudent? GetStudent(long id)
        {
            var student = db.TStudent.Where(t => t.Id == id).Select(t => new DtoStudent
            {
                Id = t.Id,
                Name = t.Name,
                Birthday = t.Birthday,
                CreateTime = t.CreateTime
            }).FirstOrDefault();

            // If student is not null, calculate the bday by using current day time
            if (student != null)
            {
                var nowDate = DateTimeOffset.UtcNow.UtcDateTime;
                var birthday = student.Birthday.ToDateTime(TimeOnly.Parse("00:00"));

                student.Age = (nowDate - birthday).Days / 365;
            }

            // No need to save the generated bday to db as bday will be different every year
            return student;
        }

        [HttpPost]
        public long EditStudent(long? id, DtoEditStudent editStudent)
        {
            TStudent student = new();
            if (id != null)
            {
                // ID 找學生，若該學生不存在，一樣 new 一個新的學生
                student = db.TStudent.Where(t => t.Id == id).FirstOrDefault() ?? new();
            }

            // 新的學生一樣添加以下資料
            student.Name = editStudent.Name;
            student.Birthday = editStudent.Birthday;

            // 如果 ID 為 0，則用以下方法生成一個 ID
            if (student.Id == 0)
            {
                student.Id = idHelper.GetId();
                db.TStudent.Add(student);
            }

            db.SaveChanges();

            return student.Id;
        }

        [HttpPost]
        public long CreateStudent(DtoCreateStudent createStudent)
        {
            TStudent student = new();
            student.Id = idHelper.GetId();
            student.Name = createStudent.Name;
            student.Birthday = createStudent.Birthday;

            db.TStudent.Add(student);
            db.SaveChanges();

            return student.Id;
        }


        [HttpPost]
        public bool UpdateStudent(DtoUpdateStudent updateStudent)
        {
            var student = db.TStudent.Where(t => t.Id == updateStudent.Id).FirstOrDefault();

            if (student != null)
            {
                student.Name = updateStudent.Name;
                student.Birthday = updateStudent.Birthday;

                db.SaveChanges();

                return true;
            }
            else
            {
                //HttpContext.SetErrMsg("不存在的用户Id");

                return false;
            }

        }


        [HttpDelete]
        public bool DeleteStudent(long id)
        {
            var student = db.TStudent.Where(t => t.Id == id).FirstOrDefault();

            if (student != null)
            {
                //db.TStudent.Remove(student);

                student.IsDelete = true;

                db.SaveChanges();

                return true;
            }
            else
            {
                //HttpContext.SetErrMsg("不存在的用户Id");

                return false;
            }

        }

    }
}
