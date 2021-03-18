﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Job_search.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }

        [Display(Name = "ذكرني")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "نوع الحساب")]
        public string UserType { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "البريد الاكتروني")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة المرور")]
        [Compare("Password", ErrorMessage = "كلمة المرور وتأكيد كلمة المرور غير متطابقتين")]
        public string ConfirmPassword { get; set; }


    }
    //---------------Edit account in profile--------------------------
    public class EditProfileViewModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "البريد الاكتروني")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "يجب ألا يقل طول الأحرف عن {2} ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور الحالية")]
        public string CurrentPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "يجب ألا يقل طول الأحرف عن {2} ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور الجديدة")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = " تأكيد كلمة المرور الجديدة")]
        [Compare("NewPassword", ErrorMessage = "كلمة المرور المدخلة غير متطابقة.. الرجاء اعادة ادخال تأكيد كلمة المرور.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
