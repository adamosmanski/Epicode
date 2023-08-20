namespace SecondTask
{
    internal class Program
    {
        public static List<Team> TeamsList = new List<Team>()
        {
            new Team(){ ID = 1, Name = ".Net Developers"},
            new Team(){ ID = 2, Name = "Backend Developers"},
            new Team(){ ID = 3, Name = "Java Developers"}
        };
        public static List<VacationPackage> VacationPackagesList = new List<VacationPackage>()
        {
            new VacationPackage(){ ID = 1, Name = "First Package", GrantedDays = 10, Year = 2019},
            new VacationPackage(){ ID = 1, Name = "Second Package", GrantedDays = 0, Year = 2019},
            new VacationPackage(){ ID = 1, Name = "Third Package", GrantedDays = 20, Year = 2021},
            new VacationPackage(){ ID = 1, Name = "Fourth Package", GrantedDays = 10, Year = 2020},
            new VacationPackage(){ ID = 1, Name = "Fifth Package", GrantedDays = 0, Year = 2023},
        };
        public static List<Employee> EmployeeList = new List<Employee>()
        {
            new Employee(){ ID = 1, Name = "Jan Kowalski", TeamID = 1, PositionID = 1, VacationPackageID = 1},
            new Employee(){ ID = 2, Name = "Kamil Nowak", TeamID = 2, PositionID = 1, VacationPackageID = 2},
            new Employee(){ ID = 3, Name = "Andrzej Abacki", TeamID = 2, PositionID = 1, VacationPackageID = 1},
            new Employee(){ ID = 4, Name = "Anna Mariacki", TeamID = 1, PositionID = 1, VacationPackageID = 5},
            new Employee(){ ID = 5, Name = "Jakub Mariacki", TeamID = 3, PositionID = 1, VacationPackageID = 5},
        };
        public static List<Vacations> VacationsList = new List<Vacations>()
        {
            new Vacations(){ ID = 1, EmployeeID = 1, DateSince = new DateTime(2019, 04,01), DateUntil = new DateTime(2019, 04, 7), IsPartialVacation=0, NumberOfHours=40 },
            new Vacations(){ ID = 1, EmployeeID = 2, DateSince = new DateTime(2021, 04,01), DateUntil = new DateTime(2021, 04, 7), IsPartialVacation=0, NumberOfHours=40 },
            new Vacations(){ ID = 1, EmployeeID = 3, DateSince = new DateTime(2022, 04,01), DateUntil = new DateTime(2022, 04, 7), IsPartialVacation=0, NumberOfHours=0 },
            new Vacations(){ ID = 1, EmployeeID = 4, DateSince = new DateTime(2019, 04,01), DateUntil = new DateTime(2019, 04, 7), IsPartialVacation=0, NumberOfHours=40 },
            new Vacations(){ ID = 1, EmployeeID = 1, DateSince = new DateTime(2021, 04,01), DateUntil = new DateTime(2021, 04, 7), IsPartialVacation=0, NumberOfHours=40 },
            new Vacations(){ ID = 1, EmployeeID = 1, DateSince = new DateTime(2022, 04,01), DateUntil = new DateTime(2022, 04, 7), IsPartialVacation=0, NumberOfHours=0 },
        };
        static void Main(string[] args)
        {
            var DotNetID = TeamsList.Where(x => x.Name.Contains(".NET") || x.Name.Contains(".Net")).Select(x => x.ID).FirstOrDefault();
            var employeeDotNet = EmployeeList.Where(employee => employee.TeamID == DotNetID && VacationsList.Any(vacation => vacation.EmployeeID == employee.ID && vacation.DateSince.Year == 2019)).ToList();
            Console.WriteLine("Ex.2-A");
            foreach (var item in employeeDotNet)
            {
                Console.WriteLine($"Name: {item.Name}\n TeamID: {item.TeamID}");
            }

            Console.WriteLine("\n\nEx.2-B");

            int currentYear = DateTime.Now.Year;

            var employeesWithUsedVacationDays = EmployeeList.Select(employee =>
            {
                var usedVacationDays = VacationsList
                    .Where(vacation => vacation.EmployeeID == employee.ID && vacation.DateSince.Year == currentYear && vacation.DateUntil <= DateTime.Now)
                    .Sum(vacation => (vacation.DateUntil - vacation.DateSince).Days + 1);

                return new
                {
                    Employee = employee,
                    UsedVacationDays = usedVacationDays
                };
            }).ToList();

            foreach(var item in employeesWithUsedVacationDays)
            {
                Console.WriteLine($"{item.Employee.Name} - {item.UsedVacationDays}");
            }

            var teamsWithoutVacation2019 = TeamsList.Where(team =>
            {
                var employeesInTeam = EmployeeList.Where(employee => employee.TeamID == team.ID).ToList();
                return employeesInTeam.All(employee =>
                    !VacationsList.Any(vacation => vacation.EmployeeID == employee.ID && vacation.DateSince.Year == 2019)
                );
            }).ToList();

            Console.WriteLine("\n\nEx.2-C");
            foreach (var item in teamsWithoutVacation2019)
            {
                Console.WriteLine($"{item.Name}");
            }
        }
    }
}