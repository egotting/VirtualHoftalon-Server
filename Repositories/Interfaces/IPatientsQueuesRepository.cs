﻿using VirtualHoftalon_Server.Models;

namespace VirtualHoftalon_Server.Repositories.Interfaces;

public interface IPatientsQueuesRepository
{
    IEnumerable<PatientsQueue?> GetPatientsQueues();
    PatientsQueue SavePatientsQueue(PatientsQueue patients);
    PatientsQueue? GetPatientsQueueById(int? id);
    PatientsQueue UpdatePatientsQueue(PatientsQueue patientsQueue);
    bool DeletePatientsQueue(PatientsQueue patients);
    int? GetLastPositionBySectorAndHour(string hour, int? sectorId);
    IEnumerable<PatientsQueue?> GetAllPatientsBySectorAndAppointmentHour(int sectorId, string? hour);
    PatientsQueue CallPatientOnQueueBySectorId(int sectorId);

    PatientsQueue GetPatientQueueByPassword(string password);




}