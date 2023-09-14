using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamAPI.Validations;

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
        [GreaterThanOld(16)]
        public string Department { get; set; }
    }
}
