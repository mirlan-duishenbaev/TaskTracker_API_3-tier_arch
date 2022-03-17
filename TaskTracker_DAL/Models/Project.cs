﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker_DAL.Models
{
    public enum ProjectStatus
    {
        NotStarted,
        Active,
        Completed
    }

    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime CompletionDate { get; set; }
        [Required]
        public ProjectStatus Status { get; set; }
        [Required]
        public int Priority { get; set; }
        [ForeignKey("ProjectId")]
        public ICollection<ProjectTask> Tasks { get; set; }
    }
}
