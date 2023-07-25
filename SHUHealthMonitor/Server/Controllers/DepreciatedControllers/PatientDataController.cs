using Microsoft.AspNetCore.Mvc;
using SHUHealthMonitor.Server.Models;
using System.Collections.Generic;


/*
 * Attempted to implement a patient editing feature. After researching multiple methods, most lead to errors. 
 * I tried to get this working a few times, but each time i recieved errors relating to json/http objects. 
 * After further research, these errors are a common bug within .net7, and currently there seems to be little solutions avaible.
 * 
 * 
namespace SHUHealthMonitor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDataController : ControllerBase
    {
        private readonly IPatientModel _IPatient;
        public PatientDataController(IPatientModel iPatient)
        {
            _IPatient = iPatient;
        }
        [HttpGet]
        public async Task<List<PatientModel>> Get()
        {
            return await Task.FromResult(_IPatient.getPatientDetails());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            PatientModel patient = _IPatient.GetPatientData(id);
            if (patient != null)
            {
                return Ok(patient);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(PatientModel patient)
        {
            _IPatient.AddPatient(patient);
        }
        [HttpPut]
        public void Put(PatientModel patient)
        {
            _IPatient.UpdatePatientDetails(patient);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IPatient.DeletePatient(id);
            return Ok();
        }
    }
}

*/