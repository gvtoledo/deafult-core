using Default.Core.Domain;
using Default.Core.Domain.Interfaces.Repository;
using Default.Core.Domain.Interfaces.UseCase;

namespace Default.Core.UseCase
{
    public class GetCourseUseCase(ICourseRepository courseRepository): IGetCourseUseCase
    {
        public List<Course> Get() 
        {
            var couses = courseRepository.GetAll();

            return couses.Where(c => c.Vacancies > 0 && c.EntranceExamStartDate <= DateTime.Now && c.EntranceExamEndDate >= DateTime.Now).ToList();
        }

    }
}
