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
    public class TechnicInspectionController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Technical_inspection> Get()
        {
            return DataReceive.GetTechnical_inspections();
        }

        [HttpGet("{id_inspection}")]
        public ActionResult<Technical_inspection> Get(int id_inspection)
        {
            var result = DataReceive.GetTechnical_inspection(id_inspection);
            if (result == null)
                return NotFound();

            return result;
        }


        [HttpPut("{id_inspection}")]
        public IActionResult Update(int id_inspection, Technical_inspection inspection)
        {
            var result = DataReceive.GetTechnical_inspection(id_inspection);
            if (result == null)
                return NotFound();

            DataReceive.UpdateInspection(id_inspection, inspection);

            return NoContent();
        }

        [HttpDelete("{id_inspection}")]
        public IActionResult Delete(int id_inspection)
        {
            var result = DataReceive.GetTechnical_inspection(id_inspection);
            if (result == null)
                return NotFound();

            DataReceive.DeleteInspection(result);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(Technical_inspection inspection)
        {
            DataReceive.AddNewTechnical_inspection(inspection);
            return NoContent();
        }
    }
}
