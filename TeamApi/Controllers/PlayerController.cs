using Microsoft.AspNetCore.Mvc;
using TeamApi.Models;

namespace TeamApi.Controllers
{
    [Route("players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Player> Post(CreatePlayerDto createPlayerDto)
        {
            var player = new Player
            {
                Id = Guid.NewGuid(),
                Name = createPlayerDto.Name,
                Height = createPlayerDto.Height,
                Weight = createPlayerDto.Weight,
                CreatedTime = DateTime.Now,
            };

            if (player != null)
            {
                using (var context = new TeamContext())
                {
                    context.Players.Add(player);
                    context.SaveChanges();
                    return StatusCode(201, player);
                }
            }
            return StatusCode(400);
        }

        [HttpGet]
        public ActionResult<Player> Get()
        {
            using (var context = new TeamContext())
            {
                return StatusCode(200, context.Players.ToList());
            }
        }
    }
}
