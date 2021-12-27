using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;

namespace ApiUchet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentFailureController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Equipment_failure> Get()
        {
            return DataReceive.GetFailures();
        }

        [HttpGet("{id_equipment_failure}")]
        public ActionResult<Equipment_failure> Get(int id_equipment_failure)
        {
            var result = DataReceive.GetFailure(id_equipment_failure);
            if (result == null)
                return NotFound();

            return result;
        }
    }
}
