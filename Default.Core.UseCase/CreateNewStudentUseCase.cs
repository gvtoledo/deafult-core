using Default.Core.Domain;
using Default.Core.Domain.Dto;
using Default.Core.Domain.Interfaces.Repository;
using Default.Core.Domain.Interfaces.UseCase;

namespace Default.Core.UseCase
{
    public class CreateNewStudentUseCase(IStudentRepository studentRepository): ICreateNewStudentUseCase
    {
        public bool CreateStudent(StudentDto studentDto)
        {
            if (!ValidateCPF(studentDto.Cpf))
            {
                return false;
            }

            if (GetAge(studentDto.DateOfBirth) < 18)
            {
                return false;
            }

            var student = studentRepository.GetByCpf(studentDto.Cpf);

            if(student != null)
            {
                return false;
            }


            var newstudent = new Student()
            {
                Name = studentDto.Name,
                DateOfBirth = studentDto.DateOfBirth,
                Cpf = studentDto.Cpf,
                Rg = studentDto.Rg,
                Email = studentDto.Email,
                PhoneNumber = studentDto.PhoneNumber,
                CellPhoneNumber = studentDto.CellPhoneNumber,
                Address = studentDto.Address,
                City = studentDto.City,
                State = studentDto.State,
                Country = studentDto.Country,
                ZipCode = studentDto.ZipCode,
                CourseId = studentDto.CourseId
            };

            return studentRepository.Create(newstudent);
        }

        public static bool ValidateCPF(string cpf)
        {
            // Remove pontos e traços do CPF
            cpf = cpf.Replace(".", "").Replace("-", "");

            // Verifica se o CPF tem 11 dígitos e se não é uma sequência repetida de números
            if (cpf.Length != 11 || cpf.All(c => c == cpf[0]))
                return false;

            // Array com os multiplicadores para o cálculo do primeiro e segundo dígitos verificadores
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Extraindo os 9 primeiros dígitos do CPF
            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            // Calcula o primeiro dígito verificador
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            // Compara o primeiro dígito verificador
            string digito = resto.ToString();
            tempCpf += digito;

            soma = 0;

            // Calcula o segundo dígito verificador
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            // Compara o segundo dígito verificador
            digito += resto.ToString();

            // Retorna true se os dígitos verificadores forem iguais aos do CPF, false caso contrário
            return cpf.EndsWith(digito);
        }

        public static int GetAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;

        }
    }
}
