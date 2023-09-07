using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

using PoolTrackerBackEnd.Models;

namespace PoolTrackerBackEnd.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
       private readonly IDbConnection _dbConnection;

        public PlayerRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection"); 
            _dbConnection = new SqlConnection(connectionString);
        }

        public List<Player> GetAllPlayers()
        {
            var players  = _dbConnection.Query<Player>("SELECT * FROM MegaClass.Players").ToList();
            return players;
            //return _dbConnection.Query<Player>("SELECT * FROM Players").ToList();
        }
        public void InsertPlayer(Player player) => _dbConnection.Execute("INSERT INTO Players (Name, Win, Loss) VALUES (@Name, @Win, @Loss)", player);

        public Player GetPlayerById(int id) => _dbConnection.QuerySingleOrDefault<Player>("SELECT * FROM Players WHERE Id = @Id", new { Id = id });
        
        public void DeletePlayer(int id) => _dbConnection.Execute("DELETE FROM Players WHERE Id = @Id", new { Id = id });

        public void IncreaseWin(int playerId) => _dbConnection.Execute("UPDATE Players SET Win = Win + 1 WHERE Id = @Id", new { Id = playerId });

        public void DecreaseWin(int playerId) => _dbConnection.Execute("UPDATE Players SET Win = Win - 1 WHERE Id = @Id AND Win > 0", new { Id = playerId });

        public void IncreaseLoss(int playerId) => _dbConnection.Execute("UPDATE Players SET Loss = Loss + 1 WHERE Id = @Id", new { Id = playerId });

        public void DecreaseLoss(int playerId) => _dbConnection.Execute("UPDATE Players SET Loss = Loss - 1 WHERE Id = @Id AND Loss > 0", new { Id = playerId });

    }
}
