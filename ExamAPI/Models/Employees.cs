
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamAPI.Models
{
    [Table("Employees")]
    public class Employees
    {

        [Key]
        public int Id { get; set; }

        [Required, StringLength(150, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public DateTime DOB { get; set; }

        [Required,DataType(DataType.Date)]
        public string Department { get; set; }


        public virtual ICollection<ProjectEmployee>? ProjectEmployees { get; set; } = new List<ProjectEmployee>();

    }
}
