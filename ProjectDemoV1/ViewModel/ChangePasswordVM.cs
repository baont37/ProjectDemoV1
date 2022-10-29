using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectDemoV1.ViewModel
{
    public class ChangePasswordVM
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        [StringLength(50, MinimumLength = 8, ErrorMessage = "Mật khẩu phải ít nhất 8 kí tự")]
        public string NewPassword { get; set; }


        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "Mật khẩu nhập lại không khớp. Vui lòng nhập lại!!!")]
        public string ConfirmPassword { get; set; }


    }
}