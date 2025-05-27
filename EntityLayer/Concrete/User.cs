using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserId { get; set; } // Primary key
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public bool Status{ get; set; } // Sisteme giren kullanıcı başlangıçta onaylanmamış kullanıcı olacak. Onayladığımızda authenticate edilecek.

        // UserMessage sınıfı ile ilişki kurmak için:
        public List<UserMessage> UserMessages { get; set; } // Navigation property
    }
}
