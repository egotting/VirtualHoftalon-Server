using VirtualHoftalon_Server.Models.Dto.Patient;

namespace VirtualHoftalon_Server.Services.Interfaces;

public interface IPatientService
{
    PatientResponseDTO SavePatient(PatientRequestDTO patient);

    IEnumerable<PatientResponseDTO> GetAll();

    PatientResponseDTO GetOneById(int id);
    PatientResponseDTO GetByCPF(string cpf);
    PatientResponseDTO GetByEmail(string email);

    PatientResponseDTO UpdateById(int id, PatientUpdateRequestDTO patient);

    void DeleteById(int id);
}