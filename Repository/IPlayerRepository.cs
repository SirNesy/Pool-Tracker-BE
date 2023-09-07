using PoolTrackerBackEnd.Models;

namespace PoolTrackerBackEnd.Repository
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAllPlayersAsync();
        Task<Player> InsertPlayerAsync(Player player);
        Task DeletePlayerAsync(int id);
        Task<Player> GetPlayerByIdAsync(int id);

        // Update Player: Methods to increase and decrease Win and Loss 
        Task IncreaseWinAsync(int id);
        Task DecreaseWinAsync(int playerId);
        Task IncreaseLossAsync(int playerId);
        Task DecreaseLossAsync(int playerId);
        
    }
}
