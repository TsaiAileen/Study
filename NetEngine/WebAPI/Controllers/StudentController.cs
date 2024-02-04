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


        [HttpPost]
        public long CreateStudent(DtoCreateStudent createStudent)
        {
            TStudent student = new();
            student.Id = idHelper.GetId();

            student.Name = createStudent.Name;
            student.Birthday = createStudent.Birthday;
            student.Age = createStudent.Age;

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
                student.Age = updateStudent.Age;

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
