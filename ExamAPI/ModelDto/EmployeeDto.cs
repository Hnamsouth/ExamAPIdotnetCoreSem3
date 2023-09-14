using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamAPI.ModelDto
{
    public class EmployeeDto
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Department { get; set; }
    }
}
