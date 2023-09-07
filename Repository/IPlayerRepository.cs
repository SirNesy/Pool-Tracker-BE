using PoolTrackerBackEnd.Models;

namespace PoolTrackerBackEnd.Repository
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAllPlayersAsync();
        Task InsertPlayerAsync(Player player);
        Task DeletePlayerAsync(int id);
        Task<Player> GetPlayerByIdAsync(int id);

        // Update Player: Methods to increase and decrease Win and Loss 
        Task IncreaseWinAsync(Player player);
        Task DecreaseWinAsync(Player player);
        Task IncreaseLossAsync(Player player);
        Task DecreaseLossAsync(Player player);
        
    }
}
