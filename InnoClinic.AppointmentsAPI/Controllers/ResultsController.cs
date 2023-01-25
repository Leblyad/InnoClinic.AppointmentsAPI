using InnoClinic.AppointmentsAPI.Application.DataTransferObjects;
using InnoClinic.AppointmentsAPI.Application.Services.Abstractions;
using InnoClinic.AppointmentsAPI.Attributes;
using InnoClinic.AppointmentsAPI.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.AppointmentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IResultService _resultService;

        public ResultsController(IResultService resultService)
        {
            _resultService = resultService;
        }

        [Roles(Role.Patient, Role.Doctor)]
        [HttpGet("{resultId:guid}")]
        public async Task<IActionResult> GetResultById(Guid resultId)
        {
            var resultDTO = await _resultService.GetResultAsync(resultId);

            return Ok(resultDTO);
        }

        [Roles(Role.Doctor)]
        [HttpPost]
        public async Task<IActionResult> CreateResult([FromBody] ResultForCreationDTO result)
        {
            var resultDTO = await _resultService.CreateResultAsync(result);

            return CreatedAtAction(nameof(GetResultById), new { resultId = resultDTO.Id }, resultDTO);
        }

        [Roles(Role.Doctor)]
        [HttpPut("{resultId:guid}")]
        public async Task<IActionResult> UpdateResult(Guid resultId, [FromBody] ResultForUpdateDTO result)
        {
            await _resultService.UpdateResultAsync(resultId, result);

            return NoContent();
        }
    }
}
