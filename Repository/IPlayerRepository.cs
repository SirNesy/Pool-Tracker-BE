using PoolTrackerBackEnd.Models;

namespace PoolTrackerBackEnd.Repository
{
    public interface IPlayerRepository
    {
        List<Player> GetAllPlayers();
        void InsertPlayer(Player player);
        void DeletePlayer(int id);
        Player GetPlayerById(int id);

        // Update Player: Methods to increase and decrease Win and Loss 
        void IncreaseWin(int playerId);
        void DecreaseWin(int playerId);
        void IncreaseLoss(int playerId);
        void DecreaseLoss(int playerId);
        
    }
}
