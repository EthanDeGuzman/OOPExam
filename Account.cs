using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam
{
    public abstract class Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
        public string InterestDate { get; set; }
    }
}
