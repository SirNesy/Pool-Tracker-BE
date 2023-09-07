using Microsoft.AspNetCore.Mvc;
using PoolTrackerBackEnd.Models;
using PoolTrackerBackEnd.Repository;

namespace PoolTrackerBackEnd.Controllers
{
    [Route("api/players/")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        //[Route("allplayers")]
        [HttpGet]
        public ActionResult<IEnumerable<Player>> GetAllPlayers()
        {
            try
            {
                var players = _playerRepository.GetAllPlayers();
                return Ok(players);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<Player> CreatePlayer([FromBody] Player player)
        {
            try
            {
                _playerRepository.InsertPlayer(player);
                return CreatedAtRoute("GetPlayerById", new { id = player.Id }, player);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePlayer(int id)
        {
            try
            {
                var existingPlayer = _playerRepository.GetPlayerById(id);
                if (existingPlayer == null)
                {
                    return NotFound();
                }

                _playerRepository.DeletePlayer(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/increase-win")]
        public ActionResult IncreaseWin(int id)
        {
            try
            {
                var existingPlayer = _playerRepository.GetPlayerById(id);
                if (existingPlayer == null)
                {
                    return NotFound();
                }

                _playerRepository.IncreaseWin(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/decrease-win")]
        public ActionResult DecreaseWin(int id)
        {
            try
            {
                var existingPlayer = _playerRepository.GetPlayerById(id);
                if (existingPlayer == null)
                {
                    return NotFound();
                }

                _playerRepository.DecreaseWin(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/increase-loss")]
        public ActionResult IncreaseLoss(int id)
        {
            try
            {
                var existingPlayer = _playerRepository.GetPlayerById(id);
                if (existingPlayer == null)
                {
                    return NotFound();
                }

                _playerRepository.IncreaseLoss(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/decrease-loss")]
        public ActionResult DecreaseLoss(int id)
        {
            try
            {
                var existingPlayer = _playerRepository.GetPlayerById(id);
                if (existingPlayer == null)
                {
                    return NotFound();
                }

                _playerRepository.DecreaseLoss(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
