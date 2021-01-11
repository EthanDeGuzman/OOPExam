using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace OOPExam
{
    public abstract class Account
    {
        // Set up Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
        public string InterestDate { get; set; }
        public int AccountNumber { get; set; }
        
        //Abstract Method
        public abstract double CalculateInterest();

        //ToString Method
        public override string ToString()
        {
            return $"{AccountNumber} - {LastName}, {FirstName}";
        }

    }

    public class CurrentAccount : Account // Inherits from Account Class
    {
        const double InterestRate = 0.03;
        public override double CalculateInterest()
        {
            InterestDate = DateTime.Now.ToString("MM-dd-yyyy");
            return Balance * InterestRate;
        }
    }

    public class SavingsAccount : Account // Inherits from Account Class
    {
        const double InterestRate = 0.06;
        public override double CalculateInterest()
        {
            InterestDate = DateTime.Now.ToString("MM-dd-yyyy");
            return Balance * InterestRate;
        }
    }
}
