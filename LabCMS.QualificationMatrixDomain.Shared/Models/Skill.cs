using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabCMS.QualificationMatrixDomain.Shared.Models
{
    public class Skill
    {
        [Key]
        public int SkillId {get;set;}

        [ForeignKey(nameof(SkillDomain))]
        public int SkillDomainId {get;set;}
        public SkillDomain SkillDomain {get;set;} = null!;
        public string Name {get;set;}=null!;
        public string Description {get;set;}=null!;
    }
}