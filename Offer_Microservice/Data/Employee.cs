using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Offer_Microservice.Data
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }       
        public long MobileNo { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public int? Points { get; set; }
    }
}
