using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

[Table("TB_Game")]
public class Game
{
    [Key]
    public int GameId { get; set; }
    public int GameHash { get; set; }
    public int TotalKills { get; set; }
}