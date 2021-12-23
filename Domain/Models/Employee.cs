using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Employee: BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Adress { get; set; }
        public int Age { get; set; }
    }
}
