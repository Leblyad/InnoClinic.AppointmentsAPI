using InnoClinic.AppointmentsAPI.Application.DataTransferObjects;
using InnoClinic.AppointmentsAPI.Application.Services.Abstractions;
using InnoClinic.AppointmentsAPI.Attributes;
using InnoClinic.AppointmentsAPI.Core.Entitites.QueryParameters;
using InnoClinic.AppointmentsAPI.Core.Enums;
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

        [Roles(Role.Receptionist)]
        [HttpGet]
        public async Task<IActionResult> GetAppointments([FromQuery] AppointmentQueryParameters appointmentParameters)
        {
            var appointmentsCollection = await _appointmentService.GetAllAppointmentsByPagesAsync(appointmentParameters);

            return Ok(appointmentsCollection);
        }

        [Roles]
        [HttpGet("{appointmentId:guid}")]
        public async Task<IActionResult> GetAppointmentById(Guid appointmentId)
        {
            var appointmentDTO = await _appointmentService.GetAppointmentAsync(appointmentId);

            return Ok(appointmentDTO);
        }

        [Roles]
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentForCreationDTO appointment)
        {
            var appointmentDTO = await _appointmentService.CreateAppointmentAsync(appointment);

            return CreatedAtAction(nameof(GetAppointmentById), new { appointmentId = appointmentDTO.Id }, appointmentDTO);
        }

        [Roles(Role.Receptionist)]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAppointment(Guid id, [FromBody] AppointmentForUpdateDTO appointment)
        {
            await _appointmentService.UpdateAppointmentAsync(id, appointment);

            return NoContent();
        }

        [Roles(Role.Receptionist)]
        [HttpGet("view")]
        public async Task<IActionResult> ViewAppointmentListByReceptionist()
        {
            var accessToken = HttpContext.Request.Headers["Authorization"];
            var appointments = await _appointmentService.ViewAppointmentListByReceptionistAsync(accessToken);

            return Ok(appointments);
        }

        [Roles(Role.Doctor, Role.Patient)]
        [HttpGet("Patient/{patientId:guid}")]
        public async Task<IActionResult> ViewAppointmentHistoryByDoctorAndPatient(Guid patientId)
        {
            var accessToken = HttpContext.Request.Headers["Authorization"];
            var appointments = await _appointmentService.ViewAppointmentHistoryByDoctorAndPatientAsync(patientId, accessToken);

            return Ok(appointments);
        }

        [Roles(Role.Doctor)]
        [HttpGet("Doctor/{doctorId:guid}")]
        public async Task<IActionResult> ViewAppointmentScheduleByDoctor(Guid doctorId)
        {
            var accessToken = HttpContext.Request.Headers["Authorization"];
            var appointments = await _appointmentService.ViewAppointmentScheduleByDoctorAsync(doctorId, accessToken);

            return Ok(appointments);
        }
    }
}
