using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

[Table("TB_Player_Kill")]
public class PlayerKill
{
    [Key]
    public int PlayerId { get; set; }
    public string PlayerName { get; set; }
    public int Kills { get; set; }
    public int GameId { get; set; }
}