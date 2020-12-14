using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LabCMS.QualificationMatrixDomain.Shared.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId {get;set;}
        public string Name { get; init; } = null!;
        [ForeignKey(nameof(Position))]
        public int PositionId{get;set;}
        public Position Position {get;set;} = null!;
        
    }
}