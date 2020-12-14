using LabCMS.QualificationMatrixDomain.Server.Models;
using LabCMS.QualificationMatrixDomain.Server.Repositories;
using LabCMS.QualificationMatrixDomain.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabCMS.QualificationMatrixDomain.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationMatrixController : ControllerBase
    {
        private readonly QualificationMatrixRepository _repository;
        public QualificationMatrixController(QualificationMatrixRepository repository)
        { _repository = repository; }
        [HttpGet("EmployeeEvaluationScores/{employeeId}")]
        public IAsyncEnumerable<EmployeeEvaluationScore> GetEmployeeEvaluationScoresAsync(int employeeId)=>
            _repository.EmployeeEvaluationScores.Where(item => item.EmployeeId == employeeId)
                .AsNoTracking().AsAsyncEnumerable();

        [HttpGet("EmployeeEvalutationScores")]
        public IAsyncEnumerable<EmployeeEvaluationScoresGroup> GetEmploeeEvaluationScoresGroupsAsync() =>
            _repository.EmployeeEvaluationScores
                .Include(item=>item.Employee).Include(item=>item.Skill)
                .GroupBy(item => item.EmployeeId).AsNoTracking()
                .Select(group=>new EmployeeEvaluationScoresGroup(group.Key,group))
                .AsAsyncEnumerable();

        [HttpGet("PositionRequirementScores/{positionId}")]
        public IAsyncEnumerable<PositionRequirementScore> GetPositionRequirementScoresAsync(int positionId) =>
            _repository.PositionRequirementScores.Where(item => item.PositionId == positionId)
                .AsNoTracking().AsAsyncEnumerable();

        [HttpGet("PositionRequirementScores")]
        public IAsyncEnumerable<PositionRequirementScoresGroup> GetPositionRequirementScoresGroupAsync() =>
            _repository.PositionRequirementScores
                .Include(item => item.Position).Include(item => item.Skill)
                .GroupBy(item => item.PositionId).AsNoTracking()
                .Select(group => new PositionRequirementScoresGroup(group.Key, group))
                .AsAsyncEnumerable();

        [HttpPost("EmployeeEvalutationScores")]
        public async ValueTask AddEmployeeEvaluationScoreAsync(EmployeeEvaluationScore employeeEvaluationScore)
        {
            await _repository.EmployeeEvaluationScores.AddAsync(employeeEvaluationScore);
            await _repository.SaveChangesAsync();
        }
        [HttpPost("PositionRequirementScores")]
        public async ValueTask AddPositionRequirementScores(PositionRequirementScore positionRequirementScore)
        {
            await _repository.PositionRequirementScores.AddAsync(positionRequirementScore);
            await _repository.SaveChangesAsync();
        }

        [HttpPut("EmployeeEvalutationScores")]
        public async ValueTask UpdateEmployeeEvaluationScoreAsync(EmployeeEvaluationScore employeeEvaluationScore)
        {
            _repository.EmployeeEvaluationScores.Update(employeeEvaluationScore);
            await _repository.SaveChangesAsync();
        }
        [HttpPut("PositionRequirementScores")]
        public async ValueTask UpdatePositionRequirementScores(PositionRequirementScore positionRequirementScore)
        {
            _repository.PositionRequirementScores.Update(positionRequirementScore);
            await _repository.SaveChangesAsync();
        }

        [HttpDelete("EmployeeEvaluationScores")]
        public async ValueTask RemoveEmployeeEvaluationScoreAsync(EmployeeEvaluationScore employeeEvaluationScore)
        {
            _repository.EmployeeEvaluationScores.Remove(employeeEvaluationScore);
            await _repository.SaveChangesAsync();
        }
        [HttpDelete("PositionRequirementScores")]
        public async ValueTask RemovePositionRequirementScores(PositionRequirementScore positionRequirementScore)
        {
            _repository.PositionRequirementScores.Remove(positionRequirementScore);
            await _repository.SaveChangesAsync();
        }
    }
}
