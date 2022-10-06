using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Controllers
{
    [Route("api/[controller]")]//api/Persons
    [ApiController]
    public class PersonsController : ControllerBase
    {

		[HttpGet]
		public IActionResult Get() {

			List<Person> PersonsList = new List<Person>()
			{
				new Person()
				{
					Id="100",
				Name= "Meier",
				Vorname="Markus"
				},
				new Person()
				{
					Id="101",
				Name= "Mueller",
				Vorname="Frank"
				},
				new Person()
				{
					Id="102",
				Name= "Berg",
				Vorname="Manuel"
				},

			};

			return Ok(PersonsList);
		}

		[HttpPost("Post")]
		public IActionResult Post([FromBody] Person person) {
			//Add in Array/List/Database
			Person postPerson = new Person();
			postPerson.Id = person.Id;
			postPerson.Name = person.Name;
			postPerson.Vorname = person.Vorname;
			return Ok(postPerson);
		}

		[HttpPut]
		public IActionResult Put([FromBody] Person person) {
			//get from Array/List/Database and change/update it
			person.Name = "Mueller";



			return Ok(person);
		}

		[AllowAnonymous]
		[HttpPost("Delete")]
		public IActionResult Delete([FromBody] Person person) {
			//Look in Array/List/Database
			Person temp = person;
			person = null;

			return Ok(temp);
		}

	}
}
