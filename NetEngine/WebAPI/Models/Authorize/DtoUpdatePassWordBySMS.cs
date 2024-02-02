﻿using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Authorize
{

    /// <summary>
    /// 通过短信修改账户密码入参
    /// </summary>
    public class DtoUpdatePassWordBySMS
    {

        /// <summary>
        /// 短信验证码
        /// </summary>
        [Required(ErrorMessage = "短信验证码不可以为空")]
        public string SmsCode { get; set; }



        /// <summary>
        /// 新密码
        /// </summary>
        [Required(ErrorMessage = "新密码不可以为空")]
        public string NewPassWord { get; set; }

    }
}
