using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Collections.Immutable;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestSolutionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        // GET: api/<APIController>
        [HttpGet]
        //public IEnumerable<string> Get()
        public IEnumerable<Boardgame> Get()  //Gets the whole array/list with boardgames
        {
            string? jsonText = null;
            using (var streamReader = new StreamReader(@"C:\Users\hakan\Downloads\json_response_senarion_webapp.json"))
            {
                jsonText = streamReader.ReadToEnd();
            }

            var bGame = JsonConvert.DeserializeObject<List<Boardgame>>(jsonText);

            if(bGame == null)
            {
                string error = "ERROR! No information in list/arrary.";
                return (IEnumerable<Boardgame>)error.ToList();
            }
            else
            {
                return bGame.ToArray();
            }

            //return new string[] { "value1", "value2" }; Mock value from VS2022
        }

        // GET api/<APIController>/5
        [HttpGet("{id}")]
        //public string Get(int id)
        public string Get(string id)
        {
            string? jsonText = null;
            using (var streamReader = new StreamReader(@"C:\Users\hakan\Downloads\json_response_senarion_webapp.json"))
            {
                jsonText = streamReader.ReadToEnd();
            }

            var bGame = JsonConvert.DeserializeObject<List<Boardgame>>(jsonText);

            //return bGame.ToString(); // No
            //Boardgame boardgame = bGame.Where(e => e.id == id); not functioning properly
            Boardgame boardgame = bGame.FirstOrDefault(e => e.id == id);
            if (boardgame == null)
            {
                //boardgame = new Boardgame(); //behövs ej
                return "ERROR! Wrong index, try again.".ToString();
            }

            else
            {
                return boardgame.ToJson(); // or .ToArray()?
            }

        }

        // POST api/<APIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<APIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
