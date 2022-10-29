using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectDemoV1.ViewModel
{
    public class Register
    {
        public int AccountId { get; set; }


        [Remote("IsUserExists", "Home", ErrorMessage = "Tên người dùng đã tồn tại")]
        public string UserName { get; set; }


        [StringLength(50, MinimumLength = 8, ErrorMessage = "Mật khẩu phải ít nhất 8 kí tự")]
        public string PassWord { get; set; }


        [System.Web.Mvc.Compare("PassWord", ErrorMessage = "Mật khẩu nhập lại không khớp. Vui lòng nhập lại!!!")]
        public string ConfirmPassword { get; set; }

        public DateTime CreateDate { get; set; }
        public int RoleId { get; set; }
        public string FullName { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0]{1})\)?[-. ]?([0-9]{2})?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; }

        public int GenderId { get; set; }
        public string SchoolName { get; set; }


        [Remote("IsEmailExists", "Home", ErrorMessage = "Email đã tồn tại")]
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
    }
}