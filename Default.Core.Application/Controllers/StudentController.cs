using Default.Core.Domain.Dto;
using Default.Core.Domain.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace Default.Core.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController(ICreateNewStudentUseCase createNewStudentUseCase) : ControllerBase
    {

        [HttpPost]
        public ActionResult<bool> Get(StudentDto studentDto)
        {
            return createNewStudentUseCase.CreateStudent(studentDto);
        }
    }
}
