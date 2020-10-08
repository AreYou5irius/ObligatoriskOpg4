using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FanLibrary;
using Microsoft.AspNetCore.Mvc;



namespace Obligatorisk_opg_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FanOutPutController : ControllerBase
    {


        private static readonly List<FanOutput> measurments = new List<FanOutput>()
        {
            new FanOutput(Id, "AZ",21,40),
            new FanOutput(Id, "BF", 15,51)

        };

        private static int _id = 1;

        public static int Id
        {
            get => _id++;
            set => _id = value;
        }

        // GET: api/<FanOutPutController>
        [HttpGet]
        public IEnumerable<FanOutput> Get()
        {
            return measurments;
        }

        // GET api/<FanOutPutController>/5
        [HttpGet("{id}")]
        public FanOutput Get(int id)
        {
            return measurments.Find(i => i.Id == id);
        }

        // POST api/<FanOutPutController>
        [HttpPost]
        public void Post([FromBody] FanOutput value)
        {

            measurments.Add(new FanOutput(Id, value.Navn, value.Temp, value.Fugt));
        }

        // PUT api/<FanOutPutController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FanOutput value)
        {
            FanOutput item = Get(id);
            if (item != null)
            {
                item.Navn = value.Navn;
                item.Temp = value.Temp;
                item.Fugt = value.Fugt;
            }
        }

        // DELETE api/<FanOutPutController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FanOutput item = Get(id);
            measurments.Remove(item);
        }
    }
}
