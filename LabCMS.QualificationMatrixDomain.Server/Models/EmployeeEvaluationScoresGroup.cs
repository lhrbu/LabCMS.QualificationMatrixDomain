using LabCMS.QualificationMatrixDomain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabCMS.QualificationMatrixDomain.Server.Models
{
    public record EmployeeEvaluationScoresGroup(int EmployeeId,
        IEnumerable<EmployeeEvaluationScore> Scores);
}
