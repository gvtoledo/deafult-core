using Default.Core.Domain;
using Default.Core.Domain.Interfaces.Repository;

namespace Default.Core.Repository
{
    public class StudentRepository: IStudentRepository
    {
        public Student? GetByCpf(string cpf)
        {
            List<Student> students = new List<Student>
            {

                new Student()
                {
                    Id = 1,
                    Name = "João da Silva",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Cpf = "79785606007",
                    Rg = "123456789",
                    Email = "jsilva@gmail.com",
                    PhoneNumber = "03138732199",
                    CellPhoneNumber = "031999875454",
                    Address = "R. Bernardo Tôrres, 180",
                    City = "Matipó",
                    State = "Minas Gerais",
                    Country = "Brasil",
                    ZipCode = "35367-000",
                    CourseId = 1
                },
                new Student()
                {
                    Id = 2,
                    Name = "Maria da Silva",
                    DateOfBirth = new DateTime(1995, 2, 2),
                    Cpf = "94244515046",
                    Rg = "123456788",
                    Email = "msilva@gmail.com",
                    PhoneNumber = "03133328585",
                    CellPhoneNumber = "03199979865",
                    Address = "R. Santa Teresinha ,510",
                    City = "Matipó",
                    State = "Minas Gerais",
                    Country = "Brasil",
                    ZipCode = "35367-000",
                    CourseId = 1
                }
            };

            return students.FirstOrDefault(s => s.Cpf == cpf);
        }

        public bool Create(Student student)
        {
            // Persiste o estudante no banco de dados
            return true;
        }
    }
}
