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

        [HttpGet("byId")]
        public ActionResult<Player> GetById(Guid id)
        {
            using (var context = new TeamContext())
            {
                var player = context.Players.FirstOrDefault(player => player.Id == id);

                if (player != null)
                {
                    return StatusCode(200, player);
                }

                return NotFound();
            }
        }

        [HttpPut]
        public ActionResult<Player> Put(UpdatePlayerDto updatePlayerDto, Guid id)
        {
            using (var context = new TeamContext())
            {
                var existingPlayer = context.Players.FirstOrDefault(player => player.Id == id);

                if (existingPlayer != null)
                {
                    existingPlayer.Name = updatePlayerDto.Name;
                    existingPlayer.Weight = updatePlayerDto.Weight;

                    context.Players.Update(existingPlayer);
                    context.SaveChanges();
                    return StatusCode(200, existingPlayer);
                }

                return StatusCode(404);
            }

        }

        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            using (var context = new TeamContext())
            {
                var player = context.Players.FirstOrDefault(player => player.Id == id);

                if (player != null)
                {
                    context.Players.Remove(player);
                    context.SaveChanges();
                    return StatusCode(200, new { message = "Sikeres törlés." });
                }

                return StatusCode(404, new { message = "Nincs ilyen találat." });
            }
        }
    }
}
