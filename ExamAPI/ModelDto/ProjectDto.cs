﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamAPI.Validations;

namespace ExamAPI.ModelDto
{
    public class ProjectDto
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        [ProjectDate("StartDate")]
        public DateTime EndDate { get; set; }

    }
}
