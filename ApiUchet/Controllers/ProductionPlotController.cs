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
    public class ProductionPlotController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Production_plot> Get()
        {
            return DataReceive.GetPlots();
        }

        [HttpGet("{id_plot}")]
        public ActionResult<Production_plot> Get(int id_plot)
        {
            var result = DataReceive.GetPlot(id_plot);
            if (result == null)
                return NotFound();

            return result;
        }
    }
}
