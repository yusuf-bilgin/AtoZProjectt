﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Announcement
    {
        [Key] // Id is the primary key
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Content { get; set; }
    }
}
