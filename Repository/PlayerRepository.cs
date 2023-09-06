using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

using PoolTrackerBackEnd.Models;

namespace PoolTrackerBackEnd.Repository
{
    public class PlayerRepository
    {
       private readonly IDbConnection _dbConnection;

       public PlayerRepository(string connectionString)
        {
            this._dbConnection = new SqlConnection(connectionString);
        }

       public IEnumerable<Player> GetAllTeams()
       {
           return _dbConnection.Query<Player>("SELECT * FROM Teams");
       }

    
    }
}
