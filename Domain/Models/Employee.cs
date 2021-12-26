using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Employee: BaseEntity
    {
        public Company Company { get; set; }
        public string  Surname { get; set; }
        public string  Name    { get; set; }
        public int?    Age     { get; set; }
    }
}
