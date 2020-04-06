using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Web.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OrderNumber { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}