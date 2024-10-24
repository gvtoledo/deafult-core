using Default.Core.Domain.Dto;

namespace Default.Core.Domain.Interfaces.UseCase
{
    public interface ICreateNewStudentUseCase
    {
        bool CreateStudent(StudentDto studentDto);
    }
}
