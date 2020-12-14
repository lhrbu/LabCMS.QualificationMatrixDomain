using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabCMS.QualificationMatrixDomain.Shared.Models
{
    public class EmployeeEvaluationScore
    {

        [ForeignKey(nameof(Employee))]
        public int EmployeeId {get;set;}
        public Employee Employee {get;set;} = null!;

        [ForeignKey(nameof(Skill))]
        public int SkillId {get;set;}
        public Skill Skill {get;set;}=null!;
        public double Value {get;set;} 
    }
}