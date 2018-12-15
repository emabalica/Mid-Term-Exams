using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementOfExams.Data;
using ManagementOfExams.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementOfExams.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Teachers2Controller : ControllerBase
    {
        private readonly IRepository<Teacher> _repo;

        public Teachers2Controller(IRepository<Teacher> _repo) => this._repo = _repo;

        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> Get()
        {
            var teachers = _repo.GetAll();
            return Ok(teachers);
        }

        


     

    }
}