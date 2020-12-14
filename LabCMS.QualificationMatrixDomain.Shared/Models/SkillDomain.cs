using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LabCMS.QualificationMatrixDomain.Shared.Models
{
    public class SkillDomain
    {
        [Key]
        public int SkillDomainId {get;set;}
        public string Name {get;set;}=null!;
    }
}