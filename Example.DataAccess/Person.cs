using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DataAccess
{
    public class Person
    {
        public int Id

        {
            get; set;
        }

        public string FirstName

        {
            get { return "123"; }
            set { value = "123"; }
        }

        public string LastName

        {
            get; set;
        }

        public string Address

        {
            get; set;
        }
    }
}
