using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class VacationPackage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int GrantedDays { get; set; }
        public int Year { get; set; }
    }
    public class Vacations 
    {
        public int ID { get; set; }
        public DateTime DateSince { get; set; }
        public DateTime DateUntil { get; set; }
        public int NumberOfHours { get; set; }
        public int IsPartialVacation { get; set; }
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
    }
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TeamID { get; set; }
        public virtual Team Team { get; set; }
        public int PositionID { get; set; }
        public int VacationPackageID { get; set; }
        public virtual VacationPackage VacationPackage { get; set; }    
    }
}
