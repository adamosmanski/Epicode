using System.Globalization;

namespace FirstTask
{
    internal class Program
    {
        public static List<Employee> Employees = new List<Employee>()
        {
            new Employee() { Id = 1, Name = "Jan Kowalski", SuperiorId = null },
            new Employee() { Id = 2, Name = "Kamil Nowak", SuperiorId = 1 },
            new Employee() { Id = 3, Name = "Anna Mariacka", SuperiorId = 1 },
            new Employee() { Id = 5, Name = "Anna Mariacka", SuperiorId = 4 },
            new Employee() { Id = 4, Name = "Andrzej Abacki", SuperiorId = 2 }
        };
        static void Main(string[] args)
        {
            var employeesStructureList = FillStructure(Employees);
            foreach(var employee in employeesStructureList)
            {
                Console.WriteLine($"Number Employee Id : {employee.EmployeeId}\nNumber Superior Id: {employee.SuperiorId} \nNumber of row: {employee.NumberOfRow}");
            }
            Console.WriteLine("-----------------");
            var row1 = GetSuperiorRowOfEmployee(1, 0);
            var row2 = GetSuperiorRowOfEmployee(2, 1);
            var row3 = GetSuperiorRowOfEmployee(3, 1);
            var row4 = GetSuperiorRowOfEmployee(4, 1);
            var row5 = GetSuperiorRowOfEmployee(4,2);
            var row6 = GetSuperiorRowOfEmployee(5, 4);
            var row7 = GetSuperiorRowOfEmployee(5, 1);
            var row8 = GetSuperiorRowOfEmployee(5, 3);
            Console.WriteLine($"row 1 : = {row1}");
            Console.WriteLine($"row 2 : = {row2}");
            Console.WriteLine($"row 3 : = {row3}");
            Console.WriteLine($"row 4 : = {row4}");
            Console.WriteLine($"row 5 : = {row5}");
            Console.WriteLine($"row 6 : = {row6}");
            Console.WriteLine($"row 7 : = {row7}");
            Console.WriteLine($"row 8 : = {row8}");
        }

        public static List<EmployeesStructure> FillStructure(List<Employee> employees)
        {
            var employeesStructure = new List<EmployeesStructure>();
            foreach (var item in employees)
            {
                employeesStructure.Add(
                    new EmployeesStructure()
                    {
                        EmployeeId = item.Id,
                        SuperiorId = item.SuperiorId ?? 0,
                        NumberOfRow = GetSuperiorRowOfEmployee(item.Id, item.SuperiorId??0)
                    });
            }
            return employeesStructure;
        }

        public static int? GetSuperiorRowOfEmployee(int employeeId, int superiorId)
        {
            var employee = Employees.FirstOrDefault(e => e.Id == employeeId);
            var superior = Employees.FirstOrDefault(e => e.Id == superiorId);

            if (employee == null || superior == null)
            {
                return null;
            }

            var NumberRow = 0;
            var currentEmployee = employee;

            while (currentEmployee.Id != superior.Id)
            {
                currentEmployee = Employees.FirstOrDefault(e => e.Id == currentEmployee.SuperiorId);
                if (currentEmployee == null)
                {
                    return null;
                }
                NumberRow++;
            }

            return NumberRow;
        }

    }
}