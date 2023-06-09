﻿using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<dynamic> Login(LoginBody login);
        Task<List<User>> GetAll();
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<User> GetById(int id);
        Task<Professor> GetProfessorByIdUser(int idUser);
        Task<Admin> GetAdminByIdUser(int idUser);
        Task<Student> GetStudentByIdUser(int idUser);
        Task<Boolean> Delete(int id);
    }
}
