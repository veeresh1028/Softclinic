using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static BusinessEntities.Common.CustomValidationAttribute;

namespace BusinessEntities
{
    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class LoginResponse
    {
        public string url { get; set; }
        public string error { get; set; }
    }

    public class LoginViewModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Please Enter Username")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class ResetPassword
    {
        [Required(ErrorMessage = "Please Enter Username")]
        [Display(Name = "UserName")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please Enter Old Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Old Password")]
        public string old_password { get; set; }

        [Required(ErrorMessage = "Please Enter New Password")]
        [NotSameAs("old_password", ErrorMessage = "New Password cannot be the same as the Old Password.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,12}$", ErrorMessage = "Password doesn't meet the length, age, and complexity requirements. Password must be 8 to 12 characters long & include at least 1 uppercase letter, 1 lowercase letter, and 1 numeric.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required(ErrorMessage = "Please Confirm New Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("password", ErrorMessage = "Password & Confirm Password do not match.")]
        public string confirm_password { get; set; }
    }

    public class ForgotPassword
    {
        public string userName { get; set; }
        public string errorMessage { get; set; }
    }

    public class mForgotPasswordResponse
    {
        public bool isReset { get; set; }
        public string status { get; set; }
        public string error_message { get; set; }
    }

    public class mResetPassword
    {
        public int empId { get; set; } = 0;
        public string recoveryCode { get; set; }
        public string emp_pass { get; set; }
    }
}