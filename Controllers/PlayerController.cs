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
                var insertedPlayer = await _playerRepository.InsertPlayerAsync(player);

                if (insertedPlayer == null)
                {
                    return BadRequest("Failed to insert player."); 
                }

                return Ok(insertedPlayer); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetPlayerById")]
        public async Task<ActionResult<Player>> GetPlayerById(int id)
        {
            try
            {
                var player = await _playerRepository.GetPlayerByIdAsync(id);
                if (player == null)
                {
                    return NotFound();
                }

                return Ok(player);
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
        public async Task<ActionResult<Player>> IncreaseWin(int id)
        {
            try
            {
                var existingPlayer = await _playerRepository.GetPlayerByIdAsync(id);
                if (existingPlayer == null)
                {
                    return NotFound();
                }

                await _playerRepository.IncreaseWinAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/decrease-win")]
        public async Task<ActionResult> DecreaseWin(int id)
        {
            try
            {
                var existingPlayer = await _playerRepository.GetPlayerByIdAsync(id);
                if (existingPlayer == null)
                {
                    return NotFound();
                }

                await _playerRepository.DecreaseWinAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/increase-loss")]
        public async Task<ActionResult> IncreaseLoss(int id)
        {
            try
            {
                var existingPlayer = await _playerRepository.GetPlayerByIdAsync(id);
                if (existingPlayer == null)
                {
                    return NotFound();
                }

                await _playerRepository.IncreaseLossAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/decrease-loss")]
        public async Task<ActionResult> DecreaseLoss(int id)
        {
            try
            {
                var existingPlayer = await _playerRepository.GetPlayerByIdAsync(id);
                if (existingPlayer == null)
                {
                    return NotFound();
                }

                await _playerRepository.DecreaseLossAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
