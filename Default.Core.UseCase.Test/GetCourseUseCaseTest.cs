using Default.Core.Domain;
using Default.Core.Domain.Interfaces.Repository;
using NSubstitute;

namespace Default.Core.UseCase.Test
{
    [TestClass]
    public class GetCourseUseCaseTest
    {
        private ICourseRepository _courseRepository;
        private GetCourseUseCase _getCourseUseCase;

        [TestInitialize]
        public void Setup()
        {
            _courseRepository = Substitute.For<ICourseRepository>();
            
            _getCourseUseCase = new GetCourseUseCase(_courseRepository);
        }


        [TestMethod]
        public void GetCourse_ShouldReturnCourses_WithSucess()
        {
            // Arrange
            var courses = new List<Course>
            {
                new Course()
                {
                    Id = 1,
                    Name = "Course 1",
                    Vacancies = 10,
                    EntranceExamStartDate = DateTime.Now.AddDays(-5),
                    EntranceExamEndDate = DateTime.Now.AddDays(5)
                },

                new Course()
                {
                    Id = 2,
                    Name = "Course 2",
                    Vacancies = 10,
                    EntranceExamStartDate = DateTime.Now.AddDays(-5),
                    EntranceExamEndDate = DateTime.Now.AddDays(5)
                },
            };

            _courseRepository.GetAll().Returns(courses);

            // Act
            var result = _getCourseUseCase.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            _courseRepository.Received(1).GetAll();
        }

        [TestMethod]
        public void GetCourse_ShouldReturnCoursesHasVacancies_WithSucess()
        {
            // Arrange
            var courses = new List<Course>
            {
                new Course()
                {
                    Id = 1,
                    Name = "Course 1",
                    Vacancies = 0,
                    EntranceExamStartDate = DateTime.Now.AddDays(-5),
                    EntranceExamEndDate = DateTime.Now.AddDays(5)
                },

                new Course()
                {
                    Id = 2,
                    Name = "Course 2",
                    Vacancies = 10,
                    EntranceExamStartDate = DateTime.Now.AddDays(-5),
                    EntranceExamEndDate = DateTime.Now.AddDays(5)
                },
            };

            _courseRepository.GetAll().Returns(courses);

            // Act
            var result = _getCourseUseCase.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(2, result[0].Id);
            _courseRepository.Received(1).GetAll();
        }

        [TestMethod]
        public void GetCourse_ShouldReturnCoursesHasEntranceExamDate_WithSucess()
        {
            // Arrange
            var courses = new List<Course>
            {
                new Course()
                {
                    Id = 1,
                    Name = "Course 1",
                    Vacancies = 10,
                    EntranceExamStartDate = DateTime.Now.AddDays(5),
                    EntranceExamEndDate = DateTime.Now.AddDays(10)
                },

                new Course()
                {
                    Id = 2,
                    Name = "Course 2",
                    Vacancies = 10,
                    EntranceExamStartDate = DateTime.Now.AddDays(-5),
                    EntranceExamEndDate = DateTime.Now.AddDays(5)
                },
            };

            _courseRepository.GetAll().Returns(courses);

            // Act
            var result = _getCourseUseCase.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(2, result[0].Id);
            _courseRepository.Received(1).GetAll();
        }
    }
}