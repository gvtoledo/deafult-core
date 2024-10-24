using Default.Core.Domain;
using Default.Core.Domain.Interfaces.Repository;

namespace Default.Core.Repository
{
    public class CourseRepository : ICourseRepository
    {
        public List<Course> GetAll() => new List<Course>
            {
                new Course
                {
                    Id = 1,
                    Name = "Ciência da Computação",
                    EntranceExamStartDate = new DateTime(2024, 10, 20),
                    EntranceExamEndDate = new DateTime(2024, 10, 30),
                    Vacancies = 10
                },
                new Course
                {
                    Id = 2,
                    Name = "Medicina",
                    EntranceExamStartDate = new DateTime(2024, 6, 1),
                    EntranceExamEndDate = new DateTime(2024, 6, 10),
                    Vacancies = 20
                },
                new Course
                {
                    Id = 3,
                    Name = "Direito",
                    EntranceExamStartDate = new DateTime(2021, 10, 20),
                    EntranceExamEndDate = new DateTime(2021, 10, 30),
                    Vacancies = 0
                }
            };
    }
}
