using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LabCMS.QualificationMatrixDomain.Shared.Models
{
    public class Position
    {
        [Key]
        public int PositionId {get;set;}
        public string Title {get;set;}=null!;
    }
}