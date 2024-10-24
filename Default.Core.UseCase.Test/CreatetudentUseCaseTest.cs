using Default.Core.Domain;
using Default.Core.Domain.Dto;
using Default.Core.Domain.Interfaces.Repository;
using NSubstitute;

namespace Default.Core.UseCase.Test
{
    [TestClass]
    public class CreatetudentUseCaseTest
    {
        public IStudentRepository _studentRepository;
        public CreateNewStudentUseCase _createNewStudentUseCase;

        [TestInitialize]
        public void Setup()
        {
            _studentRepository = Substitute.For<IStudentRepository>();

            _createNewStudentUseCase = new CreateNewStudentUseCase(_studentRepository);
        }

        [TestMethod]
        public void CreateStudent_ShoudValidStudent_WithSucess()
        {
            // Arrange
            var studentDto = new StudentDto()
            {
                Name = "Student 1",
                DateOfBirth = DateTime.Now.AddYears(-20),
                Cpf = "424.122.640-07",
                Rg = "123456789",
                Email = "",
                PhoneNumber = "123456789",
                CellPhoneNumber = "123456789",
                Address = "Rua 1",
                City = "City 1",
                State = "State 1",
                Country = "Country 1",
                ZipCode = "12345678",
                CourseId = 1
            };


            _studentRepository.GetByCpf(studentDto.Cpf).Returns((Student)null);
            _studentRepository.Create(Arg.Any<Student>()).Returns(true);

            // Act
            var result = _createNewStudentUseCase.CreateStudent(studentDto);

            // Assert
            Assert.IsTrue(result);
            _studentRepository.Received(1).Create(Arg.Any<Student>());
            _studentRepository.Received(1).GetByCpf(studentDto.Cpf);

        }

        [TestMethod]
        public void CreateStudent_ShoudInvalidCpf_WithReturnsFalse()
        {
            // Arrange
            var studentDto = new StudentDto()
            {
                Name = "Student 1",
                DateOfBirth = DateTime.Now.AddYears(-20),
                Cpf = "111.111.111-11",
                Rg = "123456789",
                Email = "",
                PhoneNumber = "123456789",
                CellPhoneNumber = "123456789",
                Address = "Rua 1",
                City = "City 1",
                State = "State 1",
                Country = "Country 1",
                ZipCode = "12345678",
                CourseId = 1
            };

            // Act
            var result = _createNewStudentUseCase.CreateStudent(studentDto);

            // Assert
            Assert.IsFalse(result);
            _studentRepository.DidNotReceive().GetByCpf(Arg.Any<string>());
            _studentRepository.DidNotReceive().Create(Arg.Any<Student>());

        }

        [TestMethod]
        public void CreateStudent_ShouldInvalidAge_WithReturnsFalse()
        {
            // Arrange
            var studentDto = new StudentDto()
            {
                Name = "Student 1",
                DateOfBirth = DateTime.Now.AddYears(-10),
                Cpf = "424.122.640-07",
                Rg = "123456789",
                Email = "",
                PhoneNumber = "123456789",
                CellPhoneNumber = "123456789",
                Address = "Rua 1",
                City = "City 1",
                State = "State 1",
                Country = "Country 1",
                ZipCode = "12345678",
                CourseId = 1
            };

            // Act
            var result = _createNewStudentUseCase.CreateStudent(studentDto);

            // Assert
            Assert.IsFalse(result);
            _studentRepository.DidNotReceive().GetByCpf(Arg.Any<string>());
            _studentRepository.DidNotReceive().Create(Arg.Any<Student>());
        }


        [TestMethod]
        public void CreateStudent_ShouldStudentAlreadyExists_WithReturnsFalse()
        {
            // Arrange
            var studentDto = new StudentDto()
            {
                Name = "Student 1",
                DateOfBirth = DateTime.Now.AddYears(-20),
                Cpf = "424.122.640-07",
                Rg = "123456789",
                Email = "",
                PhoneNumber = "123456789",
                CellPhoneNumber = "123456789",
                Address = "Rua 1",
                City = "City 1",
                State = "State 1",
                Country = "Country 1",
                ZipCode = "12345678",
                CourseId = 1
            };

            var student = new Student()
            {
                Name = "Student 1",
                DateOfBirth = DateTime.Now.AddYears(-20),
                Cpf = "424.122.640-07",
                Rg = "123456789",
                Email = "",
                PhoneNumber = "123456789",
                CellPhoneNumber = "123456789",
                Address = "Rua 1",
                City = "City 1",
                State = "State 1",
                Country = "Country 1",
                ZipCode = "12345678",
                CourseId = 1
            };

            _studentRepository.GetByCpf(studentDto.Cpf).Returns(student);

            // Act
            var result = _createNewStudentUseCase.CreateStudent(studentDto);

            // Assert
            Assert.IsFalse(result);
            _studentRepository.Received(1).GetByCpf(studentDto.Cpf);
            _studentRepository.DidNotReceive().Create(Arg.Any<Student>());
        }
    }
}
