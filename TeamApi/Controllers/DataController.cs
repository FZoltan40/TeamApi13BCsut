using Microsoft.AspNetCore.Mvc;
using TeamApi.Models;

namespace TeamApi.Controllers
{
    [Route("datas")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Data> Get()
        {
            using (var context = new TeamContext())
            {
                return StatusCode(200, context.Data.ToList());
            }
        }

    }
}
