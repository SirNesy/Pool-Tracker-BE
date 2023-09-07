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

        public async Task<List<Player>> GetAllPlayersAsync()
        {
            var players = await _dbConnection.QueryAsync<Player>("SELECT * FROM MegaClass.Players");
            return players.AsList();
        }

        
        public async Task<Player> InsertPlayerAsync(Player player)
        {
            int playerId = await _dbConnection.ExecuteScalarAsync<int>("INSERT INTO MegaClass.Players (Name, Win, Loss) VALUES (@Name, @Win, @Loss)", player);
            return player;
        }

        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            return await _dbConnection.QuerySingleOrDefaultAsync<Player>("SELECT * FROM MegaClass.Players WHERE Id = @Id", new { Id = id });
        }

        public async Task DeletePlayerAsync(int id)
        {
            await _dbConnection.ExecuteAsync("DELETE FROM MegaClass.Players WHERE Id = @Id", new { Id = id });
        }

        public async Task IncreaseWinAsync(int playerId)
        {
            await _dbConnection.ExecuteAsync("UPDATE MegaClass.Players SET Win = Win + 1 WHERE Id = @Id AND Win > 0", new { Id = playerId });
        }

        public async Task DecreaseWinAsync(int playerId)
        {
            await _dbConnection.ExecuteAsync("UPDATE MegaClass.Players SET Win = Win - 1 WHERE Id = @Id AND Win > 0", new { Id = playerId });
        }

        public async Task IncreaseLossAsync(int playerId)
        {
            await _dbConnection.ExecuteAsync("UPDATE MegaClass.Players SET Loss = Loss + 1 WHERE Id = @Id", new { Id = playerId });
        }

        public async Task DecreaseLossAsync(int playerId)
        {
            await _dbConnection.ExecuteAsync("UPDATE MegaClass.Players SET Loss = Loss - 1 WHERE Id = @Id AND Loss > 0", new { Id = playerId });
        }

     
    }
}
