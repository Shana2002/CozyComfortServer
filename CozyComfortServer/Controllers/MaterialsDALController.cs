using System.Collections.Generic;
using System.Web.Http;
using CozyComfortServer.Models;
using CozyComfortServer.Data;

namespace CozyComfortServer.Controllers
{
    public class MaterialsDALController : ApiController
    {
        private MaterialsDAL data = new MaterialsDAL();

        [HttpGet]
        public IHttpActionResult GetMaterials()
        {
            var materials = data.GetAllMaterials();
            return Ok(materials);
        }

        [HttpPost]
        public IHttpActionResult AddMaterial([FromBody] Material material)
        {
            if (material == null || string.IsNullOrWhiteSpace(material.MaterialName))
                return BadRequest("Invalid material data.");

            data.AddMaterial(material);
            return Ok("Material added successfully.");
        }

        [HttpPut]
        public IHttpActionResult UpdateMaterial([FromBody] Material material)
        {
            if (material == null || material.MaterialId <= 0)
                return BadRequest("Invalid material data.");

            data.UpdateMaterial(material);
            return Ok("Material updated.");
        }

        [HttpDelete]
        public IHttpActionResult DeleteMaterial(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid material ID.");

            data.DeleteMaterial(id);
            return Ok("Material deleted.");
        }
    }
}
