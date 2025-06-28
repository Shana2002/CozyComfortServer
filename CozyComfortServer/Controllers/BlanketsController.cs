using System.Collections.Generic;
using System.Web.Http;
using CozyComfortServer.Models;
using CozyComfortServer.Data;

namespace CozyComfortServer.Controllers
{
    public class BlanketsController : ApiController
    {
        private readonly BlanketsDAL data = new BlanketsDAL();

        // GET: api/Blankets
        [HttpGet]
        public IHttpActionResult GetAllBlankets()
        {
            var blankets = data.GetAllBlankets();
            return Ok(blankets);
        }

        // GET: api/Blankets/5
        [HttpGet]
        public IHttpActionResult GetBlanket(int id)
        {
            var blanket = data.GetAllBlankets().Find(b => b.BlanketId == id);
            if (blanket == null)
                return NotFound();
            return Ok(blanket);
        }

        // POST: api/Blankets
        [HttpPost]
        public IHttpActionResult AddBlanket([FromBody] Blanket blanket)
        {
            if (blanket == null || blanket.Material == null)
                return BadRequest("Invalid blanket data.");

            data.AddBlanket(blanket);
            return Ok("Blanket added successfully.");
        }

        // PUT: api/Blankets/5
        [HttpPut]
        public IHttpActionResult UpdateBlanket(int id, [FromBody] Blanket blanket)
        {
            if (blanket == null || id != blanket.BlanketId)
                return BadRequest("Invalid data.");

            data.UpdateBlanket(blanket);
            return Ok("Blanket updated successfully.");
        }

        // DELETE: api/Blankets/5
        [HttpDelete]
        public IHttpActionResult DeleteBlanket(int id)
        {
            data.DeleteBlanket(id);
            return Ok("Blanket deleted successfully.");
        }
    }
}
