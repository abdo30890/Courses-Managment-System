using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Web.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string TrainerName { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}