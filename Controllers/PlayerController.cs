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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetAllPlayers()
        {
            try
            {
                var players = await _playerRepository.GetAllPlayersAsync();
                return Ok(players);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Player>> CreatePlayer([FromBody] Player player)
        {
            try
            {
                await _playerRepository.InsertPlayerAsync(player);
                return CreatedAtRoute("GetPlayerById", new { id = player.Id }, player);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlayer(int id)
        {
            try
            {
                var existingPlayer = await _playerRepository.GetPlayerByIdAsync(id);
                if (existingPlayer == null)
                {
                    return NotFound();
                }

                await _playerRepository.DeletePlayerAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/increase-win")]
        public async Task<ActionResult> IncreaseWin(Player player)
        {
            try
            {
                var existingPlayer = await _playerRepository.GetPlayerByIdAsync(player.Id);
                if (existingPlayer == null)
                {
                    return NotFound();
                }

                await _playerRepository.IncreaseWinAsync(player);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/decrease-win")]
        public async Task<ActionResult> DecreaseWin(Player player)
        {
            try
            {
                var existingPlayer = await _playerRepository.GetPlayerByIdAsync(player.Id);
                if (existingPlayer == null)
                {
                    return NotFound();
                }

                await _playerRepository.DecreaseWinAsync(player);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/increase-loss")]
        public async Task<ActionResult> IncreaseLoss(Player player)
        {
            try
            {
                var existingPlayer = await _playerRepository.GetPlayerByIdAsync(player.Id);
                if (existingPlayer == null)
                {
                    return NotFound();
                }

                await _playerRepository.IncreaseLossAsync(player);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/decrease-loss")]
        public async Task<ActionResult> DecreaseLoss(Player player)
        {
            try
            {
                var existingPlayer = await _playerRepository.GetPlayerByIdAsync(player.Id);
                if (existingPlayer == null)
                {
                    return NotFound();
                }

                await _playerRepository.DecreaseLossAsync(player);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
