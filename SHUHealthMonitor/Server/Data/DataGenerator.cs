using SHUHealthMonitor.Server.Models;
using Bogus;
using Bogus.DataSets;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace SHUHealthMonitor.Server.Data;

//dummy data generation for patients using the bogus library. Patients will be added to the patientsdb database

public class DataGenerator
{

    public static readonly List<PatientModel> Patients = new();

    private static Faker<PatientModel> getPatientData2()
    {

        return new Faker<PatientModel>()
.RuleFor(e => e.FirstName, f => f.Name.FirstName())
.RuleFor(e => e.LastName, f => f.Name.LastName())
.RuleFor(e => e.age, f => f.Random.Int(min: 18, max: 105))
.RuleFor(e => e.DOB, f => f.Random.Int(min: 1899, max: 2100).ToString())
.RuleFor(e => e.Address, f => f.Address.StreetAddress());

        //        var PatientInfo = FakePatientModel.Generate(5);

        //      var options = new JsonSerializerOptions { WriteIndented = true };
        //    Console.WriteLine(JsonSerializer.Serialize(PatientInfo, options));
        //  return Console.WriteLine(JsonSerializer.Serialize(PatientInfo, options));


    }

    private static List<PatientModel> getPatientData()
    {
        var PatientGen = getPatientData2();
        var generatedPatients = PatientGen.Generate(5);
        Patients.AddRange(generatedPatients);
        return generatedPatients;

    }

    public static void InitData()
    {
        var PatientGen = getPatientData2();
        var generatedPatients = PatientGen.Generate(5);
        Patients.AddRange(generatedPatients);
        getPatientData();
    }

    /*
    public static List<PatientModel> GetSeededPatientsFromDb()
    {
        using var patientDbContext = new PatientDbContext();
        patientDbContext.Database.EnsureCreated();
        var dbPatients = patientDbContext.patient
               .Include(e => patientDbContext.patient)
               .ToList();
        return dbPatients;
    }
    */

    /*
    public DataGenerator()
    {
        Randomizer.Seed = new Random(123);

        FakePatientModel = new Faker<PatientModel>()
            .RuleFor(e => e.FirstName, f => f.Name.FirstName())
            .RuleFor(e => e.LastName, f => f.Name.LastName())
            .RuleFor(e => e.age, f => f.Random.Int(min: 18, max: 105))
            .RuleFor(e => e.DOB, f => f.Random.Int(min: 1899, max: 2100).ToString())
            .RuleFor(e => e.Address, f => f.Address.StreetAddress());
    }
    */

    /*
    public PatientModel GeneratePatient()
    {
        return FakePatientModel.Generate();
    }
*/
}


