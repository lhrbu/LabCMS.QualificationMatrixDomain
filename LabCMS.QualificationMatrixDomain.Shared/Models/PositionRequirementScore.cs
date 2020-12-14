using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabCMS.QualificationMatrixDomain.Shared.Models
{
    public class PositionRequirementScore
    {
        
        [ForeignKey(nameof(Position))]
        public int PositionId {get;set;}
        public Position Position {get;set;} = null!;

        [ForeignKey(nameof(Skill))]
        public int SkillId {get;set;}
        public Skill Skill {get;set;}=null!;
        public double Value {get;set;}
    }
}