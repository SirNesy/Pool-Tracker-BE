using PoolTrackerBackEnd.Models;

namespace PoolTrackerBackEnd.Repository
{
    public interface IPlayerRepository
    {
        List<Player> GetAllPlayers();
        Player Update(int id);
        void Remove(int id);

        void InsertPlayer(Player player);
        void UpdatePlayer(Player player); // optimistically render on the front end, no return needed 
        void DeletePlayer(int id);

        // Methods to increase and decrease Win and Loss
        void IncreaseWin(int playerId);
        void DecreaseWin(int playerId);
        void IncreaseLoss(int playerId);
        void DecreaseLoss(int playerId);

    }
}
