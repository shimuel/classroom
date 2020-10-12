using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomApp.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassroomApp.Model;

namespace ClassroomApp.Controllers
{
    [ApiController]
    [Route("api/Classroom/Departments")]
    public class ClassRoomController : ControllerBase
    {
        private IClassroomService _classroomService; 

        public ClassRoomController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

        [HttpPost]
        public ActionResult<bool> AddStudent(Student student)
        {
            return true;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IList<Department>> GetAllDepartments()
        {
            if (_classroomService == null)
            {
                return NotFound();
            }

            return _classroomService.GetAllDepartments().ToList();
        }
    }
}
