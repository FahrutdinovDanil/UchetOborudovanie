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
    public class EquipmentController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Equipment> Get()
        {
            return DataReceive.GetEquipments();
        }

        [HttpGet("{id_equipment}")]
        public ActionResult<Equipment> Get(int id_equipment)
        {
            var result = DataReceive.GetEquipment(id_equipment);
            if (result == null)
                return NotFound();

            return result;
        }

        //[HttpPut("{id_equipment}")]
        //public IActionResult Update(int id_equipment, Equipment equipment)
        //{
        //    var result = DataReceive.GetEquipment(id_equipment);
        //    if (result == null)
        //        return NotFound();

        //    DataReceive.UpdateEquipment(id_equipment, equipment);

        //    return NoContent();
        //}

        //[HttpDelete("{id_equipment}")]
        //public IActionResult Delete(int id_equipment)
        //{
        //    var result = DataReceive.GetEquipment(id_equipment);
        //    if (result == null)
        //        return NotFound();

        //    DataReceive.DeleteEquipment(result);
        //    return NoContent();
        //}
    }
}
