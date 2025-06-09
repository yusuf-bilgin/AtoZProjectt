using System.ComponentModel.DataAnnotations;

namespace AtoZProject.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adını Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz")]
        [Compare("Password",ErrorMessage = "Şifreler Uyumlu Değil!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Mail Adresinizi Giriniz")]
        public string Mail { get; set; }
    }
}
