using InnoClinic.AppointmentsAPI.Application.DataTransferObjects;
using InnoClinic.AppointmentsAPI.Application.Services.Abstractions;
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

        [HttpGet]
        public async Task<IActionResult> GetResults()
        {
            var resultsCollection = await _resultService.GetAllResultsAsync();

            return Ok(resultsCollection);
        }

        [HttpGet("{resultId:guid}")]
        public async Task<IActionResult> GetResultById(Guid resultId)
        {
            var resultDTO = await _resultService.GetResultAsync(resultId);

            return Ok(resultDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResult([FromBody] ResultForCreationDTO result)
        {
            var resultDTO = await _resultService.CreateResultAsync(result);

            return CreatedAtAction(nameof(GetResultById), new { resultId = resultDTO.Id }, resultDTO);
        }

        [HttpPut("{resultId:guid}")]
        public async Task<IActionResult> UpdateResult(Guid resultId, [FromBody] ResultForUpdateDTO result)
        {
            await _resultService.UpdateResultAsync(resultId, result);

            return NoContent();
        }

        [HttpDelete("{resultId:guid}")]
        public async Task<IActionResult> DeleteResult(Guid resultId)
        {
            await _resultService.DeleteResultAsync(resultId);

            return NoContent();
        }
    }
}
