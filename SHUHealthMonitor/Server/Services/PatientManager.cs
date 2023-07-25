/*

using SHUHealthMonitor.Server.Interfaces;
using SHUHealthMonitor.Server.Models;
using SHUHealthMonitor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using SHUHealthMonitor.Server.Data;

namespace SHUHealthMonitor.Server.Services
{
    public class PatientManager : IPatientModel
    {
        readonly PatientDbContext _dbContext = new();

        public PatientManager(PatientDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddPatient(PatientModel patient)
        {
            try
            {
                _dbContext.patient.Add(patient);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeletePatient(int id)
        {
            try
            {
                PatientModel? patient = _dbContext.patient.Find(id);
                if (patient != null)
                {
                    _dbContext.patient.Remove(patient);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public PatientModel GetPatientData(int id)
        {
            try
            {
                PatientModel patient = _dbContext.patient.Find(id);
                if (patient != null) {
                    return patient;
                }
                else
                {

                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<PatientModel> getPatientDetails()
        {
            try
            {
                return _dbContext.patient.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void UpdatePatientDetails(PatientModel patient)
        {
            try
            {
                _dbContext.Entry(patient).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}

*/