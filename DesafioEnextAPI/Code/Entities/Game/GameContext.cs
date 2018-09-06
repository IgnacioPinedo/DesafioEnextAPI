using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class GameContext : DbContext
{
    public GameContext() : base("name=DesafioBD")
    {
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<PlayerKill> PlayerKills { get; set; }

    public IQueryable<Game> GetGames()
    {
        return Games;
    }

    public Game GetGamesById(int id)
    {
        return Games.FirstOrDefault(f => f.GameId == id);
    }
    
    public Game GetGamesByHash(int hash)
    {
        return Games.FirstOrDefault(f => f.GameHash == hash);
    }

    public IQueryable<PlayerKill> GetPlayerKills()
    {
        return PlayerKills;
    }

    public IQueryable<PlayerKill> GetPlayerKillsFromGameId(int gameId)
    {
        return PlayerKills.Where(w => w.GameId == gameId);
    }
}