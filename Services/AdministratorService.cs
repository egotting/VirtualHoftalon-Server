﻿using VirtualHoftalon_Server.Enums;
using VirtualHoftalon_Server.Models;
using VirtualHoftalon_Server.Models.Dto.Administrator;
using VirtualHoftalon_Server.Repositories.Interfaces;
using VirtualHoftalon_Server.Services.Interfaces;

namespace VirtualHoftalon_Server.Services;

public class AdministratorService : IAdministratorService
{

    private readonly IAdministratorRepository _repository;
    private readonly ILoginRepository _loginRepository;

    public AdministratorService(IAdministratorRepository repository, ILoginRepository loginRepository)
    {
        _repository = repository;
        _loginRepository = loginRepository;
    }


    public List<AdministratorResponseDTO> GetAll()
    {
        return _repository.GetAll().Select(a => ToResponseDTO(a)).ToList();
    }

    public AdministratorResponseDTO Save(AdministratorRequestDTO administrator)
    {
        Administrator adminToSave = new Administrator()
        {
            FirstName = administrator.FirstName,
            LastName = administrator.LastName,
            Cpf = administrator.Cpf,
            Email = administrator.Email,
            DateBirth = DateTime.Parse(administrator.DateBirth).ToUniversalTime(),
        };
        _repository.SaveAdministrator(adminToSave);
        Login login = CreateLoginByAdminstratorDTO(administrator);
        adminToSave.Login = login;
        _repository.UpdateAdministrator(adminToSave);
        return ToResponseDTO(adminToSave);
    }

    public AdministratorResponseDTO GetOneById(int id)
    {
        throw new NotImplementedException();
    }

    public AdministratorResponseDTO Update(int id, AdministratorRequestDTO administrator)
    {
        throw new NotImplementedException();
    }

    public bool DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    private Login CreateLoginByAdminstratorDTO(AdministratorRequestDTO administrator)
    {
        Login login = new Login()
        {
            Password = administrator.Password,
            Role = Roles.ADMIN,
            Username = administrator.Email.Split("@")[0]
        };
        _loginRepository.Save(login);
        return login;
    }

    private AdministratorResponseDTO ToResponseDTO(Administrator administrator)
    {
        return new AdministratorResponseDTO(administrator.Id, administrator.FirstName,
            administrator.LastName, administrator.Cpf,
            administrator.Email, administrator.DateBirth, administrator.LoginId);
    }
}