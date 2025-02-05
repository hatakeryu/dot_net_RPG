using dot_net_RPG.Migrations;

namespace dot_net_RPG.Models
{
  public class Character
  { 
    public int Id { get; set; }
    public string Name { get; set; }

    public int HitPoints { get; set; }

    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Intelligence { get; set; }
    public RpgClass Class { get; set; } = RpgClass.Knight;

     public User User { get; set; }
  }
}