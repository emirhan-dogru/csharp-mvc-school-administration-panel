using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCrudProje.Models.Entities
{
    public class Worker : BaseClass
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}