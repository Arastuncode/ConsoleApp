using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Exceptions
{
    public class CustomException:Exception
    {
        public CustomException(string str):base(str) { }
    }
}
