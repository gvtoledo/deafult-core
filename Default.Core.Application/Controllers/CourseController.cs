using Default.Core.Domain;
using Default.Core.Domain.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace Default.Core.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController(IGetCourseUseCase getCourseUseCase) : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get()
        {
            return getCourseUseCase.Get();
        }
    }
}
