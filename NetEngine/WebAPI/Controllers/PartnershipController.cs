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
using WebAPI.Models.Partnership;
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
  public class PartnershipController : ControllerBase
  {

    private readonly DatabaseContext db;

    private readonly IDHelper idHelper;

    public PartnershipController(DatabaseContext db, IDHelper idHelper)
    {
      this.db = db;
      this.idHelper = idHelper;
    }


    [HttpPost]
    public long AddPartner(DtoCreatePartner addPartner)
    {
      TPartner partner = new();
      partner.Id = idHelper.GetId();

      partner.Name = addPartner.Name;
      partner.Relation = addPartner.Relation;

      db.TPartner.Add(partner);
      db.SaveChanges();

      return partner.Id;
    }


    [HttpPost]
    public bool EditPartner(DtoUpdatePartner editPartner)
    {
      var partner = db.TPartner.Where(t => t.Id == editPartner.Id).FirstOrDefault();

      if (partner != null)
      {
        partner.Name = editPartner.Name;
        partner.Relation = editPartner.Relation;

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
    public bool DeletePartner(long id)
    {
      var partner = db.TPartner.Where(t => t.Id == id).FirstOrDefault();

      if (partner != null)
      {
        //db.TStudent.Remove(student);

        partner.IsDelete = true;

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
