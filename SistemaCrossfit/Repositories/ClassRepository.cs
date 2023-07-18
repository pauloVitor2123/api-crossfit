using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
    public class ClassRepository : IClassRespository
    {
        private readonly AppDBContext _dbContext;

        public ClassRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ClassDTO>> GetAll()
        {
            var classes = await _dbContext.Class.ToListAsync();
            List<ClassDTO> classDTOs = classes.Select(c => new ClassDTO
            {
                IdClass = c.IdClass,
                Name = c.Name,
                Date = c.Date,
                StartHour = c.StartHour,
                EndHour = c.EndHour,
                Description = c.Description,
                IdProfessor = c.IdProfessor,
                Professor = c.Professor,
                IdStatus = c.IdStatus,
                Status = c.Status,
                ConfirmedStudents = null
            }).ToList();

            foreach (var item in classDTOs)
            {
                var p = await _dbContext.Professor.FirstOrDefaultAsync(e => e.IdProfessor == item.IdProfessor);
                if (p == null) throw new Exception("Professor not found!");

                item.Professor = p;

                var u = await _dbContext.User.FirstOrDefaultAsync(e => e.IdUser == p.IdUser);
                if (u == null) throw new Exception("User not found!");

                item.Professor.User = u;

                var s = await _dbContext.Status.FirstOrDefaultAsync(e => e.IdStatus == item.IdStatus);
                if (s == null) throw new Exception("Status not found!");

                item.Status = s;

                var studentsCheckInClass = await _dbContext.StudentCheckInClass.Where(e => e.IdClass == item.IdClass).ToListAsync();

                List<StudentDTO> confirmedStudents = new List<StudentDTO>();

                foreach (var studentCheckIn in studentsCheckInClass)
                {
                    var student = await _dbContext.Student.FindAsync(studentCheckIn.IdStudent);

                    if (student != null)
                    {
                        var user = await _dbContext.User.FirstOrDefaultAsync(e => e.IdUser == student.IdUser);
                        if (user != null)
                        {
                            var studentDTO = new StudentDTO
                            {
                                IdStudent = student.IdStudent,
                                Name = user.Name
                            };

                            confirmedStudents.Add(studentDTO);
                        }
                    }
                }

                item.ConfirmedStudents = confirmedStudents;

            }

            return classDTOs;
        }

        public async Task<List<ClassDTO>> GetAllClassesWithStudentInfo(int idStudent)
        {
            var classes = await _dbContext.Class.ToListAsync();
            List<ClassDTO> classList = new List<ClassDTO>();

            foreach (var item in classes)
            {
                var p = await _dbContext.Professor.FirstOrDefaultAsync(e => e.IdProfessor == item.IdProfessor);
                if (p == null)
                    throw new Exception("Professor not found!");

                item.Professor = p;

                var u = await _dbContext.User.FirstOrDefaultAsync(e => e.IdUser == p.IdUser);
                if (u == null)
                    throw new Exception("User not found!");

                item.Professor.User = u;

                var s = await _dbContext.Status.FirstOrDefaultAsync(e => e.IdStatus == item.IdStatus);
                if (s == null)
                    throw new Exception("Status not found!");

                item.Status = s;

                var checkinInClass = await _dbContext.StudentCheckInClass.FirstOrDefaultAsync(x => x.IdClass == item.IdClass && x.IdStudent == idStudent);
                var classDto = new ClassDTO
                {
                    IdClass = item.IdClass,
                    Name = item.Name,
                    Date = item.Date,
                    StartHour = item.StartHour,
                    EndHour = item.EndHour,
                    Description = item.Description,
                    IdProfessor = item.IdProfessor,
                    Professor = item.Professor,
                    IdStatus = item.IdStatus,
                    Status = item.Status,
                    CheckIn = checkinInClass != null
                };

                classList.Add(classDto);
            }

            return classList;
        }

        public async Task<Class> GetByName(string name)
        {
            var className = await _dbContext.Class.FirstOrDefaultAsync(c => c.Name == name);

            return className == null ? throw new Exception("Class not found!") : className;
        }

        public async Task<ClassDTO> GetById(int id)
        {
            var classVariable = await _dbContext.Class.FirstOrDefaultAsync(c => c.IdClass == id);
            if (classVariable == null) throw new Exception("Class not found!");

            var p = await _dbContext.Professor.FirstOrDefaultAsync(e => e.IdProfessor == classVariable.IdProfessor);
            if (p == null) throw new Exception("Professor not found!");

            classVariable.Professor = p;

            var u = await _dbContext.User.FirstOrDefaultAsync(e => e.IdUser == p.IdUser);
            if (u == null) throw new Exception("User not found!");

            classVariable.Professor.User = u;

            var s = await _dbContext.Status.FirstOrDefaultAsync(e => e.IdStatus == classVariable.IdStatus);
            if (s == null) throw new Exception("Status not found!");

            classVariable.Status = s;

            var checkinInClass = await _dbContext.StudentCheckInClass.FirstOrDefaultAsync(x => x.IdClass == classVariable.IdClass);
            var classDto = new ClassDTO
            {
                IdClass = classVariable.IdClass,
                Name = classVariable.Name,
                Date = classVariable.Date,
                StartHour = classVariable.StartHour,
                EndHour = classVariable.EndHour,
                Description = classVariable.Description,
                IdProfessor = classVariable.IdProfessor,
                Professor = classVariable.Professor,
                IdStatus = classVariable.IdStatus,
                Status = classVariable.Status,
            };

            var studentsCheckInClass = await _dbContext.StudentCheckInClass.Where(e => e.IdClass == classDto.IdClass).ToListAsync();

            List<StudentDTO> confirmedStudents = new List<StudentDTO>();

            foreach (var studentCheckIn in studentsCheckInClass)
            {
                var student = await _dbContext.Student.FindAsync(studentCheckIn.IdStudent);

                if (student != null)
                {
                    var user = await _dbContext.User.FirstOrDefaultAsync(e => e.IdUser == student.IdUser);
                    if (user != null)
                    {
                        var studentDTO = new StudentDTO
                        {
                            IdStudent = student.IdStudent,
                            Name = user.Name
                        };

                        confirmedStudents.Add(studentDTO);
                    }
                }
            }

            classDto.ConfirmedStudents = confirmedStudents;


            return classDto;
        }

        public async Task<Class> Create(Class classCreate)
        {
            await _dbContext.Class.AddAsync(classCreate);
            await _dbContext.SaveChangesAsync();

            return classCreate;
        }

        public async Task<Class> Update(Class classEntity, int id)
        {
            var classUpdate = await _dbContext.Class.FirstOrDefaultAsync(c => c.IdClass == id);
            if (classUpdate == null) throw new Exception("Class not found!");

            classUpdate.Name = classEntity.Name;
            classUpdate.Description = classEntity.Description;
            classUpdate.StartHour = classEntity.StartHour;
            classUpdate.EndHour = classEntity.EndHour;
            classUpdate.IdProfessor = classEntity.IdProfessor;
            classUpdate.Date = classEntity.Date;
            classUpdate.IdStatus = classEntity.IdStatus;
            await _dbContext.SaveChangesAsync();

            return classUpdate;
        }

        public async Task<bool> Delete(int id)
        {
            var classDelete = await _dbContext.Class.FirstOrDefaultAsync(c => c.IdClass == id);
            if (classDelete == null) throw new Exception("Class not found!");

            _dbContext.Class.Remove(classDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        Task<List<Class>> IBaseRepository<Class>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Class> IBaseRepository<Class>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}