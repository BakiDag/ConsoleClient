using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {

        [HttpGet]
        public List<string> Get()
        {
            List<string> NumbersList = new List<string>();
            NumbersList.Add("1");
            NumbersList.Add("2");
            NumbersList.Add("3");

            return NumbersList;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string id)
        {
            string _id = id;
            return Ok("Nummer eingetragen " + _id);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] string id)
        {
            string _id = id;
            _id = "3";
            return Ok("Nummer geaendert " + _id);
        }


        [AllowAnonymous]
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] string id)
        {
            //Look in Array/List/Database
            id = "0";
            return Ok("Nummer geloescht " + id);
        }

    }
}
