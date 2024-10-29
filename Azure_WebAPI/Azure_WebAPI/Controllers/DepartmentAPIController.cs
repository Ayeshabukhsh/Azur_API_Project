using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Azure_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentAPIController : ControllerBase
    {
        public List<string> departments = new List<string>()
        {
            "HR",
            "IT",
            "Acounts",
            "Marketing",
            "Sales",
            "operations",
            "Engineer",
            "QA"
        };

        [HttpGet]
        public List<string> GetDepartments()
        {
            return departments;
        }
        [HttpGet("{id}")]
        public string GetDepartmentsByIndex( int id )
        {
            return departments.ElementAt(id);
        }

    }
}
