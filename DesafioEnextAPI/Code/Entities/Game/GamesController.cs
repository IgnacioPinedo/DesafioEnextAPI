using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

public class GamesController : ApiController
{
    private GameContext db = new GameContext();

    [Route("Games")]
    public IHttpActionResult GetGames()
    {
        var games = db.GetGames().AsEnumerable();
        var playerKills = db.GetPlayerKills().AsEnumerable();

        if (games == null || playerKills == null)
            return NotFound();

        return Ok(games.Select(g => new
        {
            g.GameId,
            g.GameHash,
            g.TotalKills,
            Players = playerKills.Where(p => p.GameId == g.GameId).Select(p => p.PlayerName).ToArray(),
            Kills = playerKills.Where(p => p.GameId == g.GameId).Select(s => new { s.PlayerName, s.Kills }).ToDictionary(p => p.PlayerName, p => p.Kills)
        }));
    }

    [Route("Games({id})")]
    [ResponseType(typeof(Game))]
    public IHttpActionResult GetGameById(int id)
    {
        Game game = db.GetGamesById(id);
        var playerKills = db.GetPlayerKillsFromGameId(game.GameId).AsEnumerable();

        if (game == null || playerKills == null)
            return NotFound();

        return Ok(new
        {
            game.GameId,
            game.GameHash,
            game.TotalKills,
            Players = playerKills.Select(s => s.PlayerName).ToArray(),
            Kills = playerKills.Select(p => new { p.PlayerName, p.Kills }).ToDictionary(p => p.PlayerName, p => p.Kills)
        });
    }



    [Route("GamesByHash({hash})")]
    [ResponseType(typeof(Game))]
    public IHttpActionResult GetGamesByHash(int hash)
    {
        Game game = db.GetGamesByHash(hash);
        var playerKills = db.GetPlayerKillsFromGameId(game.GameId).AsEnumerable();

        if (game == null || playerKills == null)
            return NotFound();

        return Ok(new
        {
            game.GameId,
            game.GameHash,
            game.TotalKills,
            Players = playerKills.Select(s => s.PlayerName).ToArray(),
            Kills = playerKills.Select(p => new { p.PlayerName, p.Kills }).ToDictionary(p => p.PlayerName, p => p.Kills)
        });
    }
}