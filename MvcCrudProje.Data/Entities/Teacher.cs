using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCrudProje.Models.Entities
{
    public class Teacher : BaseClass
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public ICollection<Student> student { get; set; }

        public int studentCounts { get; set; }
    }
}

