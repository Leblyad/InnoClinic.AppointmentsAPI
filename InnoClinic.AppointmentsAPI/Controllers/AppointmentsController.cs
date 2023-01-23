using InnoClinic.AppointmentsAPI.Application.DataTransferObjects;
using InnoClinic.AppointmentsAPI.Application.Services.Abstractions;
using InnoClinic.AppointmentsAPI.Core.Entitites.QueryParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinicsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments([FromQuery] AppointmentQueryParameters appointmentParameters)
        {
            var appointmentsCollection = await _appointmentService.GetAllAppointmentsByPagesAsync(appointmentParameters);

            return Ok(appointmentsCollection);
        }

        [HttpGet("{appointmentId:guid}")]
        public async Task<IActionResult> GetAppointmentById(Guid appointmentId)
        {
            var appointmentDTO = await _appointmentService.GetAppointmentAsync(appointmentId);

            return Ok(appointmentDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentForCreationDTO appointment)
        {
            var appointmentDTO = await _appointmentService.CreateAppointmentAsync(appointment);

            return CreatedAtAction(nameof(GetAppointmentById), new { appointmentId = appointmentDTO.Id }, appointmentDTO);
        }

        [HttpPut("{appointmentId:guid}")]
        public async Task<IActionResult> UpdateAppointment(Guid appointmentId, [FromBody] AppointmentForUpdateDTO appointment)
        {
            await _appointmentService.UpdateAppointmentAsync(appointmentId, appointment);

            return NoContent();
        }

        [HttpDelete("{appointmentId:guid}")]
        public async Task<IActionResult> DeleteAppointment(Guid appointmentId)
        {
            await _appointmentService.DeleteAppointmentAsync(appointmentId);

            return NoContent();
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet("view")]
        public async Task<IActionResult> ViewAppointments()
        {
            var accessToken = HttpContext.Request.Headers["Authorization"];
            var appointmentsCollection = await _appointmentService.GetAllAppointmentsAsync(accessToken);

            return Ok(appointmentsCollection);
        }
    }
}
