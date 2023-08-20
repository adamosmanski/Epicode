using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstTask
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SuperiorId { get; set; }
        public virtual Employee Superior { get; set; }
    }

}