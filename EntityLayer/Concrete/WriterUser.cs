﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class WriterUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
    }
    /* WriterUser sınıfı, ASP.NET Identity'nin özelliklerine (email, password hash, security stamp, vs.) ek olarak 
     * senin belirttiğin Name, Surname, ImageUrl gibi alanları da barındırıyor.*/
}
