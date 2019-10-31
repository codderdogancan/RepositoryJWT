using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApı.Dto;
using WebApı.Interfaces;

namespace WebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly IRepository _repository;

        public ValuesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult Index([FromBody]List<JDto> jDto)
        {
            Console.WriteLine(jDto);

            foreach(var item in jDto)
            {
                User user = new User()
                {
                 // id = item.id,
                    firstname = item.firstname,
                    lastname = item.lastname,
                    username = item.username
                };
                var result = _repository.FindUser(user.username);
                if(result == null)
                {
                    _repository.Insert(user);
                }
            }
            return new JsonResult(_repository.List());
        }


        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return new JsonResult(_repository.List());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
