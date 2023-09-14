using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ExamAPI.Models
{
    [Table("ProjectEmployee")]
    public class ProjectEmployee
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        [Required]
        public string Task { get; set; }

        public virtual Employees Employees { get; set; }
        public virtual Project Projects { get; set; }
    }
}
