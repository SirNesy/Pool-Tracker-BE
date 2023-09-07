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

        //player.Points = (player.Win* 3) + player.Loss;
        public async Task InsertPlayerAsync(Player player)
        {
            await _dbConnection.ExecuteAsync("INSERT INTO MegaClass.Players (Name, Win, Loss) VALUES (@Name, @Win, @Loss)", player);
        }

        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            return await _dbConnection.QuerySingleOrDefaultAsync<Player>("SELECT * FROM MegaClass.Players WHERE Id = @Id", new { Id = id });
        }

        public async Task DeletePlayerAsync(int id)
        {
            await _dbConnection.ExecuteAsync("DELETE FROM MegaClass.Players WHERE Id = @Id", new { Id = id });
        }

        public async Task IncreaseWinAsync(Player player)
        {
            player.Points = (player.Win + 1) * 3 + player.Loss;
            await _dbConnection.ExecuteAsync("UPDATE MegaClass.Players SET Name = @Name, Win = @Win, Loss = @Loss, Points = @Points WHERE Id = @Id", player);
        }

        public async Task DecreaseWinAsync(Player player)
        {
            await _dbConnection.ExecuteAsync("UPDATE MegaClass.Players SET Win = Win - 1 WHERE Id = @Id AND Win > 0", player);
        }

        public async Task IncreaseLossAsync(Player player)
        {
            await _dbConnection.ExecuteAsync("UPDATE MegaClass.Players SET Loss = Loss + 1 WHERE Id = @Id", player);
        }

        public async Task DecreaseLossAsync(Player player)
        {
            await _dbConnection.ExecuteAsync("UPDATE MegaClass.Players SET Loss = Loss - 1 WHERE Id = @Id AND Loss > 0", player);
        }

     
    }
}
