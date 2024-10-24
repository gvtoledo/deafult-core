namespace Default.Core.Domain.Interfaces.Repository
{
    public interface IStudentRepository
    {
        Student? GetByCpf(string cpf);
        bool Create(Student student);
    }
}
