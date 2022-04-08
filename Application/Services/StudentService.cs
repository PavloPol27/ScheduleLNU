using Application.Services.Interfaces;
using Domain.Models;
using Domain.Repository;

namespace Application.Services
{
    public class StudentService: IStudentService
    {
        IRepository<Student> studentRepository;
        public StudentService(IRepository<Student> _studentRepository)
        {
            studentRepository = _studentRepository;
        }
    }
}
