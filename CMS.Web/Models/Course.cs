using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CMS.Web.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public DateTime CreationDate { get; set; }
        public Category Category{ get; set; }
        public int CategoryId { get; set; }
        public Trainer Trainer { get; set; }
        public int TrainerId { get; set; }
        public string Description { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Member> Members { get; set; }
    }
}